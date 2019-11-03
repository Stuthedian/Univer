namespace Lab4_Postavki
{
    partial class TableForm
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
            this.Postavshikbutton = new System.Windows.Forms.Button();
            this.Produktbutton = new System.Windows.Forms.Button();
            this.Postavkibutton = new System.Windows.Forms.Button();
            this.Exitbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Postavshikbutton
            // 
            this.Postavshikbutton.Location = new System.Drawing.Point(78, 12);
            this.Postavshikbutton.Name = "Postavshikbutton";
            this.Postavshikbutton.Size = new System.Drawing.Size(123, 30);
            this.Postavshikbutton.TabIndex = 0;
            this.Postavshikbutton.Text = "Поставщики";
            this.Postavshikbutton.UseVisualStyleBackColor = true;
            this.Postavshikbutton.Click += new System.EventHandler(this.Postavshikbutton_Click);
            // 
            // Produktbutton
            // 
            this.Produktbutton.Location = new System.Drawing.Point(78, 48);
            this.Produktbutton.Name = "Produktbutton";
            this.Produktbutton.Size = new System.Drawing.Size(123, 30);
            this.Produktbutton.TabIndex = 1;
            this.Produktbutton.Text = "Продукты";
            this.Produktbutton.UseVisualStyleBackColor = true;
            this.Produktbutton.Click += new System.EventHandler(this.Produktbutton_Click);
            // 
            // Postavkibutton
            // 
            this.Postavkibutton.Location = new System.Drawing.Point(78, 84);
            this.Postavkibutton.Name = "Postavkibutton";
            this.Postavkibutton.Size = new System.Drawing.Size(123, 30);
            this.Postavkibutton.TabIndex = 2;
            this.Postavkibutton.Text = "Поставки";
            this.Postavkibutton.UseVisualStyleBackColor = true;
            this.Postavkibutton.Click += new System.EventHandler(this.Postavkibutton_Click);
            // 
            // Exitbutton
            // 
            this.Exitbutton.Location = new System.Drawing.Point(78, 120);
            this.Exitbutton.Name = "Exitbutton";
            this.Exitbutton.Size = new System.Drawing.Size(123, 30);
            this.Exitbutton.TabIndex = 3;
            this.Exitbutton.Text = "Выход";
            this.Exitbutton.UseVisualStyleBackColor = true;
            this.Exitbutton.Click += new System.EventHandler(this.Exitbutton_Click);
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 161);
            this.Controls.Add(this.Exitbutton);
            this.Controls.Add(this.Postavkibutton);
            this.Controls.Add(this.Produktbutton);
            this.Controls.Add(this.Postavshikbutton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TableForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Таблицы";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button Postavshikbutton;
        private System.Windows.Forms.Button Produktbutton;
        private System.Windows.Forms.Button Postavkibutton;
        private System.Windows.Forms.Button Exitbutton;
    }
}