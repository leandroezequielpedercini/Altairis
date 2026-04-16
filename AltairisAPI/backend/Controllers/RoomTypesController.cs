using Microsoft.AspNetCore.Mvc;
using AltairisAPI.Data;
using AltairisAPI.Models;
using AltairisAPI.DTOs;
using System.Linq;

namespace AltairisAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomTypesController : ControllerBase
{
    private readonly AppDbContext _context;

    public RoomTypesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.RoomTypes.ToList());
    }

    [HttpPost]
    public IActionResult Create([FromBody] RoomTypeDto dto)
    {
        var roomType = new RoomType
        {
            Name = dto.Name,
            Capacity = dto.Capacity,
            HotelId = dto.HotelId
        };

        _context.RoomTypes.Add(roomType);
        _context.SaveChanges();

        return Ok(roomType);
    }
}