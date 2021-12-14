using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SogetiOrders.Models;

namespace SogetiOrders.Data
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        
        Task<Product> GetProduct(int id);

        Task<Product> Create(Product product);

        Task Update(Product product);

        Task Delete(int id);
    }
}