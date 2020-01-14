using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Auction.Entities;

namespace Auction.Web.ViewModels
{
    public class ShopViewModel
    {
        public int? SortBy { get; set; }
        public string SearchText { get; set; }
        public List<Category> FeaturedCategories { get; set; }
        public List<Product> Products { get; set; }
        public List<District> Districts { get; set; }
        public List<Bidder> Bidders { get; set; }
        public int? DistrictId { get; set; }
        public int MaximumPrice { get; set; }
        public int MinimumPrice { get; set; }
        public int? CategoryID { get; set; }
        public Pager Pager { get; set; }
    }

}
