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

namespace Auction.Functionality.Module
{
    public class ModuleUser
    {
        private readonly AuctionDBContext _context;

        public ModuleUser(AuctionDBContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// REST GET for User get all User ( but not include API - UserController)
        /// </summary>
        /// <returns></returns>
        public List<UserInfomation> Get()
        {
            try
            {
                UserInfomation result = new UserInfomation();
                List<UserInfomation> listresult = new List<UserInfomation>();
                List<User> listuser = this._context.PdbUser.ToList();
                for (int i = 0; i < listuser.Count - 1; i++)
                {
                    result.address = listuser[i].address;
                    result.age = listuser[i].age;
                    result.displayname = listuser[i].displayname;
                    result.email = listuser[i].email;
                    result.phone = listuser[i].phone;
                    listresult.Add(result);
                }
                return listresult;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// REST GET for User get one User with Username
        /// </summary>
        /// <param name="_us">Username of User</param>
        /// <returns></returns>
        public UserInfomation Get(string _us)
        {
            try
            {
                User us = this._context.PdbUser.Where(item => item.username == _us).FirstOrDefault();
                UserInfomation userInfomation = new UserInfomation();
                userInfomation.address = us.address;
                userInfomation.age = us.age;
                userInfomation.displayname = us.displayname;
                userInfomation.email = us.email;
                userInfomation.phone = us.phone;
                return userInfomation;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// REST POST for User
        /// </summary>
        /// <param name="user">UserResgiter for Resgiter</param>
        /// <returns>200 OK - 401 Failed - 500 Failed from server</returns>
        public int Post(UserResgiter user)
        {
            User item = new User();
            if (CheckInfoUser(user.username, user.password, user.displayname))
            {
                try
                {
                    item.IDuser = Guid.NewGuid();
                    item.createddate = DateTime.Now;
                    item.address = user.address;
                    item.age = user.age;
                    item.countlogin = 0;
                    item.failedlogin = 0;
                    item.lastlogin = DateTime.Now;
                    item.displayname = user.displayname;
                    item.email = user.email;
                    item.phone = user.phone;
                    item.password = user.password;
                    item.username = user.username;
                    item.status = true;
                    this._context.PdbUser.Add(item);
                    this._context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    this._context.SaveChanges();
                    return 200;
                }
                catch
                {
                    return 500;
                }
            }
            else
            {
                return 401;
            }
        }

        // Not yet !
        public bool Put(User user)
        {
            if (ExistsUser(user.username, user.password))
            {
                try
                {
                    this._context.PdbUser.Attach(user);
                    this._context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    this._context.SaveChanges();
                    return true;
                }
                catch (System.Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// REST DELETE for User
        /// </summary>
        /// <param name="us">UserLogin (username,password)</param>
        /// <param name="user">User who you want to delete</param>
        /// <returns> 401 not found user - 200 OK - 401 for UserLogin Forbid - 500 Failed from server
        /// </returns>
        public int Delete(UserLogin us, string user)
        {
            if (us.username != user)
            {
                return 404;
            }
            else
            {
                User usremove = FindUser(us.username, us.password);
                if (usremove != null)
                {
                    return 401;
                }
                else
                {
                    try
                    {
                        this._context.PdbUser.Remove(usremove);
                        this._context.Entry(usremove).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                        this._context.SaveChanges();
                        return 200;
                    }
                    catch
                    {
                        return 500;
                    }
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
        public bool CheckInfoUser(string _us, string _pa, string _displayname)
        {
            if (_us == null || _us == "")
            {
                return false;
            }
            else if (_pa == null || _pa == "")
            {
                return false;
            }
            else if (_displayname == null || _displayname == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// This Method for Finding User with username and password
        /// </summary>
        /// <param name="_us">Username of User</param>
        /// <param name="_pa">Password of User</param>
        /// <returns>return true for one user found and false for not found</returns>
        public User FindUser(string _us, string _pa)
        {
            return this._context.PdbUser.Where(item => item.username == _us && item.password == _pa).FirstOrDefault();
        }

        /// <summary>
        /// The method for Finding User with username and password but return boolean
        /// </summary>
        /// <param name="_us">Username of User</param>
        /// <param name="_pa">Password of User</param>
        /// <returns>return true for one user found and false for not found with boolean</returns>
        public bool ExistsUser(string _us, string _pa)
        {
            return (this._context.PdbUser.Where(item => item.username == _us && item.password == _pa).FirstOrDefault()) != null;
        }

        /// <summary>
        /// Login API (404,200,500)
        /// </summary>
        /// <param name="us">username of user</param>
        /// <param name="pass">password of user</param>
        /// <returns>return HTTP code</returns>
        public int Login(string us, string pass)
        {
            User user = FindUser(us, pass);
            if (user == null)
            {
                return 404;
            }
            else
            {
                user.countlogin++;
                user.lastlogin = DateTime.Now;
                bool vlreturn = Put(user);
                if (vlreturn)
                {
                    return 200;
                }
                else
                {
                    return 500;
                }
            }
        }

        /// <summary>
        /// Resgister API (200,500,401)
        /// </summary>
        /// <param name="user">Infomation about User</param>
        /// <returns></returns>
        public int Resgister(UserResgiter user)
        {
            return Post(user);
        }
    }
}