using Auction.EF.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auction.Functionality.Module
{
    public class ModuleProduct
    {
        private readonly AuctionDBContext _context;

        public ModuleProduct(AuctionDBContext context)
        {
            this._context = context;
        }

        
    }
}
