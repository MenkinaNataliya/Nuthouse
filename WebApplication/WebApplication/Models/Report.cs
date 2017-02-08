using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Report
    {
        [Display(Name = "Города")]
        public List<string> FilterCities { get; set; }

        [Display(Name = "Кто ответственный (ФИО)")]
        public List<string> FilterResponsibles { get; set; }

        [Display(Name = "Статусы")]
        public List<string> FilterStatus { get; set; }

        [Display(Name = "Наименования")]
        public List<string> FilterDenominations { get; set; }

        [Display(Name = "Прграмма модернизации")]
        public string FilterModernisation { get; set; }

        [Display(Name = "Марки")]
        public List<string> FilterMarks { get; set; }

    }
}