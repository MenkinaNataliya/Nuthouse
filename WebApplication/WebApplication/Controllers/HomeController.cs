using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Newtonsoft.Json;
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
            
            //var list = connect.GetCity();
            //var listItem = new List<SelectListItem>();
            //foreach (var item in list)
            //{
            //    listItem.Add(new SelectListItem() {Text = item});

            //}

            //ViewBag.cities = connect.GetCity();
            return View();
        }
        [HttpGet]
        public ActionResult Equipments()
        {
            var connect = new ConnectWithServer();
           
            return View(connect.GetEquipments(""));
        }

        [HttpGet]
        public ActionResult Report()
        {
            //var connect = new ConnectWithServer();
            //ViewBag.message = connect.GetHello();
            return View();
        }
        [HttpGet]
        public ActionResult Change()
        {
            //var connect = new ConnectWithServer();
            //ViewBag.message = connect.GetHello();
            return View();
        }
        [HttpPost]
        public ActionResult AddEquipment( Equipment equip)
        {
            if (ModelState.IsValid)
            {
                var connect = new ConnectWithServer();
                var error = connect.SetInformation(equip);
                if ( error == "Данные добавлены успешно")
                    return RedirectToAction("Index");
                ViewBag.Message = error;
                return View(equip);
            }
            ViewBag.Message = "Non Valid";
            return View(equip);
            //return View();
        }
    }
}