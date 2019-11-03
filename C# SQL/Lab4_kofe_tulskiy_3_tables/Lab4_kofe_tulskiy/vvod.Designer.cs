namespace Lab4_kofe_tulskiy
{
	partial class vvod
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.Exit_button = new System.Windows.Forms.Button();
			this.Delete_button = new System.Windows.Forms.Button();
			this.Add_button = new System.Windows.Forms.Button();
			this.Edit_button = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.comboBox_tovar = new System.Windows.Forms.ComboBox();
			this.comboBox_postavshik = new System.Windows.Forms.ComboBox();
			this.Cancel_button = new System.Windows.Forms.Button();
			this.Save_button = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridView1.Location = new System.Drawing.Point(12, 205);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(624, 171);
			this.dataGridView1.TabIndex = 0;
			// 
			// Column1
			// 
			this.Column1.HeaderText = "Номер поставки";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Visible = false;
			// 
			// Column2
			// 
			this.Column2.HeaderText = "Наименование поставщика";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Width = 150;
			// 
			// Column3
			// 
			this.Column3.HeaderText = "Наименование товара";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Width = 183;
			// 
			// Column4
			// 
			this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Column4.HeaderText = "Объем поставки (кг)";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column4.Width = 150;
			// 
			// Column5
			// 
			this.Column5.HeaderText = "Дата  поставки";
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			this.Column5.Width = 137;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(282, 179);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(84, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Поставки";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.Exit_button);
			this.panel2.Controls.Add(this.Delete_button);
			this.panel2.Controls.Add(this.Add_button);
			this.panel2.Controls.Add(this.Edit_button);
			this.panel2.Location = new System.Drawing.Point(492, 12);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(140, 160);
			this.panel2.TabIndex = 0;
			// 
			// Exit_button
			// 
			this.Exit_button.Location = new System.Drawing.Point(28, 111);
			this.Exit_button.Name = "Exit_button";
			this.Exit_button.Size = new System.Drawing.Size(92, 32);
			this.Exit_button.TabIndex = 7;
			this.Exit_button.Text = "Выход";
			this.Exit_button.UseVisualStyleBackColor = true;
			this.Exit_button.Click += new System.EventHandler(this.Exit_button_Click);
			// 
			// Delete_button
			// 
			this.Delete_button.Location = new System.Drawing.Point(28, 79);
			this.Delete_button.Name = "Delete_button";
			this.Delete_button.Size = new System.Drawing.Size(92, 32);
			this.Delete_button.TabIndex = 6;
			this.Delete_button.Text = "Удалить";
			this.Delete_button.UseVisualStyleBackColor = true;
			this.Delete_button.Click += new System.EventHandler(this.Delete_button_Click);
			// 
			// Add_button
			// 
			this.Add_button.Location = new System.Drawing.Point(28, 15);
			this.Add_button.Name = "Add_button";
			this.Add_button.Size = new System.Drawing.Size(92, 32);
			this.Add_button.TabIndex = 4;
			this.Add_button.Text = "Добавить";
			this.Add_button.UseVisualStyleBackColor = true;
			this.Add_button.Click += new System.EventHandler(this.Add_button_Click);
			// 
			// Edit_button
			// 
			this.Edit_button.Location = new System.Drawing.Point(28, 47);
			this.Edit_button.Name = "Edit_button";
			this.Edit_button.Size = new System.Drawing.Size(92, 32);
			this.Edit_button.TabIndex = 5;
			this.Edit_button.Text = "Изменить";
			this.Edit_button.UseVisualStyleBackColor = true;
			this.Edit_button.Click += new System.EventHandler(this.Edit_button_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.dateTimePicker1);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.comboBox_tovar);
			this.panel1.Controls.Add(this.comboBox_postavshik);
			this.panel1.Controls.Add(this.Cancel_button);
			this.panel1.Controls.Add(this.Save_button);
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(449, 160);
			this.panel1.TabIndex = 3;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(102, 125);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(205, 30);
			this.dateTimePicker1.TabIndex = 13;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 116);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(46, 23);
			this.label5.TabIndex = 12;
			this.label5.Text = "Дата";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 86);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(61, 23);
			this.label4.TabIndex = 11;
			this.label4.Text = "Расход";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 49);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 23);
			this.label3.TabIndex = 10;
			this.label3.Text = "Товар";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(97, 23);
			this.label2.TabIndex = 9;
			this.label2.Text = "Поставщик";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(102, 89);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(205, 30);
			this.textBox1.TabIndex = 8;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// comboBox_tovar
			// 
			this.comboBox_tovar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_tovar.FormattingEnabled = true;
			this.comboBox_tovar.Location = new System.Drawing.Point(102, 52);
			this.comboBox_tovar.Name = "comboBox_tovar";
			this.comboBox_tovar.Size = new System.Drawing.Size(205, 31);
			this.comboBox_tovar.TabIndex = 7;
			// 
			// comboBox_postavshik
			// 
			this.comboBox_postavshik.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_postavshik.FormattingEnabled = true;
			this.comboBox_postavshik.Location = new System.Drawing.Point(102, 15);
			this.comboBox_postavshik.Name = "comboBox_postavshik";
			this.comboBox_postavshik.Size = new System.Drawing.Size(205, 31);
			this.comboBox_postavshik.TabIndex = 6;
			// 
			// Cancel_button
			// 
			this.Cancel_button.Location = new System.Drawing.Point(332, 83);
			this.Cancel_button.Name = "Cancel_button";
			this.Cancel_button.Size = new System.Drawing.Size(99, 34);
			this.Cancel_button.TabIndex = 5;
			this.Cancel_button.Text = "Отмена";
			this.Cancel_button.UseVisualStyleBackColor = true;
			this.Cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
			// 
			// Save_button
			// 
			this.Save_button.Location = new System.Drawing.Point(332, 43);
			this.Save_button.Name = "Save_button";
			this.Save_button.Size = new System.Drawing.Size(99, 34);
			this.Save_button.TabIndex = 4;
			this.Save_button.Text = "Сохранить";
			this.Save_button.UseVisualStyleBackColor = true;
			this.Save_button.Click += new System.EventHandler(this.Save_button_Click);
			// 
			// vvod
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(644, 387);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dataGridView1);
			this.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "vvod";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Бастурма";
			this.Load += new System.EventHandler(this.vvod_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button Exit_button;
		private System.Windows.Forms.Button Delete_button;
		private System.Windows.Forms.Button Add_button;
		private System.Windows.Forms.Button Edit_button;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ComboBox comboBox_tovar;
		private System.Windows.Forms.ComboBox comboBox_postavshik;
		private System.Windows.Forms.Button Cancel_button;
		private System.Windows.Forms.Button Save_button;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
	}
}