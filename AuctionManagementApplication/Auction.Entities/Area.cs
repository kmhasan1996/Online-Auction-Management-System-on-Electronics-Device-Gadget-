using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Entities
{
    public class Area
    {
        public int Id { get; set; }
        [Required]
        public int ThanaId { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual Thana Thana { get; set; }
    }
}
