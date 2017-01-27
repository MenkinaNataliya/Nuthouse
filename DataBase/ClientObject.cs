using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

    class JsonMessage
    {
        public string Type;
        public List<EquipmentJson> equipment;
        public string InventoryNumber;
        public string NewStatus;
        public List<string> citiesFilters;
        public List<string> denominationFilter;
        public List<string> markFilter;
        public List<string> statusFilter;
        public List<string> responsibleFilter;
        public bool modernizationFilter;
    }


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
                                var list = Get.Employee();
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
                                var error = Service.AddEquipment(Translate(jsonmsg.equipment[0]));

                                message = error == "" ? "Данные добавлены успешно" : "Устройство с таким инвентарным номером уже существует";
                            }
                            break;
                        case "GetEquipment":
                            {
                                var list = Get.Equipments(jsonmsg.InventoryNumber);
                                
                                var json = new JsonMessage { equipment = list.ConvertAll(new Converter<Equipment, EquipmentJson>(TranslateJson)) };

                                message = JsonConvert.SerializeObject(json);
                            }
                            break;
                        case "ChangeStatus": Service.ChangeStatus(jsonmsg.InventoryNumber, jsonmsg.NewStatus); break;
                        case "GetReport":
                            {
                                var list = Get.Equipments(jsonmsg.citiesFilters, jsonmsg.denominationFilter,
                                    jsonmsg.markFilter, jsonmsg.statusFilter, jsonmsg.responsibleFilter,
                                    jsonmsg.modernizationFilter);
                                
                                var json = new JsonMessage { equipment = list.ConvertAll(new Converter<Equipment, EquipmentJson>(TranslateJson)) };

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

        private static EquipmentJson TranslateJson(Equipment eq)
        {
            return new EquipmentJson
            {
                InventoryNumber = eq.InventoryNumber,
                OldInventoryNumber = eq.OldInventoryNumber,
                denomination = eq.denomination.Naming,
                mark = eq.mark.Naming,
                model = eq.model,
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
                    denomination = new Denomination { Naming = eq.denomination},
                    mark =new Mark {Naming =  eq.mark},
                    model = eq.model,
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
