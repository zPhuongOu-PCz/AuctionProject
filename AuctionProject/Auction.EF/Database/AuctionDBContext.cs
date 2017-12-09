﻿using Auction.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Auction.EF.Database
{
    public class AuctionDBContext : DbContext
    {
        public AuctionDBContext(DbContextOptions<AuctionDBContext> options)
            : base(options)
        {

        }

        public DbSet<User> PdbUser { get; set; }

        public DbSet<Role> PdbRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=AuctionProject;Integrated Security=True");
            base.OnConfiguring(builder);
        }
    }
}