using System;
using System.Collections.Generic;
using Auction.EF.Database;
using Auction.Functionality.Function;
using Auction.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Auction.Test
{
    [TestClass]
    public class Categorytest
    {
        public FunctionCategory function;
        public List<Category> list;

        [TestInitialize]
        public void Setup()
        {
            function = new FunctionCategory(new AuctionDBContext(new Microsoft.EntityFrameworkCore.DbContextOptions<AuctionDBContext>()));
            list = null;
        }

        [TestMethod]
        public void CateGetAll()
        {
            
        }

        [TestMethod]
        public void CateGetOne()
        {
            
        }

        [TestMethod]
        public void CateInsert()
        {
            
        }

        [TestMethod]
        public void CateInsertsub()
        {
            
        }

        [TestMethod]
        public void Post()
        {

        }

        [TestMethod]
        public void Cleanup()
        {

        }
    }
}