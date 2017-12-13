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
    public class FunctionUser {
        private readonly AuctionDBContext _context;

        public FunctionUser (AuctionDBContext context) {
            this._context = context;
        }

        public List<UserInfomation> Get () {
            try {
                UserInfomation result = new UserInfomation ();
                List<UserInfomation> listresult = new List<UserInfomation> ();
                List<User> listuser = this._context.PdbUser.ToList ();
                for (int i = 0; i < listuser.Count - 1; i++) {
                    result.address = listuser[i].address;
                    result.age = listuser[i].age;
                    result.displayname = listuser[i].displayname;
                    result.email = listuser[i].email;
                    result.phone = listuser[i].phone;
                    listresult.Add (result);
                }
                return listresult;
            } catch {
                return null;
            }
        }

        public UserInfomation Get (string _us) {
            try {
                User us = this._context.PdbUser.Where (item => item.username == _us).FirstOrDefault ();
                UserInfomation userInfomation = new UserInfomation ();
                userInfomation.address = us.address;
                userInfomation.age = us.age;
                userInfomation.displayname = us.displayname;
                userInfomation.email = us.email;
                userInfomation.phone = us.phone;
                return userInfomation;
            } catch {
                return null;
            }
        }

        public bool Post (UserResgiter user) {
            User item = new User();
            if (CheckUser (user)) {
                item.IDuser = Guid.NewGuid ();
                item.CreatedDate = DateTime.Now;
                item.address = user.address;
                item.age = user.age;
                item.countlogin = 0;
                item.lastlogin = DateTime.Now;
                item.displayname = user.displayname;
                item.email = user.email;
                item.phone = user.phone;
                item.password = user.password;
                item.username = user.username;
                this._context.PdbUser.Add (item);
                this._context.Entry (item).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                return this._context.SaveChanges () == 1;
            } else {
                return false;
            }
        }

        public bool Put (User user) {
            // if (CheckUser (user)) {
            //     this._context.PdbUser.Attach (user);
            //     this._context.Entry (user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //     return this._context.SaveChanges () == 1;
            // } else {
            //     return false;
            // }
            return true;
        }

        public bool Delete () {
            return true;
        }

        public bool CheckUser (UserResgiter user) {
            if (user.username == null || user.username == "") {
                return false;
            } else if (user.password == null || user.password == "") {
                return false;
            } else if (user.displayname == null || user.displayname == "") {
                return false;
            } else {
                return true;
            }
        }
    }
}