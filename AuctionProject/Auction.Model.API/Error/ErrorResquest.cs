using System;
using System.Collections.Generic;
using System.Text;

namespace Auction.Model.API.Error
{
    public class ErrorResquest
    {
        public ErrorCode Error401()
        {
            return new ErrorCode(401, "Not Found");
        }

        public ErrorCode Error404()
        {
            return new ErrorCode(401, "Unauthorized");
        }

        public ErrorCode Error403()
        {
            return new ErrorCode(401, "Forbidden");
        }
    }
}
