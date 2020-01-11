using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Auction.Entities;

namespace Auction.Web.ViewModels
{
    public class PostDetailsViewModel
    {
        public bool OwnAd { get; set; }
        public User User { get; set; }
        public bool ExistenceBidder { get; set; }
        public  Product Product { get; set; }
        public List<Bidder>  Bidders { get; set; }
        
    }
}