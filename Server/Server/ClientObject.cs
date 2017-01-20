using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataBase;
using Newtonsoft.Json;


namespace Server
{
    class ClientObject
    {
        public TcpClient client;

        public ClientObject(TcpClient tcpClient)
        {
            client = tcpClient;
        }

        public void Process()
        {
            NetworkStream stream = null;
            try
            {
                stream = client.GetStream();
                byte[] data = new byte[64]; // буфер для получаемых данных
                while (true)
                {
                    // получаем сообщение
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    } while (stream.DataAvailable);

                    string message = builder.ToString();

                    Console.WriteLine(message);
                    var jsonmsg = JsonConvert.DeserializeObject<JsonMessage>(message);
                    switch (jsonmsg.Type)
                    {
                        case "Marks": message = ArrayObjectToString(Get.Marks()); break;
                        case "Denomination": message = ArrayObjectToString(Get.Denominations()); break;
                        case "City": message = ArrayObjectToString(Get.City()); break;
                        case "Employee":
                            {
                                var list = DataBase.Get.Employee();
                                message = "";
                                foreach (var item in list)
                                {
                                    message += item.FirstName + " " + item.SecondName + " " + item.LastName + ",";
                                }
                                message.Remove(message.Length - 1);
                            }
                            break;
                        
                        case "AddEquipment":
                        {
                            var error = Service.AddEquipment(jsonmsg.equipment[0].InventoryNumber,
                                jsonmsg.equipment[0].OldInventoryNumber,
                                jsonmsg.equipment[0].denomination, jsonmsg.equipment[0].mark,
                                jsonmsg.equipment[0].model, jsonmsg.equipment[0].Status,
                                jsonmsg.equipment[0].Comment, jsonmsg.equipment[0].Modernization,
                                jsonmsg.equipment[0].Responsible, jsonmsg.equipment[0].WhoUses,
                                jsonmsg.equipment[0].City, jsonmsg.equipment[0].Housing, 
                                jsonmsg.equipment[0].Floor, jsonmsg.equipment[0].Cabinet);

                            message = error != "" ? error : "Данные добавлены успешно";
                        }
                            break;
                        case "GetEquipment":
                        {
                            var tmp = Get.Equipments(jsonmsg.InventoryNumber);
                            var list = TranslateEquipments(tmp);
                            //list = tmp.ConvertAll(new Converter<DataBase.Equipment, Equipment>(ConvertEquipment));
                            var json = new JsonMessage {equipment = list};

                            message = JsonConvert.SerializeObject(json);
                        }
                            break;
                        case "ChangeStatus": Service.ChangeStatus(jsonmsg.InventoryNumber, jsonmsg.NewStatus); break;

                    }
                    data = Encoding.Unicode.GetBytes(message);
                    stream.Write(data, 0, data.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
                if (client != null)
                    client.Close();
            }

        }

        private string ArrayObjectToString(BaseClass[] list)
        {
            string message = "";
            foreach (var item in list)
            {
                message += item.Naming + ",";
            }
            return message.Remove(message.Length - 1);
        }

        private static List<Equipment> TranslateEquipments(List<DataBase.Equipment> equipments)
        {
            var res = new List<Equipment>();
            foreach (var eq in equipments)
            {
                var t = new Equipment
                {
                    InventoryNumber = eq.InventoryNumber,
                    OldInventoryNumber = eq.OldInventoryNumber,
                    denomination = eq.denomination.Naming,
                    mark = eq.mark.Naming,
                    model = eq.model,
                    Comment = eq.Comment,
                    Modernization = eq.Modernization,
                    Responsible = eq.Responsible.SecondName + " " + eq.Responsible.FirstName + " " + eq.Responsible.LastName,
                    WhoUses = eq.WhoUses.SecondName + " " + eq.WhoUses.FirstName + " " + eq.WhoUses.LastName,
                    Status = eq.status.Naming,
                    City = eq.city.Naming,
                    Floor = eq.Floor,
                    Housing = eq.Housing,
                    Cabinet = eq.Cabinet
                };
                res.Add(t);
            }
            return res;
        }
    }
}
