namespace Lab3_Pansionat
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
            this.yearBox = new System.Windows.Forms.ListBox();
            this.monthBox = new System.Windows.Forms.ListBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // yearBox
            // 
            this.yearBox.FormattingEnabled = true;
            this.yearBox.ItemHeight = 23;
            this.yearBox.Location = new System.Drawing.Point(12, 12);
            this.yearBox.Name = "yearBox";
            this.yearBox.Size = new System.Drawing.Size(120, 119);
            this.yearBox.TabIndex = 0;
            this.yearBox.ValueMember = "yearexpr";
            this.yearBox.SelectedIndexChanged += new System.EventHandler(this.yearBox_SelectedIndexChanged);
            // 
            // monthBox
            // 
            this.monthBox.FormattingEnabled = true;
            this.monthBox.ItemHeight = 23;
            this.monthBox.Location = new System.Drawing.Point(138, 12);
            this.monthBox.Name = "monthBox";
            this.monthBox.Size = new System.Drawing.Size(120, 119);
            this.monthBox.TabIndex = 1;
            this.monthBox.ValueMember = "monthexpr";
            this.monthBox.SelectedIndexChanged += new System.EventHandler(this.monthBox_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(264, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(434, 119);
            this.dataGridView1.TabIndex = 2;
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox yearBox;
        private System.Windows.Forms.ListBox monthBox;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}