using Microsoft.EntityFrameworkCore;

namespace SpotiPie.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }


}
