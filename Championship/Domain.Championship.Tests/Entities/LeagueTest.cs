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
    public class LeagueTest
    {
        League league;
        DateTime dateNow = DateTime.Now;

        [TestInitialize()]
        public void Setup()
        {
            league = new League();
        }

        [TestMethod()]
        public void IsOddTeam()
        {
            league.Teams = new List<Team>() { new Team() { Id = 1, Name = "Team 1" }, { new Team() { Id = 2, Name = "Team 2" } } };

            league.IsOddTeam();

            Assert.IsNotNull(league);
            Assert.AreEqual(0, league.Exceptions.Count);
        }
        [TestMethod()]
        public void IsOddTeamError()
        {
            league.Teams = new List<Team>() { new Team() { Id = 1, Name = "Team 1" } };

            league.IsOddTeam();

            Assert.IsNotNull(league);
            Assert.AreEqual(1, league.Exceptions.Count);
        }
    }
}