using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Api.DTOs;

public class CreateReportDto
{
    [Required]
    public required string Name { get; set; }
    [Required]
    public string Description { get; set; } = string.Empty;
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
    [Required]
    public RegularShifts RegularShift { get; set; }


}