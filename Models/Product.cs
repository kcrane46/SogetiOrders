using System.ComponentModel.DataAnnotations;

namespace SogetiOrders.Models
{
    public class Product 
    {
        [Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductPrice { get; set; }

    }
         
   
}