﻿using AutoMapper;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Services.Contracts;
using CarModsHeaven.Web.Infrastructure;
using CarModsHeaven.Web.Models.ProjectsList;
using PagedList;
using System.Linq;
using System.Web.Mvc;

namespace CarModsHeaven.Web.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectsService projectsService;
        private readonly IUsersService usersService;

        public ProjectsController(IProjectsService projectsService, IUsersService usersService)
        {
            this.projectsService = projectsService;
            this.usersService = usersService;
        }

        public ActionResult Index(int? page)
        {
            var projects = this.projectsService
                .GetAll()
                .MapTo<ProjectViewModel>()
                .ToList();


            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(projects.ToPagedList(pageNumber, pageSize));
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddProject()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddProject(ProjectViewModel project)
        {
            var dbModel = Mapper.Map<Project>(project);
            this.projectsService.Add(dbModel);
            return RedirectToAction("Index");
        }
    }
}