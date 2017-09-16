using Application.Championship.Interface;
using Domain.Championship.Entities;
using Domain.Championship.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Championship
{
    public class AppServiceLeague : AppServiceBase<League>, IAppServiceLeague
    {
        readonly IServiceLeague _serviceLeague;
        public AppServiceLeague(IServiceLeague serviceLeague)
            : base(serviceLeague)
        {
            _serviceLeague = serviceLeague;
        }

    }
}
