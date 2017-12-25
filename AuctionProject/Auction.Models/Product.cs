using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Auction.Models
{
    public class Product
    {
        [Key]
        public Guid idpro { get; set; }

        [Required]
        public string catename { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        public byte[] image { get; set; }

        [Required]
        public bool hotitem { get; set; }

        [Required]
        public bool newitem { get; set; }

        [Required]
        public bool bestitem { get; set; }
    }
}
