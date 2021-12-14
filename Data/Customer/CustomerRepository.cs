using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SogetiOrders.Models;
using Microsoft.EntityFrameworkCore;

namespace SogetiOrders.Data
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<Customer> Create(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        public async Task Update(Customer customer)
        {
            var checkCustomer = GetCustomer(customer.CustomerId);
            if(checkCustomer != null)
            {
                _context.Entry(customer).State = EntityState.Modified;
               await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var itemToDelete = await _context.Customers.FindAsync(id);

            if(itemToDelete != null)
            {
                _context.Customers.Remove(itemToDelete);
                await _context.SaveChangesAsync();
            }
        }

    }
}