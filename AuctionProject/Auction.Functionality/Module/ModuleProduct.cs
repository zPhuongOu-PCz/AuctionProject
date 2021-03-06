﻿using System;
using System.Collections.Generic;
using System.Linq;
using Auction.EF.Database;
using Auction.Model.API.Product;
using Auction.Models;


namespace Auction.Functionality.Module
{
    public class ModuleProduct
    {
        private readonly AuctionDBContext _context;

        public ModuleProduct(AuctionDBContext context)
        {
            this._context = context;
        }

        public List<Product> Get()
        {
            try
            {
                return this._context.PdbProduct.ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<Product> Get(string _cate)
        {
            try
            {
                return this._context.PdbProduct.Where(item => item.catename == _cate).ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool Post(ProductNew item)
        {
            try
            {
                List<Product> list = Get();

                Product cate = new Product
                {
                    auctiontime = item.auctiontime,
                    bigimage = item.bigimage,
                    brand = item.brand,
                    catename = item.catename,
                    idpro = Guid.NewGuid(),
                    name = item.name,
                    note = item.note,
                    smallimage1 = item.smallimage1,
                    smallimage2 = item.smallimage2,
                    smallimage3 = item.smallimage3,
                    warrantyperiod = item.warrantyperiod,                
                };
                this._context.PdbProduct.Add(cate);
                this._context.Entry(cate).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                this._context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string GetNamewithId(int _id)
        {
            return this._context.PdbCategory.Where(item => item.Id == _id).FirstOrDefault().name;
        }
    }
}
