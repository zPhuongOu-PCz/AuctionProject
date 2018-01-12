using System;
using System.ComponentModel.DataAnnotations;

namespace Auction.Models
{
    public class Product
    {
        [Key]
        public Guid idpro { get; set; }

        [Required]
        [StringLength(50)]
        public string catename { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string brand { get; set; }

        [Required]
        [StringLength(50)]
        public string warrantyperiod { get; set; }

        [Required]
        public int auctiontime { get; set; }

        [StringLength(30)]
        public string bigimage { get; set; }

        [StringLength(30)]
        public string smallimage1 { get; set; }

        [StringLength(30)]
        public string smallimage2 { get; set; }

        [StringLength(30)]
        public string smallimage3 { get; set; }

        [StringLength(100)]
        public string note { get; set; }
    }
}
