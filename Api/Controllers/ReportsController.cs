using Core.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

public class ReportsController : ControllerBase
{
    private readonly ReportDbContext _context;
    
    public ReportsController(ReportDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    [Route("/api/reports")]
    public ActionResult<List<InternshipReport>> GetReports()
    {
        return _context.InternshipReports.Include(x=> x.Entries).ToList();
    }
    
    [HttpGet]
    [Route("/api/reports/{id:int}")]
    public ActionResult<InternshipReport> GetReportById(int id)
    {
        var report = 
            _context.InternshipReports.Include(x => x.Entries).Where(r => r.Id == id);
        return Ok(report);
    }
    
    [HttpPost]
    [Route("/api/reports")]
    public ActionResult<List<InternshipReport>> UploadReport([FromBody] InternshipReport? report)
    {
        if (report is null) return BadRequest();
        
        _context.InternshipReports.Add(report);
        _context.SaveChanges();
        return Ok();
    }
}