namespace DesktopApplication
{
    partial class GenerateReports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.добавитьОборудованиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьСтатусToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Denominations = new System.Windows.Forms.CheckedListBox();
            this.Cities = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox3 = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Marks = new System.Windows.Forms.CheckedListBox();
            this.Status = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Modernisation = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Responsible = new System.Windows.Forms.CheckedListBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьОборудованиеToolStripMenuItem,
            this.изменитьСтатусToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(559, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // добавитьОборудованиеToolStripMenuItem
            // 
            this.добавитьОборудованиеToolStripMenuItem.Name = "добавитьОборудованиеToolStripMenuItem";
            this.добавитьОборудованиеToolStripMenuItem.Size = new System.Drawing.Size(153, 20);
            this.добавитьОборудованиеToolStripMenuItem.Text = "Добавить оборудование";
            this.добавитьОборудованиеToolStripMenuItem.Click += new System.EventHandler(this.добавитьОборудованиеToolStripMenuItem_Click);
            // 
            // изменитьСтатусToolStripMenuItem
            // 
            this.изменитьСтатусToolStripMenuItem.Name = "изменитьСтатусToolStripMenuItem";
            this.изменитьСтатусToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.изменитьСтатусToolStripMenuItem.Text = "Изменить статус";
            this.изменитьСтатусToolStripMenuItem.Click += new System.EventHandler(this.изменитьСтатусToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(148, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Сгенерировать отчет";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(29, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Город:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(246, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Отделение:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(29, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "Наименование:";
            // 
            // Denominations
            // 
            this.Denominations.FormattingEnabled = true;
            this.Denominations.Location = new System.Drawing.Point(163, 159);
            this.Denominations.Name = "Denominations";
            this.Denominations.Size = new System.Drawing.Size(169, 64);
            this.Denominations.TabIndex = 10;
            // 
            // Cities
            // 
            this.Cities.FormattingEnabled = true;
            this.Cities.Location = new System.Drawing.Point(120, 87);
            this.Cities.Name = "Cities";
            this.Cities.Size = new System.Drawing.Size(120, 49);
            this.Cities.TabIndex = 11;
            // 
            // checkedListBox3
            // 
            this.checkedListBox3.FormattingEnabled = true;
            this.checkedListBox3.Location = new System.Drawing.Point(353, 87);
            this.checkedListBox3.Name = "checkedListBox3";
            this.checkedListBox3.Size = new System.Drawing.Size(120, 64);
            this.checkedListBox3.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(29, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 19);
            this.label5.TabIndex = 13;
            this.label5.Text = "Марка:";
            // 
            // Marks
            // 
            this.Marks.FormattingEnabled = true;
            this.Marks.Location = new System.Drawing.Point(120, 258);
            this.Marks.Name = "Marks";
            this.Marks.Size = new System.Drawing.Size(120, 64);
            this.Marks.TabIndex = 14;
            // 
            // Status
            // 
            this.Status.FormattingEnabled = true;
            this.Status.Location = new System.Drawing.Point(417, 258);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(120, 64);
            this.Status.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(262, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 19);
            this.label6.TabIndex = 15;
            this.label6.Text = "Статус оборудовани:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(29, 340);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(153, 19);
            this.label7.TabIndex = 17;
            this.label7.Text = "Ответственное лицо:";
            // 
            // Modernisation
            // 
            this.Modernisation.AutoSize = true;
            this.Modernisation.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Modernisation.Location = new System.Drawing.Point(33, 419);
            this.Modernisation.Name = "Modernisation";
            this.Modernisation.Size = new System.Drawing.Size(375, 23);
            this.Modernisation.TabIndex = 31;
            this.Modernisation.Text = "Устройство получено по программе модернизации";
            this.Modernisation.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(428, 404);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 38);
            this.button1.TabIndex = 32;
            this.button1.Text = "Создать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Responsible
            // 
            this.Responsible.FormattingEnabled = true;
            this.Responsible.Location = new System.Drawing.Point(212, 340);
            this.Responsible.Name = "Responsible";
            this.Responsible.Size = new System.Drawing.Size(199, 64);
            this.Responsible.TabIndex = 33;
            // 
            // GenerateReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 464);
            this.Controls.Add(this.Responsible);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Modernisation);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Marks);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkedListBox3);
            this.Controls.Add(this.Cities);
            this.Controls.Add(this.Denominations);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GenerateReports";
            this.Text = "Генерация отчета";
            this.Load += new System.EventHandler(this.GenerateReports_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem добавитьОборудованиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьСтатусToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox Denominations;
        private System.Windows.Forms.CheckedListBox Cities;
        private System.Windows.Forms.CheckedListBox checkedListBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox Marks;
        private System.Windows.Forms.CheckedListBox Status;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox Modernisation;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox Responsible;
    }
}