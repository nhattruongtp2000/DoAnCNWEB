﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.ViewModels.Catalog.ProductImages;
using WebAPI.ViewModels.Catalog.Products;
using WebAPI.ViewModels.Common;

namespace WebAPI.Application.Catalog.Products
{
    public interface IProductService
    {
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int idProduct);

        Task<bool> UpdatePrice(int idProduct, decimal newPrice);

        Task<ProductVm> GetById(int productId, string languageId);

        Task AddViewcount(int idProduct);

        Task<PagedResult<ProductVm>> GetAllPaging(GetManageProductPagingRequest request);

        //image
        Task<int> AddImage(int idProduct, ProductImageCreateRequest request);

        Task<int> RemoveImage(int  imageId);

        Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request);

        Task<ProductImageViewModel> GetImageById(int imageId);

        Task<List<ProductImageViewModel>> GetListImages(int idProduct);

        Task<PagedResult<ProductVm>> GetAllByCategoryId(string languageId,GetPublicProductPagingRequest request);

        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);
    }
}
