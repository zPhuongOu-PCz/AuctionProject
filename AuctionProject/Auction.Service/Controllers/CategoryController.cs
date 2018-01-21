using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auction.EF.Database;
using Auction.Functionality.Module;
using Auction.Model.API.Category;
using Auction.Model.API.Error;
using Auction.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/Category")]
    [EnableCors("AllowSpecificOrigin")]
    public class CategoryController : Controller
    {
        private readonly AuctionDBContext _context;
        private readonly ModuleCategory catefunction;
        private readonly ErrorResquest errorResquest;

        public CategoryController(AuctionDBContext context)
        {
            this._context = context;
            catefunction = new ModuleCategory(this._context);
            errorResquest = new ErrorResquest();
        }

        // GET: api/Category
        [HttpGet]
        [EnableCors("AllowSpecificOrigin")]
        public IActionResult Get()
        {
            var list = catefunction.Get().ToArray();
            return Ok(list);
        }

        [EnableCors("AllowSpecificOrigin")]
        [HttpPut]
        public IActionResult Put([FromBody] CategoryEdit item)
        {
            if (item == null)
            {
                return NotFound();
            }
            else if (item.oldname == item.newname)
            {
                return NotFound();
            }
            else
            {
                if (catefunction.Put(item))
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
        }

        // POST: api/Category
        [EnableCors("AllowSpecificOrigin")]
        [HttpPost]
        public IActionResult Post([FromBody] CategoryNew item)
        {
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    if (catefunction.Post(item))
                    {
                        return Ok();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return NotFound();
                }
            }
        }

        // DELETE: api/ApiWithActions/5
        [EnableCors("AllowSpecificOrigin")]
        [HttpDelete]
        public IActionResult Delete([FromBody] CategoryNew item)
        {
            if (item.name == "" || item.name == null || item.name == string.Empty)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    if (catefunction.Delete(item))
                    {
                        return Ok();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch
                {
                    return NotFound();
                }
            }
        }
    }
}