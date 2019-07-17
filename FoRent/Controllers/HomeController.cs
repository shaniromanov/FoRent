using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoRent.Models;
using System.IO;
using System.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace FoRent.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    //    [HttpPost]
    //    public ActionResult Index(User user)
    //    {
    //        try
    //        {

    //            if (ModelState.IsValid)
    //            {
    //                return View();
    //            }
    //            var item = UserService.GetLoginInfo(user);
    //            if (item == "Success")
    //            {
    //                // Roles.AddUserToRole(user.UserName, user.Role);

    //                //var userStore = new UserStore<UserService>(context);
    //                //var userManager = new UserManager<UserService>(userStore);
    //                //userManager.AddToRole(user.Id, "User");

    //                UserService.UserRole = UserService.GetUserRole(user);
    //                return View("About");
    //            }
    //            else if (item == "User Does not Exists")
    //            {
    //                ViewBag.NotValidUser = "משתמש לא קיים";
    //            }
    //            else
    //            {
    //                ViewBag.Failedcount = item;
    //            }

    //            return View("Index");

    //        }
    //        catch (Exception e)
    //        {

    //            return null;
    //        }
    //    }

    //    public ActionResult UserLandingView()
    //    {
    //        return View("About");
    //    }

    //    public ActionResult About()
    //    {
    //        ViewBag.Message = "Your application description page.";

    //        return View();
    //    }

    //    public ActionResult Contact()
    //    {
    //        ViewBag.Message = "Your contact page.";

    //        return View();
    //    }

    //    public ActionResult CreateMasavRep()
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            var fileName = DateTime.Now.ToString("yyMMdd") + ".txt";
    //            string filePath = @"C:\Users\racheli\Desktop\" + fileName;
    //            if (FileService.CreateMasavReport(filePath))
    //            {
    //                byte[] fileData = System.IO.File.ReadAllBytes(filePath);
    //                string contentType = MimeMapping.GetMimeMapping(filePath);

    //                var cd = new System.Net.Mime.ContentDisposition
    //                {
    //                    FileName = fileName,
    //                    Inline = false,
    //                };

    //                Response.AppendHeader("Content-Disposition", cd.ToString());

    //                return File(fileData, contentType);
    //            }
    //        }
    //        return null;
    //    }

    //    public ActionResult TestModel()
    //    {
    //        ItemProgram.Cal();

    //        return null;
    //    }

    }
}
    
