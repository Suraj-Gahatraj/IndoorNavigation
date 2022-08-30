using IndoorNavigation.Api.Utilities;
using IndoorNavigation.Application.Contracts.Persistence;
using IndoorNavigation.Application.Features.Sites.Commands.CreateSite;
using IndoorNavigation.Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;

namespace IndoorNavigation.Api.Controllers
{



    [Authorize]
    public class SiteController : ControllerBase
    {
        private IWebHostEnvironment _webHostEnvironment;
        private readonly ISiteRepository _siteRepository;
        public SiteController(IWebHostEnvironment webHostEnvironment, ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [Authorize]
        [HttpGet("api/GetAllSites")]
        public async Task<IActionResult> GetAllAdminSite()
        {

            var userId = User.FindFirstValue(ClaimTypes.Name);
            var siteList = await _siteRepository.GetAllAdminSite(userId);

            return Ok(siteList);

        }


        [Authorize]
        [HttpPost("api/createSite")]
        public async Task<IActionResult> CreateSite([FromForm] CreateSiteVm input)
        {

            var userId = User.FindFirstValue(ClaimTypes.Name);

           var model= await _siteRepository.CreateSite(input, userId);

            return Ok(model);
        }

        [Authorize]
        [HttpPost("api/deleteSite")]       
        public async Task<IActionResult> DeleteSite(string SiteId)
        {
            var isSuccess =await  _siteRepository.DeleteSiteAysnc(SiteId);
            if (isSuccess) return Ok("Site deleted successfully");

            return NotFound(" given site don't exist");
        }

        [AllowAnonymous]
        [HttpPost("api/UpdateSiteMarker")]
       public async Task<IActionResult> UpdateSiteMarker([FromForm] SiteMapMarkerVm input )
        {
            var isSuccess = await _siteRepository.CreateSiteMapMarker(input);
            if (isSuccess) return Ok("Image uploaded successfully to site marker");
            else
            {
                return Conflict("Something went wrong");
            }
        }

        [AllowAnonymous]
        [HttpGet("api/getAllMarkerImageGallery")]
        public async Task<IActionResult> GetAllMarkerImageGallery(string siteId,string markerId)
        {
            var response = await _siteRepository.GetMarkerImageGallery(siteId, markerId);
            return Ok(response);
        }


      

       
    }
}
