using System.ComponentModel.DataAnnotations;

namespace Week8ClassTask.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
