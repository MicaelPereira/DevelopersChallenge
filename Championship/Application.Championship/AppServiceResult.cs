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
    public class AppServiceResult : AppServiceBase<Result>, IAppServiceResult
    {
        readonly IServiceResult _serviceResult;
        public AppServiceResult(IServiceResult serviceResult)
            : base(serviceResult)
        {
            _serviceResult = serviceResult;
        }

    }
}
