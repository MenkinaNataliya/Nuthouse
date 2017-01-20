using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApplication
{
    public partial class Equipments : Form
    {
        public Equipments()
        {
            InitializeComponent();
        }

        private void Equipments_Load(object sender, EventArgs e)
        {
            //var equipments = ServerApp.Controller.GetEquipments("");
            ConnectWithServer connect = new ConnectWithServer();
            var equipments = connect.GetEquipments("");
            DataTable t = new DataTable();
            t.Columns.Add("Инвентарный номер");
            t.Columns.Add("Старый инвентарный номер");
            t.Columns.Add("Наименование");
            t.Columns.Add("Марка");
            t.Columns.Add("Расположение");
            t.Columns.Add("Ответственное лицо");
            t.Columns.Add("Кто использует");
            t.Columns.Add("Статус");
            t.Columns.Add("Примечание");

            foreach (var equip in equipments)
            {
                t.Rows.Add(equip.InventoryNumber, equip.OldInventoryNumber, equip.denomination,
                                equip.mark, equip.City + "" + equip.Housing, equip.Responsible, equip.WhoUses,
                                equip.Status, equip.Comment);

            }
            table.DataSource = t;
        }

    }
}
