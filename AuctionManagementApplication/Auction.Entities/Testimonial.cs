using System;

namespace Auction.Entities
{
    public class Testimonial
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime DateTime { get; set; }
        public string Comment { get; set; }
        public virtual User User { get; set; }
    }
}
