using Api.DTOs;
using Core.Contracts;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportsController : ControllerBase
{
    private readonly IReportRepository _reportRepository;

    public ReportsController(IReportRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<InternshipReport>>> GetReports()
    {
        var books = await _reportRepository.GetAllInternshipReportsAsync();

        return Ok(books);
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<InternshipReport>> GetReportById(int id)
    {
        var report = await _reportRepository.GetOneInternshipReportByIdAsync(id);

        if (report is null)
        {
            return NotFound();
        }

        return Ok(report);
    }
    
    [HttpPost]
    public ActionResult<CreateReportDto> CreateReport([FromBody] CreateReportDto reportForCreate)
    {
        if (reportForCreate is null)
        {
            return BadRequest("Hatalı defter girişi.");
        }

        var report = new InternshipReport 
        {
            Name = reportForCreate.Name,
            Description = reportForCreate.Description,
            StartDate = reportForCreate.StartDate,
            EndDate = reportForCreate.EndDate,
            RegularShift = reportForCreate.RegularShift
        };
        
        _reportRepository.CreateOneInternshipReport(report);
        _reportRepository.SaveChangesToReports();
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteReportById(int id)
    {
        var report = await _reportRepository.GetOneInternshipReportByIdAsync(id);

        if (report is null)
        {
            return NotFound();
        }

        _reportRepository.DeleteOneInternshipReport(report);
        _reportRepository.SaveChangesToReports();

        return Ok();
    }
    /*
    [HttpPost]
    [Route("{id:int}/entry")]
    public async Task<ActionResult<ReportEntry>> CreateReportEntry(int id, [FromBody] string content)
    {
        var report = await _reportRepository.GetOneInternshipReportByIdAsync(id);
        
        if (report is null)
        {
            return NotFound();
        }

        var newEntry = new ReportEntry {
            Content = content,
            InternshipReportId = id
        };

        report.Entries.Add(newEntry);
        _reportRepository.SaveChangesToReports();
        return Ok();
    }
    */
}