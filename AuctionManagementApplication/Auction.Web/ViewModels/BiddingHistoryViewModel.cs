using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Auction.Entities;

namespace Auction.Web.ViewModels
{
    public class BiddingHistoryViewModel
    {
        public List<Product> Products { get; set; }
        public User User { get; set; }
    }
}