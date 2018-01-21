using System;
using System.Collections.Generic;
using Auction.Models;
using Microsoft.EntityFrameworkCore;

namespace Auction.EF.Database
{
    public class AuctionDBContext : DbContext
    {
        public AuctionDBContext(DbContextOptions<AuctionDBContext> options) : base(options)
        {

        }

        public DbSet<User> PdbUser { get; set; }

        public DbSet<Category> PdbCategory { get; set; }

        public DbSet<Product> PdbProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            //This is a connectionString
            builder.UseSqlServer(@"Data Source=.\sqlexpress01;Initial Catalog=AuctionProject;Integrated Security=True");

            base.OnConfiguring(builder);
        }
    }
}