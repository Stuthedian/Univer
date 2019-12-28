namespace Lab2
{
    partial class BludoEdit
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BludoProduktslistBox = new System.Windows.Forms.ListBox();
            this.AllProduktslistBox = new System.Windows.Forms.ListBox();
            this.ToSostavbutton = new System.Windows.Forms.Button();
            this.FromSostavbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 26);
            this.textBox1.TabIndex = 0;
            // 
            // BludoProduktslistBox
            // 
            this.BludoProduktslistBox.FormattingEnabled = true;
            this.BludoProduktslistBox.ItemHeight = 20;
            this.BludoProduktslistBox.Location = new System.Drawing.Point(128, 28);
            this.BludoProduktslistBox.Name = "BludoProduktslistBox";
            this.BludoProduktslistBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.BludoProduktslistBox.Size = new System.Drawing.Size(120, 84);
            this.BludoProduktslistBox.TabIndex = 1;
            this.BludoProduktslistBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // AllProduktslistBox
            // 
            this.AllProduktslistBox.FormattingEnabled = true;
            this.AllProduktslistBox.ItemHeight = 20;
            this.AllProduktslistBox.Location = new System.Drawing.Point(335, 28);
            this.AllProduktslistBox.Name = "AllProduktslistBox";
            this.AllProduktslistBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.AllProduktslistBox.Size = new System.Drawing.Size(120, 84);
            this.AllProduktslistBox.TabIndex = 2;
            this.AllProduktslistBox.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // ToSostavbutton
            // 
            this.ToSostavbutton.Location = new System.Drawing.Point(271, 28);
            this.ToSostavbutton.Name = "ToSostavbutton";
            this.ToSostavbutton.Size = new System.Drawing.Size(39, 36);
            this.ToSostavbutton.TabIndex = 3;
            this.ToSostavbutton.Text = "<-";
            this.ToSostavbutton.UseVisualStyleBackColor = true;
            this.ToSostavbutton.Click += new System.EventHandler(this.ToSostavbutton_Click);
            // 
            // FromSostavbutton
            // 
            this.FromSostavbutton.Location = new System.Drawing.Point(271, 76);
            this.FromSostavbutton.Name = "FromSostavbutton";
            this.FromSostavbutton.Size = new System.Drawing.Size(39, 36);
            this.FromSostavbutton.TabIndex = 4;
            this.FromSostavbutton.Text = "->";
            this.FromSostavbutton.UseVisualStyleBackColor = true;
            this.FromSostavbutton.Click += new System.EventHandler(this.FromSostavbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Блюдо";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Состав блюда";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(353, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Продукты";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(246, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 31);
            this.button1.TabIndex = 8;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BludoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 173);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FromSostavbutton);
            this.Controls.Add(this.ToSostavbutton);
            this.Controls.Add(this.AllProduktslistBox);
            this.Controls.Add(this.BludoProduktslistBox);
            this.Controls.Add(this.textBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BludoEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BludoEdit";
            this.Load += new System.EventHandler(this.BludoEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox BludoProduktslistBox;
        private System.Windows.Forms.ListBox AllProduktslistBox;
        private System.Windows.Forms.Button ToSostavbutton;
        private System.Windows.Forms.Button FromSostavbutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}