namespace Lab2_Pansionat
{
    partial class button1_Form
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.gorodTableAdapter = new Lab2_Pansionat.DataSet1TableAdapters.gorodTableAdapter();
            this.postavshikiTableAdapter = new Lab2_Pansionat.DataSet1TableAdapters.postavshikiTableAdapter();
            this.dataTable1TableAdapter = new Lab2_Pansionat.DataSet1TableAdapters.DataTable1TableAdapter();
            this.dataSet1 = new Lab2_Pansionat.DataSet1();
            this.gorodBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gorodpostavshikiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fKpostavkipc25869641BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gorodBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gorodpostavshikiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKpostavkipc25869641BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pcDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.kDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.fKpostavkipc25869641BindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 118);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(361, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Количество поставщиков — ";
            // 
            // listBox1
            // 
            this.listBox1.DataSource = this.gorodpostavshikiBindingSource;
            this.listBox1.DisplayMember = "nazvanie";
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 23;
            this.listBox1.Location = new System.Drawing.Point(205, 39);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(168, 73);
            this.listBox1.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.gorodBindingSource;
            this.comboBox1.DisplayMember = "gorod";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(17, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 31);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // gorodTableAdapter
            // 
            this.gorodTableAdapter.ClearBeforeFill = true;
            // 
            // postavshikiTableAdapter
            // 
            this.postavshikiTableAdapter.ClearBeforeFill = true;
            // 
            // dataTable1TableAdapter
            // 
            this.dataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gorodBindingSource
            // 
            this.gorodBindingSource.DataMember = "gorod";
            this.gorodBindingSource.DataSource = this.dataSet1;
            // 
            // gorodpostavshikiBindingSource
            // 
            this.gorodpostavshikiBindingSource.DataMember = "gorod_postavshiki";
            this.gorodpostavshikiBindingSource.DataSource = this.gorodBindingSource;
            // 
            // fKpostavkipc25869641BindingSource
            // 
            this.fKpostavkipc25869641BindingSource.DataMember = "FK__postavki__pc__25869641";
            this.fKpostavkipc25869641BindingSource.DataSource = this.gorodpostavshikiBindingSource;
            // 
            // pcDataGridViewTextBoxColumn
            // 
            this.pcDataGridViewTextBoxColumn.DataPropertyName = "pc";
            this.pcDataGridViewTextBoxColumn.HeaderText = "pc";
            this.pcDataGridViewTextBoxColumn.Name = "pcDataGridViewTextBoxColumn";
            this.pcDataGridViewTextBoxColumn.ReadOnly = true;
            this.pcDataGridViewTextBoxColumn.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "produkt";
            this.dataGridViewTextBoxColumn1.HeaderText = "Продукт";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // kDataGridViewTextBoxColumn
            // 
            this.kDataGridViewTextBoxColumn.DataPropertyName = "k";
            this.kDataGridViewTextBoxColumn.HeaderText = "Суммарные поставки";
            this.kDataGridViewTextBoxColumn.Name = "kDataGridViewTextBoxColumn";
            this.kDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // button1_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 278);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "button1_Form";
            this.Text = " Поставщики, города, продукты ";
            this.Load += new System.EventHandler(this.button1_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gorodBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gorodpostavshikiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKpostavkipc25869641BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private DataSet1TableAdapters.gorodTableAdapter gorodTableAdapter;
        private DataSet1TableAdapters.postavshikiTableAdapter postavshikiTableAdapter;
        private DataSet1TableAdapters.DataTable1TableAdapter dataTable1TableAdapter;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource gorodBindingSource;
        private System.Windows.Forms.BindingSource gorodpostavshikiBindingSource;
        private System.Windows.Forms.BindingSource fKpostavkipc25869641BindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn kDataGridViewTextBoxColumn;
    }
}