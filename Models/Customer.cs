using System.ComponentModel.DataAnnotations;

namespace SogetiOrders.Models
{
    public class Customer 
    {
        [Key]
        public int CustomerId { get; set; }

        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }

        public string  CustomerAddress { get; set; }

        public string CustomerPhoneNumber { get; set; }

        public string CustomerEmail { get; set; }
    }
         
   
}