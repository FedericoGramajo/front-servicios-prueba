using System;

namespace ClientLibrary.Models.Booking;

public class ProfessionalAvailability
{
    public Guid Id { get; set; }
    public string ProfessionalId { get; set; } = string.Empty;
    
    public DateTime Date { get; set; }
    public DayOfWeek DayOfWeek { get; set; } 
    public TimeSpan StartTime { get; set; } 
    public TimeSpan EndTime { get; set; } 
}
