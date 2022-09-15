using IndoorNavigation.Application.Contracts.Persistence;
using IndoorNavigation.Application.Features.Sites.Commands.CreateSite;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IndoorNavigation.Api.Controllers
{
    public class MarkerController:ControllerBase
    {
        private IWebHostEnvironment _webHostEnvironment;
        private readonly IMarkerRepository _markerRepo;
        public MarkerController(IWebHostEnvironment webHostEnvironment, IMarkerRepository markerRepo)
        {
            _markerRepo = markerRepo;
            _webHostEnvironment = webHostEnvironment;
        }

        [Authorize]
        [HttpPost("api/createMarker")]
        public async Task<IActionResult> CreateMarker([FromBody] CreateMarkerVm input)
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);
            var marker = await _markerRepo.CreateMarker(input,userId);
            return Ok(marker);
        }






    }
}
