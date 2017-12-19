using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Auction.Models
{
    public class Category
    {
        [Key]        
        public Guid idcategory { get; set; }

        [Required]
        [MaxLength(50)]        
        public string name { get; set; }
    }
}
