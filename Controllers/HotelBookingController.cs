using HotelBookingAPI.Data;
using HotelBookingAPI.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class HotelBookingController : ControllerBase
{
    private readonly ApiContext _context;

    public HotelBookingController(ApiContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Create(HotelBookingModel booking)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.Bookings.Add(booking);
        _context.SaveChanges();

        return CreatedAtAction(nameof(Get), new { id = booking.Id }, booking);
    }

    [HttpPut("{id}")]
    public IActionResult Edit(int id, HotelBookingModel booking)
    {
        var bookingInDb = _context.Bookings.Find(id)
;
        if (bookingInDb == null)
            return NotFound();

        bookingInDb.Name = booking.Name;
        _context.SaveChanges();

        return Ok(bookingInDb);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var result = _context.Bookings.Find(id)
;

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _context.Bookings.Find(id)
;

        if (result == null)
            return NotFound();

        _context.Bookings.Remove(result);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpGet]
    public IActionResult GetAll(int page = 1, int pageSize = 10)
    {
        var result = _context.Bookings
                             .Skip((page - 1) * pageSize)
                             .Take(pageSize)
                             .ToList();

        return Ok(result);
    }
}