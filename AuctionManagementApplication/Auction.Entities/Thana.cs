using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Auction.Entities
{
    public class Thana
    {
        public int Id { get; set; }
        [Required] public int DistrictId { get; set; }
        [Required] public string Name { get; set; }
        public virtual District District { get; set; }

    }
}
