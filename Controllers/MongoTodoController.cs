using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using System.Linq;
using MongoDB.Driver;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class MongoTodoController : Controller
    {
        private readonly MongoDBContext  _context;

        public MongoTodoController()
        {
            _context = new MongoDBContext(); 
        }

        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return _context.TodoItems.Find(m => true).ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var item = _context.TodoItems.Find(m => m.UserId == id).FirstOrDefault();
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }  

        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }


            _context.TodoItems.InsertOneAsync(item);
            return new NoContentResult();
        } 

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] TodoItem item)
        {
            if (item == null || item.UserId != id)
            {
                return BadRequest();
            }

            var todo = _context.TodoItems.ReplaceOne(m => m.UserId == id, item);
            if (todo == null)
            {
                return NotFound();
            }

            return new NoContentResult();
        }   

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.TodoItems.DeleteOne(t => t.UserId == id);
            if (todo == null)
            {
                return NotFound();
            }

            return new NoContentResult();
        }
    }
}