﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Data.Entities;
using WebAPI.Data.Enums;

namespace WebAPI.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<productDetail>().HasData(
                new productDetail() { ProductId = 1,idProductDetail=1, LanguageId = "vi-VN", ProductName="Shoe",price=1000000,salePrice=1000000,detail="goood product",isSaling=false,dateAdded=new DateTime(2019,10,21)},
                new productDetail() { ProductId = 2,idProductDetail = 2, LanguageId = "vi-VN", ProductName = "Pro" ,price = 2000000, salePrice = 1000000, detail = "goood product", isSaling = false, expiredSalingDate=new DateTime(2020,10,12), dateAdded = new DateTime(2019, 10, 21) }
            );;
            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi-VN", Name = "Tiếng Việt", IsDefault = true },
                new Language() { Id = "en-US", Name = "English", IsDefault = false }
            );

            modelBuilder.Entity<productSize>().HasData(
                new productSize() { idSize="1",sizeName="L"},
                new productSize() { idSize="2",sizeName="M"}
            );
            modelBuilder.Entity<productBrand>().HasData(
                new productBrand() { idBrand="1",brandName="Logo",brandDetail="Logo"},
                new productBrand() { idBrand = "2", brandName = "Company", brandDetail = "Company" }
            );
            modelBuilder.Entity<productColor>().HasData(
                new productColor() { idColor="ffffff",colorName="While"},
                new productColor() { idColor = "Red", colorName = "Red" }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category() { idCategory=1, IsShowOnHome = true, SortOrder = 1, },
                new Category() { idCategory = 2, IsShowOnHome = true, SortOrder = 2, }
            );
            modelBuilder.Entity<productTypes>().HasData(
                new productTypes() { idType="1",typeName="Cheap"},
                new productTypes() { idType = "2", typeName = "Expensive" }
            );
            modelBuilder.Entity<products>().HasData(
                new products() { ProductId = 1 ,idSize = "1", idBrand = "1", idColor = "ffffff",  idType = "1" },
                new products() { ProductId = 2, idSize = "1", idBrand = "1", idColor = "ffffff",  idType = "1" }
            );
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { ProductId = 1, idCategory = 1 }
                
                );
            modelBuilder.Entity<CategoryTranslation>().HasData(
                 new CategoryTranslation() { Id = 1, CategoryId = 1, Name = "Áo nam", LanguageId = "vi-VN", SeoAlias = "ao-nam", SeoDescription = "Sản phẩm áo thời trang nam", SeoTitle = "Sản phẩm áo thời trang nam" },
                 new CategoryTranslation() { Id = 2, CategoryId = 1, Name = "Men Shirt", LanguageId = "en-US", SeoAlias = "men-shirt", SeoDescription = "The shirt products for men", SeoTitle = "The shirt products for men" },
                 new CategoryTranslation() { Id = 3, CategoryId = 2, Name = "Áo nữ", LanguageId = "vi-VN", SeoAlias = "ao-nu", SeoDescription = "Sản phẩm áo thời trang nữ", SeoTitle = "Sản phẩm áo thời trang women" },
                 new CategoryTranslation() { Id = 4, CategoryId = 2, Name = "Women Shirt", LanguageId = "en-US", SeoAlias = "women-shirt", SeoDescription = "The shirt products for women", SeoTitle = "The shirt products for women" }
                   );

            // any guid

            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            modelBuilder.Entity<role>().HasData(new role
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<users>();
            modelBuilder.Entity<users>().HasData(new users
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "nhattruongtp2000@gmail.com",
                NormalizedEmail = "nhattruongtp2000@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin@123"),
                SecurityStamp = string.Empty,
                birthday=new DateTime(2020,10,12),
                firstName = "Nguyen",
                lastName = "Truong",
                lastLogin=new DateTime(2020,11,13)
 
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
            
        }
    }
}
