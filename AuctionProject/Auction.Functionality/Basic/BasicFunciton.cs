using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Auction.EF.Database;
using Auction.Models;

namespace Auction.Functionality.Basic
{
    public class BasicFunciton
    {
        private readonly AuctionDBContext _context;
        private readonly Module.ModuleUser moduleuser;
        private readonly Module.ModuleCategory modulecate;

        public BasicFunciton(AuctionDBContext context)
        {
            this._context = context;
            modulecate = new Module.ModuleCategory(this._context);
            moduleuser = new Module.ModuleUser(this._context);
        }
    }
}