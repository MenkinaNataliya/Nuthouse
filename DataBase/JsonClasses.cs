using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    class EquipmentJson
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
        public string Status { get; set; }//
        public string City { get; set; }
        public int Floor { get; set; }
        public string Housing { get; set; }
        public string Cabinet { get; set; }
    }

    class HistoryEquipment
    {
        public string InventoryNumber;
        public string OldStatus;
        public string NewStatus;
    }

    class JsonMessage
    {
        public string Type;
        public List<EquipmentJson> equipment;
        public string InventoryNumber;
        public List<HistoryEquipment> History;
        public string OldStatus;
        public List<string> citiesFilters;
        public List<string> denominationFilter;
        public List<string> markFilter;
        public List<string> statusFilter;
        public List<string> responsibleFilter;
        public bool modernizationFilter;
    }

}
