using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Auction.Entities;

namespace Auction.Web.ViewModels
{
    public class ProductWidgetViewmodel
    {
        public List<Product> Products { get; set; }
        public Boolean IsLatestProduct { get; set; }
        public Boolean ByCategory { get; set; }
    }
}