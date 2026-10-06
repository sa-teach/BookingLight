using Bookings.API.Data;
using Bookings.API.Models;
using Microsoft.EntityFrameworkCore;


namespace Bookings.API.Services
{
    public class BookingService : IBookingService
    {
        private readonly BookingsDbContext _context;

        public BookingService(BookingsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetBookingsByAnnouncementAsync(Guid announcementId)
        {
            return await _context.Bookings
                .Where(b => b.AnnouncementId == announcementId)
                .ToListAsync();
        }

        public async Task<Booking> CreateBookingAsync(Booking booking)
        {
            if (booking.CustomerName == "" || booking.CustomerName == null)
            {
                throw new ArgumentException("Customer name is empty");
            }

            if (booking.EndDate < booking.StartDate)
            {
                throw new ArgumentException("Start date is later then end date");
            }

            var bookings = _context.Bookings.ToList();
            bool dateCheck = false;

            foreach (var b in bookings)
            {
                if (b.AnnouncementId == booking.AnnouncementId && booking.StartDate < b.EndDate && booking.EndDate > b.StartDate)
                {
                    dateCheck = true;
                    break;
                }
            }

            if (dateCheck)
            {
                throw new ArgumentException("Booking dates overlap with existing booking");
            }

            booking.Id = Guid.NewGuid();

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return booking;
        }
    }
}
