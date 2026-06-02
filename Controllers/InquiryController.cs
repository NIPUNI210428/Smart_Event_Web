using Microsoft.AspNetCore.Mvc;
using Smart_Event_Web.Data;
using Smart_Event_Web.Models;

namespace Smart_Event_Web.Controllers;


public class InquiryController(MongoDbContext context) : Controller
{
    
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Inquiry inquiry)
    {
        if (ModelState.IsValid)
        {
            var collection = context.GetCollection<Inquiry>("Inquiries");
            await collection.InsertOneAsync(inquiry);

            TempData["Success"] = "Your inquiry has been sent to the Cultural Council!";
            return RedirectToAction("Index", "Event");
        }
        return View(inquiry);
    }
} 
