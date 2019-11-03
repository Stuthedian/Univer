namespace Lab4_Postavki
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.Tablebutton = new System.Windows.Forms.Button();
            this.Querybutton = new System.Windows.Forms.Button();
            this.Exitbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "База данных \"Поставки\"";
            // 
            // Tablebutton
            // 
            this.Tablebutton.Location = new System.Drawing.Point(79, 57);
            this.Tablebutton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Tablebutton.Name = "Tablebutton";
            this.Tablebutton.Size = new System.Drawing.Size(120, 30);
            this.Tablebutton.TabIndex = 1;
            this.Tablebutton.Text = "Таблицы";
            this.Tablebutton.UseVisualStyleBackColor = true;
            this.Tablebutton.Click += new System.EventHandler(this.Tablebutton_Click);
            // 
            // Querybutton
            // 
            this.Querybutton.Location = new System.Drawing.Point(79, 97);
            this.Querybutton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Querybutton.Name = "Querybutton";
            this.Querybutton.Size = new System.Drawing.Size(120, 30);
            this.Querybutton.TabIndex = 2;
            this.Querybutton.Text = "Запросы";
            this.Querybutton.UseVisualStyleBackColor = true;
            this.Querybutton.Click += new System.EventHandler(this.Querybutton_Click);
            // 
            // Exitbutton
            // 
            this.Exitbutton.Location = new System.Drawing.Point(79, 137);
            this.Exitbutton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Exitbutton.Name = "Exitbutton";
            this.Exitbutton.Size = new System.Drawing.Size(120, 30);
            this.Exitbutton.TabIndex = 3;
            this.Exitbutton.Text = "Выход";
            this.Exitbutton.UseVisualStyleBackColor = true;
            this.Exitbutton.Click += new System.EventHandler(this.Exitbutton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 211);
            this.Controls.Add(this.Exitbutton);
            this.Controls.Add(this.Querybutton);
            this.Controls.Add(this.Tablebutton);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поставки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Tablebutton;
        private System.Windows.Forms.Button Querybutton;
        private System.Windows.Forms.Button Exitbutton;
    }
}

