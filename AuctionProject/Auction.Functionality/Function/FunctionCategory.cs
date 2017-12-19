using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Auction.EF.Database;
using Auction.Model.API.User;
using Auction.Models;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Functionality.Function {
    public class FunctionCategory {
        private readonly AuctionDBContext _context;

        public FunctionCategory (AuctionDBContext context) {
            this._context = context;
        }

        /// <summary>
        /// Get AllCategory
        /// </summary>
        /// <returns></returns>
        public List<Category> Get () {
            return this._context.PdbCategory.ToList ();
        }

        public Category Get (string _name) {
            if (_name == "" || _name == null || _name == string.Empty) {
                return null;
            } else {
                return this._context.PdbCategory.SingleOrDefault (item => item.name == _name);
            }
        }

        public bool Post (Category cate) {
            if (cate != null) {
                cate.idcategory = Guid.NewGuid ();
                this._context.PdbCategory.Add (cate);
                this._context.Entry (cate).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                return this._context.SaveChanges () == 1;
            } else {
                return false;
            }

        }

        public bool Put (Category cate) {
            if (cate != null) {
                this._context.PdbCategory.Attach (cate);
                this._context.Entry (cate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return this._context.SaveChanges () == 1;
            } else {
                return false;
            }
        }

        public bool Delete (string _name) {
            if (_name == "" || _name == null || _name == string.Empty) {
                return false;;
            } else {
                Category cate = this._context.PdbCategory.SingleOrDefault (item => item.name == _name);
                this._context.PdbCategory.Remove (cate);
                this._context.Entry (cate).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                return this._context.SaveChanges () == 1;
            }
        }
    }
}