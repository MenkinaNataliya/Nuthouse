using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class JsonMessage
    {
        public string Type;
        public List<HistoryEquipment> History;
    }
    class HistoryEquipment
    {
        public string InventoryNumber;
        public string OldStatus;
        public string NewStatus;
    }

}
