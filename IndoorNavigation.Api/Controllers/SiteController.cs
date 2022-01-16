using IndoorNavigation.Api.Utilities;
using IndoorNavigation.Application.Contracts.Persistence;
using IndoorNavigation.Application.Features.Sites.Commands.CreateSite;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IndoorNavigation.Api.Controllers
{
    [Authorize]
    public class SiteController:ControllerBase
    {
        private IWebHostEnvironment _webHostEnvironment;
        private readonly ISiteRepository _siteRepository;
        public SiteController(IWebHostEnvironment webHostEnvironment,ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
            _webHostEnvironment = webHostEnvironment;   
        }
        [HttpGet("api/GetAllSites")]
        public async Task<IActionResult> GetAllAdminSite()
        {

            var userId = User.FindFirstValue(ClaimTypes.Name);
            var siteList =await  _siteRepository.GetAllAdminSite(userId);

            return Ok(siteList);
         
        }


        [Authorize]
        [HttpPost("api/createSite")]
        public async Task<IActionResult> CreateSite([FromForm] CreateSiteVm input)
        {
            
            var userId = User.FindFirstValue(ClaimTypes.Name);
            input.AdminId = userId;
            _siteRepository.CreateSite(input);

            return Ok();
        }


        [AllowAnonymous]
        [HttpPost("api/uploadPhoto")]

        public async Task<IActionResult> UploadPhoto([FromForm] UploadParam input)
        {
            Console.WriteLine(" hi hhashdashdhasd");
            string siteId = "1234";
            string markerName = "Meroghar";
            if(input!=null)
            {
                string fileName=String.Empty;
                var fileUploadPath = FileUtility.GetSiteMarkerUploadPath(siteId, markerName,out fileName);
                FileUtility.Upload(input.BlobUrl, fileUploadPath,fileName);
            }

            return Ok();
        }

        public class UploadParam
        {
            public IFormFile BlobUrl { get; set; }
        }
    }
}
