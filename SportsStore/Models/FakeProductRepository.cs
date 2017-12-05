using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Models
{

    public class FakeProductRepository : IProductRepository
    {

        public IQueryable<Product> Products => new List<Product> {
            new Product { Name = "Football", Price = 25 },
            new Product{Name="Shin Pad",Price=18},
            new Product { Name = "Surf board", Price = 179 },
            new Product { Name = "Running shoes", Price = 95 }
        }.AsQueryable<Product>();

        public Product DeleteProduct(int productID)
        {
            throw new System.NotImplementedException();
        }

        public void SaveProduct(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}
