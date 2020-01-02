using System.Collections.Generic;

namespace Auction.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Credit { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int ThanaId { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
        public virtual List<Product> Products { get; set; }
        public virtual Thana Thana { get; set; }

    }
}
