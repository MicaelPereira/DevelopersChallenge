using Domain.Championship.Entities;
using Infra.Data.Championship.EntityConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Championship.Context
{
    public class AppContext : DbContext
    {
        public AppContext()
            : base("Championship")
        {
            Database.SetInitializer<AppContext>(new CreateDatabaseIfNotExists<AppContext>());
        }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(300));

            modelBuilder.Configurations.Add(new LeagueConfiguration());
            modelBuilder.Configurations.Add(new ResultConfiguration());
            modelBuilder.Configurations.Add(new TeamConfiguration());

        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedDate") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedDate").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("UpdatedDate").CurrentValue  = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }
}
