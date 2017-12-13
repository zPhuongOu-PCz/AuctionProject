using System;
using System.ComponentModel.DataAnnotations;

namespace Auction.Model.API.User {
    public class UserResgiter {
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
    }
}