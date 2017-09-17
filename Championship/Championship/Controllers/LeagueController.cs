using Application.Championship.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using entity = Domain.Championship.Entities;
using viewModel = Championship.Models;

namespace Championship.Controllers
{
    public class LeagueController : Controller
    {
        readonly IAppServiceLeague _appServiceLeague;
        readonly IAppServiceTeam _appServiceTeam;
        public LeagueController(IAppServiceLeague appServiceLeague, IAppServiceTeam appServiceTeam)
        {
            this._appServiceLeague = appServiceLeague;
            this._appServiceTeam = appServiceTeam;
        }
        // GET: League
        public ActionResult Index()
        {
            var leaguesViewModel = Mapper.Map<IEnumerable<entity.League>, IEnumerable<viewModel.League>>(_appServiceLeague.GetAll());
            return View(leaguesViewModel);
        }

        // GET: League/Details/5
        public ActionResult Details(int id)
        {
            var leagueViewModel = Mapper.Map<entity.League, viewModel.League>(_appServiceLeague.GetByIdWithTeams(id));
            return View(leagueViewModel);
        }

        // GET: League/Create
        public ActionResult Create()
        {
            var league = new viewModel.League();
            league.Teams = new List<viewModel.Team>();
            league.Teams.AddRange(Mapper.Map<IEnumerable<entity.Team>, IEnumerable<viewModel.Team>>(this._appServiceTeam.GetWithoutLeague()));
            return View(league);
        }

        // POST: League/Create
        [HttpPost]
        public ActionResult Create(viewModel.League collection, FormCollection form)
        {
            try
            {
                var ids = form.GetValue("hdnTeamsInLeague").AttemptedValue;
                collection.Teams = new List<viewModel.Team>();
                
                if (!string.IsNullOrEmpty(ids))
                {
                    foreach (var item in ids.Split(','))
                        collection.Teams.Add(new viewModel.Team() { Id = int.Parse(item) });

                    collection.SumTeams = ids.Split(',').Count();
                }
                collection.IsRandom = false;
                var newLeague = this._appServiceLeague.AddWithTeams(Mapper.Map<viewModel.League, entity.League>(collection));
                
                return RedirectToAction("Index");
            }
            catch(Exception err)
            {
                return View();
            }
        }

        // GET: League/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: League/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
