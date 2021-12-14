using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SogetiOrders.Data;
using SogetiOrders.Models;

namespace SogetiOrders.Controllers
{
    [ApiController]
    [Route("v1/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _custRepo;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _custRepo = customerRepository;
        }


        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Customer>>> GetCustomers()
        {
            var courses = await _custRepo.GetCustomers();

            if(courses == null) { return NotFound(); }
            return courses.ToList();
        }

         [HttpGet]
         [Route("{id:int}")]
         public async Task<ActionResult<Customer>> GetById(int id)
         {
             var course = await _custRepo.GetCustomer(id);
             
             if(course == null) { return NotFound(); }
             return course;
         }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Customer>> CreateCustomer([FromBody] Customer customer)
        {
            // if(!ModelState.IsValid) 
            // { 
            //     return BadRequest(ModelState); 
            // }

            var newCustomer = await _custRepo.Create(customer);
            return CreatedAtAction(nameof(GetById), new { id = newCustomer.CustomerId });
             
        }

    }
}