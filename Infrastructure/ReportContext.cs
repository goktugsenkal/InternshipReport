using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ReportContext : DbContext
{
    public ReportContext(DbContextOptions<ReportContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseIdentityColumns();
    }

    public DbSet<InternshipReport> InternshipReports { get; set; }
}