﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Web;
using Newtonsoft.Json;

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

        public string GetHello()
        {
            var json = new JsonMessage {Type = "hello"};
            return Connect(JsonConvert.SerializeObject(json));
        }

    }
    class JsonMessage
    {
        public string Type;
        //public List<Equipment> equipment;
        public string InventoryNumber;
        public string NewStatus;
        public List<string> citiesFilters;
        public List<string> denominationFilter;
        public List<string> markFilter;
        public List<string> statusFilter;
        public List<string> responsibleFilter;
        public bool modernizationFilter;

    }
}