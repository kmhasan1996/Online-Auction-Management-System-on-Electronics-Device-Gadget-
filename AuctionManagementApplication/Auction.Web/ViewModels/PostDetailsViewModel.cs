using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Auction.Entities;

namespace Auction.Web.ViewModels
{
    public class PostDetailsViewModel
    {
        public  Product Product { get; set; }
        public List<Bidder>  Bidders { get; set; }
        
    }
}