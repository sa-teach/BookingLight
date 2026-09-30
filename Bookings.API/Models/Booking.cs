namespace Bookings.API.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        public Guid AnnouncementId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
