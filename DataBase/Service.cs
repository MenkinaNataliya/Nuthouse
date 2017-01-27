using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Service
    {

        public static string AddEquipment(Equipment equip)
        {
            using (var db = new DbModel())
            {
                if (db.Equipments.Find(equip.InventoryNumber) != null || db.Equipments.Where(x => x.OldInventoryNumber == equip.InventoryNumber).ToList().Count != 0)
                    return "Устройство с таким инвентарным номером уже существует";

                /*var respons = equip.Responsible;
                //var firstResp = respons[1];
                //var secResp = respons[0];
                //var lastResp = respons[2];

                respons = equip.WhoUses;
                //var firstWho = respons[1];
                //var secWho = respons[0];
                //var lastWho = respons[2];

                CheckDenomination(equip.denomination.Naming);
                CheckMark(equip.mark.Naming);
                CheckEmploy(equip.Responsible);
                CheckEmploy(equip.WhoUses);

                var res = new Equipment
                {
                    InventoryNumber = equip.InventoryNumber,
                    OldInventoryNumber = OldInventoryNumber,
                    model = model,
                    Comment = Comment,
                    Modernization = Modernization,
                    denomination = db.Denominations.FirstOrDefault(x => x.Naming == denomination),
                    mark = db.Marks.FirstOrDefault(x => x.Naming == mark),
                    Responsible = db.Employees.FirstOrDefault(x => x.FirstName == firstResp && x.SecondName == secResp && x.LastName == lastResp),
                    WhoUses = db.Employees.FirstOrDefault(x => x.FirstName == firstWho && x.SecondName == secWho && x.LastName == lastWho),
                    city = db.city.FirstOrDefault(x => x.Naming == City),
                    Floor = Floor,
                    Housing = Housing,
                    Cabinet = Cabinet,
                    status = db.status.FirstOrDefault(x => x.Naming == Status)
                };*/
                db.Equipments.Add(equip);
                db.SaveChanges();
                return "";
            }
        }
        public static string  AddEquipment(string InventoryNumber, string OldInventoryNumber, string denomination,
               string mark,string model, string Status, string Comment,bool Modernization,  string Responsible, string WhoUses,
                string City, string Housing, int Floor, string Cabinet)
        {
            

            using (var db = new DbModel())
            {
                if (db.Equipments.Find(InventoryNumber) != null || db.Equipments.Where(x=>x.OldInventoryNumber == InventoryNumber).ToList().Count != 0)
                    return "Устройство с таким инвентарным номером уже существует";

                var respons = Responsible.Split(' ');
                var firstResp = respons[1];
                var secResp = respons[0];
                var lastResp = respons[2];

                respons = WhoUses.Split(' ');
                var firstWho = respons[1];
                var secWho = respons[0];
                var lastWho = respons[2];

                CheckDenomination(denomination);
                CheckMark(mark);
                CheckEmploy(Responsible);
                CheckEmploy(WhoUses);

                var res = new Equipment
                {
                    InventoryNumber = InventoryNumber,
                    OldInventoryNumber = OldInventoryNumber,
                    model = model,
                    Comment = Comment,
                    Modernization = Modernization,
                    denomination = db.Denominations.FirstOrDefault(x => x.Naming == denomination),
                    mark = db.Marks.FirstOrDefault(x => x.Naming == mark),
                    Responsible = db.Employees.FirstOrDefault(x => x.FirstName == firstResp && x.SecondName == secResp && x.LastName == lastResp),
                    WhoUses = db.Employees.FirstOrDefault(x => x.FirstName == firstWho && x.SecondName == secWho && x.LastName == lastWho),
                    city = db.city.FirstOrDefault(x => x.Naming == City),
                    Floor = Floor,
                    Housing =Housing,
                    Cabinet  = Cabinet,
                    status = db.status.FirstOrDefault(x => x.Naming == Status)
                };
                db.Equipments.Add(res);                         
                db.SaveChanges();
                return "";
            }
        }

        public static void ChangeStatus(string number, string newStatus)
        {
            using (DbModel db = new DbModel())
            {
                var eq = db.Equipments.Include("Status").FirstOrDefault(x => x.InventoryNumber == number);
                var oldStatus = eq.status;
                eq.status = db.status.FirstOrDefault(x => x.Naming == newStatus);
                db.SaveChanges();

                var res = new ChangeHistory
                {
                    InventNumber = number,
                    OldStatus = oldStatus,
                    NewStatus = db.status.FirstOrDefault(x => x.Naming == newStatus)
                };

                db.History.Add(res);
                db.SaveChanges();
            }   
        }

       

        public static void CleanHistry()
        {
            using (DbModel db = new DbModel())
            {
                db.History.RemoveRange(db.History);
                db.SaveChanges();

            }
        }

        private static void CheckDenomination(string denomination)
        {
            using (var db = new DbModel())
            {
                var tmp = db.Denominations.FirstOrDefault(x => x.Naming == denomination);
                if (tmp != null) return;
                db.Denominations.Add(new Denomination
                {
                    Naming = denomination
                });
                db.SaveChanges();
            }
        }
        private static void CheckMark(string mark)
        {
            using (var db = new DbModel())
            {
                if (db.Marks.FirstOrDefault(x => x.Naming == mark) != null) return;
                db.Marks.Add(new Mark
                {
                    Naming = mark
                });
                db.SaveChanges();
            }
        }
        private static void CheckEmploy(string employ)
        {
            using (var db = new DbModel())
            {

                var name = employ.Split(' ');
                var first = name[1];
                var sec = name[0];
                var las = name[2];
                if (
                    db.Employees.FirstOrDefault(x => x.SecondName == sec && x.LastName == las && x.FirstName == first) !=
                    null) return;
                db.Employees.Add(new Employee
                {
                    FirstName = first,
                    SecondName = sec,
                    LastName = las
                });
                db.SaveChanges();
            }
        }

    }
}
