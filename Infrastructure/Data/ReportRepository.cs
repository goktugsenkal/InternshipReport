using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ReportRepository(ReportDbContext context) : IReportRepository
    {
        public async Task<IReadOnlyList<InternshipReport>> GetReports()
        {
           return await context.InternshipReports.ToListAsync();
        }   

        public async Task<InternshipReport?> GetReportById(int id)
        {
            return await context.InternshipReports
                .Include(r => r.Entries)
                .Select(r => new InternshipReport
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    StartDate = r.StartDate,
                    EndDate = r.EndDate,
                    Entries = r.Entries.Select(e => new ReportEntry
                    {
                        Id = e.Id,
                        Content = e.Content,
                        InternshipReportId = e.InternshipReportId,
                    }).ToList(),
                    LeaveDays = r.LeaveDays,
                    RegularShift = r.RegularShift,
                })
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public void AddReport(InternshipReport report)
        {
            context.InternshipReports.Add(report);
            context.SaveChanges();
        }

        public void UpdateReport(InternshipReport reportForCreate)
        {
            context.InternshipReports.Update(reportForCreate);
            context.SaveChanges();
        }

        public void DeleteReport(InternshipReport report)
        {
            context.InternshipReports.Remove(report);
            context.SaveChanges();
        }
    }
}