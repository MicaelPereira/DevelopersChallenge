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
    public class ServiceLeagueTest
    {
        ServiceLeague serviceLeague;
        Mock<IRepositoryLeague> _RepositoryLeague = new Mock<IRepositoryLeague>();
        Mock<IRepositoryTeam> _RepositoryTeam = new Mock<IRepositoryTeam>();
        DateTime dateNow = DateTime.Now;

        [TestInitialize()]
        public void Setup()
        {
            serviceLeague = new ServiceLeague(_RepositoryLeague.Object, _RepositoryTeam.Object);
        }

        [TestMethod()]
        public void AddWithTeams()
        {
            _RepositoryLeague.Setup<League>(l => l.Add(It.IsAny<League>())).Returns(fakeLeagueAdd());
            _RepositoryTeam.Setup<Team>(t => t.GetById(It.IsAny<int>())).Returns(fakeTeamGetById());

            var newLeague = serviceLeague.AddWithTeams(fakeLeague());

            Assert.IsNotNull(newLeague);
            Assert.AreEqual(0, newLeague.Exceptions.Count);
            Assert.AreEqual("League Test", newLeague.Name);
            Assert.AreEqual(2, newLeague.Id);            
        }

        public League fakeLeague()
        {
            League l = new League();
            l.IsRandom = false;
            l.Name = "League Test";
            l.Teams = new List<Team>() { new Team() { Id = 1, Name = "Team 1" }, { new Team() { Id = 2, Name = "Team 2" } } };
            l.SumTeams = l.Teams.Count;
            return l;
        }
        public League fakeLeagueAdd()
        {
            League l = new League();
            l.IsRandom = false;
            l.Name = "League Test";
            l.Teams = new List<Team>() { new Team() { Id = 1, Name = "Team 1" }, { new Team() { Id = 2, Name = "Team 2" } } };
            l.SumTeams = l.Teams.Count;
            l.CreatedDate = dateNow;
            l.Id = 2;
            return l;
        }
        public Team fakeTeamGetById()
        {
            return new Team() { Id = 1, Name = "Team 1" };
        }

        [TestMethod()]
        public void GetByIdWithTeams()
        {
            int id = 1;
            _RepositoryLeague.Setup<League>(l => l.GetById(It.IsAny<int>())).Returns(fakeLeagueWithoutTeam());
            _RepositoryTeam.Setup(t => t.GetWithLeague(It.IsAny<int>())).Returns(fakeTeamsWithLeague());

            var league = serviceLeague.GetByIdWithTeams(id);

            Assert.AreEqual(2, league.Teams.Count);

        }

        public League fakeLeagueWithoutTeam()
        {
            var l = fakeLeague();
            l.Teams = new List<Team>();
            l.Id = 1;
            return l;
        }

        public List<Team> fakeTeamsWithLeague()
        {
            return new List<Team>() { new Team() { Id = 1, Name = "Team 1", IdLeague = 1 }, { new Team() { Id = 2, Name = "Team 2", IdLeague = 1 } } };
        }
    }
}