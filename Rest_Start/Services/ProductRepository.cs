using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rest_Start.Data;
using Rest_Start.Models;

namespace Rest_Start.Services
{
    public class ProductRepository : IProductsRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddProduct(Product product)
        {
            var pro = new Product { Name = "Product 1", Price = 255 };
            _context.Products.Add(pro);
            _context.SaveChanges();
        }


        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}
