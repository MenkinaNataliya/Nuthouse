using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{

    public class Dictionary
    {
        [Display(Name = "Наименование")]
        public Denomination denomination { get; set; }
        [Display(Name = "Марка")]
        public Mark mark { get; set; }
        [Display(Name = "Новый сотрудник")]
        public Employee employee { get; set; }
    }


    public class Equipment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string InventoryNumber { get; set; }
        public string OldInventoryNumber { get; set; }
        public Denomination denomination { get; set; }
        public Mark mark { get; set; }
        public string model { get; set; }
        public string Comment{get;set;}
        public bool Modernization { get; set; }
        public Employee Responsible{ get; set; }
        public Employee WhoUses{ get; set; }
        public City city { get; set; }
        public int Floor { get; set; }
        public string Housing { get; set; }
        public string Cabinet { get; set; }
        public Status status { get; set; }
    }

    public class Employee
    {
        public ICollection<Equipment> equipments { get; set; }
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Отчество")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
    }


    public class City : BaseClass{   }

    public class Status: BaseClass {
        public ICollection<Equipment> equipments { get; set; }
    }
    public class Denomination : BaseClass {
        public ICollection<Equipment> equipments { get; set; }
    }
    public class Mark : BaseClass {
        public ICollection<Equipment> equipments { get; set; }
    }

   
    public class BaseClass
    {
       
        public int Id { get; set; }
        [Display(Name = "Название")]
        public string Naming { get; set; }
    }

    public class ChangeHistory
    {
        public int Id { get; set; }
        public string InventNumber { get; set; }
        public Status OldStatus { get; set; }
        public Status NewStatus { get; set; }
    }

    public class Users
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Логин")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }

   
}
