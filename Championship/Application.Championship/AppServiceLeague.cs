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
        readonly IServiceTeam _serviceTeam;
        public AppServiceLeague(IServiceLeague serviceLeague, IServiceTeam serviceTeam)
            : base(serviceLeague)
        {
            _serviceLeague = serviceLeague;
            _serviceTeam = serviceTeam;
        }

        public League AddWithTeams(League league)
        {
            return _serviceLeague.AddWithTeams(league);
        }

        public League GetByIdWithTeams(int id)
        {
            return _serviceLeague.GetByIdWithTeams(id);
        }
    }
}
