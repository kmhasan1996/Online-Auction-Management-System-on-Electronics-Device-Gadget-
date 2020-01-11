using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Auction.Entities;

namespace Auction.Web.ViewModels
{
    public class MyAdsViewModel
    {
        public User User { get; set; }
        public List<Product> PendingAds { get; set; }
        public List<Product> RejectAds { get; set; }
        public List<Product> ActiveAds { get; set; }
    }
}