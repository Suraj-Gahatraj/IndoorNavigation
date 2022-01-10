using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorNavigation.Application.Features.Sites
{
    public  class GetSiteListQuery:IRequest<List<SiteListVm>>
    {
    }
}
