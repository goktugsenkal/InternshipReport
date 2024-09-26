using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IReportRepository
    {
        Task<IReadOnlyList<InternshipReport>> GetReports();
        Task<InternshipReport?> GetReportById(int id);
        
        void AddReport(InternshipReport report);
        
        void UpdateReport(InternshipReport report);
        
        void DeleteReport(InternshipReport report);
    }
}