using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataBase;

namespace WebApplication.Controllers
{
    public class WebService
    {

        public DataBase.Equipment Translate(Models.Equipment equip)
        {
            var responsible = equip.Responsible.Split(' ');
            var who = equip.WhoUses.Split(' ');

            return new DataBase.Equipment
            {
                InventoryNumber = equip.InventoryNumber,
                OldInventoryNumber = equip.OldInventoryNumber,
                model = equip.Model,
                Comment = equip.Comment,
                Modernization = equip.Modernization,
                denomination = new Denomination { Naming = equip.Denomination },
                mark = new Mark() { Naming = equip.Mark },
                Responsible =
                    new Employee { FirstName = responsible[1], SecondName = responsible[2], LastName = responsible[0] },
                WhoUses = new Employee { FirstName = who[1], SecondName = who[2], LastName = who[0] },
                city = new City { Naming = equip.City },
                Floor = equip.Floor,
                Housing = equip.Housing,
                Cabinet = equip.Cabinet,
                status = new Status { Naming = equip.Status }
            };
        }

        public Models.Equipment TransletFromModel(DataBase.Equipment equip)
        {
            return new Models.Equipment
            {
                InventoryNumber = equip.InventoryNumber,
                OldInventoryNumber = equip.OldInventoryNumber,
                Model = equip.model,
                Comment = equip.Comment,
                Modernization = equip.Modernization,
                Denomination = equip.denomination.Naming,
                Mark = equip.mark.Naming,
                Responsible = equip.Responsible.LastName + " " + equip.Responsible.FirstName + " " + equip.Responsible.SecondName,
                WhoUses = equip.WhoUses.LastName + " " + equip.WhoUses.FirstName + " " + equip.WhoUses.SecondName,
                City = equip.city.Naming,
                Floor = equip.Floor,
                Housing = equip.Housing,
                Cabinet = equip.Cabinet,
                Status = equip.status.Naming,
            };
        }

        public DataBase.Report TranslateReport(Models.Report report)
        {
            return new DataBase.Report
            {
                FilterModernisation = report.FilterModernisation,
                FilterStatus = report.FilterStatus,
                FilterResponsibles = report.FilterResponsibles,
                FilterCities = report.FilterCities,
                FilterMarks = report.FilterMarks,
                FilterDenominations = report.FilterDenominations
            };
        }
    }
}