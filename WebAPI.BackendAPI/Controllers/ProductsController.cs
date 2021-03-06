﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Catalog.Products;
using WebAPI.ViewModels.Catalog.ProductImages;
using WebAPI.ViewModels.Catalog.Products;

namespace WebAPI.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetManageProductPagingRequest request)
        {
            var products = await _productService.GetAllPaging(request);
            return Ok(products);
        }

        //http://localhost:port/product/1
        [HttpGet("{idProduct}/{languageId}")]
        public async Task<IActionResult> GetById(int idProduct, string languageId)
        {
            var product = await _productService.GetById(idProduct,  languageId);
            if (product == null)
                return BadRequest("Cannot find product");
            return Ok(product);
        }

        //Create
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var idProduct = await _productService.Create(request);
            if (idProduct == 0)
                return BadRequest();

            var product = await _productService.GetById(idProduct, request.LanguageId);

            return CreatedAtAction(nameof(GetById), new { id = idProduct }, product);
        }

        //edit
        [HttpPut("{productId}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update([FromRoute] int productId, [FromForm] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.Id = productId;
            var affectedResult = await _productService.Update(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }


        //delete
        [HttpDelete("{idProduct}")]
        public async Task<IActionResult> Delete(int idProduct)
        {
            var affectedResult = await _productService.Delete(idProduct);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }


        [HttpPatch("{idProduct}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int idProduct, decimal newPrice)
        {
            var isSuccessful = await _productService.UpdatePrice(idProduct, newPrice);
            if (isSuccessful)
                return Ok();

            return BadRequest();
        }

        //Images
        [HttpPost("{idProduct}/images")]
        public async Task<IActionResult> CreateImage(int idProduct, [FromForm] ProductImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imageId = await _productService.AddImage(idProduct, request);
            if (imageId == 0)
                return BadRequest();

            var image = await _productService.GetImageById(imageId);

            return CreatedAtAction(nameof(GetImageById), new { id = imageId }, image);
        }


        [HttpPut("{idProduct}/images/{imageId}")]
        public async Task<IActionResult> UpdateImage(int imageId, [FromForm] ProductImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productService.UpdateImage(imageId, request);
            if (result == 0)
                return BadRequest();

            return Ok();
        }


        [HttpDelete("{idProduct}/images/{imageId}")]
        public async Task<IActionResult> RemoveImage(int imageId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productService.RemoveImage(imageId);
            if (result == 0)
                return BadRequest();

            return Ok();
        }

        [HttpGet("{idProduct}/images/{imageId}")]
        public async Task<IActionResult> GetImageById(int idProduct, int imageId)
        {
            var image = await _productService.GetImageById(imageId);
            if (image == null)
                return BadRequest("Cannot find product");
            return Ok(image);
        }

        [HttpPut("{id}/categories")]
        public async Task<IActionResult> CategoryAssign(int id, [FromBody] CategoryAssignRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _productService.CategoryAssign(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        
    }
}
