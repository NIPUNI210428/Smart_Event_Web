using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Smart_Event_Web.Data;
using Smart_Event_Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Smart_Event_Web.Controllers;

public class AccountController(MongoDbContext context) : Controller
{
    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(Member member)
    {
        if (ModelState.IsValid)
        {
            var collection = context.GetCollection<Member>("Member");
            await collection.InsertOneAsync(member);
            TempData["Success"] = "Account created successfully!";
            return RedirectToAction("Index", "Event");
        }
        return View(member);
    }

    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(string email, string password)
    {
        var collection = context.GetCollection<Member>("Member");
        var user = await collection.Find(m => m.Email == email && m.Password == password).FirstOrDefaultAsync();

        if (user != null)
        {
            var claims = new List<Claim> { new(ClaimTypes.Name, user.FirstName), new(ClaimTypes.Email, user.Email) };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

            // Redirect directly to the Event page
            return RedirectToAction("Index", "Event");
        }
        ModelState.AddModelError("", "Invalid email or password.");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }
} 