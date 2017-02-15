using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBase;

namespace DesktopApplication
{
    public partial class AddEquipment : Form
    {
        public AddEquipment()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
           // ConnectWithServer connect = new ConnectWithServer();
            ErrModel.Text = ErrMark.Text = ErrDenomination.Text = OldInventNumber.Text =
                ErrOldInventNumber.Text = ErrInventNumber.Text = InventNumber.Text = Model.Text =
                    ErrCabinet.Text = ErrCity.Text = ErrComment.Text = ErrFloor.Text = ErrHousing.Text = Housing.Text =
                        ErrRespPerson.Text = ErrWhoUses.Text = ErrStatus.Text = Cabinet.Text = "";

            Mark.Text = @"Выберите марку";
            Mark.Items.Clear();
            Mark.Items.AddRange(Get.Marks());

            Denomination.Text = "Выберите наименование";
            Denomination.Items.Clear();
            Denomination.Items.AddRange(Get.Denominations());

            Status.Text = "Выберите статус";
            Status.Items.Clear();
            Status.Items.Add("В работе");
            Status.Items.Add("В ремонте");
            Status.Items.Add("Списано");

            var Employee = Get.Employee();
            WhoUses.Text = "Выберите кто пользуется оборудованием";
            WhoUses.Items.Clear();
            WhoUses.Items.AddRange(Employee);
            
            ResponsiblePerson.Text = "Выберите ответственное лицо";
            ResponsiblePerson.Items.Clear();
            ResponsiblePerson.Items.AddRange(Employee);

            City.Text = "Выберите город";
            City.Items.Clear();
            City.Items.AddRange(Get.City());

            Floor.Text = "Выберите этаж";
            Floor.Items.Clear();
            Floor.Items.AddRange(new object[] { "1", "2", "3", "4" });

        }

        private void изменитьСтатусToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var change = new ChangeStatus();
            change.Activate();

            change.ShowDialog();
        }

        private void сгенерироватьОтчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var generate = new GenerateReports();
            generate.Activate();

            generate.ShowDialog();
        }

        private void посмотретьВсеОборудованиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var showAll = new Equipments();
            showAll.Activate();
            showAll.ShowDialog();
        }

        private void Add_Click(object sender, EventArgs e)
        {
           if(  Status.SelectedIndex != -1 && ErrModel.Text == "" && ErrMark.Text == "" && ErrDenomination.Text == "" && 
                ErrOldInventNumber.Text == "" && ErrInventNumber.Text == "" &&
                InventNumber.Text != "" && Housing.Text!="")
            {
                string oldNum;
                if (OldInventNumber.Text == "") oldNum ="";
                else oldNum = OldInventNumber.Text;

                var equipm = new Equipment
                {
                    InventoryNumber = InventNumber.Text,
                    OldInventoryNumber = oldNum.ToString(),
                    mark = (Mark.SelectedIndex == -1 ? Mark.Text : Mark.SelectedItem.ToString()),
                    model = Model.Text,
                    Status = Status.SelectedItem.ToString(),
                    Comment = Comment.Text,
                    City = City.SelectedItem.ToString(),
                    denomination =
                        (Denomination.SelectedIndex == -1 ? Denomination.Text : Denomination.SelectedItem.ToString()),
                    Housing = Housing.Text,
                    Floor = Int32.Parse(Floor.SelectedItem.ToString()),
                    Cabinet = Cabinet.Text,
                    Responsible = (ResponsiblePerson.SelectedIndex == -1
                        ? ResponsiblePerson.Text
                        : ResponsiblePerson.SelectedItem.ToString()),
                    WhoUses = (WhoUses.SelectedIndex == -1 ? WhoUses.Text : WhoUses.SelectedItem.ToString()),
                    Modernization = Modernization.Checked
                };


                var error = Service.AddEquipment(TranslateDbEquipment(equipm));
                if (error == "Данные добавлены успешно")
                {
                   
                    MessageBox.Show("Устройство добавлено успешно");
                    InitializeForm();
                }
                else
                {
                    MessageBox.Show(error);
                }

            }
            else MessageBox.Show("Данные введены неверно");
        }

        private void OldInventNumber_Validating(object sender, CancelEventArgs e)
        {
            if (OldInventNumber.Text == string.Empty)
            {
                ErrOldInventNumber.Text = "";
                return;
            }
           
            ErrOldInventNumber.Text = "";
        }

        private void InventNumber_Validating(object sender, CancelEventArgs e)
        {
            if (InventNumber.Text == string.Empty)
            {
                ErrInventNumber.Text = "Поле должно быть заполнено";
                return;
            }
           
            ErrInventNumber.Text = "";
        }
        private void Denomination_Validating(object sender, CancelEventArgs e)
        {
            if (Denomination.SelectedIndex == -1 && Denomination.Text== "Выберите наименование")
            {
                ErrDenomination.Text = "Выберите наименование";
            }
            else ErrDenomination.Text = "";
        }

        private void Mark_Validating(object sender, CancelEventArgs e)
        {
            if (Mark.SelectedIndex == -1 && Mark.Text == "Выберите марку") ErrMark.Text = "Выберите марку";
            else ErrMark.Text = "";
        }

        private void Status_Validating(object sender, CancelEventArgs e)
        {
            if (Status.SelectedIndex == -1 ) ErrStatus.Text = "Выберите статус";
            else ErrStatus.Text = "";
        }

        private void City_Validating(object sender, CancelEventArgs e)
        {
            if (City.SelectedIndex == -1) ErrCity.Text = "Выберите город";
            else ErrCity.Text = "";
        }

        private void ResponsiblePerson_Validating(object sender, CancelEventArgs e)
        {
            if (ResponsiblePerson.SelectedIndex == -1 && ResponsiblePerson.Text == "Выберите ответственное лицо")
                ErrRespPerson.Text = "Выберите ответственное лицо";
            else ErrRespPerson.Text = "";
        }

        private void WhoUses_Validating(object sender, CancelEventArgs e)
        {
            if (WhoUses.SelectedIndex == -1 && WhoUses.Text == "Выберите сотрудника") ErrWhoUses.Text = "Выберите сотрудника";
            else  ErrWhoUses.Text = "";
        }


        public DataBase.Equipment TranslateDbEquipment(Equipment equip)
        {
            var responsible = equip.Responsible.Split(' ');
            var who = equip.WhoUses.Split(' ');

            return new DataBase.Equipment
            {
                InventoryNumber = equip.InventoryNumber,
                OldInventoryNumber = equip.OldInventoryNumber,
                model = equip.model,
                Comment = equip.Comment,
                Modernization = equip.Modernization,
                denomination = new Denomination { Naming = equip.denomination },
                mark = new Mark() { Naming = equip.mark },
                Responsible =
                    new Employee { FirstName = responsible[1], SecondName = responsible[2], LastName = responsible[0] },
                WhoUses = new Employee { FirstName = who[1], SecondName = who[2], LastName = who[0] },
                city = new City { Naming = equip.City },
                Floor = equip.Floor,
                Housing = equip.Housing,
                Cabinet = equip.Cabinet,
                status = new Status { Naming = equip.Status }
            };
        }

        private void Cabinet_Validating(object sender, CancelEventArgs e)
        {
            int cab;
            if (!Int32.TryParse(Cabinet.Text, out cab))
            {
                ErrCabinet.Text = "Поле может содержать только цифры";
                return;
            }
            else ErrCabinet.Text = "";
        }
    }
}
