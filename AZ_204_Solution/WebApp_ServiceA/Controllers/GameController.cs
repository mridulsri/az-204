using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Infrastructure;
using core.Infrastructure.Entites;
using Microsoft.AspNetCore.Mvc;
using WebApp_ServiceA.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp_ServiceA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private ApplicationDBContext _context;

        public GameController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/<DataController>
        [HttpGet]
        public IActionResult Get()
        {
            // return new string[] { "value1", "value2" };
            var games = _context.BoardGames.ToList();
            return Ok(games);
        }

        // GET api/<DataController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var game = _context.BoardGames.Find(id);
            if (game == null)
                return NotFound("Invalid id..!");
            return Ok(game);
        }

        // POST api/<DataController>
        [HttpPost]
        public IActionResult Post([FromBody] BoardGame game)
        {
            //Determine the next ID
            var newID = _context.BoardGames.Select(x => x.ID).Max() + 1;
            game.ID = newID;

            _context.BoardGames.Add(game);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = game.ID }, game);
        }

        // PUT api/<DataController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BoardGame game)
        {
            var game_db = _context.BoardGames.Find(id);
            if (game_db == null)
                return NotFound("Invalid id..!");

            _context.BoardGames.Update(game);
            _context.SaveChanges();

            return Ok(game);
        }

        // DELETE api/<DataController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var game = _context.BoardGames.Find(id);
            if (game == null)
                return NotFound("Invalid id..!");
            
            _context.BoardGames.Remove(game);
            _context.SaveChanges();

            return Ok("Data deleted");
        }
    }
}
