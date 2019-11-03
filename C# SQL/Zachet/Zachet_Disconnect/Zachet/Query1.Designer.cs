namespace Zachet
{
    partial class Query1
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.dataSet = new Zachet.DataSet();
            this.ispolnitelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ispolnitelTableAdapter = new Zachet.DataSetTableAdapters.IspolnitelTableAdapter();
            this.fKZapiscodisp5070F446BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.zapisTableAdapter = new Zachet.DataSetTableAdapters.ZapisTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispolnitelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKZapiscodisp5070F446BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.ispolnitelBindingSource;
            this.comboBox1.DisplayMember = "naim";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(16, 52);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(245, 28);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.ValueMember = "cod_isp";
            // 
            // listBox1
            // 
            this.listBox1.DataSource = this.fKZapiscodisp5070F446BindingSource;
            this.listBox1.DisplayMember = "naim_zapis";
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(17, 92);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(244, 64);
            this.listBox1.TabIndex = 1;
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "DataSet";
            this.dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ispolnitelBindingSource
            // 
            this.ispolnitelBindingSource.DataMember = "Ispolnitel";
            this.ispolnitelBindingSource.DataSource = this.dataSet;
            // 
            // ispolnitelTableAdapter
            // 
            this.ispolnitelTableAdapter.ClearBeforeFill = true;
            // 
            // fKZapiscodisp5070F446BindingSource
            // 
            this.fKZapiscodisp5070F446BindingSource.DataMember = "FK__Zapis__cod_isp__5070F446";
            this.fKZapiscodisp5070F446BindingSource.DataSource = this.ispolnitelBindingSource;
            // 
            // zapisTableAdapter
            // 
            this.zapisTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "Для выбранного исполнителя \r\nвывести список его записей";
            // 
            // Query1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(280, 176);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.comboBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "Query1";
            this.Text = "Query1";
            this.Load += new System.EventHandler(this.Query1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispolnitelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKZapiscodisp5070F446BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListBox listBox1;
        private DataSet dataSet;
        private System.Windows.Forms.BindingSource ispolnitelBindingSource;
        private DataSetTableAdapters.IspolnitelTableAdapter ispolnitelTableAdapter;
        private System.Windows.Forms.BindingSource fKZapiscodisp5070F446BindingSource;
        private DataSetTableAdapters.ZapisTableAdapter zapisTableAdapter;
        private System.Windows.Forms.Label label1;
    }
}