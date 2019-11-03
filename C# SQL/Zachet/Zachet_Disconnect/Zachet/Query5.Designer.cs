namespace Zachet
{
    partial class Query5
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.codispDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.naimDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Janr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ispolnitelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Zachet.DataSet();
            this.ispolnitelTableAdapter1 = new Zachet.DataSetTableAdapters.IspolnitelTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispolnitelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Для каждого исполнителя наименования \r\nего жанров исполнения (через запятую) ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codispDataGridViewTextBoxColumn,
            this.naimDataGridViewTextBoxColumn,
            this.Janr});
            this.dataGridView1.DataSource = this.ispolnitelBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(11, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(316, 254);
            this.dataGridView1.TabIndex = 1;
            // 
            // codispDataGridViewTextBoxColumn
            // 
            this.codispDataGridViewTextBoxColumn.DataPropertyName = "cod_isp";
            this.codispDataGridViewTextBoxColumn.HeaderText = "cod_isp";
            this.codispDataGridViewTextBoxColumn.Name = "codispDataGridViewTextBoxColumn";
            this.codispDataGridViewTextBoxColumn.ReadOnly = true;
            this.codispDataGridViewTextBoxColumn.Visible = false;
            // 
            // naimDataGridViewTextBoxColumn
            // 
            this.naimDataGridViewTextBoxColumn.DataPropertyName = "naim";
            this.naimDataGridViewTextBoxColumn.HeaderText = "Исполнитель";
            this.naimDataGridViewTextBoxColumn.Name = "naimDataGridViewTextBoxColumn";
            this.naimDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Janr
            // 
            this.Janr.HeaderText = "Жанры";
            this.Janr.Name = "Janr";
            this.Janr.ReadOnly = true;
            // 
            // ispolnitelBindingSource
            // 
            this.ispolnitelBindingSource.DataMember = "Ispolnitel";
            this.ispolnitelBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ispolnitelTableAdapter1
            // 
            this.ispolnitelTableAdapter1.ClearBeforeFill = true;
            // 
            // Query5
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(346, 319);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "Query5";
            this.Text = "Query5";
            this.Load += new System.EventHandler(this.Query5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispolnitelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DataSet dataSet1;
        private System.Windows.Forms.BindingSource ispolnitelBindingSource;
        private DataSetTableAdapters.IspolnitelTableAdapter ispolnitelTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codispDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn naimDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Janr;
    }
}