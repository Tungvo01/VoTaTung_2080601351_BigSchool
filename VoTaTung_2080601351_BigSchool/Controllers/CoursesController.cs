﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoTaTung_2080601351_BigSchool.Models;
using VoTaTung_2080601351_BigSchool.ViewModels;

namespace VoTaTung_2080601351_BigSchool.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Course
        private readonly ApplicationDbContext dbContext;
        public CoursesController()
        {
            dbContext = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {

            var viewModel = new CourseViewModel()
            {
                Categories = dbContext.categories.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = dbContext.categories.ToList();
                return View("Create", viewModel);
            }
            var course  = new Course()
            {
                LecturerId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                CategoryId = viewModel.Category,
                Place = viewModel.Place
            };

            dbContext.Courses.Add(course);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }



}