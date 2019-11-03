namespace Zachet
{
    partial class ZapisEdit
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.Savebutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Ispcombo = new System.Windows.Forms.ComboBox();
            this.Janrcombo = new System.Windows.Forms.ComboBox();
            this.Sotrcombo = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Cancelbutton);
            this.panel3.Controls.Add(this.Savebutton);
            this.panel3.Location = new System.Drawing.Point(92, 192);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(227, 43);
            this.panel3.TabIndex = 18;
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.Location = new System.Drawing.Point(116, 3);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(107, 34);
            this.Cancelbutton.TabIndex = 1;
            this.Cancelbutton.Text = "Отмена";
            this.Cancelbutton.UseVisualStyleBackColor = true;
            this.Cancelbutton.Click += new System.EventHandler(this.Cancelbutton_Click);
            // 
            // Savebutton
            // 
            this.Savebutton.Location = new System.Drawing.Point(3, 3);
            this.Savebutton.Name = "Savebutton";
            this.Savebutton.Size = new System.Drawing.Size(107, 34);
            this.Savebutton.TabIndex = 0;
            this.Savebutton.Text = "Сохранить";
            this.Savebutton.UseVisualStyleBackColor = true;
            this.Savebutton.Click += new System.EventHandler(this.Savebutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Исполнитель";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Жанр";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Сотрудник";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "Наименование";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 23;
            this.label5.Text = "Дата";
            // 
            // Ispcombo
            // 
            this.Ispcombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Ispcombo.FormattingEnabled = true;
            this.Ispcombo.Location = new System.Drawing.Point(146, 9);
            this.Ispcombo.Name = "Ispcombo";
            this.Ispcombo.Size = new System.Drawing.Size(250, 28);
            this.Ispcombo.TabIndex = 24;
            this.Ispcombo.ValueMember = "cod_isp";
            // 
            // Janrcombo
            // 
            this.Janrcombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Janrcombo.FormattingEnabled = true;
            this.Janrcombo.Location = new System.Drawing.Point(146, 43);
            this.Janrcombo.Name = "Janrcombo";
            this.Janrcombo.Size = new System.Drawing.Size(250, 28);
            this.Janrcombo.TabIndex = 25;
            this.Janrcombo.ValueMember = "cod_janr";
            // 
            // Sotrcombo
            // 
            this.Sotrcombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Sotrcombo.FormattingEnabled = true;
            this.Sotrcombo.Location = new System.Drawing.Point(146, 77);
            this.Sotrcombo.Name = "Sotrcombo";
            this.Sotrcombo.Size = new System.Drawing.Size(250, 28);
            this.Sotrcombo.TabIndex = 26;
            this.Sotrcombo.ValueMember = "cod_sotr";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(146, 111);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(250, 26);
            this.textBox1.TabIndex = 27;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(146, 143);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(250, 26);
            this.dateTimePicker1.TabIndex = 28;
            // 
            // ZapisEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(411, 240);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Sotrcombo);
            this.Controls.Add(this.Janrcombo);
            this.Controls.Add(this.Ispcombo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ZapisEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Запись";
            this.Load += new System.EventHandler(this.ZapisEdit_Load);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button Cancelbutton;
        private System.Windows.Forms.Button Savebutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Ispcombo;
        private System.Windows.Forms.ComboBox Janrcombo;
        private System.Windows.Forms.ComboBox Sotrcombo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}