using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FoRent.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoRent.Controllers
{
    public class PicturesController : Controller
    {
        private FoRentContext _context;
        public PicturesController(FoRentContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
           
            return View();

        }
        [HttpPost]
        public async Task <IActionResult> Index(Picture pictures, List<IFormFile> Image)
        {
            foreach (var item in Image)
            {
                if (item.Length>0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        pictures.Image = stream.ToArray();
                    }
                }

            }
            _context.Pictures.Add(pictures);
            _context.SaveChanges();
      
            return View();

        }
    }
}


       
   
