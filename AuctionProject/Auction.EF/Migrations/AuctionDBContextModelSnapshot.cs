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

            modelBuilder.Entity("Auction.Models.Category", b =>
                {
                    b.Property<Guid>("idcategory")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("idcategory");

                    b.ToTable("PdbCategory");
                });

            modelBuilder.Entity("Auction.Models.Product", b =>
                {
                    b.Property<Guid>("idpro")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("bestitem");

                    b.Property<bool>("hotitem");

                    b.Property<Guid>("idcate");

                    b.Property<byte[]>("image")
                        .IsRequired();

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("newitem");

                    b.HasKey("idpro");

                    b.ToTable("PdbProduct");
                });

            modelBuilder.Entity("Auction.Models.User", b =>
                {
                    b.Property<string>("username")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<Guid>("IDuser");

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

                    b.HasKey("username");

                    b.ToTable("PdbUser");
                });
#pragma warning restore 612, 618
        }
    }
}
