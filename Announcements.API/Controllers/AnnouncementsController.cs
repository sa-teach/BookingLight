using Announcements.API.Data;
using Announcements.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Announcements.API.Controllers
{
    [ApiController]
    [Route("api/announcements")]
    public class AnnouncementsController : ControllerBase
    {
        private readonly BookingDbContext _db;

        public AnnouncementsController(BookingDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Announcement>>> GetAll()
        {
            var announcements = await _db.Announcements.AsNoTracking().ToListAsync();
            return Ok(announcements);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Announcement>> GetById(Guid id)
        {
            var announcement = await _db.Announcements
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);

            if (announcement is null)
            {
                return NotFound();
            }

            return Ok(announcement);
        }
    }
}
