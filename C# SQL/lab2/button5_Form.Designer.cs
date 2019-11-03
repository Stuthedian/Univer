namespace Lab2_Pansionat
{
    partial class button5_Form
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
            this.bludaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Lab2_Pansionat.DataSet1();
            this.AnyBox = new System.Windows.Forms.ListBox();
            this.bludaPostavshikAnyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AllBox = new System.Windows.Forms.ListBox();
            this.bludaPostavshikAllBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bludaTableAdapter = new Lab2_Pansionat.DataSet1TableAdapters.bludaTableAdapter();
            this.postavshikAnyTableAdapter = new Lab2_Pansionat.DataSet1TableAdapters.PostavshikAnyTableAdapter();
            this.postavshikAllTableAdapter = new Lab2_Pansionat.DataSet1TableAdapters.PostavshikAllTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bludaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bludaPostavshikAnyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bludaPostavshikAllBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.bludaBindingSource;
            this.comboBox1.DisplayMember = "bludo";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(198, 31);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // bludaBindingSource
            // 
            this.bludaBindingSource.DataMember = "bluda";
            this.bludaBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // AnyBox
            // 
            this.AnyBox.DataSource = this.bludaPostavshikAnyBindingSource;
            this.AnyBox.DisplayMember = "nazvanie";
            this.AnyBox.FormattingEnabled = true;
            this.AnyBox.ItemHeight = 23;
            this.AnyBox.Location = new System.Drawing.Point(216, 12);
            this.AnyBox.Name = "AnyBox";
            this.AnyBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.AnyBox.Size = new System.Drawing.Size(120, 96);
            this.AnyBox.TabIndex = 1;
            // 
            // bludaPostavshikAnyBindingSource
            // 
            this.bludaPostavshikAnyBindingSource.DataMember = "bluda_PostavshikAny";
            this.bludaPostavshikAnyBindingSource.DataSource = this.bludaBindingSource;
            // 
            // AllBox
            // 
            this.AllBox.DataSource = this.bludaPostavshikAllBindingSource;
            this.AllBox.DisplayMember = "nazvanie";
            this.AllBox.FormattingEnabled = true;
            this.AllBox.ItemHeight = 23;
            this.AllBox.Location = new System.Drawing.Point(342, 12);
            this.AllBox.Name = "AllBox";
            this.AllBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.AllBox.Size = new System.Drawing.Size(120, 96);
            this.AllBox.TabIndex = 2;
            // 
            // bludaPostavshikAllBindingSource
            // 
            this.bludaPostavshikAllBindingSource.DataMember = "bluda_PostavshikAll";
            this.bludaPostavshikAllBindingSource.DataSource = this.bludaBindingSource;
            // 
            // bludaTableAdapter
            // 
            this.bludaTableAdapter.ClearBeforeFill = true;
            // 
            // postavshikAnyTableAdapter
            // 
            this.postavshikAnyTableAdapter.ClearBeforeFill = true;
            // 
            // postavshikAllTableAdapter
            // 
            this.postavshikAllTableAdapter.ClearBeforeFill = true;
            // 
            // button5_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 118);
            this.Controls.Add(this.AllBox);
            this.Controls.Add(this.AnyBox);
            this.Controls.Add(this.comboBox1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "button5_Form";
            this.Text = " Блюдо-Поставщики";
            this.Load += new System.EventHandler(this.button5_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bludaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bludaPostavshikAnyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bludaPostavshikAllBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListBox AnyBox;
        private System.Windows.Forms.ListBox AllBox;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource bludaBindingSource;
        private DataSet1TableAdapters.bludaTableAdapter bludaTableAdapter;
        private System.Windows.Forms.BindingSource bludaPostavshikAnyBindingSource;
        private DataSet1TableAdapters.PostavshikAnyTableAdapter postavshikAnyTableAdapter;
        private System.Windows.Forms.BindingSource bludaPostavshikAllBindingSource;
        private DataSet1TableAdapters.PostavshikAllTableAdapter postavshikAllTableAdapter;
    }
}