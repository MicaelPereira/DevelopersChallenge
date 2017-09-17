using Domain.Championship.Entities;
using Domain.Championship.Interfaces.Repositories;
using Domain.Championship.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Championship.Services
{
    public class ServiceLeague : ServiceBase<League>, IServiceLeague
    {
        IRepositoryLeague _repositoryLeague;
        IRepositoryTeam _repositoryTeam;
        public ServiceLeague(IRepositoryLeague repositoryLeague, IRepositoryTeam repositoryTeam)
            : base(repositoryLeague)
        {
            _repositoryLeague = repositoryLeague;
            _repositoryTeam = repositoryTeam;

        }

        public League GetByIdWithTeams(int id)
        {
            var league = _repositoryLeague.GetById(id);
            league.Teams = new List<Team>();
            league.Teams.AddRange(_repositoryTeam.GetWithLeague(league.Id));
            return league;

        }
    }
}
