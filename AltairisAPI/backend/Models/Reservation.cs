namespace AltairisAPI.Models;

public class Reservation
{
    public int Id { get; set; }

    public int RoomTypeId { get; set; }

    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }

    public string GuestName { get; set; } = string.Empty;
}