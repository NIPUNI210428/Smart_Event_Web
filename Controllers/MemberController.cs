using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Smart_Event_Web.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Smart_Event_Web.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMongoCollection<Member> _memberCollection;

        public MemberController()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("SmartEvents");
            _memberCollection = database.GetCollection<Member>("Member");
        }

        // Bypasses the old dashboard
        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Event");
        }

        // Loads the Login Page
        [HttpGet]
        public IActionResult Login()
        {
            return View("~/Views/Account/Login.cshtml");
        }

        // FIX: Added this method to load the Registration Page
        [HttpGet]
        public IActionResult Register()
        {
            return View("~/Views/Account/Register.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {
            var member = _memberCollection.Find(m => m.Email == email && m.Password == password).FirstOrDefault();

            if (member != null)
            {
                HttpContext.Session.SetString("UserName", member.FirstName);
                HttpContext.Session.SetInt32("UserId", member.Member_id);

                var claims = new List<Claim> { new(ClaimTypes.Name, member.FirstName) };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Event");
            }

            ViewBag.Error = "Invalid login.";
            return View("~/Views/Account/Login.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Member newMember)
        {
            // MongoDB Auto-increment logic
            var lastMember = _memberCollection.Find(new BsonDocument()).SortByDescending(m => m.Member_id).FirstOrDefault();
            newMember.Member_id = (lastMember == null) ? 101 : lastMember.Member_id + 1;

            _memberCollection.InsertOne(newMember);

            TempData["SuccessMessage"] = "Account created successfully! Please log in.";
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}