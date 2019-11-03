namespace Lab4_kofe_tulskiy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Vvod_button_postavki = new System.Windows.Forms.Button();
            this.Zapros_1 = new System.Windows.Forms.Button();
            this.Zapros_2 = new System.Windows.Forms.Button();
            this.Zapros_3 = new System.Windows.Forms.Button();
            this.Exit_button = new System.Windows.Forms.Button();
            this.Vvod_button_tovar = new System.Windows.Forms.Button();
            this.Vvod_button_postavshiki = new System.Windows.Forms.Button();
            this.Zapros_4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(66, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Поставки товаров";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(137, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Запросы";
            // 
            // Vvod_button_postavki
            // 
            this.Vvod_button_postavki.AutoSize = true;
            this.Vvod_button_postavki.Location = new System.Drawing.Point(48, 144);
            this.Vvod_button_postavki.Name = "Vvod_button_postavki";
            this.Vvod_button_postavki.Size = new System.Drawing.Size(291, 41);
            this.Vvod_button_postavki.TabIndex = 2;
            this.Vvod_button_postavki.Text = "Ввод и корректировка поставок";
            this.Vvod_button_postavki.UseVisualStyleBackColor = true;
            this.Vvod_button_postavki.Click += new System.EventHandler(this.Vvod_button_postavki_Click);
            // 
            // Zapros_1
            // 
            this.Zapros_1.Location = new System.Drawing.Point(40, 221);
            this.Zapros_1.Name = "Zapros_1";
            this.Zapros_1.Size = new System.Drawing.Size(298, 58);
            this.Zapros_1.TabIndex = 3;
            this.Zapros_1.Text = "Поставки для выбранного поставщика";
            this.Zapros_1.UseVisualStyleBackColor = true;
            this.Zapros_1.Click += new System.EventHandler(this.Zapros_1_Click);
            // 
            // Zapros_2
            // 
            this.Zapros_2.Location = new System.Drawing.Point(40, 285);
            this.Zapros_2.Name = "Zapros_2";
            this.Zapros_2.Size = new System.Drawing.Size(298, 59);
            this.Zapros_2.TabIndex = 4;
            this.Zapros_2.Text = "Поставки по месяцам выбранного товара";
            this.Zapros_2.UseVisualStyleBackColor = true;
            this.Zapros_2.Click += new System.EventHandler(this.Zapros_2_Click);
            // 
            // Zapros_3
            // 
            this.Zapros_3.Location = new System.Drawing.Point(40, 350);
            this.Zapros_3.Name = "Zapros_3";
            this.Zapros_3.Size = new System.Drawing.Size(298, 41);
            this.Zapros_3.TabIndex = 5;
            this.Zapros_3.Text = "Итоговые поставки по поставщикам";
            this.Zapros_3.UseVisualStyleBackColor = true;
            this.Zapros_3.Click += new System.EventHandler(this.Zapros_3_Click);
            // 
            // Exit_button
            // 
            this.Exit_button.AutoSize = true;
            this.Exit_button.Location = new System.Drawing.Point(142, 466);
            this.Exit_button.Name = "Exit_button";
            this.Exit_button.Size = new System.Drawing.Size(99, 41);
            this.Exit_button.TabIndex = 6;
            this.Exit_button.Text = "Выход";
            this.Exit_button.UseVisualStyleBackColor = true;
            this.Exit_button.Click += new System.EventHandler(this.Exit_button_Click);
            // 
            // Vvod_button_tovar
            // 
            this.Vvod_button_tovar.AutoSize = true;
            this.Vvod_button_tovar.Location = new System.Drawing.Point(48, 50);
            this.Vvod_button_tovar.Name = "Vvod_button_tovar";
            this.Vvod_button_tovar.Size = new System.Drawing.Size(291, 41);
            this.Vvod_button_tovar.TabIndex = 7;
            this.Vvod_button_tovar.Text = "Ввод и корректировка товаров";
            this.Vvod_button_tovar.UseVisualStyleBackColor = true;
            this.Vvod_button_tovar.Click += new System.EventHandler(this.Vvod_button_tovar_Click);
            // 
            // Vvod_button_postavshiki
            // 
            this.Vvod_button_postavshiki.AutoSize = true;
            this.Vvod_button_postavshiki.Location = new System.Drawing.Point(48, 97);
            this.Vvod_button_postavshiki.Name = "Vvod_button_postavshiki";
            this.Vvod_button_postavshiki.Size = new System.Drawing.Size(291, 41);
            this.Vvod_button_postavshiki.TabIndex = 8;
            this.Vvod_button_postavshiki.Text = "Ввод и корректировка поставщиков";
            this.Vvod_button_postavshiki.UseVisualStyleBackColor = true;
            this.Vvod_button_postavshiki.Click += new System.EventHandler(this.Vvod_button_postavshiki_Click);
            // 
            // Zapros_4
            // 
            this.Zapros_4.Location = new System.Drawing.Point(40, 397);
            this.Zapros_4.Name = "Zapros_4";
            this.Zapros_4.Size = new System.Drawing.Size(298, 63);
            this.Zapros_4.TabIndex = 9;
            this.Zapros_4.Text = "Поставщики со схожими поставками";
            this.Zapros_4.UseVisualStyleBackColor = true;
            this.Zapros_4.Click += new System.EventHandler(this.Zapros_4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 519);
            this.Controls.Add(this.Zapros_4);
            this.Controls.Add(this.Vvod_button_postavshiki);
            this.Controls.Add(this.Vvod_button_tovar);
            this.Controls.Add(this.Exit_button);
            this.Controls.Add(this.Zapros_3);
            this.Controls.Add(this.Zapros_2);
            this.Controls.Add(this.Zapros_1);
            this.Controls.Add(this.Vvod_button_postavki);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Кофе тульский";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button Vvod_button_postavki;
		private System.Windows.Forms.Button Zapros_1;
		private System.Windows.Forms.Button Zapros_2;
		private System.Windows.Forms.Button Zapros_3;
		private System.Windows.Forms.Button Exit_button;
		private System.Windows.Forms.Button Vvod_button_tovar;
		private System.Windows.Forms.Button Vvod_button_postavshiki;
        private System.Windows.Forms.Button Zapros_4;
    }
}

