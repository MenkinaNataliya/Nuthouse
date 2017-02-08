using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Get
    {
        public static Denomination[] Denominations()
        {
            using (var db = new DbModel())
                return db.Denominations.ToArray();
        }
        public static Mark[] Marks()
        {
            using (var db = new DbModel())
                return db.Marks.ToArray();
        }

        public static City[] City()
        {
            using (var db = new DbModel())
                return db.city.ToArray();
        }

        public static Employee[] Employee()
        {
            using (var db = new DbModel())
                return db.Employees.ToArray();
        }

        /*public static List<Equipment> EquipmentsOfModernization()
        {
            using (DbModel db = new DbModel())
                return db.Equipments.Where(x => x.Modernization == true).ToList();
        }*/

       /* public static Status[] AllStatus()
        {
            using (DbModel db = new DbModel())
            {
                return db.status.ToArray();
            }
        }*/

        public static List<Equipment> Equipments(Report report)
        {
            using (var db = new DbModel())
            {

                var bigResult = db.Equipments.Include("Status").Include("Mark")
                                .Include("Responsible").Include("WhoUses")
                                .Include("City").Include("denomination")
                                .AsQueryable();
                if (report.FilterModernisation != "whatever")
                    bigResult = report.FilterModernisation != "true" ? bigResult.Where(x => x.Modernization) : bigResult.Where(x => x.Modernization == false);
                if (report.FilterCities.Count != 0)
                    bigResult = bigResult.Where(x => report.FilterCities.Any(y => y == x.city.Naming));
                if (report.FilterDenominations.Count != 0)
                    bigResult = bigResult.Where(x => report.FilterDenominations.Any(y => y == x.denomination.Naming));
                if (report.FilterMarks.Count != 0)
                    bigResult = bigResult.Where(x => report.FilterMarks.Any(y => y == x.mark.Naming));
                if (report.FilterStatus.Count != 0)
                    bigResult = bigResult.Where(x => report.FilterStatus.Any(y => y == x.status.Naming));
                if (report.FilterResponsibles.Count != 0)
                    bigResult = bigResult.Where(x => report.FilterResponsibles.Any(y => y == (x.Responsible.SecondName + " " + x.Responsible.FirstName + " " + x.Responsible.LastName)));
                return bigResult.ToList();

            }

        }

        public static List<Equipment> Equipments(string num)
        {
            using (var db = new DbModel())
            {
                if (num == "")
                    return db.Equipments.Include("Status").Include("Mark")
                                        .Include("Responsible").Include("WhoUses")
                                        .Include("City").Include("denomination").ToList();
                return db.Equipments.Include("Status").Include("Mark")
                    .Include("Responsible").Include("WhoUses")
                    .Include("City").Include("denomination")
                    .Where(x => x.InventoryNumber == num || x.OldInventoryNumber == num).ToList();
            }
        }

        public static List<ChangeHistory> History()
        {
            using (var db = new DbModel())
            {
                var list =  db.History.ToList();
                db.History.RemoveRange(db.History);
                db.SaveChanges();
                return list;
            }
        }
    }
}
