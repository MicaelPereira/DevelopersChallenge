using Domain.Championship.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Championship.EntityConfig
{
    public class ResultConfiguration : EntityTypeConfiguration<Result>
    {
        public ResultConfiguration()
        {
            HasKey(l => l.Id);

            Property(l => l.CreatedDate)
                .IsRequired();
            Property(l => l.UpdatedDate);
            Property(l => l.VisitorResult);
            Property(l => l.HostResult);

            HasRequired(p => p.League)
                .WithMany()
                .HasForeignKey(p => p.IdLeague);

            HasRequired(p => p.Host)
                .WithMany()
                .HasForeignKey(p => p.IdHost);

            HasRequired(p => p.Visitor)
                .WithMany()
                .HasForeignKey(p => p.IdVisitor);
        }
    }
}
