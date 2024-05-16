using e_store.models;
using Microsoft.EntityFrameworkCore;
using System;
namespace e_store.Dbcontext
{
    public class AppDbcontext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Products> Products { get; set; }
       
        public AppDbcontext(DbContextOptions<AppDbcontext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Users>().HasKey(u => u.Id);
           
            // Configure other entities and relationships

            base.OnModelCreating(builder);
        }
    }
}
