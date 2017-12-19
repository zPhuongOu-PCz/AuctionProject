using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auction.Models {
    public class User {        
        [Required]
        public Guid IDuser { get; set; }

        [Key]
        [Required]
        [StringLength (50)]
        public string username { get; set; }

        [Required]

        [StringLength (50)]
        public string password { get; set; }

        [StringLength (50)]
        public string displayname { get; set; }

        [Range (0, 100)]
        public int? age { get; set; }

        [StringLength (100)]
        public string address { get; set; }

        [StringLength (15)]
        public string phone { get; set; }

        [StringLength (100)]
        public string email { get; set; }
        public int? countlogin { get; set; }
        public int? failedlogin { get; set; }
        public DateTime? lastlogin { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
    }
}