using System.ComponentModel.DataAnnotations;

namespace SogetiOrders.Models
{
    public class Order 
    {
        [Key]
        public int OrderId { get; set; }

        public Customer Customer { get; set; }

        public List<Product> Products { get; set; }

        public decimal OrderTotalCost { get; set; }

        public DateTime OrderDate { get; set; }

        public bool IsCancelled { get; set; }

    }
         
   
}