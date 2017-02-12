using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    class EquipmentJson
    {
        public string InventoryNumber;
        public string OldInventoryNumber;
        public string Denomination;
        public string Mark;
        public string Model;
        public string Comment;
        public bool Modernization;
        public string Responsible;
        public string WhoUses;
        public string Status;
        public string City;
        public int Floor;
        public string Housing;
        public string Cabinet;
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
        public List<EquipmentJson> Equipment;
        public string InventoryNumber;
        public List<HistoryEquipment> History;
        public string NewStatus;
        public Report ReportFilter;

    }

    public class Report
    {
        public List<string> FilterCities;
        public List<string> FilterResponsibles;
        public List<string> FilterStatus;
        public List<string> FilterDenominations;
        public string FilterModernisation;
        public List<string> FilterMarks;

        public Report()
        {
            FilterCities = new List<string>();
            FilterResponsibles = new List<string>();
            FilterStatus = new List<string>();
            FilterDenominations = new List<string>();
            FilterMarks = new List<string>();
            FilterModernisation = "";
        }

    }

}
