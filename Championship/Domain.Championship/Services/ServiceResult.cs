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
    public class ServiceResult : ServiceBase<Result>, IServiceResult
    {
        IRepositoryResult _repositoryResult;
        public ServiceResult(IRepositoryResult repositoryResult)
            : base(repositoryResult)
        {
            _repositoryResult = repositoryResult;

        }
    }
}
