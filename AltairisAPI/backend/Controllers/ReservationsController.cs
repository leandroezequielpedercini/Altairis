using Microsoft.AspNetCore.Mvc;
using AltairisAPI.Data;
using AltairisAPI.Models;
using System.Linq;

namespace AltairisAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ReservationsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.Reservations.ToList());
    }

    [HttpPost]
    public IActionResult Create(Reservation reservation)
    {
        if (reservation.FromDate >= reservation.ToDate)
            return BadRequest("Fechas inválidas");

        var overlapping = _context.Reservations.Any(r =>
            r.RoomTypeId == reservation.RoomTypeId &&
            reservation.FromDate < r.ToDate &&
            reservation.ToDate > r.FromDate
        );

        if (overlapping)
            return BadRequest("No hay disponibilidad");

        _context.Reservations.Add(reservation);
        _context.SaveChanges();

        return Ok(reservation);
    }
}