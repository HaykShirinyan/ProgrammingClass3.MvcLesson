using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Infrastructure;
using ProgramminClass3.MvcLesson.Models;


namespace ProgramminClass3.MvcLesson.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}