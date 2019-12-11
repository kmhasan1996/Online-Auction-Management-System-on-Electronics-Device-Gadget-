using System;

namespace Auction.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public int ImageId { get; set; }
        public string Name { get; set; }
        public double BasePrice { get; set; }
        public DateTime StarDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
        public virtual ProductImage Image { get; set; }
    }
}
