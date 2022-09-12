using IndoorNavigation.Application.Features.Sites.Commands.CreateSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorNavigation.Application.Contracts.Persistence
{
    public  interface IMarkerRepository
    {
        Task<ViewMarkerDto>  CreateMarker(CreateMarkerVm input, string userId);
        Task<ViewMarkerDto> GetMarker(string Id);
    }
}
