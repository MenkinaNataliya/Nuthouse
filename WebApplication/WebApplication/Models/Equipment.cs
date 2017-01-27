using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Equipment
    {
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Инвентарный номер")]
        public string InventoryNumber { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Старый инвентарный номер")]
        public string OldInventoryNumber { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Наменование")]
        public string Denomination { get; set; }///

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Марка")]
        public string Mark { get; set; }///

        
        [Display(Name = "Модель")]
        public string Model { get; set; }


        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Статус")]
        public string Status { get; set; }//

        [Display(Name = "Получено по программе модернизации")]
        public bool Modernization { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Город")]
        public string City { get; set; }


        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Корпус")]
        public string Housing { get; set; }


        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Этаж")]
        public int Floor { get; set; }


        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Кабинет")]
        public string Cabinet { get; set; }


        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Кто ответственный (ФИО)")]
        public string Responsible { get; set; }//


        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Кто пользуется (ФИО)")]
        public string WhoUses { get; set; }//

        [Display(Name = "Комментарии")]
        public string Comment { get; set; }
       
      
        
       
        
    }
}