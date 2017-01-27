using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApplication
{
    public class Equipment
    {
        [Display(Name = "Инвентарный номер")]
        public virtual string InventoryNumber { get; set; }
        [Display(Name = "Старый инвентарный номер")]
        public virtual  string OldInventoryNumber { get; set; }
        public string denomination { get; set; }///
        public string mark { get; set; }///
        public string model { get; set; }

        public string Comment { get; set; }
        public bool Modernization { get; set; }
        public string Responsible { get; set; }//
        public string WhoUses { get; set; }//
        //public string InstallationSite { get; set; }//
        public string Status { get; set; }//
        public string City { get; set; }
        public int Floor { get; set; }
        public string Housing { get; set; }
        public string Cabinet { get; set; }
    }
}
