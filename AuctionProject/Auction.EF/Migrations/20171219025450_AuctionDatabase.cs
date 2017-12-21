using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Auction.EF.Migrations
{
    public partial class AuctionDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PdbCategory",
                columns: table => new
                {
                    idcategory = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdbCategory", x => x.idcategory);
                });

            migrationBuilder.CreateTable(
                name: "PdbProduct",
                columns: table => new
                {
                    idpro = table.Column<Guid>(nullable: false),
                    bestitem = table.Column<bool>(nullable: false),
                    hotitem = table.Column<bool>(nullable: false),
                    idcate = table.Column<Guid>(nullable: false),
                    image = table.Column<byte[]>(nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    newitem = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdbProduct", x => x.idpro);
                });

            migrationBuilder.CreateTable(
                name: "PdbUser",
                columns: table => new
                {
                    username = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IDuser = table.Column<Guid>(nullable: false),
                    address = table.Column<string>(maxLength: 100, nullable: true),
                    age = table.Column<int>(nullable: true),
                    countlogin = table.Column<int>(nullable: true),
                    displayname = table.Column<string>(maxLength: 50, nullable: true),
                    email = table.Column<string>(maxLength: 100, nullable: true),
                    failedlogin = table.Column<int>(nullable: true),
                    lastlogin = table.Column<DateTime>(nullable: true),
                    password = table.Column<string>(maxLength: 50, nullable: false),
                    phone = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdbUser", x => x.username);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PdbCategory");

            migrationBuilder.DropTable(
                name: "PdbProduct");

            migrationBuilder.DropTable(
                name: "PdbUser");
        }
    }
}
