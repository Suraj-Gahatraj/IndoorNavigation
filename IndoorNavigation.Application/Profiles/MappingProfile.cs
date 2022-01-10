using AutoMapper;
using IndoorNavigation.Application.Features.Sites;
using IndoorNavigation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorNavigation.Application.Profiles
{
    public  class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Site,SiteListVm>().ReverseMap();
        }
    }
}
