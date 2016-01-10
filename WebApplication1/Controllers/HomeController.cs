using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Interfaces;
using WebApplication1.Repositories;
using WebApplication1.Utilities;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //Get All
        [HttpGet]
        public ActionResult Index()
        {
            var repo = new DocumentRepository();
            var results = repo.GetAll();
            return View(results);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var repo = new DocumentRepository();
            var entity = repo.GetById(id);
            return View(entity);
        }

        public ActionResult RedirectToAdd()
        {
            return View("Add");
        }

        [HttpPost]
        public ActionResult Create(PersonalDocument entity)
        {
            var repo = new DocumentRepository();
            repo.Add(entity);
            return View("index");
        }

        [HttpPut]
        public ActionResult Update(PersonalDocument entity)
        {
            var repo = new DocumentRepository();
            repo.Update(entity);
            return View("index");
        }

        public ActionResult Delete(int id)
        {
            var repo = new DocumentRepository();
            repo.Delete(id);
            return View("index");
        }




        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}