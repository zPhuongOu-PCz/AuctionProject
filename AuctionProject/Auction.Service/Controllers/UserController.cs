using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Auction.Models;
using Auction.EF.Database;
using Auction.Model.API.User;
using Auction.Functionality.Function;

namespace Auction.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]    
    public class UserController : Controller
    {
        private readonly AuctionDBContext _context;
        private readonly FunctionUserInfomation function;

        public UserController(AuctionDBContext context)
        {
            this._context = context;
            function = new FunctionUserInfomation(this._context);
        }

        private bool CheckLogin(string _us, string _ps)
        {
            if (this._context.PdbUser.Where(item => item.username == _us && item.password == _ps) == null)
                return false;
            return true;
        }

        [HttpGet]
        public IEnumerable<UserInfomation> Get()
        {
            return function.Get();
        }

        [HttpGet("{_us}")]
        public UserInfomation Get(string _us)
        {
            return function.Get(_us);
        }
    }
}