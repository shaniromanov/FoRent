using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoRent.Models;

namespace FoRent.Controllers
{
    public class LogInController : Controller
    {
        private FoRentContext _context;

        public LogInController(FoRentContext context)
        {
            _context = context;
        }

        public IActionResult LogIn()
        {
            return View();
            
        }

        [HttpPost]
        public ActionResult LogIn([Bind("Username,Password")] User user)
        {
            
            //UFind = db.Workers.FirstOrDefault(f => f.WorkerTz ==worker.WorkerTz && f.Password == worker.Password);
            var UFind = _context.User.First();
            if (UFind != null)
            {
                Renter r=new Renter();
                if (UFind.GetType()== r.GetType())
                {

                    HttpCookie cookie = new HttpCookie("LoggedIn");
                    cookie.Value = "true";
                    Response.Cookies.Add(cookie);
                    return RedirectToAction("Index", "Manager");
                }
                if (UFind.Role == (int)Models.Enums.Role.Doctor)
                {
                    HttpCookie cookie = new HttpCookie("LoggedIn");
                    cookie.Value = "true";
                    Response.Cookies.Add(cookie);
                    return RedirectToAction("Index", "Doctor");
                }
            }
            ModelState.AddModelError("Password", "תעודת זהות או סיסמה שגויים");
            return View();
        }


    }
}
}