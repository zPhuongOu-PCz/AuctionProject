using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Auction.Models
{
    public class Role
    {
        [Key]
        public int IDrole { get; set; }
        [Required]
        public string namerole{ get; set; }
    }
}
