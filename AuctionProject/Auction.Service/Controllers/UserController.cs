using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Auction.EF.Database;
using Auction.Functionality.Basic;
using Auction.Functionality.Module;
using Auction.Model.API.Error;
using Auction.Model.API.User;
using Auction.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Service.Controllers {

    [Produces ("application/json")]
    //[Authorize]
    [Route ("api/user")]
    public class UserController : Controller {
        private readonly AuctionDBContext _context;
        private readonly ModuleUser userfunction;
        private readonly ErrorResquest errorResquest;
        private readonly BasicFunciton basicfunction;

        public UserController (AuctionDBContext context) {
            this._context = context;
            userfunction = new ModuleUser (this._context);
            this.basicfunction = new BasicFunciton (this._context);
            this.errorResquest = new ErrorResquest ();
        }

        [HttpGet ("{_us}")]
        public IActionResult Get (string _us) {
            var result = userfunction.Get (_us);
            if (result == null) {
                return NotFound (errorResquest.Error404 ());
            }
            return Ok (result);
        }

        [HttpPost]
        [Route ("login")]
        public IActionResult Login ([FromBody] UserLogin item) {
            if (item == null) {
                return NotFound ();
            } else {
                if (this.userfunction.Login (item.username, item.password) == 1) {
                    return Ok ();
                } else {
                    return Unauthorized ();
                }
            }
        }

        [HttpPost]
        [Route ("register")]
        public IActionResult Register ([FromBody] UserResgiter item) {
            if (item == null) {
                return NotFound ();
            } else {
                if (this.userfunction.Post (item) == 1) {
                    return Ok ();
                } else {
                    return NotFound ();
                }
            }
        }
    }
}