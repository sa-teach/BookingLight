using Announcements.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Announcements.API.Data
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options)
        {
        }

        public DbSet<Announcement> Announcements => Set<Announcement>();
    }
}
