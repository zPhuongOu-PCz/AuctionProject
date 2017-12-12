using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Auction.Models;
using Auction.EF.Database;
using Auction.Model.API.User;
using Auction.Functionality.Function;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using Auction.Model.API.Error;

namespace Auction.Service.Controllers
{
    [Produces("application/json")]
    //[Authorize]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly AuctionDBContext _context;
        private readonly FunctionUserInfomation function;
        private readonly ErrorResquest errorResquest;

        public UserController(AuctionDBContext context)
        {
            this._context = context;
            function = new FunctionUserInfomation(this._context);
            this.errorResquest = new ErrorResquest();
        }

        private bool CheckLogin(string _us, string _ps)
        {
            if (this._context.PdbUser.Where(item => item.username == _us || item.password == _ps) == null)
                return false;
            return true;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<UserInfomation> list = function.Get();
            return Ok(list);
        }

        [HttpGet("{_us}")]
        public IActionResult Get(string _us)
        {
            var result = function.Get(_us);
            if (result == null)
            {
                return NotFound(errorResquest.Error404());
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Login([FromBody]UserLogin value)
        {
            if (CheckLogin(value.username, value.password))
            {
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}