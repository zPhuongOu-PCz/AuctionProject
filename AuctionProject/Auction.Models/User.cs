using System;
using System.ComponentModel.DataAnnotations;

namespace Auction.Models
{
    public class User
    {
        [Key]
        public Guid IDuser { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }

        public User()
        {
            this.IDuser = Guid.NewGuid();
            this.username = string.Empty;
            this.password = string.Empty;
        }

        public User(string _us, string _ps)
        {
            this.IDuser = Guid.NewGuid();
            this.username = _us;
            this.password = _ps;
        }
    }
}
