using Auction.Database;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Auction.Entities;

namespace Auction.Services.Admin
{
    public class ThanaService
    {
        #region Singleton

        public static ThanaService Instance
        {
            get
            {
                if (PrivateInstance == null)
                    PrivateInstance = new ThanaService();
                return PrivateInstance;
            }
        }
        private static ThanaService PrivateInstance { get; set; }

        private ThanaService()
        {

        }

        #endregion
        public bool UniqueName(Thana thana)
        {
            using (var context = new AuctionDbContext())
            {
                var thanas = (dynamic)null;
                if (thana.Id != 0)
                {
                    thanas = context.Thanas.Where(x => x.Name.Equals(thana.Name) && x.Id != thana.Id).ToList();
                }
                else
                {
                    thanas = context.Thanas.Where(x => x.Name.Equals(thana.Name)).ToList();
                }


                return thanas.Count > 0;
            }
        }
        public bool Add(Thana thana)
        {
            using (var context = new AuctionDbContext())
            {
                context.Thanas.Add(thana);
                return context.SaveChanges() > 0;
            }
        }

        public bool Update(Thana thana)
        {
            using (var context = new AuctionDbContext())
            {

                Thana model = new Thana();
                model = context.Thanas.Find(thana.Id);
                if (model != null)
                {
                    model.Id = thana.Id;
                    model.Name = thana.Name;

                }

                return context.SaveChanges() > 0;

            }
        }

        public bool Delete(int id)
        {
            using (var context = new AuctionDbContext())
            {

                Thana thana = context.Thanas.Find(id);
                context.Thanas.Remove(thana);
                return context.SaveChanges() > 0;
            }
        }
        public Thana GetById(int id)
        {
            using (var context = new AuctionDbContext())
            {
                return context.Thanas.Find(id);
            }
        }
        public List<Thana> GetAll()
        {
            using (var context = new AuctionDbContext())
            {
                return context.Thanas.Include(x=>x.District).ToList();

            }
        }
    }
}
