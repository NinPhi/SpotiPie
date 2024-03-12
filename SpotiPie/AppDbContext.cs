using Microsoft.EntityFrameworkCore;
using SpotiPie.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Security.AccessControl;

namespace SpotiPie
{
    public class AppDbContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
