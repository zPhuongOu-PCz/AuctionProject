using Auction.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Auction.Service.Database
{
    public class AuctionDBContext : DbContext
    {
        public AuctionDBContext(DbContextOptions<AuctionDBContext> options) 
            : base (options)
        {

        }

        public DbSet<User> PdbUser { get; set; }

        public DbSet<Role> PdbRole { get; set; }
    }
}
