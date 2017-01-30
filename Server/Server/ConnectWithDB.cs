using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;


namespace Server
{
    public class ConnectWithDB
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

            return "error";
        }//end connect

       

    }
}
