using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using System.Reflection;

namespace DesktopApplication
{
   
    public partial class Report : Form
    {
        List<Equipment> equips;


        public Report(List<string> citiesFilters, List<string> denominationFilter, List<string> markFilter, List<string> statusFilter, List<string> responsibleFilter, bool modernizationFilter)
        {
            InitializeComponent();
            InitializeForm(citiesFilters, denominationFilter, markFilter, statusFilter, responsibleFilter, modernizationFilter);
        }
        public void InitializeForm(List<string> citiesFilters, List<string> denominationFilter, List<string> markFilter, List<string> statusFilter, List<string> responsibleFilter, bool modernizationFilter)
        {
            ConnectWithServer connect = new ConnectWithServer();
            equips = connect.GetReport(citiesFilters, denominationFilter, markFilter, statusFilter, responsibleFilter, modernizationFilter);


            System.Data.DataTable t = new System.Data.DataTable();
            t.Columns.Add("Инвентарный номер");
            t.Columns.Add("Старый инвентарный номер");
            t.Columns.Add("Наименование");
            t.Columns.Add("Марка");
            t.Columns.Add("Расположение");
            t.Columns.Add("Ответственное лицо");
            t.Columns.Add("Статус");
            t.Columns.Add("Примечание");

            foreach(var equip in equips)
            {
                t.Rows.Add(equip.InventoryNumber, equip.OldInventoryNumber, equip.denomination,
                                equip.mark, equip.City + "" + equip.Housing, equip.Responsible,
                                equip.Status, equip.Comment);
                
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


            Microsoft.Office.Interop.Excel.Range excelcells = ObjWorkSheet.get_Range("C2", "F2");
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

            excelcells = ObjWorkSheet.get_Range("A5", "H5");
            excelcells.Font.Bold = true;


            int j = 6;
            foreach (var equip in equips)
            {
                ObjWorkSheet.Cells[j, 1] = equip.InventoryNumber;
                ObjWorkSheet.Cells[j, 2] = equip.OldInventoryNumber;
                ObjWorkSheet.Cells[j, 3] = equip.denomination;
                ObjWorkSheet.Cells[j , 4] = equip.mark + " " + equip.model;
                ObjWorkSheet.Cells[j, 5] = equip.City;
                ObjWorkSheet.Cells[j , 6] = equip.Responsible;
                ObjWorkSheet.Cells[j , 7] = equip.Status;
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
