using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        [HttpGet]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Gets all apartments", Description = "Returns a list of all apartments.")]
        [SwaggerResponse(StatusCodes.Status200OK, "List of apartments", typeof(IEnumerable<ApartmentDTO>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Not found! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error! See json response for details.", typeof(ContentResult))]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _apartmentService.GetAllAsync());
        }

        [HttpGet("user")]
        [Authorize]
        [SwaggerOperation(Summary = "Gets all user apartments", Description = "Returns a list of all apartments.")]
        [SwaggerResponse(StatusCodes.Status200OK, "List of user apartments", typeof(IEnumerable<ApartmentDTO>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authorization has been denied for this request")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Not found! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error! See json response for details.", typeof(ContentResult))]
        public async Task<IActionResult> GetByUserAsync()
        {
            return Ok(await _apartmentService.GetByUserAsync());
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Get apartment by Id", Description = "Return an instance of apartment.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Return Apartment by Id", typeof(ApartmentDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Not found! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error! See json response for details.", typeof(ContentResult))]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            return Ok(await _apartmentService.GetByIdAsync(id));
        }

        [HttpPost]
        [Authorize]
        [SwaggerOperation(Summary = "Allows you to add an apartment")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Apartment was added successfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authorization has been denied for this request")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Not found! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error! See json response for details.", typeof(ContentResult))]
        public async Task<IActionResult> AddAsync(AddApartmentDTO addApartmentDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException("The request data was not validated.");
            }

            await _apartmentService.AddAsync(addApartmentDTO);
            return NoContent();
        }

        [HttpPut]
        [Authorize]
        [SwaggerOperation(Summary = "Allows you to update an apartment")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Apartment was updated successfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authorization has been denied for this request")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Not found! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error! See json response for details.", typeof(ContentResult))]
        public async Task<IActionResult> UpdateAsync(UpdateApartmentDTO updateApartmentDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException("The request data was not validated.");
            }

            await _apartmentService.UpdateAsync(updateApartmentDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        [SwaggerOperation(Summary = "Allows you to delete an apartment")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Apartment was deleted successfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authorization has been denied for this request")]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Access is forbidden. This endpoint is only accessible for 'admin' role.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Not found! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error! See json response for details.", typeof(ContentResult))]
        public async Task<IActionResult> DeleteByIdAsync(Guid id)
        {
            await _apartmentService.DeleteByIdAsync(id);
            return NoContent();
        }
    }
}
