﻿// <auto-generated />
using Auction.EF.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Auction.EF.Migrations
{
    [DbContext(typeof(AuctionDBContext))]
    partial class AuctionDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Auction.Models.User", b =>
                {
                    b.Property<Guid>("IDuser")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("address")
                        .HasMaxLength(100);

                    b.Property<int?>("age");

                    b.Property<int?>("countlogin");

                    b.Property<string>("displayname")
                        .HasMaxLength(50);

                    b.Property<string>("email")
                        .HasMaxLength(100);

                    b.Property<int?>("failedlogin");

                    b.Property<DateTime?>("lastlogin");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("phone")
                        .HasMaxLength(15);

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("IDuser");

                    b.ToTable("PdbUser");
                });
#pragma warning restore 612, 618
        }
    }
}
