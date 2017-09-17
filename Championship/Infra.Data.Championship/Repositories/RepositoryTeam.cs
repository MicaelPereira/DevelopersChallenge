using Domain.Championship.Entities;
using Domain.Championship.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Championship.Repositories
{
    public class RepositoryTeam : RepositoryBase<Team>, IRepositoryTeam
    {
        public IEnumerable<Team> GetWithoutLeague()
        {
            return Db.Teams.Where(t => t.League == null);
        }

        public IEnumerable<Team> GetWithLeague(int idLeague)
        {
            return Db.Teams.Where(t => t.IdLeague == idLeague);
        }
    }
}
