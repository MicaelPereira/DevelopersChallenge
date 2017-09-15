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
        public ServiceLeague(IRepositoryLeague repositoryLeague)
            : base(repositoryLeague)
        {
            _repositoryLeague = repositoryLeague;

        }
    }
}
