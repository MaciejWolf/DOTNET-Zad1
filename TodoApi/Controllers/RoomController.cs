using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : Controller
    {
        private readonly RoomContext context;

        public RoomController(RoomContext context)
        {
            this.context = context;

            if(context.Rooms.Count() == 0)
            {
                context.Rooms.Add(new Room { Name = "A", Floor = 3 });
                context.Rooms.Add(new Room { Name = "B", Floor = 35 });
                context.Rooms.Add(new Room { Name = "C", Floor = 23 });
                context.SaveChanges();
            }
        }

        // GET: /api/Todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            return await context.Rooms.ToListAsync();
        }

        // GET: /api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(long id)
        {
            var room = await context.Rooms.FindAsync(id);

            if(room == null)
            {
                return NotFound();
            }

            return room;
        }

        // POST: api/Todo
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            context.Rooms.Add(room);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetRoom", new { id = room.Id }, room);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(long id, Room room)
        {
            if(id != room.Id)
            {
                return BadRequest();
            }

            context.Entry(room).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Room>> DeleteRoom(long id)
        {
            var room = await context.Rooms.FindAsync(id);

            if(room == null)
            {
                return NotFound();
            }

            context.Rooms.Remove(room);
            await context.SaveChangesAsync();

            return room;
        }
    }
}
