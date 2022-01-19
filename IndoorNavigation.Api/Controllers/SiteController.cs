using IndoorNavigation.Api.Utilities;
using IndoorNavigation.Application.Contracts.Persistence;
using IndoorNavigation.Application.Features.Sites.Commands.CreateSite;
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

            await _siteRepository.CreateSite(input, userId);

            return Ok();
        }

       


      

       
    }
}
