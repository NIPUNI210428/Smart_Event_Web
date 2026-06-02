using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Smart_Event_Web.Data;
using Smart_Event_Web.Models;
using MongoDB.Bson;

namespace Smart_Event_Web.Controllers
{
    public class EventController(MongoDbContext context) : Controller
    {
        private readonly MongoDbContext _context = context;

        public async Task<IActionResult> Index(string searchTerm, string category)
        {
            var eventCollection = _context.GetCollection<Event>("Events");
            var venueCollection = _context.GetCollection<Venue>("Venues");

            var builder = Builders<Event>.Filter;
            var filter = builder.Empty;

            // Existing Search Logic
            if (!string.IsNullOrEmpty(searchTerm))
            {
                filter &= builder.Regex("Event_Name", new BsonRegularExpression(searchTerm, "i"));
            }

            // Category Logic (Handles the value from the Registration dropdown)
            if (!string.IsNullOrEmpty(category))
            {
                filter &= builder.Regex("Event_Type", new BsonRegularExpression(category, "i"));
            }

            var events = await eventCollection.Find(filter).ToListAsync();
            var venues = await venueCollection.Find(_ => true).ToListAsync();

            ViewBag.Venues = venues;
            ViewBag.CurrentCategory = category;

            return View(events);
        }
    }
}