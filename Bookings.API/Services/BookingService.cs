using Bookings.API.Models;

namespace Bookings.API.Services
{
    public class BookingService : IBookingService
    {
        public Task<IEnumerable<Booking>> GetBookingsByAnnouncementAsync(Guid announcementId)
        {
            // TODO : Заменить заглушку на чтение из EF Core InMemory (фильтр по AnnouncementId).
            return Task.FromResult<IEnumerable<Booking>>(new List<Booking>());
        }

        public Task<Booking> CreateBookingAsync(Booking booking)
        {
            // TODO : Реализовать сохранение в EF Core InMemory и
            // бизнес-логику валидации: пересечение дат (StartDate и EndDate) для одного и
            // того же AnnouncementId не допускается!
            throw new NotImplementedException();
        }
    }
}
