using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorNavigation.Application.Features.Sites
{
    public class GetSiteListQueryHandler : IRequestHandler<GetSiteListQuery, List<SiteListVm>>
    {
        public Task<List<SiteListVm>> Handle(GetSiteListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
