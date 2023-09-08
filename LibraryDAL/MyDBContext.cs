using LibraryDAL.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace LibraryDAL
{

    public class MyDBContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IConfiguration _myAppSettingsConfig;
        public MyDBContext(IConfiguration configFromAppSettings)
        {
            _myAppSettingsConfig = configFromAppSettings;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Use the connection string from appsettings.json
                optionsBuilder.UseSqlServer(_myAppSettingsConfig.GetConnectionString("DefaultConnection"));
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<SystemOperator> SystemOperators { get; set; }
        public DbSet<StudentBookRequest> StudentBookRequests { get; set; }
    }
}