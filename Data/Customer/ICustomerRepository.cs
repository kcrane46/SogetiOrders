using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SogetiOrders.Models;

namespace SogetiOrders.Data
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();
        
        Task<Customer> GetCustomer(int id);

        Task<Customer> Create(Customer customer);

        Task Update(Customer customer);

        Task Delete(int id);
    }
}