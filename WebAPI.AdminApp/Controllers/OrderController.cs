﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebAPI.ApiIntegration;
using WebAPI.Utilities.Constants;
using WebAPI.ViewModels.Orders;

namespace WebAPI.AdminApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderApiClient  _orderApiClient;
        private readonly IConfiguration _configuration;
        private readonly IProductApiClient _productApiClient;
        public OrderController(IOrderApiClient orderApiClient, IConfiguration configuration, IProductApiClient productApiClient)
        {
            _orderApiClient = orderApiClient;
            _configuration = configuration;
            _productApiClient = productApiClient;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var sessions = HttpContext.Session.GetString("Token");
            var request = new GetOrderPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                LanguageId = languageId
            };
            var data = await _orderApiClient.GetOrdersPagings(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }

            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var result = await _orderApiClient.GetById(languageId, id);
            return View(result);
        }
    }
}
