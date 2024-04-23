using BharatCrafted.Data;
using BharatCrafted.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BharatCrafted.Controllers
{
    [Authorize(Roles ="MasterAdmin,Admin,Seller")]   
    
    public class productController : Controller
    {
        ApplicationDbContext my_ApplicationContext;
        IWebHostEnvironment hostingenvironment;

        public productController(ApplicationDbContext my, IWebHostEnvironment hc)
        {
            my_ApplicationContext = my;
            hostingenvironment = hc;
        }


        public IActionResult Index()
        {
            return View(my_ApplicationContext.products.ToList());
        }

        public IActionResult addproduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult addproduct(productviewsmodel product1)
        {
            String filename = "";

            if (product1.photo != null)
            {
                String uploadfolder = Path.Combine(hostingenvironment.WebRootPath, "images");
                filename = Guid.NewGuid().ToString() + "_" + product1.photo.FileName;
                String filepath = Path.Combine(uploadfolder, filename);
                product1.photo.CopyTo(new FileStream(filepath, FileMode.Create));
            }
            product p = new product
            {
                Name = product1.Name,
                price = product1.price,
                image = filename,
                description = product1.description
            };

            my_ApplicationContext.products.Add(p);
            my_ApplicationContext.SaveChanges();
            ViewBag.success = "Record Added";

            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                var data = my_ApplicationContext.products.Where(e => e.Id == id).SingleOrDefault();
                if (data != null)
                {
                    string deleteFromFolder = Path.Combine(hostingenvironment.WebRootPath, "images");
                    string currentImage = Path.Combine(Directory.GetCurrentDirectory(), deleteFromFolder, data.Name);
                    if (currentImage != null)
                    {
                        if (System.IO.File.Exists(currentImage))
                        {
                            System.IO.File.Delete(currentImage);
                        }
                    }
                    my_ApplicationContext.products.Remove(data);
                    my_ApplicationContext.SaveChanges();
                    ViewBag.success = "record deleted";
                }
            }
            // return View();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var data = my_ApplicationContext.products.Where(e => e.Id == id).SingleOrDefault();
            return View(data);
        }

        public IActionResult Edit(int id)
        {
            var data = my_ApplicationContext.products.Where(e => e.Id == id).SingleOrDefault();
            var result = new product()
            {
                Name = data.Name,
                price = data.price,
                image = data.image,
                description = data.description,
            };
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(product model)
        {
            var data = new product()
            {
                Id = model.Id,
                Name = model.Name,
                price = model.price,
                image = model.image,
                description = model.description,
            };
            my_ApplicationContext.products.Update(data);
            my_ApplicationContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
