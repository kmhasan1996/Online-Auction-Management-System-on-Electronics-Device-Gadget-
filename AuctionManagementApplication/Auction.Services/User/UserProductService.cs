using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Database;
using Auction.Entities;

namespace Auction.Services.User
{
    public class UserProductService
    {
        #region Singleton

        public static UserProductService Instance
        {
            get
            {
                if (PrivateInstance == null)
                    PrivateInstance = new UserProductService();
                return PrivateInstance;
            }
        }
        private static UserProductService PrivateInstance { get; set; }

        private UserProductService()
        {

        }

        #endregion

        public bool AddNewPost(Product model)
        {
            using (var context=new AuctionDbContext())
            {
                context.Products.Add(model);
                return context.SaveChanges() > 0;

            }
        }

        public List<Product> GetAdByUserId(int userId)
        {
            using (var context = new AuctionDbContext())
            {
                return context.Products.Where(x => x.UserId == userId).ToList();
            }
        }


    }
}
