using PracaInzynierska.DataAccessLayer;
using PracaInzynierska.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracaInzynierska.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
            Device device = new Device { Name = "nazwa", Producer = "Programista", Type = "other" };
            db.Devices.Add(device);
            db.SaveChanges();
            return View();
        }
    }
}