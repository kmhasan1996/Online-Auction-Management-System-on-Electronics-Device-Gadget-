using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Auction.Entities;

namespace Auction.Web.ViewModels
{
    public class TestimonialViewModel
    {
        public List<Testimonial> Testimonials { get; set; }
        public List<Category> FeaturedCategories { get; set; }
    }
}