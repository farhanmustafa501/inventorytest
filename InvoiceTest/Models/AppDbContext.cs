using Microsoft.EntityFrameworkCore;

namespace InvoiceTest.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Invoice> Invoice { get; set; }
}
