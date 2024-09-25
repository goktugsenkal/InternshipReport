using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Contracts;

namespace Infrastructure.Data
{
    public class ReportRepository : GenericRepository<InternshipReport>, IReportRepository
    {
        public ReportRepository(ReportDbContext context) : base(context)
        {
        }

        public void CreateOneInternshipReport(InternshipReport report)
        {
            Create(report);
        }

        public async Task<IReadOnlyList<InternshipReport>> GetAllInternshipReportsAsync()
        {
            return await FindAll();

        }

        public async Task<InternshipReport?> GetOneInternshipReportByIdAsync(int id)
        {
            var matchingReports = await FindByCondition(r => r.Id == id);

            // Desired case is 1 report but return first if there are multiple anyway.
            //
            // null return is to be dealt with in upper layer/s.

            return matchingReports.FirstOrDefault();
        }

        public void UpdateOneInternshipReport(InternshipReport report)
        {
            Update(report);
        }

        public void DeleteOneInternshipReport(InternshipReport report)
        {
            Delete(report);
        }

        public void SaveChangesToReports()
        {
            Save();
        }
    }
}