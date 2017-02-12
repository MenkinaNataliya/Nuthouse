namespace DesktopApplication
{
    partial class ChangeStatus
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
            this.изменитьСтатусToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сгенерироватьОтчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьОборудованиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.InventNum = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ErrInventNumber = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изменитьСтатусToolStripMenuItem,
            this.сгенерироватьОтчетToolStripMenuItem,
            this.добавитьОборудованиеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(446, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // изменитьСтатусToolStripMenuItem
            // 
            this.изменитьСтатусToolStripMenuItem.Name = "изменитьСтатусToolStripMenuItem";
            this.изменитьСтатусToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
            // 
            // сгенерироватьОтчетToolStripMenuItem
            // 
            this.сгенерироватьОтчетToolStripMenuItem.Name = "сгенерироватьОтчетToolStripMenuItem";
            this.сгенерироватьОтчетToolStripMenuItem.Size = new System.Drawing.Size(135, 20);
            this.сгенерироватьОтчетToolStripMenuItem.Text = "Сгенерировать отчет";
            this.сгенерироватьОтчетToolStripMenuItem.Click += new System.EventHandler(this.сгенерироватьОтчетToolStripMenuItem_Click);
            // 
            // добавитьОборудованиеToolStripMenuItem
            // 
            this.добавитьОборудованиеToolStripMenuItem.Name = "добавитьОборудованиеToolStripMenuItem";
            this.добавитьОборудованиеToolStripMenuItem.Size = new System.Drawing.Size(153, 20);
            this.добавитьОборудованиеToolStripMenuItem.Text = "Добавить оборудование";
            this.добавитьОборудованиеToolStripMenuItem.Click += new System.EventHandler(this.добавитьОборудованиеToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(87, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Изменить статус оборудования";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(33, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Введите инвентарный номер";
            // 
            // InventNum
            // 
            this.InventNum.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InventNum.Location = new System.Drawing.Point(261, 81);
            this.InventNum.Name = "InventNum";
            this.InventNum.Size = new System.Drawing.Size(136, 26);
            this.InventNum.TabIndex = 19;
            this.InventNum.Validating += new System.ComponentModel.CancelEventHandler(this.InventNum_Validating);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(288, 138);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 38);
            this.button1.TabIndex = 20;
            this.button1.Text = "Найти";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ErrInventNumber
            // 
            this.ErrInventNumber.AutoSize = true;
            this.ErrInventNumber.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ErrInventNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ErrInventNumber.Location = new System.Drawing.Point(258, 110);
            this.ErrInventNumber.Name = "ErrInventNumber";
            this.ErrInventNumber.Size = new System.Drawing.Size(41, 15);
            this.ErrInventNumber.TabIndex = 32;
            this.ErrInventNumber.Text = "label16";
            // 
            // ChangeStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 188);
            this.Controls.Add(this.ErrInventNumber);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.InventNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "ChangeStatus";
            this.Text = "Изменение статуса";
            this.Load += new System.EventHandler(this.ChangeStatus_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem изменитьСтатусToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сгенерироватьОтчетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьОборудованиеToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox InventNum;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label ErrInventNumber;
    }
}