using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auction.EF.Database;
using Auction.Functionality.Module;
using Auction.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private readonly AuctionDBContext _context;
        private readonly ModuleProduct modulep;

        public ProductController(AuctionDBContext context)
        {
            this._context = context;
            modulep = new ModuleProduct(this._context);
        }

        // GET: api/Product
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(modulep.Get());
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpGet("{_cate}")]
        public IActionResult Get(int _cate)
        {
            try
            {
                return Ok(modulep.Get(modulep.GetNamewithId(_cate)));
            }
            catch 
            {
                return NotFound();
            }
        }

        // GET: api/Product/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Product
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
