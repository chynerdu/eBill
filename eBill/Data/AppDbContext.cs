using eBill.Models;
using Microsoft.EntityFrameworkCore;

namespace eBill.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) 
        : base(options)
    {
    }

    public DbSet<Bill> bill { get; set; }
}