using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Auction.Database;
using Auction.Entities;

namespace Auction.Services.User
{
    public class TestimonialService
    {
        #region Singleton

        public static TestimonialService Instance
        {
            get
            {
                if (PrivateInstance == null)
                    PrivateInstance = new TestimonialService();
                return PrivateInstance;
            }
        }
        private static TestimonialService PrivateInstance { get; set; }

        private TestimonialService()
        {

        }

        #endregion


        public bool Add(Testimonial model)
        {
            using (var context=new AuctionDbContext())
            {
                context.Testimonials.Add(model);
                return context.SaveChanges() > 0;
            }
        }

        public List<Testimonial> GetAllTestimonials()
        {
            using (var context=new AuctionDbContext())
            {
                return context.Testimonials.Include(x => x.User).ToList();
            }
        }
    }
}
