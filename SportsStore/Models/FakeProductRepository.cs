using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Models
{

    public class FakeProductRepository : IProductRepository
    {
        List<Product> products;

        public IQueryable<Product> Products
        {
            get
            {
                if (products == null)
                    products = new List<Product> {
                    new Product { ProductID = 1, Category = "Soccer", Name = "Football", Price = 25 },
                    new Product { ProductID = 2, Category = "Soccer", Name = "Shin Pad", Price=18},
                    new Product { ProductID = 3, Category = "WaterSports", Name = "Surf board", Price = 179 },
                    new Product { ProductID = 4, Category = "Field", Name = "Running shoes", Price = 95 }
                };
                return products.AsQueryable<Product>();
            }
        }

        public Product DeleteProduct(int productID)
        {
            Product p = products.FirstOrDefault(x => x.ProductID == productID);
            if (p != null)
                products.Remove(p);
            return p;
        }

        public void SaveProduct(Product product)
        {
            product.ProductID = Products.Count() + 1;
            products?.Add(product);
        }
    }
}
