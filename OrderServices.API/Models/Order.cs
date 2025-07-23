using System.ComponentModel.DataAnnotations;

namespace OrderServices.API.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string? OrderName { get; set; }

        public DateTime? OrderDate { get; set; }
    }
}
