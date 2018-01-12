using System;
using System.Collections.Generic;
using Auction.EF.Database;
using Auction.Functionality.Module;
using Auction.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Auction.Model.API.Product;

namespace Auction.Test
{
    [TestClass]
    public class Producttest
    {
        public ModuleProduct function;
        public List<Product> list;

        [TestInitialize]
        public void Setup()
        {
            function = new ModuleProduct(new AuctionDBContext(new Microsoft.EntityFrameworkCore.DbContextOptions<AuctionDBContext>()));
            list = null;
        }

        [TestMethod]
        public void CateGetAll()
        {
            Assert.AreNotEqual(list, function.Get());
        }

        [TestMethod]
        public void CateInsert()
        {
            Assert.AreNotEqual(false, function.Post(new ProductNew
            {
                name = "Đồng hồ Casio",
                auctiontime = 12,
                bigimage = "img-1.jpg",
                brand="Casio",
                catename="Đồng hồ",
                note="Đồng hồ xịn ko bị rỉ sét",
                smallimage1="",
                smallimage2="",
                smallimage3="",
                warrantyperiod="6",
            }));
        }

        [TestMethod]
        public void CateInsertsub_1()
        {
            Assert.AreNotEqual(false, function.Post(new ProductNew
            {
                name = "Đồng hồ DW",
                auctiontime = 12,
                bigimage = "img-2.jpg",
                brand = "DW",
                catename = "Đồng hồ",
                note = "Đồng hồ xịn ko bị rỉ sét",
                smallimage1 = "",
                smallimage2 = "",
                smallimage3 = "",
                warrantyperiod = "6",
            }));
        }

        [TestMethod]
        public void CateInsertsub_2()
        {
            Assert.AreNotEqual(false, function.Post(new ProductNew
            {
                name = "Đồng hồ Apple Watch",
                auctiontime = 12,
                bigimage = "img-3.jpg",
                brand = "Apple",
                catename = "Đồng hồ",
                note = "Đồng hồ xịn ko bị rỉ sét",
                smallimage1 = "",
                smallimage2 = "",
                smallimage3 = "",
                warrantyperiod = "6",
            }));
        }

        //[TestMethod]
        //public void CateEdit()
        //{
        //    var name = "Công nghệ";
        //    Category category = new Category();
        //    category = function.Get(name);
        //    Assert.AreNotEqual(false, function.Put(new CategoryEdit
        //    {
        //        displayhome = true,
        //        name = "CN",
        //        numberorder = 1,
        //        status = true,
        //    }, name));
        //}

        [TestMethod]
        public void Cleanup()
        {

        }
    }
}