using BharatCrafted.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BharatCrafted.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
        }
        public DbSet<Seller> sellers {  get; set; } 

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<BharatCrafted.Models.Customer>? Customer { get; set; }

        public DbSet<product> products { get; set; }

        public DbSet<Admin> admins { get; set; }

        public DbSet<ModelLogin> modelLogins { get; set; } 
        public DbSet<Prod> prods { get; set; }  

        public DbSet<Category> categories { get; set; }
    }
}
