namespace Lab4_Postavki
{
    partial class Query3
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TrapezBox = new System.Windows.Forms.ComboBox();
            this.VidbludBox = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выбор трапезы";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Выбор вида блюда";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Блюдо";
            // 
            // TrapezBox
            // 
            this.TrapezBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TrapezBox.FormattingEnabled = true;
            this.TrapezBox.Location = new System.Drawing.Point(47, 34);
            this.TrapezBox.Name = "TrapezBox";
            this.TrapezBox.Size = new System.Drawing.Size(121, 28);
            this.TrapezBox.TabIndex = 3;
            this.TrapezBox.SelectedIndexChanged += new System.EventHandler(this.TrapezBox_SelectedIndexChanged);
            // 
            // VidbludBox
            // 
            this.VidbludBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VidbludBox.FormattingEnabled = true;
            this.VidbludBox.Location = new System.Drawing.Point(47, 97);
            this.VidbludBox.Name = "VidbludBox";
            this.VidbludBox.Size = new System.Drawing.Size(121, 28);
            this.VidbludBox.TabIndex = 4;
            this.VidbludBox.SelectedIndexChanged += new System.EventHandler(this.VidbludBox_SelectedIndexChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(214, 34);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 124);
            this.listBox1.TabIndex = 5;
            // 
            // Query3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 176);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.VidbludBox);
            this.Controls.Add(this.TrapezBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Query3";
            this.Text = "Query3";
            this.Load += new System.EventHandler(this.Query3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox TrapezBox;
        private System.Windows.Forms.ComboBox VidbludBox;
        private System.Windows.Forms.ListBox listBox1;
    }
}