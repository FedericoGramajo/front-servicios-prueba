using System.Text.Json.Serialization;

namespace ClientLibrary.Models.Booking;

/// <summary>
/// DTO that matches the backend /api/Availability/add payload
/// </summary>
public class AddAvailabilityRequest
{
    [JsonPropertyName("professionalId")]
    public string ProfessionalId { get; set; } = string.Empty;

    [JsonPropertyName("date")]
    public DateTime Date { get; set; }

    [JsonPropertyName("startTime")]
    public string StartTime { get; set; } = string.Empty;

    [JsonPropertyName("endTime")]
    public string EndTime { get; set; } = string.Empty;
}
