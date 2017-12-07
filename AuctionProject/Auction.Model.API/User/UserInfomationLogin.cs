using System;

namespace Auction.Model.API.User
{
    public class UserInfomationLogin
    {
        public int? countlogin { get; set; }
        public int? failedlogin { get; set; }
        public DateTime? lastlogin { get; set; }
    }
}
