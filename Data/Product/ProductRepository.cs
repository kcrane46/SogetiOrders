using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SogetiOrders.Models;
using Microsoft.EntityFrameworkCore;

namespace SogetiOrders.Data
{
    public class ProductRepository : IProductRepository
    {

        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> Create(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task Update(Product product)
        {
            var checkProduct = GetProduct(product.ProductId);
            if(checkProduct != null)
            {
                _context.Entry(product).State = EntityState.Modified;
               await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var itemToDelete = await _context.Products.FindAsync(id);

            if(itemToDelete != null)
            {
                _context.Products.Remove(itemToDelete);
                await _context.SaveChangesAsync();
            }
        }

    }
}