using Microsoft.AspNetCore.Mvc;

namespace BharatCrafted.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
