using BharatCrafted.Data;
using BharatCrafted.Models;
using Microsoft.AspNetCore.Mvc;

namespace BharatCrafted.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public LoginController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Login(ModelLogin model)
        {
            var admin = _dbContext.admins.FirstOrDefault(a => a.Email == model.Email && a.Password == model.Password);

            if (admin == null)
            {
                return NotFound("Invalid email or password");
            }

            // Authentication successful
            // You can generate a token or perform any other actions here
            return Ok("Login successful");
        }
    }

}
