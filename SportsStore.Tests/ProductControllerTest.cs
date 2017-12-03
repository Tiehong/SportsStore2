using System.Collections.Generic;
using Xunit;
using Moq;
using System.Linq;
using SportsStore.Models;
using SportsStore.Controllers;

namespace SportsStore.Tests
{
    public class ProductControllerTest
    {
        [Fact]
        public void CanPaginate()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product{ProductID=1,Name="P1"},
                new Product{ProductID=2,Name="P2"},
                new Product{ProductID=3,Name="P3"},
                new Product{ProductID=4,Name="P4"},
                new Product{ProductID=5,Name="P5"},
                new Product{ProductID=6,Name="P6"},
                new Product{ProductID=7,Name="P7"},
                new Product{ProductID=8,Name="P8"}
            }).AsQueryable());

            ProductController c = new ProductController(mock.Object);
            c.Pagesize = 3;

            ProductsListViewModel res = c.List(2).ViewData.Model as ProductsListViewModel;

            Product[] prodArr = res.Products.ToArray();
            Assert.True(prodArr.Length == 3);
            Assert.Equal("P4", prodArr[0].Name);
        }
    }
}
