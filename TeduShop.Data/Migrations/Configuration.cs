﻿namespace TeduShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using MoDel.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TeduShop.Data.TeduShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TeduShop.Data.TeduShopDbContext context)
        {
            //CreateProductCategorySimple(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            //CreateUserLogin(context);
           
        }
        public void CreateUserLogin(TeduShopDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new TeduShopDbContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new TeduShopDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "tranduy681996",
                Email = "tranduy681996@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "Tran Anh Duy"
            };

            manager.Create(user, "123456");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("tranduy681996@gmail.com");

            manager.AddToRoles(adminUser.Id, new String[] { "Admin", "User" });
        }
        private void CreateProductCategorySimple(TeduShop.Data.TeduShopDbContext context)
        {
            if (context.ProductCategorys.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
                {
                    new ProductCategory() { Name="Điện lạnh",Alias="dien_lanh",Status=true},
                    new ProductCategory() { Name="Viễn Thông",Alias="Vien_Thong",Status=true},
                    new ProductCategory() { Name="Đồ Gia Dụng",Alias="Do_Gia_Dung",Status=true},
                    new ProductCategory() { Name="Mỹ Phẩm",Alias="My_Pham",Status=true}
                };

                context.ProductCategorys.AddRange(listProductCategory);
                context.SaveChanges();
            }

        }
    }
}