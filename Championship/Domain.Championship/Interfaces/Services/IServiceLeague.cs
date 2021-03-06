﻿using Domain.Championship.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Championship.Interfaces.Service
{
    public interface IServiceLeague : IServiceBase<League>
    {
        League GetByIdWithTeams(int id);
        League AddWithTeams(League league);
        
    }
}
