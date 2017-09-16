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
    public class AppServiceTeam : AppServiceBase<Team>, IAppServiceTeam
    {
        readonly IServiceTeam _serviceTeam;
        public AppServiceTeam(IServiceTeam serviceTeam)
            : base(serviceTeam)
        {
            _serviceTeam = serviceTeam;
        }

    }
}
