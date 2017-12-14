using Microsoft.VisualStudio.TestTools.UnitTesting;
using Auction.Functionality.Function;
using Auction.EF.Database;
using Auction.Models;
using System;

namespace Auction.Test
{
    [TestClass]
    public class Usertest
    {
        public FunctionUser function;

        [TestInitialize]
        public void Setup()
        {
            function = new FunctionUser(new AuctionDBContext(new Microsoft.EntityFrameworkCore.DbContextOptions<AuctionDBContext>()));
        }

        //[TestMethod]
        //public void TestGetAll()
        //{

        //}

        //[TestMethod]
        //public void TestGetOne(string _us)
        //{

        //}

        [TestMethod]
        public void Insert()
        {
            bool check = false;
            Assert.AreNotEqual(check, this.function.Post(new Model.API.User.UserResgiter
            {
                address = "Address",
                age = 21,
                displayname = "PhuongOU",
                email = "phuongou@gmail.com",
                password = "123",
                username = "admin",
                phone = "0123456789",           
            }));
        }

        //[TestMethod]
        //public void Edit(string _us)
        //{

        //}

        //[TestMethod]
        //public void Delete(string _us)
        //{

        //}

        //[TestCleanup]
        //public void Cleanup()
        //{

        //}
    }
}
