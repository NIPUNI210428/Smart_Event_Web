using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Smart_Event_Web.Data;
using Smart_Event_Web.Models;

namespace Smart_Event_Web.Controllers;

public class BookingController(MongoDbContext context) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Create(int id)
    {
        var eventCollection = context.GetCollection<Event>("Events");
        var eventItem = await eventCollection.Find(e => e.Event_id == id).FirstOrDefaultAsync();

        if (eventItem == null) return NotFound();

        ViewBag.EventId = id;
        ViewBag.Price = eventItem.Price; 
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Booking booking)
    {
        if (ModelState.IsValid)
        {
            var collection = context.GetCollection<Booking>("Bookings");

            
            booking.Id = null;
            booking.Booking_id = new Random().Next(9000, 9999);
            booking.Booking_date = DateTime.Now.ToString("yyyy-MM-dd"); 

            await collection.InsertOneAsync(booking);
            TempData["Success"] = "Booking confirmed! Viewing history.";
            return RedirectToAction("MyBookings");
        }
        return View(booking);
    }

    [HttpGet]
    public async Task<IActionResult> MyBookings()
    {
        var collection = context.GetCollection<Booking>("Bookings");
        var myBookings = await collection.Find(_ => true).ToListAsync(); 
        return View(myBookings);
    }
} 
 