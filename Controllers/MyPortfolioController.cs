using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using System.Linq;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class MyPortfolioController : Controller
    {
        private readonly MongoDBContext  _context;

        public MyPortfolioController()
        {
            _context = new MongoDBContext(); 
        }

        [HttpGet]
        public IEnumerable<PortfolioStockDetail> GetAll()
        {
            return _context.MyPortfolio.Find(m => true).ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var item = _context.MyPortfolio.Find(m => m.UserId == id).ToList();
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }  

        [HttpPost]
        public IActionResult Create([FromBody] PortfolioStockDetail item)
        {
            if (item == null)
            {
                return BadRequest();
            }


            _context.MyPortfolio.InsertOneAsync(item);
            return new NoContentResult();
        } 

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] PortfolioStockDetail item)
        {
            if (item == null || item.UserId != id)
            {
                return BadRequest();
            }

            var todo = _context.MyPortfolio.ReplaceOne(m => m.UserId == id, item);
            if (todo == null)
            {
                return NotFound();
            }

            return new NoContentResult();
        }   

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.MyPortfolio.DeleteOne(t => t.UserId == id);
            if (todo == null)
            {
                return NotFound();
            }

            return new NoContentResult();
        }
    }
}