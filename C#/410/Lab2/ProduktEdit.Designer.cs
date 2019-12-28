namespace Lab2
{
    partial class ProduktEdit
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
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 26);
            this.textBox1.TabIndex = 0;
            // 
            // BludoProduktslistBox
            // 
            this.BludoProduktslistBox.FormattingEnabled = true;
            this.BludoProduktslistBox.ItemHeight = 20;
            this.BludoProduktslistBox.Location = new System.Drawing.Point(128, 48);
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
            this.AllProduktslistBox.Location = new System.Drawing.Point(335, 48);
            this.AllProduktslistBox.Name = "AllProduktslistBox";
            this.AllProduktslistBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.AllProduktslistBox.Size = new System.Drawing.Size(120, 84);
            this.AllProduktslistBox.TabIndex = 2;
            this.AllProduktslistBox.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // ToSostavbutton
            // 
            this.ToSostavbutton.Location = new System.Drawing.Point(271, 48);
            this.ToSostavbutton.Name = "ToSostavbutton";
            this.ToSostavbutton.Size = new System.Drawing.Size(39, 36);
            this.ToSostavbutton.TabIndex = 3;
            this.ToSostavbutton.Text = "<-";
            this.ToSostavbutton.UseVisualStyleBackColor = true;
            this.ToSostavbutton.Click += new System.EventHandler(this.ToSostavbutton_Click);
            // 
            // FromSostavbutton
            // 
            this.FromSostavbutton.Location = new System.Drawing.Point(271, 96);
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
            this.label1.Location = new System.Drawing.Point(21, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Продукт";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 40);
            this.label2.TabIndex = 6;
            this.label2.Text = "Поставщики \r\nпродукта";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(341, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Поставщики";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(244, 150);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 31);
            this.button1.TabIndex = 8;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(461, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 51);
            this.button2.TabIndex = 9;
            this.button2.Text = "Добавить поставщика";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(461, 96);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(110, 51);
            this.button3.TabIndex = 10;
            this.button3.Text = "Удалить поставщика";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ProduktEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 214);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
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
            this.Name = "ProduktEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BludoEdit";
            this.Load += new System.EventHandler(this.BludoEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox BludoProduktslistBox;
        private System.Windows.Forms.Button ToSostavbutton;
        private System.Windows.Forms.Button FromSostavbutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.ListBox AllProduktslistBox;
        private System.Windows.Forms.Button button3;
    }
}