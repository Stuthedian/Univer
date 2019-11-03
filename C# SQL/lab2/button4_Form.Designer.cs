namespace Lab2_Pansionat
{
    partial class button4_Form
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
            this.yearBox = new System.Windows.Forms.ListBox();
            this.yeartableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Lab2_Pansionat.DataSet1();
            this.monthBox = new System.Windows.Forms.ListBox();
            this.yeartableMonthTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.postavkiYearMonthBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet11 = new Lab2_Pansionat.DataSet1();
            this.yeartableTableAdapter = new Lab2_Pansionat.DataSet1TableAdapters.YeartableTableAdapter();
            this.monthTableTableAdapter = new Lab2_Pansionat.DataSet1TableAdapters.MonthTableTableAdapter();
            this.postavkiYearMonthTableAdapter = new Lab2_Pansionat.DataSet1TableAdapters.postavkiYearMonthTableAdapter();
            this.nazvanieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.produktDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expr1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yearexprDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monthexprDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.yeartableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yeartableMonthTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.postavkiYearMonthBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet11)).BeginInit();
            this.SuspendLayout();
            // 
            // yearBox
            // 
            this.yearBox.DataSource = this.yeartableBindingSource;
            this.yearBox.DisplayMember = "yearexpr";
            this.yearBox.FormattingEnabled = true;
            this.yearBox.ItemHeight = 23;
            this.yearBox.Location = new System.Drawing.Point(12, 12);
            this.yearBox.Name = "yearBox";
            this.yearBox.Size = new System.Drawing.Size(120, 119);
            this.yearBox.TabIndex = 0;
            this.yearBox.ValueMember = "yearexpr";
            this.yearBox.SelectedIndexChanged += new System.EventHandler(this.yearBox_SelectedIndexChanged);
            // 
            // yeartableBindingSource
            // 
            this.yeartableBindingSource.DataMember = "Yeartable";
            this.yeartableBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // monthBox
            // 
            this.monthBox.DataSource = this.yeartableMonthTableBindingSource;
            this.monthBox.DisplayMember = "monthexpr";
            this.monthBox.FormattingEnabled = true;
            this.monthBox.ItemHeight = 23;
            this.monthBox.Location = new System.Drawing.Point(138, 12);
            this.monthBox.Name = "monthBox";
            this.monthBox.Size = new System.Drawing.Size(120, 119);
            this.monthBox.TabIndex = 1;
            this.monthBox.ValueMember = "monthexpr";
            this.monthBox.SelectedIndexChanged += new System.EventHandler(this.monthBox_SelectedIndexChanged);
            // 
            // yeartableMonthTableBindingSource
            // 
            this.yeartableMonthTableBindingSource.DataMember = "Yeartable_MonthTable";
            this.yeartableMonthTableBindingSource.DataSource = this.yeartableBindingSource;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nazvanieDataGridViewTextBoxColumn,
            this.produktDataGridViewTextBoxColumn,
            this.expr1DataGridViewTextBoxColumn,
            this.yearexprDataGridViewTextBoxColumn,
            this.monthexprDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.postavkiYearMonthBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(264, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(434, 119);
            this.dataGridView1.TabIndex = 2;
            // 
            // postavkiYearMonthBindingSource
            // 
            this.postavkiYearMonthBindingSource.DataMember = "postavkiYearMonth";
            this.postavkiYearMonthBindingSource.DataSource = this.dataSet11;
            // 
            // dataSet11
            // 
            this.dataSet11.DataSetName = "DataSet1";
            this.dataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // yeartableTableAdapter
            // 
            this.yeartableTableAdapter.ClearBeforeFill = true;
            // 
            // monthTableTableAdapter
            // 
            this.monthTableTableAdapter.ClearBeforeFill = true;
            // 
            // postavkiYearMonthTableAdapter
            // 
            this.postavkiYearMonthTableAdapter.ClearBeforeFill = true;
            // 
            // nazvanieDataGridViewTextBoxColumn
            // 
            this.nazvanieDataGridViewTextBoxColumn.DataPropertyName = "nazvanie";
            this.nazvanieDataGridViewTextBoxColumn.HeaderText = "Поставщик";
            this.nazvanieDataGridViewTextBoxColumn.Name = "nazvanieDataGridViewTextBoxColumn";
            this.nazvanieDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // produktDataGridViewTextBoxColumn
            // 
            this.produktDataGridViewTextBoxColumn.DataPropertyName = "produkt";
            this.produktDataGridViewTextBoxColumn.HeaderText = "Продукт";
            this.produktDataGridViewTextBoxColumn.Name = "produktDataGridViewTextBoxColumn";
            this.produktDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // expr1DataGridViewTextBoxColumn
            // 
            this.expr1DataGridViewTextBoxColumn.DataPropertyName = "Expr1";
            this.expr1DataGridViewTextBoxColumn.HeaderText = "Количество";
            this.expr1DataGridViewTextBoxColumn.Name = "expr1DataGridViewTextBoxColumn";
            this.expr1DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // yearexprDataGridViewTextBoxColumn
            // 
            this.yearexprDataGridViewTextBoxColumn.DataPropertyName = "yearexpr";
            this.yearexprDataGridViewTextBoxColumn.HeaderText = "yearexpr";
            this.yearexprDataGridViewTextBoxColumn.Name = "yearexprDataGridViewTextBoxColumn";
            this.yearexprDataGridViewTextBoxColumn.ReadOnly = true;
            this.yearexprDataGridViewTextBoxColumn.Visible = false;
            // 
            // monthexprDataGridViewTextBoxColumn
            // 
            this.monthexprDataGridViewTextBoxColumn.DataPropertyName = "monthexpr";
            this.monthexprDataGridViewTextBoxColumn.HeaderText = "monthexpr";
            this.monthexprDataGridViewTextBoxColumn.Name = "monthexprDataGridViewTextBoxColumn";
            this.monthexprDataGridViewTextBoxColumn.ReadOnly = true;
            this.monthexprDataGridViewTextBoxColumn.Visible = false;
            // 
            // button4_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 140);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.monthBox);
            this.Controls.Add(this.yearBox);
            this.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "button4_Form";
            this.Text = " Для  каждого  года  поставки  и  месяца:  название поставщика,  название  продук" +
    "та  и  суммарная  поставка";
            this.Load += new System.EventHandler(this.button4_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.yeartableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yeartableMonthTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.postavkiYearMonthBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet11)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox yearBox;
        private System.Windows.Forms.ListBox monthBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource yeartableBindingSource;
        private DataSet1TableAdapters.YeartableTableAdapter yeartableTableAdapter;
        private System.Windows.Forms.BindingSource yeartableMonthTableBindingSource;
        private DataSet1TableAdapters.MonthTableTableAdapter monthTableTableAdapter;
        private DataSet1 dataSet11;
        private System.Windows.Forms.BindingSource postavkiYearMonthBindingSource;
        private DataSet1TableAdapters.postavkiYearMonthTableAdapter postavkiYearMonthTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn nazvanieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn produktDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expr1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yearexprDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn monthexprDataGridViewTextBoxColumn;
    }
}