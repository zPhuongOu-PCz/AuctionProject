using Auction.EF.Database;
using Auction.Model.API.User;
using Auction.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Auction.Functionality.Function
{
    public class FunctionUserInfomation
    {
        private readonly AuctionDBContext _context;

        public FunctionUserInfomation(AuctionDBContext context)
        {
            this._context = context;
        }

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

        public bool Post()
        {
            return true;
        }

        public bool Put()
        {
            return true;
        }
    }

    public interface IHttpActionResult
    {
        Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken);
    }

    public class TextResult : IHttpActionResult
    {
        string _value;
        HttpRequestMessage _request;

        public TextResult(string value, HttpRequestMessage request)
        {
            _value = value;
            _request = request;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_value),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }
}
