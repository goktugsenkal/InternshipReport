using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ReportDbContext : DbContext
{
    public ReportDbContext(DbContextOptions<ReportDbContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseIdentityColumns();
    }

    public DbSet<InternshipReport> InternshipReports { get; set; }
}