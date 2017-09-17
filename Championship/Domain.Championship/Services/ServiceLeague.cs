using Domain.Championship.Entities;
using Domain.Championship.Interfaces.Repositories;
using Domain.Championship.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

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

        public League AddWithTeams(League league)
        {
            if (!league.IsOddTeam())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    List<Team> teams = new List<Team>();
                    teams.AddRange(league.Teams);
                    league.Teams = new List<Team>();
                    var newLeague = this.Add(league);

                    foreach (var team in teams)
                    {
                        var teamComplete = this._repositoryTeam.GetById(team.Id);
                        teamComplete.IdLeague = newLeague.Id;
                        this._repositoryTeam.Update(teamComplete);
                    }
                    newLeague.Teams.AddRange(teams);
                    league = newLeague;
                    scope.Complete();
                }
            }    
            return league;
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
