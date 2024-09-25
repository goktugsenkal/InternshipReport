using Core.Entities;

namespace Core.Contracts
{
    public interface IReportRepository : IGenericRepository<InternshipReport>
    {
        Task<IReadOnlyList<InternshipReport>> GetAllInternshipReportsAsync();
        Task<InternshipReport?> GetOneInternshipReportByIdAsync(int id);
        void CreateOneInternshipReport(InternshipReport report);
        void UpdateOneInternshipReport(InternshipReport report);
        void DeleteOneInternshipReport(InternshipReport report);
        void SaveChangesToReports();
    }
}