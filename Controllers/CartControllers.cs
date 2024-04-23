using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BharatCrafted.Controllers
{
    public class CartControllers : Controller
    {
        // GET: CartControllers
        public ActionResult Index()
        {
            return View();
        }

        // GET: CartControllers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CartControllers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartControllers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartControllers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartControllers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartControllers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartControllers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
