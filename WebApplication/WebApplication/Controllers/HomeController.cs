using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
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
            //ViewBag.Message = message;
            return View();
        }

        [HttpGet]
        public ActionResult AddEquipment()
        {
            var connect = new ConnectWithServer();
            ViewBag.Denominations = connect.Get("Denomination");
            ViewBag.Cities = connect.Get("City");
            ViewBag.Marks = connect.Get("Marks");
            ViewBag.Employees = connect.Get("Employee");

            return View();
        }

        [HttpPost]
        public ActionResult AddEquipment(Equipment equip)
        {
            var connect = new ConnectWithServer();
            ViewBag.Denominations = connect.Get("Denomination");
            ViewBag.Cities = connect.Get("City");
            ViewBag.Marks = connect.Get("Marks");
            ViewBag.Employees = connect.Get("Employee");

            if (ModelState.IsValid)
            {
               
                var error = connect.SetInformation(equip);
                if (error == "Данные добавлены успешно")
                {
                    ViewBag.SuccessMessage = "Устройство добавлено успешно";
                    return View(new Equipment());

                }
                ViewBag.Message = error;
                return View(equip);
            }
            ViewBag.Message = "Данные введены неверно. Попробуйте снова";
            return View(equip);
            //return View();
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
            var connect = new ConnectWithServer();
            ViewBag.FilterDenominations = connect.Get("Denomination");
            ViewBag.FilterCities = connect.Get("City");
            ViewBag.FilterMarks = connect.Get("Marks");
            ViewBag.FilterResponsibles = connect.Get("Employee");
            return View();
        }

        [HttpPost]
        public ActionResult Report(Report report)
        {
            var x = report.FilterModernisation;
            return View();
        }

        [HttpPost]
        public ActionResult Status(Equipment equip)
        {
            //var connect = new ConnectWithServer();
            //ViewBag.message = connect.GetHello();
            return Redirect("Change/"+equip.InventoryNumber);
        }
        [HttpGet]
        public ActionResult Status()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Change( string id)
        {
            var connect = new ConnectWithServer();
            ViewBag.Denominations = connect.Get("Denomination");
            ViewBag.Cities = connect.Get("City");
            ViewBag.Marks = connect.Get("Marks");
            ViewBag.Employees = connect.Get("Employee");
           
            return View(connect.GetEquipments(id)[0]);
        }

        [HttpPost]
        public ActionResult Change(Equipment equip)
        {
            var connect = new ConnectWithServer();
            ViewBag.Denominations = connect.Get("Denomination");
            ViewBag.Cities = connect.Get("City");
            ViewBag.Marks = connect.Get("Marks");
            ViewBag.Employees = connect.Get("Employee");

            connect.ChangeStatus(equip.InventoryNumber, equip.Status);

            ViewBag.SuccessMessage = "Данные об устройстве изменены успешно";
            return Redirect("Index");
         }



    }
}