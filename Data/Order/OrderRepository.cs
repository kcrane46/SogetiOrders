using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SogetiOrders.Models;
using Microsoft.EntityFrameworkCore;

namespace SogetiOrders.Data
{
    public class OrderRepository : IOrderRepository
    {

        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomer(int customerID)
        {
            return await _context.Orders.Where(c => c.Customer.CustomerId == customerID).ToListAsync();
        }
        public async Task<Order> GetOrder(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<Order> Create(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task Update(Order order)
        {
            var checkOrder = GetOrder(order.OrderId);
            if(checkOrder != null)
            {
                _context.Entry(order).State = EntityState.Modified;
               await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var itemToDelete = await _context.Orders.FindAsync(id);

            if(itemToDelete != null)
            {
                _context.Orders.Remove(itemToDelete);
                await _context.SaveChangesAsync();
            }
        }

    }
}