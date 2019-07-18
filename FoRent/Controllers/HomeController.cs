using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoRent.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Web;
using Microsoft.AspNetCore.Identity;



namespace FoRent.Controllers
{
    public class HomeController : Controller
    {
         private readonly FoRentContext _context;

            public HomeController(FoRentContext context)
            {
                _context = context;
            }
            public IActionResult Index()
        {
            ViewBag.Fail = false;
            return View();
        }
       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("Id,Username,password")] User user)
        {
            var result = from u in _context.User
                         where u.Username == user.Username && u.password == user.password
                         select u;

            if (result.ToList().Count > 0)
            {
                HttpContext.Session.SetString("user", user.Username);

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Fail = true;



            return View(user);
        }

    }
}
    
