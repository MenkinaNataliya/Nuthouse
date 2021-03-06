﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ConnectWithServer
    {
        const int port = 8888;
        const string address = "192.168.0.103";
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
                data = new byte[1024]; // буфер для получаемых данных
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

        public string GetHello()
        {
            var json = new JsonMessage {Type = "hello"};
            return Connect(JsonConvert.SerializeObject(json));
        }
        public string SetInformation(Equipment information)
        {
            var list = new List<Equipment> { information };
            var json = new JsonMessage { Type = "AddEquipment", Equipment = list };

            return Connect(JsonConvert.SerializeObject(json));
        }
        public List<Equipment> GetEquipments(string inventNum)
        {
            var json = new JsonMessage { Type = "GetEquipment", InventoryNumber = inventNum };
            var list = Connect(JsonConvert.SerializeObject(json));
            var items = JsonConvert.DeserializeObject<JsonMessage>(list);
            return items.Equipment;

        }

        public string ChangeStatus(string inventNum, string status)
        {
            var json = new JsonMessage { Type = "ChangeStatus", InventoryNumber = inventNum, NewStatus = status };
            return Connect(JsonConvert.SerializeObject(json));
        }

        public List<Equipment> GetReport(Report report)
        {
            var json = new JsonMessage
            {
                Type = "GetReport",
                ReportFilters = report
            };
            var list = Connect(JsonConvert.SerializeObject(json));
            var items = JsonConvert.DeserializeObject<JsonMessage>(list);
            return items.Equipment;
        }

        public string[] Get(string type)
        {

            var json = new JsonMessage { Type = type };
            return Connect(JsonConvert.SerializeObject(json)).Split(',');
        }

    }
    class JsonMessage
    {

        public string Type;
        public List<Equipment> Equipment;
        public string InventoryNumber;
       // public List<HistoryEquipment> History;
        public string NewStatus;
        public Report ReportFilters;
        
    }
}