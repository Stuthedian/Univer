namespace Lab2
{
    partial class Main
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Zap7button = new System.Windows.Forms.Button();
            this.Zap8button = new System.Windows.Forms.Button();
            this.Zap6button = new System.Windows.Forms.Button();
            this.Zap4button = new System.Windows.Forms.Button();
            this.Zap3button = new System.Windows.Forms.Button();
            this.Zap1button = new System.Windows.Forms.Button();
            this.Zap2button = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(74, 14);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(201, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "БлюдаПродукты";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(74, 59);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(201, 35);
            this.button2.TabIndex = 1;
            this.button2.Text = "ПродуктыПоставщики";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(74, 102);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(201, 34);
            this.button3.TabIndex = 2;
            this.button3.Text = "Отображение блюд";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(74, 142);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(201, 50);
            this.button4.TabIndex = 3;
            this.button4.Text = "Отображение продуктов";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Zap7button);
            this.groupBox1.Controls.Add(this.Zap8button);
            this.groupBox1.Controls.Add(this.Zap6button);
            this.groupBox1.Controls.Add(this.Zap4button);
            this.groupBox1.Controls.Add(this.Zap3button);
            this.groupBox1.Controls.Add(this.Zap1button);
            this.groupBox1.Controls.Add(this.Zap2button);
            this.groupBox1.Location = new System.Drawing.Point(282, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(572, 310);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Запросы";
            // 
            // Zap7button
            // 
            this.Zap7button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Zap7button.Location = new System.Drawing.Point(285, 153);
            this.Zap7button.Name = "Zap7button";
            this.Zap7button.Size = new System.Drawing.Size(259, 76);
            this.Zap7button.TabIndex = 11;
            this.Zap7button.Text = "Среди  поставщиков  выбранного  продукта  вывести  тех  кто  поставлял  наибольше" +
    "е  число продуктов";
            this.Zap7button.UseVisualStyleBackColor = true;
            this.Zap7button.Click += new System.EventHandler(this.Zap7button_Click);
            // 
            // Zap8button
            // 
            this.Zap8button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Zap8button.Location = new System.Drawing.Point(285, 235);
            this.Zap8button.Name = "Zap8button";
            this.Zap8button.Size = new System.Drawing.Size(260, 60);
            this.Zap8button.TabIndex = 10;
            this.Zap8button.Text = "Для выбранного поставщика других поставщиков, которые поставляли такие же продукт" +
    "ы ";
            this.Zap8button.UseVisualStyleBackColor = true;
            this.Zap8button.Click += new System.EventHandler(this.Zap8button_Click);
            // 
            // Zap6button
            // 
            this.Zap6button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Zap6button.Location = new System.Drawing.Point(285, 106);
            this.Zap6button.Name = "Zap6button";
            this.Zap6button.Size = new System.Drawing.Size(260, 41);
            this.Zap6button.TabIndex = 12;
            this.Zap6button.Text = "Вывести блюда и продукты, входящие в блюдо";
            this.Zap6button.UseVisualStyleBackColor = true;
            this.Zap6button.Click += new System.EventHandler(this.Zap6button_Click);
            // 
            // Zap4button
            // 
            this.Zap4button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Zap4button.Location = new System.Drawing.Point(285, 25);
            this.Zap4button.Name = "Zap4button";
            this.Zap4button.Size = new System.Drawing.Size(260, 75);
            this.Zap4button.TabIndex = 8;
            this.Zap4button.Text = "Для выбранного блюда вывести поставщиков, которые поставляли хотя один из продукт" +
    "ов, \r\nвходящих в состав блюда";
            this.Zap4button.UseVisualStyleBackColor = true;
            this.Zap4button.Click += new System.EventHandler(this.Zap4button_Click);
            // 
            // Zap3button
            // 
            this.Zap3button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Zap3button.Location = new System.Drawing.Point(19, 148);
            this.Zap3button.Name = "Zap3button";
            this.Zap3button.Size = new System.Drawing.Size(260, 59);
            this.Zap3button.TabIndex = 7;
            this.Zap3button.Text = "Для каждого блюда число поставщиков необходимых продуктов из состава блюда";
            this.Zap3button.UseVisualStyleBackColor = true;
            this.Zap3button.Click += new System.EventHandler(this.Zap3button_Click);
            // 
            // Zap1button
            // 
            this.Zap1button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Zap1button.Location = new System.Drawing.Point(19, 25);
            this.Zap1button.Name = "Zap1button";
            this.Zap1button.Size = new System.Drawing.Size(260, 55);
            this.Zap1button.TabIndex = 5;
            this.Zap1button.Text = "Для каждого продукта количество блюд, содержащих продукт";
            this.Zap1button.UseVisualStyleBackColor = true;
            this.Zap1button.Click += new System.EventHandler(this.Zap1button_Click);
            // 
            // Zap2button
            // 
            this.Zap2button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Zap2button.Location = new System.Drawing.Point(19, 86);
            this.Zap2button.Name = "Zap2button";
            this.Zap2button.Size = new System.Drawing.Size(260, 59);
            this.Zap2button.TabIndex = 6;
            this.Zap2button.Text = "Для каждого поставщика количество поставляемых им продуктов";
            this.Zap2button.UseVisualStyleBackColor = true;
            this.Zap2button.Click += new System.EventHandler(this.Zap2button_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 340);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Zap1button;
        private System.Windows.Forms.Button Zap2button;
        private System.Windows.Forms.Button Zap6button;
        private System.Windows.Forms.Button Zap7button;
        private System.Windows.Forms.Button Zap8button;
        private System.Windows.Forms.Button Zap4button;
        private System.Windows.Forms.Button Zap3button;
    }
}