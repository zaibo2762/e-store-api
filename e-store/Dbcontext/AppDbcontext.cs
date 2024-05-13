using e_store.models;
using Microsoft.EntityFrameworkCore;
using System;
namespace e_store.Dbcontext
{
    public class AppDbcontext : DbContext
    {
        public DbSet<Products> Products { get; set; }

        public AppDbcontext(DbContextOptions<AppDbcontext> options)
            : base(options)
        {
        }
    }
}
