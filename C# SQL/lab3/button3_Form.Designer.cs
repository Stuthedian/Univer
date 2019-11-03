namespace Lab3_Pansionat
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
            this.trapezBox = new System.Windows.Forms.ComboBox();
            this.vidblBox = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // trapezBox
            // 
            this.trapezBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.trapezBox.FormattingEnabled = true;
            this.trapezBox.Location = new System.Drawing.Point(12, 12);
            this.trapezBox.Name = "trapezBox";
            this.trapezBox.Size = new System.Drawing.Size(121, 31);
            this.trapezBox.TabIndex = 0;
            this.trapezBox.ValueMember = "t";
            this.trapezBox.SelectedIndexChanged += new System.EventHandler(this.trapezBox_SelectedIndexChanged);
            // 
            // vidblBox
            // 
            this.vidblBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vidblBox.FormattingEnabled = true;
            this.vidblBox.Location = new System.Drawing.Point(139, 12);
            this.vidblBox.Name = "vidblBox";
            this.vidblBox.Size = new System.Drawing.Size(121, 31);
            this.vidblBox.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 23;
            this.listBox1.Location = new System.Drawing.Point(266, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(244, 142);
            this.listBox1.TabIndex = 2;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox trapezBox;
        private System.Windows.Forms.ComboBox vidblBox;
        private System.Windows.Forms.ListBox listBox1;
    }
}