using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddEquipment()
        {
            //var connect = new ConnectWithServer();
            //ViewBag.message = connect.GetHello();
            return View();
        }
        [HttpPost]
        public ActionResult AddEquipment( Equipment equip)
        {
            //var connect = new ConnectWithServer();
            //ViewBag.message = connect.GetHello();
            return View();
        }
    }
}