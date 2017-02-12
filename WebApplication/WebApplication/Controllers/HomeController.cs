using System.Web.Mvc;
using DataBase;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddEquipment()
        {
            ViewBag.Denominations = Get.Denominations();
            ViewBag.Cities = Get.City();
            ViewBag.Marks = Get.Marks();
            ViewBag.Employees = Get.Employee();

            return View();
        }

        [HttpPost]
        public ActionResult AddEquipment(Models.Equipment equip)
        {
            var service = new WebService();
            ViewBag.Denominations = Get.Denominations();
            ViewBag.Cities = Get.City();
            ViewBag.Marks = Get.Marks();
            ViewBag.Employees = Get.Employee();

            if (ModelState.IsValid)
            {
               
                var error = Service.AddEquipment(service.Translate(equip));
                if (error == "Данные добавлены успешно")
                {
                    ViewBag.SuccessMessage = "Устройство добавлено успешно";
                    return View(new Models.Equipment());

                }
                ViewBag.Message = error;
                return View(equip);
            }
            ViewBag.Message = "Данные введены неверно. Попробуйте снова";
            return View(equip);
        }

        [HttpGet]
        public ActionResult Equipments(string id="-1")
        {
             var service = new WebService();
            return View(Get.Equipments(id).ConvertAll(service.TransletFromModel));
        }
        [HttpGet]
        public ActionResult Password()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Password(Users user)
        {
            var error = Service.CheckUser(user);
            if (error == "ok") return RedirectToAction("AddDictionary");
            ViewBag.MessageError = error;
            return View();
        }

        [HttpGet]
        public ActionResult Report()
        {
            ViewBag.FilterDenominations = Get.Denominations();
            ViewBag.FilterCities = Get.City();
            ViewBag.FilterMarks = Get.Marks();
            ViewBag.FilterResponsibles = Get.Employee();
            return View();
        }

        [HttpPost]
        public ActionResult Report(Models.Report report)
        {
            var service = new WebService();
            var list = Get.Equipments(service.TranslateReport(report));
            return View("Equipments", list.ConvertAll(service.TransletFromModel));
        }

        [HttpGet]
        public ActionResult AddDictionary()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddDictionary(Dictionary  dic)
        {
            var error = Service.AddDictionary(dic);
            if (error == "OK") ViewBag.SuccessMessage = "Добавление прошло успешно";
            else ViewBag.ErrorMessage = error;
            return View();
        }


        [HttpGet]
        public ActionResult Change( string id, string oldId)
        {
            var service = new WebService();
            ViewBag.Employees = Get.Employee();
            return View(service.TransletFromModel(Get.Equipments(id, oldId)));
        }

        [HttpPost]
        public ActionResult Change(Models.Equipment equip)
        {
            ViewBag.SuccessMessage = Service.ChangeStatus(equip.InventoryNumber, equip.Status);
            return RedirectToAction("Index");
         }



        [HttpGet]
        public ActionResult Status()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Status(Models.Equipment equip)
        {
            return Redirect("Equipments/" + equip.InventoryNumber);
        }


    }
}