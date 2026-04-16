using System.Text.Json.Serialization;

namespace AltairisAPI.Models;

public class RoomType
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Capacity { get; set; }

    public int HotelId { get; set; }

    [JsonIgnore]
    public Hotel Hotel { get; set; } = null!;
}