using APIAdoPet.Models;
using Microsoft.EntityFrameworkCore;

namespace APIAdoPet.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<User> Users { get; set; }

}
