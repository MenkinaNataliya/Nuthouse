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
    public partial class ChangeStatus : Form
    {
        public ChangeStatus()
        {
            InitializeComponent();
        }

        private void сгенерироватьОтчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            var generate = new GenerateReports();
            generate.Activate();

            generate.ShowDialog();
        }

        private void добавитьОборудованиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ErrInventNumber.Text == "")
            {
                this.Close();
                var change = new ChangeStatusEquipment(InventNum.Text);
                change.Activate();

                change.ShowDialog();
            }
            
           
        }

        private void InventNum_Validating(object sender, CancelEventArgs e)
        {
            if (InventNum.Text == string.Empty)
            {
                ErrInventNumber.Text = "Поле должно быть заполнено";
                return;
            }
        }

        private void ChangeStatus_Load(object sender, EventArgs e)
        {
            ErrInventNumber.Text = "";
        }
    }
}
