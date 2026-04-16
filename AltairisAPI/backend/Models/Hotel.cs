namespace AltairisAPI.Models;

public class Hotel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;

    // Relación (1 a muchos)
    public List<RoomType> RoomTypes { get; set; } = new();
}