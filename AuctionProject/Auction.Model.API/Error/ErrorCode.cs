using System;
using System.Collections.Generic;
using System.Text;

namespace Auction.Model.API.Error
{
    public class ErrorCode
    {
        public int code { get; set; }
        public string message { get; set; }

        public ErrorCode(int _co, string _me)
        {
            this.code = _co;
            this.message = _me;
        }
    }
}
