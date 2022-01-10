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
    }
}
