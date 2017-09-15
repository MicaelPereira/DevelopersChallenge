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
    public class ServiceTeam : ServiceBase<Team>, IServiceTeam
    {
        IRepositoryTeam _repositoryTeam;
        public ServiceTeam(IRepositoryTeam repositoryTeam)
            : base(repositoryTeam)
        {
            _repositoryTeam = repositoryTeam;

        }
    }
}
