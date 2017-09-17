using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Championship.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Domain.Championship.Interfaces.Repositories;
using Domain.Championship.Entities;

namespace Domain.Championship.Services.Tests
{
    [TestClass()]
    public class ServiceTeamTest
    {
        ServiceTeam serviceTeam;
        Mock<IRepositoryTeam> _RepositoryTeam = new Mock<IRepositoryTeam>();
        DateTime dateNow = DateTime.Now;

        [TestInitialize()]
        public void Setup()
        {
            serviceTeam = new ServiceTeam(_RepositoryTeam.Object);
        }

        [TestMethod()]
        public void GetWithoutLeague()
        {
            _RepositoryTeam.Setup(t => t.GetWithoutLeague()).Returns(fakeTeam());

            var teams = serviceTeam.GetWithoutLeague();

            Assert.IsNotNull(teams);
            Assert.AreEqual(2, teams.Count());
        }

        public List<Team> fakeTeam()
        {
            return new List<Team>() { new Team() { Id = 1, Name = "Team 1" }, { new Team() { Id = 2, Name = "Team 2" } } };
        }
    }
}