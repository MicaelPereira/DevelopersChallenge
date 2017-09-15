using Domain.Championship.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Championship.EntityConfig
{
    public class LeagueConfiguration : EntityTypeConfiguration<League>
    {
        public LeagueConfiguration()
        {
            HasKey(l => l.Id);

            Property(l => l.CreatedDate)
                .IsRequired();
            Property(l => l.UpdatedDate);
            Property(l => l.IsRandom).IsRequired();
            Property(l => l.Name).IsRequired();
        }
    }
}
