using System;
using System.Collections.Generic;

namespace Auction.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public double BasePrice { get; set; }
        public double CurrentBidPrice { get; set; }
        public DateTime StarDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Description { get; set; }
        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }
        public string ImageUrl3 { get; set; }
        public string ImageUrl4 { get; set; }
        public bool IsActive { get; set; }
        public List<Bidder> Bidders { get; set; }
        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
    }
}
