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
    public partial class GenerateReports : Form
    {
        public GenerateReports()
        {
            InitializeComponent();
        }

        private void добавитьОборудованиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void изменитьСтатусToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            var change = new ChangeStatus();
            change.Activate();

            change.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();


            var citiesFilters = new List<string>();
            foreach (var city in Cities.CheckedItems)
            {
                citiesFilters.Add(city.ToString());
            }

            var denominationFilter = new List<string>();
            foreach (var denom in Denominations.CheckedItems)
            {
                denominationFilter.Add(denom.ToString());
            }

            var markFilter = new List<string>();
            foreach (var mark in Marks.CheckedItems)
            {
                markFilter.Add(mark.ToString());
            }

            var statusFilter = new List<string>();
            foreach (var status in Status.CheckedItems)
            {
                statusFilter.Add(status.ToString());
            }

            var responsibleFilter = new List<string>();
            foreach (var resp in Responsible.CheckedItems)
            {
                responsibleFilter.Add(resp.ToString());
            }

         
            var modernizationFilter = Modernisation.Checked;

            var report = new Report(citiesFilters, denominationFilter, markFilter, statusFilter, responsibleFilter, modernizationFilter);
            report.Activate();

            report.ShowDialog();
        }

        private void GenerateReports_Load(object sender, EventArgs e)
        {
            ConnectWithServer connect = new ConnectWithServer();
            Cities.Items.Add("Копейск");
            Cities.Items.Add("Челябинск");
            Denominations.Items.AddRange(connect.GetDenominations());
            Responsible.Items.AddRange(connect.GetEmployee());
            Status.Items.Add("В работе");
            Status.Items.Add("В ремонте");
            Status.Items.Add("Списано");
            Marks.Items.AddRange(connect.GetMarks());

        }

    }
}
