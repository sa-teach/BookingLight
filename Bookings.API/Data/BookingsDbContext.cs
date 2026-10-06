using Bookings.API.Models;
using Microsoft.EntityFrameworkCore;


namespace Bookings.API.Data
{
    public class BookingsDbContext : DbContext
    {
        public BookingsDbContext(DbContextOptions<BookingsDbContext> options) : base(options)
        {
        }

        public DbSet<Booking> Bookings => Set<Booking>();

    }
}
