using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DesktopApplication
{
    public class ConnectWithServer
    {
        const int port = 8888;
        const string address = "192.168.0.102";
        static TcpClient client = new TcpClient(address, port);
        public string Connect(string message)
        {
            try
            {
                NetworkStream stream = client.GetStream();

                // преобразуем сообщение в массив байтов
                byte[] data = Encoding.Unicode.GetBytes(message);
                // отправка сообщения
                stream.Write(data, 0, data.Length);

                // получаем ответ
                data = new byte[64]; // буфер для получаемых данных
                StringBuilder builder = new StringBuilder();
                int bytes = 0;
                do
                {
                    bytes = stream.Read(data, 0, data.Length);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                } while (stream.DataAvailable);

                return builder.ToString();
            }//try
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return "";
        }//end connect

        public string[] GetMarks()
        {
            var json = new JsonMessage { Type = "Marks" };
           
            return Connect(JsonConvert.SerializeObject(json)).Split(',');
        }

        public string[] GetDenominations()
        {
            var json = new JsonMessage { Type = "Denomination" };
            return Connect(JsonConvert.SerializeObject(json)).Split(',');
        }

        internal string[] GetEmployee()
        {
            var json = new JsonMessage {Type = "Employee"};
            return Connect(JsonConvert.SerializeObject(json)).Split(',');
        }

        public string[] GetCity()
        {
            
            var json = new JsonMessage { Type = "City" };
            return Connect(JsonConvert.SerializeObject(json)).Split(',');
        }

        public string SetInformation(Equipment information)
        {
            var list = new List<Equipment> {information};
            var json = new JsonMessage { Type = "AddEquipment", equipment = list};

            return Connect(JsonConvert.SerializeObject(json));
        }

        public List<Equipment> GetEquipments(string inventNum)
        {
            var json = new JsonMessage { Type = "GetEquipment", InventoryNumber = inventNum};
            var list = Connect(JsonConvert.SerializeObject(json));
            var items = JsonConvert.DeserializeObject<JsonMessage>(list);
            return items.equipment;

        }

        public string ChangeStatus(string inventNum, string status)
        {
            var json = new JsonMessage { Type = "ChangeStatus", InventoryNumber = inventNum,  NewStatus = status};
            return Connect(JsonConvert.SerializeObject(json));
        }
    }
    class JsonMessage
    {
        public string Type;
        public List<Equipment> equipment;
        public string InventoryNumber;
        public string NewStatus;
    }
}
