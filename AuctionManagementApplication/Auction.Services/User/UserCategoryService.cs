using Auction.Database;
using Auction.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Auction.Services.UserAccountService
{
    public class UserCategoryService
    {
        #region Singleton

        public static UserCategoryService Instance
        {
            get
            {
                if (PrivateInstance == null)
                    PrivateInstance = new UserCategoryService();
                return PrivateInstance;
            }
        }
        private static UserCategoryService PrivateInstance { get; set; }

        private UserCategoryService()
        {

        }

        #endregion


        public List<Category> GetAll()
        {
            using(var context =new AuctionDbContext())
            {
               return context.Categories.Where(x=>x.IsActive).ToList();
            }
        }

        public List<Category> GetFeaturedNotNullItemCategory()
        {
            using (var context = new AuctionDbContext())
            {
               

                return context.Categories.Include(x=>x.Products).Where(x => x.IsActive  && x.Products.Count != 0 ).Where(c => c.Products.Any(i => i.IsActive)).ToList();
            }

        }
    }
}
