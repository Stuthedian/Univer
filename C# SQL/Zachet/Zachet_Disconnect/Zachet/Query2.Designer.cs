namespace Zachet
{
    partial class Query2
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataSet = new Zachet.DataSet();
            this.zapisBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.zapisTableAdapter = new Zachet.DataSetTableAdapters.ZapisTableAdapter();
            this.naimzapisDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Isp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Janr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sotr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codispDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codjanrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codsotrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zapisBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 40);
            this.label1.TabIndex = 3;
            this.label1.Text = "Вывести записи, которые транслировались \r\nмежду двумя заданными датами\r\n";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(16, 63);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(119, 26);
            this.dateTimePicker1.TabIndex = 4;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(167, 63);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(119, 26);
            this.dateTimePicker2.TabIndex = 5;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.naimzapisDataGridViewTextBoxColumn,
            this.dataDataGridViewTextBoxColumn,
            this.Isp,
            this.Janr,
            this.Sotr,
            this.codispDataGridViewTextBoxColumn,
            this.codjanrDataGridViewTextBoxColumn,
            this.codsotrDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.zapisBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(16, 120);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(523, 150);
            this.dataGridView1.TabIndex = 6;
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "DataSet";
            this.dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // zapisBindingSource
            // 
            this.zapisBindingSource.DataMember = "Zapis";
            this.zapisBindingSource.DataSource = this.dataSet;
            // 
            // zapisTableAdapter
            // 
            this.zapisTableAdapter.ClearBeforeFill = true;
            // 
            // naimzapisDataGridViewTextBoxColumn
            // 
            this.naimzapisDataGridViewTextBoxColumn.DataPropertyName = "naim_zapis";
            this.naimzapisDataGridViewTextBoxColumn.HeaderText = "Наименование записи";
            this.naimzapisDataGridViewTextBoxColumn.Name = "naimzapisDataGridViewTextBoxColumn";
            this.naimzapisDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataDataGridViewTextBoxColumn
            // 
            this.dataDataGridViewTextBoxColumn.DataPropertyName = "data";
            this.dataDataGridViewTextBoxColumn.HeaderText = "Дата";
            this.dataDataGridViewTextBoxColumn.Name = "dataDataGridViewTextBoxColumn";
            this.dataDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Isp
            // 
            this.Isp.HeaderText = "Исполнитель";
            this.Isp.Name = "Isp";
            this.Isp.ReadOnly = true;
            // 
            // Janr
            // 
            this.Janr.HeaderText = "Жанр";
            this.Janr.Name = "Janr";
            this.Janr.ReadOnly = true;
            // 
            // Sotr
            // 
            this.Sotr.HeaderText = "Сотрудник";
            this.Sotr.Name = "Sotr";
            this.Sotr.ReadOnly = true;
            // 
            // codispDataGridViewTextBoxColumn
            // 
            this.codispDataGridViewTextBoxColumn.DataPropertyName = "cod_isp";
            this.codispDataGridViewTextBoxColumn.HeaderText = "cod_isp";
            this.codispDataGridViewTextBoxColumn.Name = "codispDataGridViewTextBoxColumn";
            this.codispDataGridViewTextBoxColumn.ReadOnly = true;
            this.codispDataGridViewTextBoxColumn.Visible = false;
            // 
            // codjanrDataGridViewTextBoxColumn
            // 
            this.codjanrDataGridViewTextBoxColumn.DataPropertyName = "cod_janr";
            this.codjanrDataGridViewTextBoxColumn.HeaderText = "cod_janr";
            this.codjanrDataGridViewTextBoxColumn.Name = "codjanrDataGridViewTextBoxColumn";
            this.codjanrDataGridViewTextBoxColumn.ReadOnly = true;
            this.codjanrDataGridViewTextBoxColumn.Visible = false;
            // 
            // codsotrDataGridViewTextBoxColumn
            // 
            this.codsotrDataGridViewTextBoxColumn.DataPropertyName = "cod_sotr";
            this.codsotrDataGridViewTextBoxColumn.HeaderText = "cod_sotr";
            this.codsotrDataGridViewTextBoxColumn.Name = "codsotrDataGridViewTextBoxColumn";
            this.codsotrDataGridViewTextBoxColumn.ReadOnly = true;
            this.codsotrDataGridViewTextBoxColumn.Visible = false;
            // 
            // Query2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(551, 283);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "Query2";
            this.Text = "Query2";
            this.Load += new System.EventHandler(this.Query2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zapisBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DataSet dataSet;
        private System.Windows.Forms.BindingSource zapisBindingSource;
        private DataSetTableAdapters.ZapisTableAdapter zapisTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn naimzapisDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Isp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Janr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sotr;
        private System.Windows.Forms.DataGridViewTextBoxColumn codispDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codjanrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codsotrDataGridViewTextBoxColumn;
    }
}