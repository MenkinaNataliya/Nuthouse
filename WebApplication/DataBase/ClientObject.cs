using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DataBase
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
                    var builder = new StringBuilder();
                    var bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    } while (stream.DataAvailable);

                    var message = builder.ToString();

                    Console.WriteLine(message);
                    var jsonmsg = JsonConvert.DeserializeObject<JsonMessage>(message);
                    switch (jsonmsg.Type)
                    {
                        case "GetHistory":
                        {
                            var list = Get.History();

                            var json = new JsonMessage {History = new List<HistoryEquipment>()};
                            foreach (var item in list)
                            {
                                var equip = new HistoryEquipment
                                {
                                    InventoryNumber = item.InventNumber,
                                    NewStatus = item.NewStatus.Naming,
                                    OldStatus = item.OldStatus.Naming
                                };
                                json.History.Add(equip);
                            }

                            message = JsonConvert.SerializeObject(json);
                        }
                            break;
                        case "Marks":
                            message = ArrayObjectToString(Get.Marks());
                            break;
                        case "Denomination":
                            message = ArrayObjectToString(Get.Denominations());
                            break;
                        case "City":
                            message = ArrayObjectToString(Get.City());
                            break;
                        case "Employee":
                        {
                            var list = Get.Employee();
                            message = "";
                            foreach (var item in list)
                            {
                                message += item.LastName + " "+ item.FirstName + " " + item.SecondName + ",";
                            }
                            message.Remove(message.Length - 1);
                        }
                            break;
                        case "AddEquipment":
                        {
                            var error = Service.AddEquipment(Translate(jsonmsg.Equipment[0]));

                            message = error == ""
                                ? "Данные добавлены успешно"
                                : "Устройство с таким инвентарным номером уже существует";
                        }
                            break;
                        case "GetEquipment":
                        {
                            var list = Get.Equipments(jsonmsg.InventoryNumber);

                            var json = new JsonMessage {Equipment = list.ConvertAll(TranslateJson)};

                            message = JsonConvert.SerializeObject(json);
                        }
                            break;
                        case "ChangeStatus":
                            Service.ChangeStatus(jsonmsg.InventoryNumber, jsonmsg.NewStatus);
                            break;
                        case "GetReport":
                        {
                            var list = Get.Equipments(jsonmsg.ReportFilter);

                            var json = new JsonMessage {Equipment = list.ConvertAll(TranslateJson)};

                            message = JsonConvert.SerializeObject(json);
                        }
                            break;
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
                stream?.Close();
                client?.Close();
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

        private static EquipmentJson TranslateJson(Equipment eq)
        {
            return new EquipmentJson
            {
                InventoryNumber = eq.InventoryNumber,
                OldInventoryNumber = eq.OldInventoryNumber,
                Denomination = eq.denomination.Naming,
                Mark = eq.mark.Naming,
                Model = eq.model,
                Comment = eq.Comment,
                Modernization = eq.Modernization,
                Responsible = eq.Responsible.LastName+" " + eq.Responsible.FirstName+" "+eq.Responsible.SecondName ,
                WhoUses = eq.WhoUses.LastName + " " + eq.WhoUses.FirstName + " " + eq.WhoUses.SecondName,
                Status =  eq.status.Naming ,
                City = eq.city.Naming,
                Floor = eq.Floor,
                Housing = eq.Housing,
                Cabinet = eq.Cabinet
            };
        }


        private static Equipment Translate(EquipmentJson eq)
        {
            var resp = eq.Responsible.Split(' ');
            var who = eq.WhoUses.Split(' ');
            return new Equipment
                {
                    InventoryNumber = eq.InventoryNumber,
                    OldInventoryNumber = eq.OldInventoryNumber,
                    denomination = new Denomination { Naming = eq.Denomination},
                    mark =new Mark {Naming =  eq.Mark},
                    model = eq.Model,
                    Comment = eq.Comment,
                    Modernization = eq.Modernization,
                    Responsible = new Employee { LastName = resp[0], FirstName = resp[1], SecondName = resp[2]},
                    WhoUses = new Employee { LastName = who[0], FirstName = who[1], SecondName = who[2] },
                    status = new Status{Naming = eq.Status},
                    city = new City{Naming = eq.City},
                    Floor = eq.Floor,
                    Housing = eq.Housing,
                    Cabinet = eq.Cabinet
                };

        }
    }
}
