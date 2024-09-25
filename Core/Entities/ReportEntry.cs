namespace Core.Entities;

public class ReportEntry : BaseEntity
{
    public string Content { get; set; } = string.Empty;
    public required InternshipReport InternshipReport { get; set; }
    public int InternshipReportId { get; set; }
}