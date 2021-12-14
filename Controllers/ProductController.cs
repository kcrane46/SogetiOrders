using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SogetiOrders.Data;
using SogetiOrders.Models;

namespace SogetiOrders.Controllers
{
    [ApiController]
    [Route("v1/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        public ProductController(IProductRepository productRepository)
        {
            _productRepo = productRepository;
        }


        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _productRepo.GetProducts();

            if(products == null) { return NotFound(); }
            return products.ToList();
        }

         [HttpGet]
         [Route("{id:int}")]
         public async Task<ActionResult<Product>> GetById(int id)
         {
             var product = await _productRepo.GetProduct(id);
             
             if(product == null) { return NotFound(); }
             return product;
         }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
        {
            // if(!ModelState.IsValid) 
            // { 
            //     return BadRequest(ModelState); 
            // }

            var newProduct = await _productRepo.Create(product);
            return CreatedAtAction(nameof(GetById), new { id = newProduct.ProductId });
             
        }

        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<Product>> UpdateProduct([FromBody] Product product)
        {
            // if(!ModelState.IsValid) 
            // { 
            //     return BadRequest(ModelState); 
            // }

            await _productRepo.Update(product);
            return CreatedAtAction(nameof(GetById), new { id = product.ProductId });
             
        }

    }
}