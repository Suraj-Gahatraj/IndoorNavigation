﻿using IndoorNavigation.Application.Features.Sites;
using IndoorNavigation.Application.Features.Sites.Commands.CreateSite;
using IndoorNavigation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorNavigation.Application.Contracts.Persistence
{
    public interface ISiteRepository:IAsyncRepository<Site>
    {
        Task CreateSite(CreateSiteVm input,string userId);
        Task<List<SiteListVm>> GetAllAdminSite(string userId);
        Task<bool> DeleteSiteAysnc(string id);
    }
}
