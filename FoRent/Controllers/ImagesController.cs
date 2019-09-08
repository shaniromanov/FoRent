using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoRent.Models;
using System.IO;                    //*Directory
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Reflection.Emit;

namespace FoRent.Controllers
{
    public class ImagesController : Controller
    {
        private readonly FoRentContext _context;
        private readonly IHostingEnvironment _appEnvironment;

        public ImagesController(FoRentContext context, IHostingEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        // GET: Images
        public async Task<IActionResult> Index()
        {
            return View(await _context.Image.ToListAsync());
        }
        [HttpGet] //1.Load

        public IActionResult Upload_Image()

        {

            //--< Upload Form >--

            return View();

            //--</ Upload Form >--

        }





        [HttpPost] //Postback
      
        public async Task<IActionResult> Upload_Image(IFormFile file1, IFormFile file2, IFormFile file3, IFormFile file4)

        {

            //--------< Upload_ImageFile() >--------

            //< check >

            if (file1 == null || file1.Length == 0) return Content("לא נבחר קובץ");
            if (file2 == null || file2.Length == 0) return Content("לא נבחר קובץ");
            if (file3 == null || file3.Length == 0) return Content("לא נבחר קובץ");
            if (file4 == null || file4.Length == 0) return Content("לא נבחר קובץ");

            //</ check >



            //< get Path >

            string path_Root = _appEnvironment.WebRootPath;

            string path_to_Images1 = path_Root + "\\User_Files\\Images\\" + file1.FileName;
            string path_to_Images2 = path_Root + "\\User_Files\\Images\\" + file2.FileName;
            string path_to_Images3 = path_Root + "\\User_Files\\Images\\" + file3.FileName;
            string path_to_Images4 = path_Root + "\\User_Files\\Images\\" + file4.FileName;
            //</ get Path >



            //< Copy File to Target >

            using (var stream = new FileStream(path_to_Images1, FileMode.Create))

            {

                await file1.CopyToAsync(stream);

            }
            using (var stream = new FileStream(path_to_Images2, FileMode.Create))

            {

                await file2.CopyToAsync(stream);

            }
            using (var stream = new FileStream(path_to_Images3, FileMode.Create))

            {

                await file3.CopyToAsync(stream);

            }
            using (var stream = new FileStream(path_to_Images4, FileMode.Create))

            {

                await file4.CopyToAsync(stream);

            }

            //</ Copy File to Target >



            //< output >
            Image image=new Image();
            image.BedRoom = "/User_Files/Images/" + Path.GetFileName(file1.FileName);
            image.DiningRoom = "/User_Files/Images/" + Path.GetFileName(file2.FileName);
            image.Ketchen = "/User_Files/Images/" + Path.GetFileName(file3.FileName);
            image.LivingRoom = "/User_Files/Images/" + Path.GetFileName(file4.FileName);





            _context.Add(image);
            await _context.SaveChangesAsync();
           

            return RedirectToAction("Create","Apartments");

            //</ output >

            //--------</ Upload_ImageFile() >--------

        }
        // GET: Images/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Image
                .SingleOrDefaultAsync(m => m.Id == id);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

        // GET: Images/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Images/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LivingRoom,DiningRoom,BedRoom,Ketchen")] Image image)
        {
            if (ModelState.IsValid)
            {
                _context.Add(image);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(image);
        }

        // GET: Images/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Image.SingleOrDefaultAsync(m => m.Id == id);
            if (image == null)
            {
                return NotFound();
            }
            return View(image);
        }

        // POST: Images/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LivingRoom,DiningRoom,BedRoom,Ketchen")] Image image)
        {
            if (id != image.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(image);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageExists(image.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                var apartmentId = _context.Apartment.Include(l => l.Image).Where(a => a.Image.Id == id).Select(i => i.Id).FirstOrDefault();

                return RedirectToAction("EditControl", "Apartments", new { id = apartmentId });
            }
            return View(image);
        }

        // GET: Images/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Image
                .SingleOrDefaultAsync(m => m.Id == id);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

        // POST: Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var image = await _context.Image.SingleOrDefaultAsync(m => m.Id == id);
            _context.Image.Remove(image);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImageExists(int id)
        {
            return _context.Image.Any(e => e.Id == id);
        }
    }
}
