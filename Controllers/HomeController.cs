using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Smart_Event_Web.Data;
using Smart_Event_Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smart_Event_Web.Controllers
{
    // Primary Constructor - Resolves IDE0290
    public class HomeController(MongoDbContext context) : Controller
    {
        private readonly MongoDbContext _context = context;

        public async Task<IActionResult> Index()
        {
            try
            {
                // Accessing the 'Events' collection
                var collection = _context.GetCollection<Event>("Events");

                // Filter for 'Available' events for the home gallery
                var events = await collection.Find(e => e.Status == "Available")
                                             .Limit(3)
                                             .ToListAsync();

                // Standard initialization to resolve CS1729 and CS1003
                if (events == null)
                {
                    return View(new List<Event>());
                }

                return View(events);
            }
            catch
            {
                // Guaranteed error-free fallback
                return View(new List<Event>());
            }
        }
    }
}