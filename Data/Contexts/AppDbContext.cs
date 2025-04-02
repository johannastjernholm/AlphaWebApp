
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;


public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<ProjectEntity> Projects { get; set; }
}

