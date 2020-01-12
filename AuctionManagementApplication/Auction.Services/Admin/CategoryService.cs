using System.Collections.Generic;
using System.Linq;
using Auction.Database;
using Auction.Entities;

namespace Auction.Services.Admin
{
    public class CategoryService
    {
        #region Singleton

        public static CategoryService Instance
        {
            get
            {
                if(PrivateInstance == null)
                    PrivateInstance=new CategoryService();
                return PrivateInstance;
            }
        }
        private static CategoryService PrivateInstance { get; set; }

        private CategoryService()
        {

        }

        #endregion

        #region Admin
        public bool UniqueName(Category category)
        {
            using (var context = new AuctionDbContext())
            {
                var categories = (dynamic)null;
                if (category.Id != 0)
                {
                    categories = context.Categories.Where(x => x.Name.Equals(category.Name) && x.Id != category.Id).ToList();
                }
                else
                {
                    categories = context.Categories.Where(x => x.Name.Equals(category.Name)).ToList();
                }


                return categories.Count > 0;
            }
        }
        public bool Create(Category category)
        {
            using (var context=new AuctionDbContext())
            {
                context.Categories.Add(category);
                return context.SaveChanges() > 0;
            }
        }
        public bool Update(Category category)
        {
            using (var context = new AuctionDbContext())
            {

                Category model = new Category();
                model = context.Categories.Find(category.Id);
                if (model != null)
                {
                    model.Id = category.Id;
                    model.Name = category.Name;
                    model.Icon = category.Icon;
                    model.ImageUrl = category.ImageUrl;
                    model.IsActive = category.IsActive;
                }

                return context.SaveChanges() > 0;

            }
        }

        public bool Delete(int id)
        {
            using (var context = new AuctionDbContext())
            {
                Category category = context.Categories.Find(id);
                context.Categories.Remove(category);
                return context.SaveChanges() > 0;
            }
        }
        public Category GetCategoryById(int id)
        {
            using (var context = new AuctionDbContext())
            {
                return context.Categories.Find(id);
            }
        }
        public List<Category> GetAllCategory()
        {
            using (var context=new AuctionDbContext())
            {
                return context.Categories.ToList();
            }
        }
        public List<Category> GetAllActiveCategory()
        {
            using (var context=new AuctionDbContext())
            {
                return context.Categories.Where(x=>x.IsActive).ToList();
            }
        }

        #endregion
    }
}
