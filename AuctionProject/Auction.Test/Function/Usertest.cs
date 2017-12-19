using System;
using System.Collections.Generic;
using Auction.EF.Database;
using Auction.Functionality.Function;
using Auction.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Auction.Test {
    [TestClass]
    public class Usertest {
        public FunctionUser function;
        public List<FunctionUser> list;

        [TestInitialize]
        public void Setup () {
            function = new FunctionUser (new AuctionDBContext (new Microsoft.EntityFrameworkCore.DbContextOptions<AuctionDBContext> ()));
            list = null;
        }

        [TestMethod]
        public void UserTestGetAll() {
            Assert.AreNotEqual (list, this.function.Get ());
        }

        [TestMethod]
        public void UserTestGetOne() {
            Assert.AreNotEqual (list, this.function.Get ("admin"));
        }

        [TestMethod]
        public void UserInsert() {
            bool check = false;
            Assert.AreNotEqual (check, this.function.Post (new Model.API.User.UserResgiter {
                address = "Address",
                    age = 21,
                    displayname = "PhuongOU",
                    email = "phuongou@gmail.com",
                    password = "123",
                    username = "admin",
                    phone = "0123456789",
            }));
        }

        [TestMethod]
        public void UserInsertsub()
        {
            bool check = false;
            Assert.AreNotEqual(check, this.function.Post(new Model.API.User.UserResgiter
            {
                address = "Address",
                age = 21,
                displayname = "PhuongOU",
                email = "phuongou@gmail.com",
                password = "123",
                username = "admin1",
                phone = "0123456789",
            }));
        }

        [TestCleanup]
        public void Cleanup()
        {

        }
    }
}