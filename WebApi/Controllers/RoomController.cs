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
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            return await context.Rooms.ToListAsync();
        }

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
