using System.Collections.Generic;

namespace Auction.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int UserPicture { get; set; }
        public int FirstName { get; set; }
        public int LastName { get; set; }
        public string Gender { get; set; }
        //public int DistrictId { get; set; }
        public int ThanaId { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public virtual List<Product> Products { get; set; }
        //public virtual District District { get; set; }
        public virtual Thana Thana { get; set; }

    }
}
