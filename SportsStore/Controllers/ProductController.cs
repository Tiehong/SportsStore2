using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public ViewResult List(int page=1) => View(
            new ProductsListViewModel {
                Products=
            repo.Products
            .OrderBy(p=>p.ProductID)
            .Skip(Pagesize*(page-1))
            .Take(Pagesize),
                PagingInfo=new PagingInfo {
                    CurrentPage=page,
                    ItemsPerPage=Pagesize,
                    TotalItems=repo.Products.Count()
                }
                });

        public IActionResult Index()
        {
            return View();
        }
    }
}