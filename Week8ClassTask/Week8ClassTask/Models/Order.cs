using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Week8ClassTask.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public User User { get; set; }
    }
}
