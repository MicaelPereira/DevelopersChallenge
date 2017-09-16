using Application.Championship.Interface;
using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using entity = Domain.Championship.Entities;
using viewModel = Championship.Models;

namespace Championship.Controllers
{
    public class TeamController : Controller
    {
        readonly IAppServiceTeam _appServiceTeam;
        public TeamController(IAppServiceTeam appServiceTeam)
        {
            _appServiceTeam = appServiceTeam;
        }
        // GET: Team
        public ActionResult Index()
        {
            var teamsViewModel = GetAllTeams();
            return View(teamsViewModel);
        }

        // GET: Team/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Team/Create
        [HttpPost]
        public ActionResult Create(viewModel.Team collection)
        {
            try
            {
                // TODO: Add insert logic here
                var teamEntity = Mapper.Map<viewModel.Team, entity.Team>(collection);
                _appServiceTeam.Add(teamEntity);
                return RedirectToAction("Index");
            }
            catch(Exception err)
            {
                return View();
            }
        }

        // GET: Team/Edit/5
        public ActionResult Edit(int id)
        {
            var teamViewModel = Mapper.Map<entity.Team, viewModel.Team>(_appServiceTeam.GetById(id));
            return View(teamViewModel);
        }

        // POST: Team/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, viewModel.Team collection)
        {
            try
            {
                var teamEntity = Mapper.Map<viewModel.Team, entity.Team>(collection);
                _appServiceTeam.Update(teamEntity);
                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                return View();
            }
        }

        public JsonResult AllTeams()
        {
            return Json(this.GetAllTeams(), JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<viewModel.Team> GetAllTeams()
        {
            return Mapper.Map<IEnumerable<entity.Team>, IEnumerable<viewModel.Team>>(_appServiceTeam.GetAll());

        }
    }
}
