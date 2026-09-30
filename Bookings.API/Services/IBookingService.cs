using Bookings.API.Models;

namespace Bookings.API.Services
{
    public interface IBookingService
    {
        /// Возвращает все бронирования для указанного объявления.
        Task<IEnumerable<Booking>> GetBookingsByAnnouncementAsync(Guid announcementId);

        /// Создаcт бронирование.
        /// При некорректных данных или пересечении дат должен выбрасывать
        /// ArgumentException / InvalidOperationException (контроллер вернут 400 BadRequest).
        Task<Booking> CreateBookingAsync(Booking booking);
    }
}
