namespace Lab2_Pansionat
{
    partial class button3_Form
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
            this.trapezBox = new System.Windows.Forms.ComboBox();
            this.trapeziBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Lab2_Pansionat.DataSet1();
            this.vidblBox = new System.Windows.Forms.ComboBox();
            this.vidbludBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.fKbludab15502E78BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.trapeziTableAdapter = new Lab2_Pansionat.DataSet1TableAdapters.trapeziTableAdapter();
            this.vid_bludTableAdapter = new Lab2_Pansionat.DataSet1TableAdapters.vid_bludTableAdapter();
            this.menubludoTableAdapter = new Lab2_Pansionat.DataSet1TableAdapters.menubludoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.trapeziBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vidbludBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKbludab15502E78BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // trapezBox
            // 
            this.trapezBox.DataSource = this.trapeziBindingSource;
            this.trapezBox.DisplayMember = "trapeza";
            this.trapezBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.trapezBox.FormattingEnabled = true;
            this.trapezBox.Location = new System.Drawing.Point(12, 12);
            this.trapezBox.Name = "trapezBox";
            this.trapezBox.Size = new System.Drawing.Size(121, 31);
            this.trapezBox.TabIndex = 0;
            this.trapezBox.ValueMember = "t";
            this.trapezBox.SelectedIndexChanged += new System.EventHandler(this.trapezBox_SelectedIndexChanged);
            // 
            // trapeziBindingSource
            // 
            this.trapeziBindingSource.DataMember = "trapezi";
            this.trapeziBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vidblBox
            // 
            this.vidblBox.DataSource = this.vidbludBindingSource;
            this.vidblBox.DisplayMember = "vid";
            this.vidblBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vidblBox.FormattingEnabled = true;
            this.vidblBox.Location = new System.Drawing.Point(139, 12);
            this.vidblBox.Name = "vidblBox";
            this.vidblBox.Size = new System.Drawing.Size(121, 31);
            this.vidblBox.TabIndex = 1;
            // 
            // vidbludBindingSource
            // 
            this.vidbludBindingSource.DataMember = "vid_blud";
            this.vidbludBindingSource.DataSource = this.dataSet1;
            // 
            // listBox1
            // 
            this.listBox1.DataSource = this.fKbludab15502E78BindingSource;
            this.listBox1.DisplayMember = "bludo";
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 23;
            this.listBox1.Location = new System.Drawing.Point(266, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(244, 142);
            this.listBox1.TabIndex = 2;
            // 
            // fKbludab15502E78BindingSource
            // 
            this.fKbludab15502E78BindingSource.DataMember = "FK__bluda__b__15502E78";
            this.fKbludab15502E78BindingSource.DataSource = this.vidbludBindingSource;
            // 
            // trapeziTableAdapter
            // 
            this.trapeziTableAdapter.ClearBeforeFill = true;
            // 
            // vid_bludTableAdapter
            // 
            this.vid_bludTableAdapter.ClearBeforeFill = true;
            // 
            // menubludoTableAdapter
            // 
            this.menubludoTableAdapter.ClearBeforeFill = true;
            // 
            // button3_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 162);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.vidblBox);
            this.Controls.Add(this.trapezBox);
            this.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "button3_Form";
            this.Text = " Список  блюд,  предлагаемых  в  меню  на  заданную трапезу  и  заданный  вид  бл" +
    "юд";
            this.Load += new System.EventHandler(this.button3_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trapeziBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vidbludBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKbludab15502E78BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox trapezBox;
        private System.Windows.Forms.ComboBox vidblBox;
        private System.Windows.Forms.ListBox listBox1;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource trapeziBindingSource;
        private DataSet1TableAdapters.trapeziTableAdapter trapeziTableAdapter;
        private System.Windows.Forms.BindingSource vidbludBindingSource;
        private DataSet1TableAdapters.vid_bludTableAdapter vid_bludTableAdapter;
        private DataSet1TableAdapters.menubludoTableAdapter menubludoTableAdapter;
        private System.Windows.Forms.BindingSource fKbludab15502E78BindingSource;
    }
}