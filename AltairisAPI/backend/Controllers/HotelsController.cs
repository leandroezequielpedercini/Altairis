using Microsoft.AspNetCore.Mvc;
using AltairisAPI.Data;
using AltairisAPI.Models;
using System.Linq;

namespace AltairisAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HotelsController : ControllerBase
{
    private readonly AppDbContext _context;

    public HotelsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/hotels
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.Hotels.ToList());
    }

    // POST: api/hotels
    [HttpPost]
    public IActionResult Create([FromBody] Hotel hotel)
    {
        if (hotel == null)
            return BadRequest();

        _context.Hotels.Add(hotel);
        _context.SaveChanges();

        return Ok(hotel);
    }

    // DELETE: api/hotels/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var hotel = _context.Hotels.Find(id);

        if (hotel == null)
            return NotFound();

        _context.Hotels.Remove(hotel);
        _context.SaveChanges();

        return NoContent();
    }

    // GET: api/hotels/1/roomtypes
    [HttpGet("{id}/roomtypes")]
    public IActionResult GetRoomTypesByHotel(int id)
    {
        var roomTypes = _context.RoomTypes
            .Where(r => r.HotelId == id)
            .ToList();

        return Ok(roomTypes);
    }
}