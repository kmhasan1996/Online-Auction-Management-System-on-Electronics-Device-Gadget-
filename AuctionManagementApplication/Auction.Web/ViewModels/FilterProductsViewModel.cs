using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Auction.Entities;

namespace Auction.Web.ViewModels
{
    public class FilterProductsViewModel
    {
        public List<Product> Products { get; set; }
        public List<User> Bidders { get; set; }
        public Pager Pager { get; set; }
        public int? SortBy { get; set; }
        public string SearchText { get; set; }
        public int? CategoryID { get; set; }
        public int? DistrictId { get; set; }
    }
}