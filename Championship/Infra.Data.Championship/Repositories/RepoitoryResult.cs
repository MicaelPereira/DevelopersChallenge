using Domain.Championship.Entities;
using Domain.Championship.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Championship.Repositories
{
    public class RepositoryResult : RepositoryBase<Result>, IRepositoryResult
    {
    }
}
