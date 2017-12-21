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

namespace Auction.Functionality.Module {
    public class ModuleCategory {
        private readonly AuctionDBContext _context;

        public ModuleCategory (AuctionDBContext context) {
            this._context = context;
        }

        /// <summary>
        /// Get All Category
        /// </summary>
        /// <returns>return null fail somewhere in Server</returns>
        public List<Category> Get () {
            try {
                return this._context.PdbCategory.ToList ();
            } catch {
                return null;
            }

        }

        /// <summary>
        /// Get One Category with name
        /// </summary>
        /// <param name="_name">Name of category</param>
        /// <returns>return null fail somewhere in Server</returns>
        public Category Get (string _name) {
            if (_name == "" || _name == null || _name == string.Empty) {
                return null;
            } else {
                try {
                    return this._context.PdbCategory.SingleOrDefault (item => item.name == _name);
                } catch {
                    return null;
                }

            }
        }

        /// <summary>
        /// Insert new Category
        /// </summary>
        /// <param name="cate">infomation cate</param>
        /// <returns>return false is fail to insert</returns>
        public bool Post (Category cate) {
            if (cate != null) {
                try {
                    cate.idcategory = Guid.NewGuid ();
                    this._context.PdbCategory.Add (cate);
                    this._context.Entry (cate).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    return this._context.SaveChanges () == 1;
                } catch {
                    return false;
                }

            } else {
                return false;
            }
        }

        /// <summary>
        /// Edit infomation Category
        /// </summary>
        /// <param name="cate">infomation cate</param>
        /// <returns>return false is fail to edit</returns>
        public bool Put (Category cate) {
            if (cate != null) {
                try {
                    this._context.PdbCategory.Attach (cate);
                    this._context.Entry (cate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    return this._context.SaveChanges () == 1;
                } catch {
                    return false;
                }

            } else {
                return false;
            }
        }

        /// <summary>
        /// Delete Category
        /// </summary>
        /// <param name="_name">name of Category</param>
        /// <returns>return false if fail to delete</returns>
        public bool Delete (string _name) {
            if (_name == "" || _name == null || _name == string.Empty) {
                return false;;
            } else {
                try {
                    Category cate = this._context.PdbCategory.SingleOrDefault (item => item.name == _name);
                    this._context.PdbCategory.Remove (cate);
                    this._context.Entry (cate).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    return this._context.SaveChanges () == 1;
                } catch {
                    return false;
                }
            }
        }
    }
}