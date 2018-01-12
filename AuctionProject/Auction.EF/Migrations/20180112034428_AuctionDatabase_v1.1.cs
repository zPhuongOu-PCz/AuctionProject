using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Auction.EF.Migrations
{
    public partial class AuctionDatabase_v11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bestitem",
                table: "PdbProduct");

            migrationBuilder.DropColumn(
                name: "hotitem",
                table: "PdbProduct");

            migrationBuilder.DropColumn(
                name: "idcate",
                table: "PdbProduct");

            migrationBuilder.DropColumn(
                name: "image",
                table: "PdbProduct");

            migrationBuilder.DropColumn(
                name: "newitem",
                table: "PdbProduct");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "PdbProduct",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "auctiontime",
                table: "PdbProduct",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "bigimage",
                table: "PdbProduct",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "brand",
                table: "PdbProduct",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "catename",
                table: "PdbProduct",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "smallimage1",
                table: "PdbProduct",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "smallimage2",
                table: "PdbProduct",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "smallimage3",
                table: "PdbProduct",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "warrantyperiod",
                table: "PdbProduct",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "PdbProduct");

            migrationBuilder.DropColumn(
                name: "auctiontime",
                table: "PdbProduct");

            migrationBuilder.DropColumn(
                name: "bigimage",
                table: "PdbProduct");

            migrationBuilder.DropColumn(
                name: "brand",
                table: "PdbProduct");

            migrationBuilder.DropColumn(
                name: "catename",
                table: "PdbProduct");

            migrationBuilder.DropColumn(
                name: "smallimage1",
                table: "PdbProduct");

            migrationBuilder.DropColumn(
                name: "smallimage2",
                table: "PdbProduct");

            migrationBuilder.DropColumn(
                name: "smallimage3",
                table: "PdbProduct");

            migrationBuilder.DropColumn(
                name: "warrantyperiod",
                table: "PdbProduct");

            migrationBuilder.AddColumn<bool>(
                name: "bestitem",
                table: "PdbProduct",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "hotitem",
                table: "PdbProduct",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "idcate",
                table: "PdbProduct",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<byte[]>(
                name: "image",
                table: "PdbProduct",
                nullable: false,
                defaultValue: new byte[] {  });

            migrationBuilder.AddColumn<bool>(
                name: "newitem",
                table: "PdbProduct",
                nullable: false,
                defaultValue: false);
        }
    }
}
