namespace Lab4_Postavki
{
    partial class QueryForm
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
            this.Query1 = new System.Windows.Forms.Button();
            this.Query2 = new System.Windows.Forms.Button();
            this.Query3 = new System.Windows.Forms.Button();
            this.Exitbutton = new System.Windows.Forms.Button();
            this.Query4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Query1
            // 
            this.Query1.Location = new System.Drawing.Point(31, 12);
            this.Query1.Name = "Query1";
            this.Query1.Size = new System.Drawing.Size(262, 33);
            this.Query1.TabIndex = 0;
            this.Query1.Text = "Блюда с заданным продуктом";
            this.Query1.UseVisualStyleBackColor = true;
            this.Query1.Click += new System.EventHandler(this.Query1_Click);
            // 
            // Query2
            // 
            this.Query2.Location = new System.Drawing.Point(31, 51);
            this.Query2.Name = "Query2";
            this.Query2.Size = new System.Drawing.Size(262, 89);
            this.Query2.TabIndex = 1;
            this.Query2.Text = "Для каждого поставщика суммарная масса поставленных продуктов по каждому кварталу" +
    " и всего за год";
            this.Query2.UseVisualStyleBackColor = true;
            this.Query2.Click += new System.EventHandler(this.Query2_Click);
            // 
            // Query3
            // 
            this.Query3.Location = new System.Drawing.Point(31, 146);
            this.Query3.Name = "Query3";
            this.Query3.Size = new System.Drawing.Size(262, 68);
            this.Query3.TabIndex = 2;
            this.Query3.Text = "Список блюд, предлагаемых на заданную трапезу и заданный вид блюда";
            this.Query3.UseVisualStyleBackColor = true;
            this.Query3.Click += new System.EventHandler(this.Query3_Click);
            // 
            // Exitbutton
            // 
            this.Exitbutton.Location = new System.Drawing.Point(31, 274);
            this.Exitbutton.Name = "Exitbutton";
            this.Exitbutton.Size = new System.Drawing.Size(262, 28);
            this.Exitbutton.TabIndex = 3;
            this.Exitbutton.Text = "Выход";
            this.Exitbutton.UseVisualStyleBackColor = true;
            this.Exitbutton.Click += new System.EventHandler(this.Exitbutton_Click);
            // 
            // Query4
            // 
            this.Query4.Location = new System.Drawing.Point(31, 220);
            this.Query4.Name = "Query4";
            this.Query4.Size = new System.Drawing.Size(262, 48);
            this.Query4.TabIndex = 4;
            this.Query4.Text = "Информация о заданном блюде";
            this.Query4.UseVisualStyleBackColor = true;
            this.Query4.Click += new System.EventHandler(this.Query4_Click);
            // 
            // QueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 312);
            this.Controls.Add(this.Query4);
            this.Controls.Add(this.Exitbutton);
            this.Controls.Add(this.Query3);
            this.Controls.Add(this.Query2);
            this.Controls.Add(this.Query1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "QueryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Запросы";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Query1;
        private System.Windows.Forms.Button Query2;
        private System.Windows.Forms.Button Query3;
        private System.Windows.Forms.Button Exitbutton;
        private System.Windows.Forms.Button Query4;
    }
}