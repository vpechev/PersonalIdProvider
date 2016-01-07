using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Interfaces;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //Get All
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetById(int id)
        {
            return View();
        }

        public ActionResult Insert(DocumentEntity entity)
        {
            return null;
        }

        public ActionResult Update(DocumentEntity entity)
        {
            return null;
        }

        public ActionResult Delete(int id)
        {
            return null;
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