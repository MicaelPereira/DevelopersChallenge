using Application.Championship.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using entity = Domain.Championship.Entities;
using viewModel = Championship.Models;

namespace Championship.Controllers
{
    public class LeagueController : Controller
    {
        readonly IAppServiceLeague _appServiceLeague;
        public LeagueController(IAppServiceLeague appServiceLeague)
        {
            this._appServiceLeague = appServiceLeague;
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
            var leagueViewModel = Mapper.Map<entity.League, viewModel.League>(_appServiceLeague.GetById(id));
            return View(leagueViewModel);
        }

        // GET: League/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: League/Create
        [HttpPost]
        public ActionResult Create(viewModel.League collection)
        {
            try
            {
                //viewModel.League league = new viewModel.League();

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
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
