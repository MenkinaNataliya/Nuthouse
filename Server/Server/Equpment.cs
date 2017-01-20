using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Equipment
    {
        public string InventoryNumber { get; set; }
        public string OldInventoryNumber { get; set; }
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
