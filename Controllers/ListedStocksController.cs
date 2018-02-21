using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using System.Linq;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class ListedStocksController : Controller
    {
        private readonly MongoDBContext  _context;

        public ListedStocksController()
        {
            _context = new MongoDBContext(); 
        }

        [HttpGet("{stockName}")]
        public IActionResult SearchStockName(string stockName)
        {
            var item = _context.ListedStocks.Find(m => m.NAMEOFCOMPANY.Contains(stockName)).ToList();
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }  

      
    }
}