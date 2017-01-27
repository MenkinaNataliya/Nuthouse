using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            //ViewBag.message = connect.GetHello();
            return View();
        }
        [HttpPost]
        public ActionResult AddEquipment( Equipment equip)
        {
            if (ModelState.IsValid)
            {
                var list = new List<Equipment> { information };
                var json = new JsonMessage { Type = "AddEquipment", equipment = list };

                if( JsonConvert.SerializeObject(json) == "Данные добавлены успешно")
                    return RedirectToAction("Index");
                else ViewBag.Message = "Устройство с таким инвентарным номером уже существует";
            }
            ViewBag.Message = "Non Valid";
            return View(equip);
            //return View();
        }
    }
}