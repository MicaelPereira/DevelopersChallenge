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

        public League GetByIdWithTeams(int id)
        {
            return _serviceLeague.GetByIdWithTeams(id);
        }

        //TODO:Refactory
        //public IEnumerable<League> GetAllWithTeams()
        //{
        //    var leagues = _serviceLeague.GetAll();
        //    foreach (var league in leagues)
        //    {
        //        league.Teams.AddRange(_serviceTeam.GetAll());
        //    }
        //    return leagues;
        //}
    }
}
