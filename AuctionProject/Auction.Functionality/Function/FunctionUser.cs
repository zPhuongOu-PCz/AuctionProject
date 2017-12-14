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

        /// <summary>
        /// REST POST for User
        /// </summary>
        /// <param name="user">UserResgiter for Resgiter</param>
        /// <returns>1 OK - 0 Failed</returns>
        public int Post (UserResgiter user) {
            User item = new User ();
            if (CheckUser (user.username, user.password, user.displayname)) {
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
                this._context.SaveChanges ();
                return 1;
            } else {
                return 0;
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

        /// <summary>
        /// REST DELETE for User
        /// </summary>
        /// <param name="us">UserLogin (username,password)</param>
        /// <param name="user">User who you want to delete</param>
        /// <returns> -1 not found user - 1 OK - 0 for UserLogin Forbid
        /// </returns>
        public int Delete (UserLogin us, string user) {
            if (us.username != user) {
                return -1;
            } else {
                User usremove = FindUser (us.username, us.password);
                if (usremove != null) {
                    return 0;
                } else {
                    this._context.PdbUser.Remove (usremove);
                    this._context.Entry (usremove).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    this._context.SaveChanges ();
                    return 1;
                }
            }
        }

        /// <summary>
        /// This Methid for Checking User for not null username, password and displayname
        /// </summary>
        /// <param name="_us">Username of User</param>
        /// <param name="_pa">Password of User</param>
        /// <param name="_displayname">Name of User</param>
        /// <returns>if 3 param not null return true else return false</returns>
        public bool CheckUser (string _us, string _pa, string _displayname) {
            if (_us == null || _us == "") {
                return false;
            } else if (_pa == null || _pa == "") {
                return false;
            } else if (_displayname == null || _displayname == "") {
                return false;
            } else {
                return true;
            }
        }

        /// <summary>
        /// This Method for Finding User with username and password
        /// </summary>
        /// <param name="_us">Username of User</param>
        /// <param name="_pa">Password of User</param>
        /// <returns>return true for one user found and false for not found</returns>
        public User FindUser (string _us, string _pa) {
            return this._context.PdbUser.Where (item => item.username == _us && item.password == _pa).FirstOrDefault ();
        }

        /// <summary>
        /// The method for Finding User with username and password but return boolean
        /// </summary>
        /// <param name="_us">Username of User</param>
        /// <param name="_pa">Password of User</param>
        /// <returns>return true for one user found and false for not found with boolean</returns>
        public bool ExistsUser (string _us, string _pa) {
            return (this._context.PdbUser.Where (item => item.username == _us && item.password == _pa).FirstOrDefault ()) != null;
        }
    }
}