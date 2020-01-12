using System.Collections.Generic;
using Auction.Database;
using System.Linq;
using System.Data.Entity;
using Auction.Entities;


namespace Auction.Services.UserAccountService
{
    public class UserAccountService
    {
        #region Singleton

        public static UserAccountService Instance
        {
            get
            {
                if (PrivateInstance == null)
                    PrivateInstance = new UserAccountService();
                return PrivateInstance;
            }
        }
        private static UserAccountService PrivateInstance { get; set; }

        private UserAccountService()
        {

        }

        #endregion

        #region User

        public Entities.User IsRegisteredUser(Entities.User model)
        {
            using (var context = new AuctionDbContext())
            {
                return context.Users.Include(x=>x.Products).FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);

            }

        }

        public bool AddUser(Entities.User model)
        {
            using (var context = new AuctionDbContext())
            {
                context.Users.Add(model);
                return context.SaveChanges() > 0;
            }
        }

        #endregion

        #region Admin

        public List<Entities.User> GetAllUsers()
        {
            using (var context=new AuctionDbContext())
            {
                return context.Users.ToList();
            }
        }

        public Entities.User GetUserById(int userId)
        {
            using (var context = new AuctionDbContext())
            {
                return context.Users.FirstOrDefault(x=>x.Id==userId);
            }
        }


        public bool Update(int userId)
        {
            using (var context = new AuctionDbContext())
            {
                var model = context.Users.Find(userId);

                model.Id = userId;
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

        public double MyCredit(int userId)  
        {
            using (var context=new AuctionDbContext())
            {
                return context.Users.Where(x => x.Id == userId).Select(x => x.Credit).FirstOrDefault();
            }
        }

        public bool UpdateMyCredit(int userId, double credit)
        {
            using (var context=new AuctionDbContext())
            {
                var user = context.Users.Find(userId);

                user.Credit += credit;

                return context.SaveChanges() > 0;

            }
        }

        public bool DepositCreditForBidding(int userId, double credit)
        {
            using (var context = new AuctionDbContext())
            {
                var user = context.Users.Find(userId);

                user.Credit -= credit;

                return context.SaveChanges() > 0;

            }
        }


        #endregion

        #region MyRegion



        #endregion

    }
}
