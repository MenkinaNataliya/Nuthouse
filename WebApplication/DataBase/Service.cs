using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace DataBase
{
    public class Service
    {

        public static string AddDictionary(Dictionary dict)
        {
            if(dict.denomination!= null)
            {
                return CheckDenomination(dict.denomination.Naming);
            }
            if (dict.mark != null)
            {
                return CheckMark(dict.mark.Naming);
            }
            if (dict.employee != null)
            {
                return CheckEmploy(dict.employee);
            }
            return "Введите данные";

        }


        public static string AddEquipment(Equipment equip)
        {
            using (var db = new DbModel())
            {
                if (db.Equipments.Find(equip.InventoryNumber) != null || db.Equipments.Where(x => x.OldInventoryNumber == equip.InventoryNumber).ToList().Count != 0)
                    return "Устройство с таким инвентарным номером уже существует";

                CheckDenomination(equip.denomination.Naming);
                CheckMark(equip.mark.Naming);
                CheckEmploy(equip.Responsible);
                CheckEmploy(equip.WhoUses);

                var res = new Equipment
                {
                    InventoryNumber = equip.InventoryNumber,
                    OldInventoryNumber = equip.OldInventoryNumber,
                    model = equip.model,
                    Comment = equip.Comment,
                    Modernization = equip.Modernization,
                    denomination = db.Denominations.FirstOrDefault(x => x.Naming == equip.denomination.Naming),
                    mark = db.Marks.FirstOrDefault(x => x.Naming == equip.mark.Naming),
                    Responsible = db.Employees.FirstOrDefault(x => x.FirstName == equip.Responsible.FirstName && x.SecondName == equip.Responsible.SecondName && x.LastName == equip.Responsible.LastName),
                    WhoUses = db.Employees.FirstOrDefault(x => x.FirstName == equip.WhoUses.FirstName && x.SecondName == equip.WhoUses.SecondName && x.LastName == equip.WhoUses.LastName),
                    city = db.city.FirstOrDefault(x => x.Naming == equip.city.Naming),
                    Floor = equip.Floor,
                    Housing = equip.Housing,
                    Cabinet = equip.Cabinet,
                    status = db.status.FirstOrDefault(x => x.Naming == equip.status.Naming)
                };
                db.Equipments.Add(res);
                db.SaveChanges();
                return "Данные добавлены успешно";
            }
        }

        public static string ChangeStatus(string number, string newStatus)
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
                return "Данные изменены успешно";
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

        private static string CheckDenomination(string denomination)
        {
            using (var db = new DbModel())
            {
                var tmp = db.Denominations.FirstOrDefault(x => x.Naming == denomination);
                if (tmp != null) return "Такое наименование уже существует";
                db.Denominations.Add(new Denomination
                {
                    Naming = denomination
                });
                db.SaveChanges();
                return "OK";
            }
        }
        private static string CheckMark(string mark)
        {
            using (var db = new DbModel())
            {
                if (db.Marks.FirstOrDefault(x => x.Naming == mark) != null) return "Такая марка уже существует";
                db.Marks.Add(new Mark
                {
                    Naming = mark
                });
                db.SaveChanges();
                return "OK";
            }
        }
        private static string CheckEmploy(Employee employ)
        {
            using (var db = new DbModel())
            {
                if (
                    db.Employees.FirstOrDefault(x => x.SecondName == employ.SecondName && x.LastName == employ.LastName && x.FirstName == employ.FirstName) !=
                    null) return "Такой сотрудник уже существует";
                db.Employees.Add(new Employee
                {
                    FirstName = employ.FirstName,
                    SecondName = employ.SecondName,
                    LastName = employ.LastName
                });
                db.SaveChanges();
                return "OK";
            }
        }

        public static string CheckUser(Users user)
        {
            using (var db = new DbModel())
            {
                var dbuser = db.Users.First(x => x.UserName == user.UserName);
                if (dbuser == null) return "Неверное имя пользователя или пароль";
                return dbuser.Password == GetHashString(user.Password + user.UserName) ? "ok" : "Неверное имя пользователя или пароль";
            }
        }

        private static  string GetHashString(string s)
        {
        //переводим строку в байт-массим  
            var bytes = Encoding.Unicode.GetBytes(s);

            //создаем объект для получения средст шифрования  
            var CSP =new MD5CryptoServiceProvider();

            //вычисляем хеш-представление в байтах  
            var byteHash = CSP.ComputeHash(bytes);

            var hash = string.Empty;

            //формируем одну цельную строку из массива  
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return hash;
        }

}
}
