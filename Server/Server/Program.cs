using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace Server
{
    class Program
    {
        //В планировщике задач windows настроить ежемесячную задачу которая запускает эту программу раз в месяц
        static void Main(string[] args)
        {
            SendingStoriesInThePastMonth();
        }

        public static void SendingStoriesInThePastMonth()
        {
            var json = new JsonMessage { Type = "GetHistory" };
            var connect = new ConnectWithDB();
            var message = connect.Connect(JsonConvert.SerializeObject(json));
            if (message == "error")
            {
                System.Threading.Thread.Sleep(50000);
                SendingStoriesInThePastMonth();
                return;
            }
            json = JsonConvert.DeserializeObject<JsonMessage>(message);
            var messageBody = MessageBodyFormation(json.History);
            SendMail("smtp.gmail.com", "tasiamenkina@gmail.com", "14091974NatA", "tasiamenkina@gmail.com", "Передвижение оборудования за месяц", messageBody);
        }

        public static string MessageBodyFormation(List<HistoryEquipment> history )
        {
            string text = "Отчет по передвижению техники за "+ DateTime.Now+"\n";
            foreach (var item in history)
            {
                text += "Устройство " + item.InventoryNumber + " перешло из состояния " + item.OldStatus.ToUpper() +
                        " в состояние " + item.NewStatus.ToUpper() + "\n";
            }
            return text;
        }


       
        public static void SendMail(string smtpServer, string from, string password,
            string mailto, string caption, string message, string attachFile = null)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(new MailAddress(mailto));
                mail.Subject = caption;
                mail.Body = message;
                if (!string.IsNullOrEmpty(attachFile))
                    mail.Attachments.Add(new Attachment(attachFile));
                SmtpClient client = new SmtpClient();
                client.Host = smtpServer;
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(from.Split('@')[0], password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                mail.Dispose();
            }
            catch (Exception e)
            {
                throw new Exception("Mail.Send: " + e.Message);
            }
        }

 
    }
}
