using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using System.Reflection;
using DataBase;

namespace DesktopApplication
{
   
    public partial class Report : Form
    {
        List<DataBase.Equipment> _equips;


        public Report(DataBase.Report reportFilter)
        {
            InitializeComponent();
            InitializeForm(reportFilter);
        }
        public void InitializeForm(DataBase.Report reportFilter)
        {
           
            _equips = Get.Equipments(reportFilter);


            System.Data.DataTable t = new System.Data.DataTable();
            t.Columns.Add("Инвентарный номер");
            t.Columns.Add("Старый инвентарный номер");
            t.Columns.Add("Наименование");
            t.Columns.Add("Марка");
            t.Columns.Add("Расположение");
            t.Columns.Add("Ответственное лицо");
            t.Columns.Add("Статус");
            t.Columns.Add("Примечание");

            foreach(var equip in _equips)
            {
                var res = new Employee[1];
                res[0] = equip.Responsible;
                t.Rows.Add(equip.InventoryNumber, equip.OldInventoryNumber, equip.denomination.Naming,
                                equip.mark.Naming, equip.city.Naming + ", корпус " + equip.Housing + ", кабинет " + equip.Cabinet,Service.GetEmployeeString(res)[0],
                                equip.status.Naming, equip.Comment);
                
            }
            table.DataSource = t;
          
        }

        private void ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void print_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application ObjExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ObjWorkBook = ObjExcel.Workbooks.Add(Missing.Value);
            Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook.Sheets[1];

            ObjExcel.StandardFont = "Times New Roman";
            ObjExcel.StandardFontSize = 14;


            var excelcells = ObjWorkSheet.Range["C2", "F2"];
            excelcells.Merge(Type.Missing);
            excelcells.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            excelcells.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            excelcells.Font.Bold = true;

            //Выводим число
            excelcells.Value2 = "Отчет за " + DateTime.Now;

            //Значения [y - строка,x - столбец]
            ObjWorkSheet.Cells[5, 1] = "Инвентарный номер";
            ObjWorkSheet.Cells[5, 2] = "Старый инвентарный номер";
            ObjWorkSheet.Cells[5, 3] = "Наименование";
            ObjWorkSheet.Cells[5, 4] = "Марка - модель";
            ObjWorkSheet.Cells[5, 5] = "Расположение";
            ObjWorkSheet.Cells[5, 6] = "Ответственное лицо";
            ObjWorkSheet.Cells[5, 7] = "Статус";
            ObjWorkSheet.Cells[5, 8] = "Примечание";

            excelcells = ObjWorkSheet.Range["A5", "H5"];
            excelcells.Font.Bold = true;


            int j = 6;
            foreach (var equip in _equips)
            {
                var res = new Employee[1];
                res[0] = equip.Responsible;
                ObjWorkSheet.Cells[j, 1] = equip.InventoryNumber;
                ObjWorkSheet.Cells[j, 2] = equip.OldInventoryNumber;
                ObjWorkSheet.Cells[j, 3] = equip.denomination.Naming;
                ObjWorkSheet.Cells[j , 4] = equip.mark + " " + equip.model;
                ObjWorkSheet.Cells[j, 5] = equip.city.Naming;
                ObjWorkSheet.Cells[j , 6] = DataBase.Service.GetEmployeeString(res)[0];
                ObjWorkSheet.Cells[j , 7] = equip.status.Naming;
                ObjWorkSheet.Cells[j , 8] = equip.Comment;
                j++;
            }

            excelcells = ObjWorkSheet.get_Range("A5", "H"+(j-1));
            excelcells.Borders.ColorIndex = 1;
            excelcells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            excelcells.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

            ObjExcel.Visible = true;
            ObjExcel.UserControl = true;
        }
    }
}
