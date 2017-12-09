using Auction.EF.Database;
using Auction.Models;
using System.Linq;

namespace Auction.Functionality.Function
{
    public class FunctionUser
    {
        private readonly AuctionDBContext _context;

        public FunctionUser(AuctionDBContext context)
        {
            this._context = context;
        }

        public bool Insert(User _us)
        {
            this._context.PdbUser.Add(_us);
            this._context.Entry(_us).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            return this._context.SaveChanges() == 1;
        }

        public bool Edit(User us)
        {
            this._context.PdbUser.Attach(us);
            this._context.Entry(us).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return this._context.SaveChanges() == 1;
        }

        public bool Delete(string _us)
        {
            User itemc = _context.PdbUser.SingleOrDefault(item => item.username == _us);
            _context.PdbUser.DefaultIfEmpty(itemc);
            _context.Entry(itemc).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return _context.SaveChanges() == 1;
        }
    }
}
