namespace Zachet
{
    partial class Zapis
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.Exitbutton = new System.Windows.Forms.Button();
            this.Delbutton = new System.Windows.Forms.Button();
            this.Editbutton = new System.Windows.Forms.Button();
            this.Addbutton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.codzapDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.naimzapisDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Isp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Janr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sotr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codispDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codjanrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codsotrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zapisBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet = new Zachet.DataSet();
            this.Viewbutton = new System.Windows.Forms.Button();
            this.zapisTableAdapter = new Zachet.DataSetTableAdapters.ZapisTableAdapter();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zapisBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Exitbutton);
            this.panel2.Controls.Add(this.Delbutton);
            this.panel2.Controls.Add(this.Editbutton);
            this.panel2.Controls.Add(this.Addbutton);
            this.panel2.Location = new System.Drawing.Point(402, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(101, 144);
            this.panel2.TabIndex = 12;
            // 
            // Exitbutton
            // 
            this.Exitbutton.Location = new System.Drawing.Point(5, 108);
            this.Exitbutton.Name = "Exitbutton";
            this.Exitbutton.Size = new System.Drawing.Size(93, 31);
            this.Exitbutton.TabIndex = 3;
            this.Exitbutton.Text = "Выход";
            this.Exitbutton.UseVisualStyleBackColor = true;
            this.Exitbutton.Click += new System.EventHandler(this.Exitbutton_Click);
            // 
            // Delbutton
            // 
            this.Delbutton.Location = new System.Drawing.Point(5, 75);
            this.Delbutton.Name = "Delbutton";
            this.Delbutton.Size = new System.Drawing.Size(93, 31);
            this.Delbutton.TabIndex = 2;
            this.Delbutton.Text = "Удалить";
            this.Delbutton.UseVisualStyleBackColor = true;
            this.Delbutton.Click += new System.EventHandler(this.Delbutton_Click);
            // 
            // Editbutton
            // 
            this.Editbutton.Location = new System.Drawing.Point(5, 38);
            this.Editbutton.Name = "Editbutton";
            this.Editbutton.Size = new System.Drawing.Size(93, 31);
            this.Editbutton.TabIndex = 1;
            this.Editbutton.Text = "Изменить";
            this.Editbutton.UseVisualStyleBackColor = true;
            this.Editbutton.Click += new System.EventHandler(this.Editbutton_Click);
            // 
            // Addbutton
            // 
            this.Addbutton.Location = new System.Drawing.Point(5, 3);
            this.Addbutton.Name = "Addbutton";
            this.Addbutton.Size = new System.Drawing.Size(93, 31);
            this.Addbutton.TabIndex = 0;
            this.Addbutton.Text = "Добавить";
            this.Addbutton.UseVisualStyleBackColor = true;
            this.Addbutton.Click += new System.EventHandler(this.Addbutton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
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
            this.codzapDataGridViewTextBoxColumn,
            this.naimzapisDataGridViewTextBoxColumn,
            this.dataDataGridViewTextBoxColumn,
            this.Isp,
            this.Janr,
            this.Sotr,
            this.codispDataGridViewTextBoxColumn,
            this.codjanrDataGridViewTextBoxColumn,
            this.codsotrDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.zapisBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(384, 144);
            this.dataGridView1.TabIndex = 13;
            // 
            // codzapDataGridViewTextBoxColumn
            // 
            this.codzapDataGridViewTextBoxColumn.DataPropertyName = "cod_zap";
            this.codzapDataGridViewTextBoxColumn.HeaderText = "cod_zap";
            this.codzapDataGridViewTextBoxColumn.Name = "codzapDataGridViewTextBoxColumn";
            this.codzapDataGridViewTextBoxColumn.ReadOnly = true;
            this.codzapDataGridViewTextBoxColumn.Visible = false;
            this.codzapDataGridViewTextBoxColumn.Width = 76;
            // 
            // naimzapisDataGridViewTextBoxColumn
            // 
            this.naimzapisDataGridViewTextBoxColumn.DataPropertyName = "naim_zapis";
            this.naimzapisDataGridViewTextBoxColumn.HeaderText = "Запись";
            this.naimzapisDataGridViewTextBoxColumn.Name = "naimzapisDataGridViewTextBoxColumn";
            this.naimzapisDataGridViewTextBoxColumn.ReadOnly = true;
            this.naimzapisDataGridViewTextBoxColumn.Width = 89;
            // 
            // dataDataGridViewTextBoxColumn
            // 
            this.dataDataGridViewTextBoxColumn.DataPropertyName = "data";
            this.dataDataGridViewTextBoxColumn.HeaderText = "Дата";
            this.dataDataGridViewTextBoxColumn.Name = "dataDataGridViewTextBoxColumn";
            this.dataDataGridViewTextBoxColumn.ReadOnly = true;
            this.dataDataGridViewTextBoxColumn.Width = 73;
            // 
            // Isp
            // 
            this.Isp.HeaderText = "Исполнитель";
            this.Isp.Name = "Isp";
            this.Isp.ReadOnly = true;
            this.Isp.Width = 136;
            // 
            // Janr
            // 
            this.Janr.HeaderText = "Жанр";
            this.Janr.Name = "Janr";
            this.Janr.ReadOnly = true;
            this.Janr.Width = 74;
            // 
            // Sotr
            // 
            this.Sotr.HeaderText = "Сотрудник";
            this.Sotr.Name = "Sotr";
            this.Sotr.ReadOnly = true;
            this.Sotr.Width = 116;
            // 
            // codispDataGridViewTextBoxColumn
            // 
            this.codispDataGridViewTextBoxColumn.DataPropertyName = "cod_isp";
            this.codispDataGridViewTextBoxColumn.HeaderText = "cod_isp";
            this.codispDataGridViewTextBoxColumn.Name = "codispDataGridViewTextBoxColumn";
            this.codispDataGridViewTextBoxColumn.ReadOnly = true;
            this.codispDataGridViewTextBoxColumn.Visible = false;
            this.codispDataGridViewTextBoxColumn.Width = 89;
            // 
            // codjanrDataGridViewTextBoxColumn
            // 
            this.codjanrDataGridViewTextBoxColumn.DataPropertyName = "cod_janr";
            this.codjanrDataGridViewTextBoxColumn.HeaderText = "cod_janr";
            this.codjanrDataGridViewTextBoxColumn.Name = "codjanrDataGridViewTextBoxColumn";
            this.codjanrDataGridViewTextBoxColumn.ReadOnly = true;
            this.codjanrDataGridViewTextBoxColumn.Visible = false;
            this.codjanrDataGridViewTextBoxColumn.Width = 95;
            // 
            // codsotrDataGridViewTextBoxColumn
            // 
            this.codsotrDataGridViewTextBoxColumn.DataPropertyName = "cod_sotr";
            this.codsotrDataGridViewTextBoxColumn.HeaderText = "cod_sotr";
            this.codsotrDataGridViewTextBoxColumn.Name = "codsotrDataGridViewTextBoxColumn";
            this.codsotrDataGridViewTextBoxColumn.ReadOnly = true;
            this.codsotrDataGridViewTextBoxColumn.Visible = false;
            this.codsotrDataGridViewTextBoxColumn.Width = 96;
            // 
            // zapisBindingSource
            // 
            this.zapisBindingSource.DataMember = "Zapis";
            this.zapisBindingSource.DataSource = this.dataSet;
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "DataSet";
            this.dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Viewbutton
            // 
            this.Viewbutton.Location = new System.Drawing.Point(12, 162);
            this.Viewbutton.Name = "Viewbutton";
            this.Viewbutton.Size = new System.Drawing.Size(142, 34);
            this.Viewbutton.TabIndex = 33;
            this.Viewbutton.Text = "Просмотр строк";
            this.Viewbutton.UseVisualStyleBackColor = true;
            this.Viewbutton.Click += new System.EventHandler(this.Viewbutton_Click);
            // 
            // zapisTableAdapter
            // 
            this.zapisTableAdapter.ClearBeforeFill = true;
            // 
            // Zapis
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(513, 204);
            this.Controls.Add(this.Viewbutton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Zapis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Запись";
            this.Load += new System.EventHandler(this.Zapis_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zapisBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Exitbutton;
        private System.Windows.Forms.Button Delbutton;
        private System.Windows.Forms.Button Editbutton;
        private System.Windows.Forms.Button Addbutton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn famDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn otchDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn drDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn polDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button Viewbutton;
        private DataSet dataSet;
        private System.Windows.Forms.BindingSource zapisBindingSource;
        private DataSetTableAdapters.ZapisTableAdapter zapisTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn codzapDataGridViewTextBoxColumn;
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