using Bookings.API.Models;
using Bookings.API.Services;
using Microsoft.AspNetCore.Mvc;


namespace Bookings.API.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("announcement/{announcementId:guid}")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetByAnnouncement(Guid announcementId)
        {
            var bookings = await _bookingService.GetBookingsByAnnouncementAsync(announcementId);
            return Ok(bookings);
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> Create([FromBody] Booking booking)
        {
            try
            {
                var created = await _bookingService.CreateBookingAsync(booking);

                return CreatedAtAction(
                    nameof(GetByAnnouncement),
                    new { announcementId = created.AnnouncementId },
                    created);
            }
            catch (NotImplementedException)
            {
                return StatusCode(501, "Реализуйте бизнес-логику бронирования и валидацию дат");
            }
            catch (Exception ex) when (ex is ArgumentException or InvalidOperationException)
            {
                // Некорректные данные или пересечение дат
                return BadRequest(ex.Message);
            }
        }
    }
}
    