using System;
using System.Collections.Generic;
using Auction.EF.Database;
using Auction.Functionality.Module;
using Auction.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Auction.Model.API.Category;

namespace Auction.Test
{
    [TestClass]
    public class Categorytest
    {
        public ModuleCategory function;
        public List<Category> list;

        [TestInitialize]
        public void Setup()
        {
            function = new ModuleCategory(new AuctionDBContext(new Microsoft.EntityFrameworkCore.DbContextOptions<AuctionDBContext>()));
            list = null;
        }

        [TestMethod]
        public void CateGetAll()
        {
            Assert.AreNotEqual(list, function.Get());
        }

        [TestMethod]
        public void CateGetOne()
        {
            Assert.AreNotEqual(list, function.Get("Quần Áo"));
        }

        [TestMethod]
        public void CateInsert()
        {
            Assert.AreNotEqual(false, function.Post(new CategoryNew
            {                
                name = "Công nghệ"
            }));
        }

        [TestMethod]
        public void CateInsertsub()
        {
            Assert.AreNotEqual(false, function.Post(new CategoryNew
            {
                name = "Đồng hồ"
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