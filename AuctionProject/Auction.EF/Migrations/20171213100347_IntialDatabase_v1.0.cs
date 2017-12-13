using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Auction.EF.Migrations
{
    public partial class IntialDatabase_v10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PdbUser",
                columns: table => new
                {
                    IDuser = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    address = table.Column<string>(maxLength: 100, nullable: true),
                    age = table.Column<int>(nullable: true),
                    countlogin = table.Column<int>(nullable: true),
                    displayname = table.Column<string>(maxLength: 50, nullable: true),
                    email = table.Column<string>(maxLength: 100, nullable: true),
                    failedlogin = table.Column<int>(nullable: true),
                    lastlogin = table.Column<DateTime>(nullable: true),
                    password = table.Column<string>(maxLength: 50, nullable: false),
                    phone = table.Column<string>(maxLength: 15, nullable: true),
                    username = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdbUser", x => x.IDuser);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PdbUser");
        }
    }
}
