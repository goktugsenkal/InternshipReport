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
        modelBuilder.Entity<ReportEntry>()
            .HasOne(r => r.InternshipReport)
            .WithMany(e => e.Entries)
            .HasForeignKey(r => r.InternshipReportId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    public DbSet<InternshipReport> InternshipReports { get; set; }
}