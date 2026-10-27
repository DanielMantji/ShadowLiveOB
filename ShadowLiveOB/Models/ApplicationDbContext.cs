using Microsoft.EntityFrameworkCore;
using ShadowLiveOB.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<ObLog> ObLogs { get; set; }
    public DbSet<Guard> Guards { get; set; }
    public DbSet<Site> Sites { get; set; }
}