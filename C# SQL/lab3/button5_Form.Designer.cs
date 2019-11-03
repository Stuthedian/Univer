namespace Lab3_Pansionat
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.AnyBox = new System.Windows.Forms.ListBox();
            this.AllBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(198, 31);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // AnyBox
            // 
            this.AnyBox.FormattingEnabled = true;
            this.AnyBox.ItemHeight = 23;
            this.AnyBox.Location = new System.Drawing.Point(216, 12);
            this.AnyBox.Name = "AnyBox";
            this.AnyBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.AnyBox.Size = new System.Drawing.Size(120, 96);
            this.AnyBox.TabIndex = 1;
            // 
            // AllBox
            // 
            this.AllBox.FormattingEnabled = true;
            this.AllBox.ItemHeight = 23;
            this.AllBox.Location = new System.Drawing.Point(342, 12);
            this.AllBox.Name = "AllBox";
            this.AllBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.AllBox.Size = new System.Drawing.Size(120, 96);
            this.AllBox.TabIndex = 2;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListBox AnyBox;
        private System.Windows.Forms.ListBox AllBox;
    }
}