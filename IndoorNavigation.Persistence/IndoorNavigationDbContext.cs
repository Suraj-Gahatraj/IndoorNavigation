using IndoorNavigation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using IndoorNavigation.Domain.Common;

namespace IndoorNavigation.Persistence
{
    public  class IndoorNavigationDbContext:IdentityDbContext<ApplicationUser>
    {
        public IndoorNavigationDbContext( DbContextOptions<IndoorNavigationDbContext> options):base(options)
        {

        }

        public DbSet<Site> Sites { get; set; }
        public DbSet<MapMarker> MapMarkers { get; set; }    
        public DbSet<SiteMarkerImage> SiteMarkerImages { get; set; }
        public DbSet<Marker> Markers { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken=new CancellationToken())
        {
            foreach(var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch(entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn=DateTime.Now;
                        break;
                }

            }

            return base.SaveChangesAsync(cancellationToken);    
        }
    }
}
