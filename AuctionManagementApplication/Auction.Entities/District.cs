using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Auction.Entities
{
    public class District
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual List<Thana> Thanas { get; set; }
    }
}
