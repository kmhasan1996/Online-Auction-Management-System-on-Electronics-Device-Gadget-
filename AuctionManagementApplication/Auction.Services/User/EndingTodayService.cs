﻿using System;
using Auction.Database;
using Auction.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace Auction.Services.User
{
    public class EndingTodayService
    {
        #region Singleton

        public static EndingTodayService Instance
        {
            get
            {
                if (PrivateInstance == null)
                    PrivateInstance = new EndingTodayService();
                return PrivateInstance;
            }
        }
        private static EndingTodayService PrivateInstance { get; set; }

        private EndingTodayService()
        {

        }

        #endregion


        //public List<Product> GetLatestProductPosts(int numberOfProducts)
        //{
        //    using (var context = new AuctionDbContext())
        //    {
        //        return context.Products.
        //            Where(x => x.Category.IsActive && x.IsActive && x.User.IsActive).
        //            OrderByDescending(x => x.Id).Take(numberOfProducts).
        //            Include(x => x.Category).
        //            ToList();

        //    }

        //}

        //public List<Product> GetEightProducts(int numberOfProducts)
        //{

        //    using (var context = new AuctionDbContext())
        //    {
        //        return context.Products.
        //            Where(x => x.Category.IsActive && x.IsActive && x.User.IsActive).
        //            OrderByDescending(x => x.Id).Take(numberOfProducts).

        //            Include(x => x.Category).
        //            ToList();
        //    }

        //}

        //public List<Product> GetProductsByCategory(int categoryId, int numberOfProducts)
        //{

        //    using (var context = new AuctionDbContext())
        //    {
        //        return context.Products.
        //            Where(x => x.Category.Id == categoryId && x.Category.IsActive && x.User.IsActive).
        //            OrderByDescending(x => x.Id).
        //            Take(numberOfProducts).
        //            Include(x => x.Category).Include(x => x.User).Include(x => x.User.Thana).Include(x => x.User.Thana.District).
        //            ToList();

        //    }

        //}


        [Obsolete]
        public List<Category> GetFeaturedNotNullItemCategory()
        {
            using (var context = new AuctionDbContext())
            {


                return context.Categories.Include(x => x.Products).Where(x => x.IsActive && x.Products.Count != 0).Where(c => c.Products.Any(i => i.IsActive) && c.Products.Any(i=> EntityFunctions.TruncateTime(i.EndDateTime) == DateTime.Today.Date)).ToList();
            }

        }

        [Obsolete]
        public int GetMaximumPrice()
        {
            using (var context = new AuctionDbContext())
            {
                return (int)(context.Products.Where(x => x.Category.IsActive && x.IsActive && x.User.IsActive && EntityFunctions.TruncateTime(x.EndDateTime) == DateTime.Today.Date).Max(x =>(double?) x.BasePrice) ?? 0);
            }
        }

        [Obsolete]
        public int GetMinimumPrice()
        {
            using (var context = new AuctionDbContext())
            {
                return (int)(context.Products.Where(x => x.Category.IsActive && x.IsActive && x.User.IsActive && EntityFunctions.TruncateTime(x.EndDateTime) == DateTime.Today.Date).Min(x =>(double?) x.BasePrice) ?? 0);
            }
        }

        [Obsolete]
        public List<Product> SearchProduct(string searchTxt, int? minimumPrice, int? maximumPrice, int? categoryId, int? sortBy, int pageNo, int pageSize)
        {
            using (var context = new AuctionDbContext())
            {
                var products = context.Products.
                    Where(x => x.Category.IsActive && x.IsActive && x.User.IsActive && EntityFunctions.TruncateTime(x.EndDateTime) == DateTime.Today.Date).
                    Include(x => x.User).Include(x => x.User.Thana).Include(x => x.User.Thana.District).ToList();

                if (categoryId.HasValue)
                {
                    products = products.Where(x => x.Category.Id == categoryId.Value).ToList();
                }

                if (!string.IsNullOrEmpty(searchTxt))
                {
                    products = products.Where(x => x.Name.ToLower().Contains(searchTxt.ToLower())).ToList();
                }

                if (minimumPrice.HasValue)
                {
                    products = products.Where(x => x.BasePrice >= minimumPrice.Value).ToList();
                }

                if (maximumPrice.HasValue)
                {
                    products = products.Where(x => x.BasePrice <= maximumPrice.Value).ToList();
                }



                if (sortBy.HasValue)
                {
                    switch (sortBy.Value)
                    {
                        case 2:
                            products = products.OrderBy(x => x.BasePrice).ToList();
                            break;
                        case 3:
                            products = products.OrderByDescending(x => x.BasePrice).ToList();
                            break;
                        case 4:
                            products = products.OrderByDescending(x => x.StarDateTime).ToList();
                            break;
                        case 5:
                            products = products.OrderBy(x => x.StarDateTime).ToList();
                            break;
                        default:
                            products = products.OrderByDescending(x => x.Id).ToList();
                            break;
                    }
                }

                return products.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        [Obsolete]
        public int SearchProductCount(string searchTxt, int? minimumPrice, int? maximumPrice, int? categoryId, int? sortBy)
        {
            using (var context = new AuctionDbContext())
            {
                var products = context.Products.Where(x => x.Category.IsActive && x.IsActive && x.User.IsActive && EntityFunctions.TruncateTime(x.EndDateTime) == DateTime.Today.Date).ToList();

                if (categoryId.HasValue)
                {
                    products = products.Where(x => x.Category.Id == categoryId.Value).ToList();
                }

                if (!string.IsNullOrEmpty(searchTxt))
                {
                    products = products.Where(x => x.Name.ToLower().Contains(searchTxt.ToLower())).ToList();
                }

                if (minimumPrice.HasValue)
                {
                    products = products.Where(x => x.BasePrice >= minimumPrice.Value).ToList();
                }

                if (maximumPrice.HasValue)
                {
                    products = products.Where(x => x.BasePrice <= maximumPrice.Value).ToList();
                }



                if (sortBy.HasValue)
                {
                    switch (sortBy.Value)
                    {
                        case 2:
                            products = products.OrderBy(x => x.BasePrice).ToList();
                            break;
                        case 3:
                            products = products.OrderByDescending(x => x.BasePrice).ToList();
                            break;
                        case 4:
                            products = products.OrderByDescending(x => x.StarDateTime).ToList();
                            break;
                        case 5:
                            products = products.OrderBy(x => x.StarDateTime).ToList();
                            break;
                        default:
                            products = products.OrderByDescending(x => x.Id).ToList();
                            break;
                    }
                }

                return products.Count;
            }
        }
    }
}
