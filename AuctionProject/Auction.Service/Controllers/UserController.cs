using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Auction.Models;
using Auction.Service.Database;

namespace Auction.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly AuctionDBContext _context;

        public UserController(AuctionDBContext context)
        {
            this._context = context;
        }

        private bool CheckLogin(string _us, string _ps)
        {
            if (this._context.PdbUser.Where(item => item.username == _us && item.password == _ps) == null)
                return false;
            return true;
        }

        //[HttpGet]
        //public IEnumerable<User> Get()
        //{

        //}

        //[HttpGet("{id}")]
        //public IEnumerable<User> Get(Guid id)
        //{

        //}

    }
}