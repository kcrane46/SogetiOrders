using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SogetiOrders.Data;
using SogetiOrders.Models;

namespace SogetiOrders.Controllers
{
    [ApiController]
    [Route("v1/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepo;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepo = orderRepository;
        }


        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Order>>> GetOrders()
        {
            var orders = await _orderRepo.GetOrders();

            if(orders == null) { return NotFound(); }
            return orders.ToList();
        }

        [HttpGet]
        [Route("customer/{id:int}")]
        public async Task<ActionResult<List<Order>>> GetOrdersByCustomer(int id)
        {
            var orders = await _orderRepo.GetOrdersByCustomer(id);

            if(orders == null) { return NotFound(); }
            return orders.ToList();
        }

         [HttpGet]
         [Route("{id:int}")]
         public async Task<ActionResult<Order>> GetById(int id)
         {
             var order = await _orderRepo.GetOrder(id);
             
             if(order == null) { return NotFound(); }
             return order;
         }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Order>> CreateOrder([FromBody] Order order)
        {
            // if(!ModelState.IsValid) 
            // { 
            //     return BadRequest(ModelState); 
            // }

            var newOrder = await _orderRepo.Create(order);
            return CreatedAtAction(nameof(GetById), new { id = newOrder.OrderId });
             
        }

        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<Order>> UpdateOrder([FromBody] Order order)
        {
            // if(!ModelState.IsValid) 
            // { 
            //     return BadRequest(ModelState); 
            // }

            await _orderRepo.Update(order);
            return CreatedAtAction(nameof(GetById), new { id = order.OrderId });
             
        }

        [HttpPost]
        [Route("cancel")]
        public async Task<ActionResult<Order>> CancelOrder([FromBody] Order order)
        {
            // if(!ModelState.IsValid) 
            // { 
            //     return BadRequest(ModelState); 
            // }
            order.IsCancelled = true;
            await _orderRepo.Update(order);
            return CreatedAtAction(nameof(GetById), new { id = order.OrderId });
             
        }

    }
}