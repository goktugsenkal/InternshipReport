namespace Core.Entities;

public class ReportEntry : BaseEntity
{
    public string Content { get; set; } = string.Empty;
    public int InternshipReportId { get; set; }
}