using System;
using System.Collections.Generic;
using System.Text;

namespace Auction.Model.API.Product
{
    public class ProductNew
    {
        public string catename { get; set; }
        
        public string name { get; set; }
        
        public string brand { get; set; }
    
        public string warrantyperiod { get; set; }
        
        public int auctiontime { get; set; }
        
        public string bigimage { get; set; }
        
        public string smallimage1 { get; set; }
        
        public string smallimage2 { get; set; }
        
        public string smallimage3 { get; set; }
        
        public string note { get; set; }
    }
}
