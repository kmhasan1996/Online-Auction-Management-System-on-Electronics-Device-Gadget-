using System.Collections.Generic;
using System.Linq;
using Auction.Database;
using Auction.Entities;

namespace Auction.Services.Admin
{
    public class DistrictService
    {
        #region Singleton

        public static DistrictService Instance
        {
            get
            {
                if (PrivateInstance == null)
                    PrivateInstance = new DistrictService();
                return PrivateInstance;
            }
        }
        private static DistrictService PrivateInstance { get; set; }

        private DistrictService()
        {

        }

        #endregion
        public bool UniqueName(District district)
        {
            using (var context = new AuctionDbContext())
            {
                var districts = (dynamic)null;
                if (district.Id != 0)
                {
                    districts = context.Districts.Where(x => x.Name.Equals(district.Name) && x.Id != district.Id).ToList();
                }
                else
                {
                    districts = context.Districts.Where(x => x.Name.Equals(district.Name)).ToList();
                }


                return districts.Count > 0;
            }
        }
        public bool Add(District district)
        {
            using (var context = new AuctionDbContext())
            {
                context.Districts.Add(district);
                return context.SaveChanges() > 0;
            }
        }

        public bool Update(District district)
        {
            using (var context = new AuctionDbContext())
            {

                District model = new District();
                model = context.Districts.Find(district.Id);
                if (model != null)
                {
                    model.Id = district.Id;
                    model.Name = district.Name;

                }

                return context.SaveChanges() > 0;

            }
        }

        public bool Delete(int id)
        {
            using (var context = new AuctionDbContext())
            {

                District district = context.Districts.Find(id);
                context.Districts.Remove(district);
                return context.SaveChanges() > 0;
            }
        }
        public District GetById(int id)
        {
            using (var context = new AuctionDbContext())
            {
                return context.Districts.Find(id);
            }
        }
        public List<District> GetAll()
        {
            using (var context = new AuctionDbContext())
            {
                return context.Districts.ToList();

            }
        }

    }
}
