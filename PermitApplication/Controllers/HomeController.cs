using Microsoft.AspNetCore.Mvc;
using PermitApplication.Models;

namespace PermitApplication.Controllers
{
    /// <summary>
    /// Web API controller to handle permit requests
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly PermitsRepository _permitsRepository;

        public HomeController(PermitsRepository permitRepository)
        {
            _permitsRepository = permitRepository;
        }

        /// <summary>
        /// Method to handle the submission of a permit request in the database
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Successful message</returns>

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitCreatePermitRequest([FromBody] PermitRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Map DTO → SubmitterUser for repository
            var user = new SubmitterUser
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Address = new SubmitterAddress
                {
                    FullUSPSAddress = dto.FullUSPSAddress
                },
                PermitType = new PermitTypeAndCounty
                {
                    PermitTypeID = dto.Type_ID
                },
                County = new PermitTypeAndCounty
                {
                    CountyID = dto.County_ID
                }
            };

            await _permitsRepository.AddPermitRequest(user);
            return Ok("Data submitted successfully!");
        }
    }
}

