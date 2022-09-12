using IndoorNavigation.Application.Contracts.Persistence;
using IndoorNavigation.Application.Features.Sites.Commands.CreateSite;
using IndoorNavigation.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorNavigation.Persistence.Repositories.EntityRepositories
{
    public class MarkerRepository : IMarkerRepository
    {
        private readonly IndoorNavigationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public MarkerRepository(IndoorNavigationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task< ViewMarkerDto> CreateMarker(CreateMarkerVm input, string userId)
        {
            
            var newMarker = new Marker()
            {
                Name = input.Name,
                X_Pos = input.X,
                Y_Pos = input.Y,
                Z_Pos = input.Z,
                CreatedBy = userId,
                CreatedOn = DateTime.Now,
                LastModifiedBy = userId,
            };

            _context.Markers.Add(newMarker);    
            _context.SaveChanges();


            return new ViewMarkerDto()
            {
                Id = newMarker.Id,
                Name = newMarker.Name,
                X_Pos = input.X,
                Y_Pos = input.Y,
                Z_Pos = input.Z,
            };
        }

        public async Task<ViewMarkerDto> GetMarker(string Id)
        {
            var markerId = Guid.Parse(Id);
            var marker = _context.Markers.Where(x => x.Id == markerId).FirstOrDefault();
            return new ViewMarkerDto()
            {
                Id = marker.Id,
                Name = marker.Name,
                X_Pos = marker.X_Pos,
                Y_Pos = marker.Y_Pos,
                Z_Pos = marker.Z_Pos,

            };
        }


    }
}
