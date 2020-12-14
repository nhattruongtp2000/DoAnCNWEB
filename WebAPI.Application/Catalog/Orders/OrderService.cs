﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.EF;
using WebAPI.ViewModels.Common;
using WebAPI.ViewModels.Orders;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace WebAPI.Application.Catalog.Orders
{
    public class OrderService : IOrderService
    {

        private readonly WebApiDbContext _context;
        
        public OrderService(WebApiDbContext context)
        {
            _context = context;            
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderVm>> GetAll(string languageId)
        {
            
            var query = from p in _context.Orders
                        join pt in _context.OrderDetails on p.Id equals pt.OrderId
                        join ptt in _context.users on p.UserId equals ptt.Id
                        join c in _context.products on pt.ProductId equals c.ProductId
                        select new { p, pt,ptt,c };
            return await query.Select(x => new OrderVm()
            {
                Id = x.p.Id,
                ProductId = x.c.ProductId,
                UserId = x.ptt.Id,
                ShipName = x.p.ShipName,
                ShipAddress = x.p.ShipAddress,
                ShipEmail = x.p.ShipEmail,
                ShipPhoneNumber = x.p.ShipPhoneNumber,
                Quantity = x.pt.Quantity,
                Price = x.pt.Price,
                OrderDate = x.p.OrderDate,
                Status = x.p.Status,
                

            }).ToListAsync();
        }

        public async Task<OrderVm> GetById(int id, string languageId)
        {
            var query = from p in _context.Orders
                        join pt in _context.OrderDetails on p.Id equals pt.OrderId
                        join ptt in _context.users on p.UserId equals ptt.Id
                        join c in _context.products on pt.ProductId equals c.ProductId
                        where pt.LanguageId == languageId
                        select new { p, pt, ptt, c };
            return await query.Select(x => new OrderVm()
            {
                Id = x.p.Id,
                ProductId = x.c.ProductId,
                UserId = x.ptt.Id,
                ShipName = x.p.ShipName,
                ShipAddress = x.p.ShipAddress,
                ShipEmail = x.p.ShipEmail,
                ShipPhoneNumber = x.p.ShipPhoneNumber,
                Quantity = x.pt.Quantity,
                Price = x.pt.Price,
                OrderDate = x.p.OrderDate,
            }).FirstOrDefaultAsync();
        }

        public async Task<PagedResult<OrderVm>> GetOrdersPagings(GetOrderPagingRequest request)
        {
            //1. Select join
            var query = from p in _context.Orders
                        join pt in _context.OrderDetails on p.Id equals pt.OrderId
                        join ptt in _context.users on p.UserId equals ptt.Id
                        join c in _context.products on pt.ProductId equals c.ProductId
                        where pt.LanguageId==request.LanguageId
                        select new { p, pt,ptt,c };
            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.p.ShipName.Contains(request.Keyword));


            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new OrderVm()
                {
                    Id=x.p.Id,
                    ProductId=x.c.ProductId,
                    UserId=x.ptt.Id,
                    ShipName=x.p.ShipName,
                    ShipAddress=x.p.ShipAddress,
                    ShipEmail=x.p.ShipEmail,
                    ShipPhoneNumber=x.p.ShipPhoneNumber,
                    Quantity=x.pt.Quantity,
                    Price=x.pt.Price,
                    OrderDate=x.p.OrderDate,
                    Status=x.p.Status,
                    LanguageId=request.LanguageId

                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<OrderVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }
    }
}
