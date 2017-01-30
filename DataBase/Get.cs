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
            using (DbModel db = new DbModel())
            {
                return db.Denominations.ToArray();
            }
        }
        public static Mark[] Marks()
        {
            using (DbModel db = new DbModel())
            {
                return db.Marks.ToArray();
            }
        }

        public static City[] City()
        {
            using (DbModel db = new DbModel())
            {
                return db.city.ToArray();
            }
        }

        public static Employee[] Employee()
        {
            using (DbModel db = new DbModel())
            {
                return db.Employees.ToArray();
            }
        }

        public static List<Equipment> EquipmentsOfModernization()
        {
            using (DbModel db = new DbModel())
            {
                return db.Equipments.Where(x => x.Modernization == true).ToList();
            }
        }

        public static Status[] AllStatus()
        {
            using (DbModel db = new DbModel())
            {
                return db.status.ToArray();
            }
        }

        public static List<Equipment> Equipments(List<string> citiesFilters, List<string> denominationFilter,
                                                    List<string> markFilter, List<string> statusFilter,
                                                    List<string> responsibleFilter, bool modernizationFilter)
        {
            using (DbModel db = new DbModel())
            {

                var bigResult = db.Equipments.Include("Status").Include("Mark")
                                .Include("Responsible").Include("WhoUses")
                                .Include("City").Include("denomination")
                                .AsQueryable();
                if (modernizationFilter != false)
                    bigResult = bigResult.Where(x => x.Modernization == modernizationFilter);
                if (citiesFilters.Count != 0)
                    bigResult = bigResult.Where(x => citiesFilters.Any(y => y == x.city.Naming));
                if (denominationFilter.Count != 0)
                    bigResult = bigResult.Where(x => denominationFilter.Any(y => y == x.denomination.Naming));
                if (markFilter.Count != 0)
                    bigResult = bigResult.Where(x => markFilter.Any(y => y == x.mark.Naming));
                if (statusFilter.Count != 0)
                    bigResult = bigResult.Where(x => statusFilter.Any(y => y == x.status.Naming));
                if (responsibleFilter.Count != 0)
                    bigResult = bigResult.Where(x => responsibleFilter.Any(y => y == (x.Responsible.SecondName + " " + x.Responsible.FirstName + " " + x.Responsible.LastName)));
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
                else
                    return db.Equipments.Include("Status").Include("Mark")
                                .Include("Responsible").Include("WhoUses")
                                .Include("City").Include("denomination")
                                .Where(x => x.InventoryNumber == num || x.OldInventoryNumber == num).ToList();
            }
        }

        public static List<ChangeHistory> History()
        {
            using (DbModel db = new DbModel())
            {
                var list =  db.History.ToList();
                db.History.RemoveRange(db.History);
                db.SaveChanges();
                return list;
            }
        }
    }
}
