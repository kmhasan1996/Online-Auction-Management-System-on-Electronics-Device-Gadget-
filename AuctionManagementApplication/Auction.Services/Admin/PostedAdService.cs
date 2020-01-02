using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Auction.Database;
using Auction.Entities;

namespace Auction.Services.Admin
{
    public class PostedAdService
    {
        #region Singleton

        public static PostedAdService Instance
        {
            get
            {
                if (PrivateInstance == null)
                    PrivateInstance = new PostedAdService();
                return PrivateInstance;
            }
        }
        private static PostedAdService PrivateInstance { get; set; }

        private PostedAdService()
        {

        }

        #endregion


        public List<Product> GetAllPostedAd()
        {
            using (var context=new AuctionDbContext())
            {
                return context.Products.Include(x => x.User).Include(x=>x.Category).Where(x=> !x.IsPending && !x.IsRejected && x.Category.IsActive && x.User.IsActive ).ToList();
            }

        }
        public List<Product> GetAllPendingAds()
        {
            using (var context=new AuctionDbContext())
            {
                return context.Products.Include(x => x.User).Include(x=>x.Category).Where(x=>x.Category.IsActive && x.IsPending).ToList();
            }

        }
        public List<Product> GetAllRejectedAds()
        {
            using (var context=new AuctionDbContext())
            {
                return context.Products.Include(x => x.User).Include(x=>x.Category).Where(x=>x.Category.IsActive && x.IsRejected).ToList();
            }

        }

        public bool ActivateDeactivatePostedAd(int productId)
        {
            using (var context = new AuctionDbContext())
            {
                var model = context.Products.Find(productId);

                model.Id = productId;
                if (model.IsActive)
                {
                    model.IsActive = false;
                }
                else
                {
                    model.IsActive = true;
                }

                return context.SaveChanges() > 0;

            }
        }

        public bool AcceptPostedAd(int productId)
        {
            using (var context = new AuctionDbContext())
            {
                var model = context.Products.Find(productId);

                model.Id = productId;
                if (model.IsPending)
                {
                    model.IsPending = false;
                    model.IsActive = true;
                   
                }
               

                return context.SaveChanges() > 0;

            }
        }

        public bool RejectPostedAd(int productId)
        {
            using (var context = new AuctionDbContext())
            {
                var model = context.Products.Find(productId);

                model.Id = productId;
                if (model.IsPending)
                {
                    model.IsPending = false;
                    model.IsRejected = true;
                   
                }
                
                return context.SaveChanges() > 0;

            }
        }
        public Product GetPostedAdById(int productId)
        {
            using (var context = new AuctionDbContext())
            {
                return context.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == productId);



            }
        }



    }
}
