using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SogetiOrders.Models;

namespace SogetiOrders.Data
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrders();
        
        Task<IEnumerable<Order>> GetOrdersByCustomer(int customerID);

        Task<Order> GetOrder(int id);

        Task<Order> Create(Order order);

        Task Update(Order order);

        Task Delete(int id);
    }
}