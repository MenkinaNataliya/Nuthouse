using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApplication
{
    public class ReportJson
    {
            public List<string> FilterCities;
            public List<string> FilterResponsibles;
            public List<string> FilterStatus;
            public List<string> FilterDenominations;
            public string FilterModernisation;
            public List<string> FilterMarks;

        public ReportJson()
        {
            FilterCities = new List<string>();
            FilterResponsibles = new List<string>();
            FilterDenominations = new List<string>();
            FilterStatus = new List<string>();
            FilterModernisation = "";
            FilterMarks = new List<string>();
        }

    }
}
