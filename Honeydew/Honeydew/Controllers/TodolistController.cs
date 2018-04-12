using Honeydew.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honeydew.Controllers
{
    [Route("api/Todolist")]
    public class TodoListController : Controller
    {
        private readonly HoneydewContext _context;

        public TodoListController(HoneydewContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Todolist> GetAll()
        {
            return _context.Todolists.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetOne (int id)
        {
            if (_context.Todolists.Any(x => x.Id == id)) // Todo List exists
            {
                if (_context.Todos.Any (x => x.Belongs.Id == id)) // Todos exit in that list
                {
                    IEnumerable<Todo> tasks = _context.Todos.Where(x => x.Belongs.Id == id); // todos from that list
                    return Ok(new object[] { _context.Todolists.First(x => x.Id == id), tasks }); //package and return
                }
                return BadRequest();
            }
            else return NotFound();
        }

        [HttpPost]
        public IActionResult Add ([FromBody] Todolist addition)
        {
            if (addition == null)
            {
                return NotFound();
            }
            else
            {
                _context.Todolists.Add(addition);
            }
            _context.SaveChanges();
            return GetOne(addition.Id);
        }

        [HttpDelete("{id}")]
        public IActionResult Eliminate (int id)
        {
            Todolist ob;
            if (_context.Todolists.Any(x => x.Id == id))
            {
                ob = _context.Todolists.FirstOrDefault(x => x.Id == id);
            }
            else
            {
                return BadRequest();
            }
            _context.Todolists.Remove(ob);

            _context.SaveChanges();
            return new ObjectResult(ob);
        }
    }
}
