using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using FoRent.Models;

namespace FoRent.Controllers

{
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly FoRentContext _context;

        public AccountController(FoRentContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login(string _username, string _password)
        {
            var result = from u in _context.User
                         where u.Username == _username && u.password == _password
                         select u;
            var role = result.First().GetType().ToString();
            if (_username != null && _password != null && result.ToList().Count > 0)
            {
                HttpContext.Session.SetString("username", _username);
                HttpContext.Session.SetString("Role", role);
                return RedirectToAction("Home", "Apartments");
            }
            else
            {
                ViewBag.error = "שם משתמש או סיסמה שגויים";
                TempData["Error"] = "שם משתמש או סיסמה שגויים, נסה שנית ";
                return RedirectToAction("Home","Apartments");
            }
        }

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Home", "Apartments");
        }
    }
}