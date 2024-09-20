namespace Core.Entities;

public class InternshipReport : BaseEntity
{
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    public RegularShifts RegularShift { get; set; }
    public List<DateTime> LeaveDays { get; set; } = new List<DateTime>();

    public List<ReportEntry> Entries { get; set; } =  new List<ReportEntry>();
}

public enum RegularShifts
{
    WeekDays,
    WeekDaysAndSaturday,
    Everyday
}