using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Auction.EF.Database;

namespace Auction.Functionality.Basic {
    public class BasicFunciton {
        private readonly AuctionDBContext _context;

        public BasicFunciton (AuctionDBContext context) {
            this._context = context;
        }

        public int CheckLogin (string us, string pa) {
            if (this._context.PdbUser.Where (item => item.username == us || item.password == pa) == null)
                return 1;
            return 0;
        }
    }
}