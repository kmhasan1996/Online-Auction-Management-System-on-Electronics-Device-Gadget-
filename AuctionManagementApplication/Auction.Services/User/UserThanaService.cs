using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Database;
using Auction.Entities;

namespace Auction.Services.User
{
    public  class UserThanaService
    {
        #region Singleton

        public static UserThanaService Instance
        {
            get
            {
                if (PrivateInstance == null)
                    PrivateInstance = new UserThanaService();
                return PrivateInstance;
            }
        }
        private static UserThanaService PrivateInstance { get; set; }

        private UserThanaService()
        {

        }

        #endregion

        public List<Thana> GetThanaByDistrictId(int districtId)
        {
            using (var context=new AuctionDbContext())
            {
                return context.Thanas.Where(x => x.DistrictId == districtId).ToList();
            }
        }
       
    }
}
