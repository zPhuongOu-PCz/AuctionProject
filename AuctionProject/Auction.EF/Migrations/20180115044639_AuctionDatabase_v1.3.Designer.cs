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
    [Migration("20180115044639_AuctionDatabase_v1.3")]
    partial class AuctionDatabase_v13
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Auction.Models.Category", b =>
                {
                    b.Property<Guid?>("idcategory")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Id")
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

                    b.Property<int>("auctiontime");

                    b.Property<string>("bigimage")
                        .HasMaxLength(30);

                    b.Property<string>("brand")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("catename")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("note")
                        .HasMaxLength(100);

                    b.Property<string>("smallimage1")
                        .HasMaxLength(30);

                    b.Property<string>("smallimage2")
                        .HasMaxLength(30);

                    b.Property<string>("smallimage3")
                        .HasMaxLength(30);

                    b.Property<string>("warrantyperiod")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("idpro");

                    b.ToTable("PdbProduct");
                });

            modelBuilder.Entity("Auction.Models.User", b =>
                {
                    b.Property<string>("username")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<Guid>("IDuser");

                    b.Property<string>("address")
                        .HasMaxLength(100);

                    b.Property<int?>("age");

                    b.Property<int?>("countlogin");

                    b.Property<DateTime>("createddate");

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

                    b.Property<bool>("status");

                    b.HasKey("username");

                    b.ToTable("PdbUser");
                });
#pragma warning restore 612, 618
        }
    }
}
