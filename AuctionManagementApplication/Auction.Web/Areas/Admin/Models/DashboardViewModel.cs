using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction.Web.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public int CategoryCount { get; set; }
        public int AdRequestCount { get; set; }
        public int LiveAdCount { get; set; }
        public int BlockedAdCount { get; set; }
        public int UserCount { get; set; }
        public int BlockedUserCount { get; set; }
        public int DistrictCount { get; set; }
        public int ThanaCount { get; set; }
    }
}