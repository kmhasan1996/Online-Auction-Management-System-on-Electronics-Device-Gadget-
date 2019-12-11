using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Auction.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
