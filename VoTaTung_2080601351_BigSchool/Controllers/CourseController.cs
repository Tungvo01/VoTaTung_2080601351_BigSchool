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
    public class CourseController : Controller
    {
        // GET: Course
        private readonly ApplicationDbContext dbContext;
        public CourseController()
        {
            dbContext = new ApplicationDbContext();
        }
       
        public ActionResult Create()
        {

            var viewModel = new CourseViewModel()
            {
                Categories = dbContext.categories.ToList()
            };
            return View(viewModel);
        }
    }



}