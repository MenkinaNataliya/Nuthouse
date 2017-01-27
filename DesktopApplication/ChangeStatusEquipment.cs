using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using Microsoft.Office.Interop.Word;

using System.Reflection;

namespace DesktopApplication
{
    public partial class ChangeStatusEquipment : Form
    {
        public ChangeStatusEquipment(string inventNum)
        {
            InitializeComponent();
            InitializeForm(inventNum);
        }

        private void InitializeForm(string inventNum)
        {
            var connect = new ConnectWithServer();

            var equipments = connect.GetEquipments(inventNum);

            if (equipments.Count == 0 || equipments == null) error.Text = "Данные не найдены";

            else
            {
                table.Columns.Add("InventNum", "Инвентарный номер");
                table.Columns.Add("OldInventNum", "Старый инвентарный номер");
                table.Columns.Add("Denomination", "Наименование");
                table.Columns.Add("Mark", "Марка");
                table.Columns.Add("Site", "Расположение");
                table.Columns.Add("Respon", "Ответственное лицо");
                table.Columns.Add("CurStatus", "Текущий статус");
                DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
                combo.HeaderText = "Изменить на";
                combo.Name = "status";
                combo.Items.Add("В работе");
                combo.Items.Add("В ремонте");
                combo.Items.Add("Списано");


                table.Columns.Add(combo);
                table.Columns.Add("Comment", "Примечание");

                DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                button.HeaderText = "Изменить";
                button.Text = "Изменить";

                table.Columns.Add(button);

                foreach (var equip in equipments)
                {
                    table.Rows.Add(equip.InventoryNumber, equip.OldInventoryNumber,
                                    equip.denomination, equip.mark, 
                                    equip.City+" "+" "+equip.Housing,
                                    equip.Responsible, equip.Status, "", equip.Comment, "");
                }
            }
        }


        private void table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 9)
            {

                var rows = table.Rows[e.RowIndex];
                if (rows.Cells[7].Value.ToString() == "") MessageBox.Show("Выберите новый статус");
                else
                {
                    var connect = new ConnectWithServer();

                    
                    connect.ChangeStatus(rows.Cells[0].Value.ToString(), rows.Cells[7].Value.ToString());
                    if(rows.Cells[7].Value.ToString() == "Списано")
                        GenerateDefect(rows.Cells[0].Value.ToString(), rows.Cells[2].Value.ToString(), rows.Cells[5].Value.ToString(), rows.Cells[4].Value.ToString());
                    MessageBox.Show("Данные успешно измененны");
                    this.Close();
                }
            }
           
        }


        private static void GenerateDefect(string inventnumber, string denomination, string responsible, string place)
        {
            Microsoft.Office.Interop.Word.Application application = new Microsoft.Office.Interop.Word.Application();
            Object missingObj = Missing.Value;
            Object templatePathObj = "C:/Users/Наталия/Documents/Учеба/Nuthouse/DesktopApplication/templateDefect.docx";
            Document document = application.Documents.Add(ref templatePathObj, ref missingObj, ref missingObj, ref missingObj);


            var name = responsible.Split(' ');
            string resp = name[0] + " " + name[1][0] + ". " + name[2][0] + ".";
            object findPlace = "%%place%%";
            object findNumber = "%%inventnumber%%";
            object findDenomination = "%%denomination%%";
            object findResponsible = "%%responsible%%";

            // диапазон документа Word
            Range wordRange;
            //тип поиска и замены
            object replaceTypeObj;
            replaceTypeObj = WdReplace.wdReplaceAll;
            // обходим все разделы документа
            for (int i = 1; i <= document.Sections.Count; i++)
            {
                // берем всю секцию диапазоном
                wordRange = document.Sections[i].Range;

                Find wordFindObj = wordRange.Find;
                object[] wordFindParameters = new object[15] { findPlace, missingObj, missingObj, missingObj,
                                                               missingObj,missingObj, missingObj, missingObj,
                                                               missingObj, place, replaceTypeObj,
                                                               missingObj, missingObj, missingObj, missingObj };

                wordFindObj.GetType().InvokeMember("Execute", BindingFlags.InvokeMethod, null, wordFindObj, wordFindParameters);

                wordFindParameters = new object[15] { findNumber, missingObj, missingObj, missingObj,
                                                               missingObj,missingObj, missingObj, missingObj,
                                                               missingObj, inventnumber, replaceTypeObj,
                                                               missingObj, missingObj, missingObj, missingObj };
                wordFindObj.GetType().InvokeMember("Execute", BindingFlags.InvokeMethod, null, wordFindObj, wordFindParameters);

                wordFindParameters = new object[15] { findDenomination, missingObj, missingObj, missingObj,
                                                               missingObj,missingObj, missingObj, missingObj,
                                                               missingObj, denomination, replaceTypeObj,
                                                               missingObj, missingObj, missingObj, missingObj };
                wordFindObj.GetType().InvokeMember("Execute", BindingFlags.InvokeMethod, null, wordFindObj, wordFindParameters);

                wordFindParameters = new object[15] { findResponsible, missingObj, missingObj, missingObj,
                                                               missingObj,missingObj, missingObj, missingObj,
                                                               missingObj, resp, replaceTypeObj,
                                                               missingObj, missingObj, missingObj, missingObj };
                wordFindObj.GetType().InvokeMember("Execute", BindingFlags.InvokeMethod, null, wordFindObj, wordFindParameters);
            }


            application.Visible = true;
        }
    }
}


