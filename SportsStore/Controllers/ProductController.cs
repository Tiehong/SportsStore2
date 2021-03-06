﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        public int Pagesize { get; set; } = 5;
        IProductRepository repo;
        public ProductController(IProductRepository repo)
        {
            this.repo = repo;
        }

        public ViewResult List(string category, int page = 1) => View(
            new ProductsListViewModel
            {
                Products = repo.Products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductID)
                    .Skip(Pagesize * (page - 1))
                    .Take(Pagesize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = Pagesize,
                    TotalItems = category==null?
                    repo.Products.Count():
                    repo.Products.Where(pro=>pro.Category==category).Count()
                },
                CurrentCategory = category
            });

        public IActionResult Index()
        {
            return View();
        }

        public FileContentResult GetImage(int productID)
        {
            Product prod = repo.Products.FirstOrDefault(p => p.ProductID == productID);
            if (prod != null)
                return File(prod.ImageData, prod.ImageMimeType);
            else
                return null;
        }
    }
}