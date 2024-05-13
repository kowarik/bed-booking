using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        [SwaggerOperation(Summary = "Gets all bookings", Description = "Returns a list of all bookings.")]
        [SwaggerResponse(StatusCodes.Status200OK, "List of bookings", typeof(IEnumerable<BookingDTO>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authorization has been denied for this request")]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Access is forbidden. This endpoint is only accessible for 'admin' role.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Not found! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error! See json response for details.", typeof(ContentResult))]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _bookingService.GetAllAsync());
        }

        [HttpGet("apartment")]
        [Authorize]
        [SwaggerOperation(Summary = "Gets all apartment bookings", Description = "Returns a list of all apartments bookings by apartment id.")]
        [SwaggerResponse(StatusCodes.Status200OK, "List of apartment bookings", typeof(IEnumerable<BookingDTO>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authorization has been denied for this request")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Not found! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error! See json response for details.", typeof(ContentResult))]
        public async Task<IActionResult> GetByApartmentIdAsync([FromQuery] Guid apartmentId)
        {
            return Ok(await _bookingService.GetByApartmentIdAsync(apartmentId));
        }

        [HttpGet("user")]
        [Authorize]
        [SwaggerOperation(Summary = "Gets all user bookings", Description = "Returns a list of all user bookings.")]
        [SwaggerResponse(StatusCodes.Status200OK, "List of user bookings", typeof(IEnumerable<BookingDTO>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authorization has been denied for this request")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Not found! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error! See json response for details.", typeof(ContentResult))]
        public async Task<IActionResult> GetByUserAsync()
        {
            return Ok(await _bookingService.GetByUserAsync());
        }

        [HttpGet("{id}")]
        [Authorize]
        [SwaggerOperation(Summary = "Get booking by Id", Description = "Return an instance of booking.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Return booking by Id", typeof(BookingDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authorization has been denied for this request")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Not found! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error! See json response for details.", typeof(ContentResult))]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            return Ok(await _bookingService.GetByIdAsync(id));
        }

        [HttpPost]
        [Authorize]
        [SwaggerOperation(Summary = "Allows you to add an booking")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Booking was added successfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authorization has been denied for this request")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Not found! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error! See json response for details.", typeof(ContentResult))]
        public async Task<IActionResult> AddAsync(AddBookingDTO addBookingDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException("The request data was not validated.");
            }

            await _bookingService.AddAsync(addBookingDTO);
            return NoContent();
        }

        [HttpPut]
        [Authorize]
        [SwaggerOperation(Summary = "Allows you to update an booking")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Booking was updated successfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authorization has been denied for this request")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Not found! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error! See json response for details.", typeof(ContentResult))]
        public async Task<IActionResult> UpdateAsync(UpdateBookingDTO updateBookingDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException("The request data was not validated.");
            }
            
            await _bookingService.UpdateAsync(updateBookingDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        [SwaggerOperation(Summary = "Allows you to delete an booking")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Booking was deleted successfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authorization has been denied for this request")]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Access is forbidden. This endpoint is only accessible for 'admin' role.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Not found! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error! See json response for details.", typeof(ContentResult))]
        public async Task<IActionResult> DeleteByIdAsync(Guid id)
        {
            await _bookingService.DeleteByIdAsync(id);
            return NoContent();
        }
    }
}
