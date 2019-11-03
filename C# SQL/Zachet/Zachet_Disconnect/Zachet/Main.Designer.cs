namespace Zachet
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.таблицаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.исполнительToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.жанрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сотрудникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.записьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tESTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.записиИсполнителя1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.записиМеждуДатамиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сотрудникКварталыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.максЖанрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.максИсполнителиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.записиПоЖанрамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.таблицаToolStripMenuItem,
            this.отчётыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(448, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // таблицаToolStripMenuItem
            // 
            this.таблицаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.исполнительToolStripMenuItem,
            this.жанрToolStripMenuItem,
            this.сотрудникToolStripMenuItem,
            this.записьToolStripMenuItem,
            this.tESTToolStripMenuItem});
            this.таблицаToolStripMenuItem.Name = "таблицаToolStripMenuItem";
            this.таблицаToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.таблицаToolStripMenuItem.Text = "Таблица";
            // 
            // исполнительToolStripMenuItem
            // 
            this.исполнительToolStripMenuItem.Name = "исполнительToolStripMenuItem";
            this.исполнительToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.исполнительToolStripMenuItem.Text = "Исполнитель";
            this.исполнительToolStripMenuItem.Click += new System.EventHandler(this.исполнительToolStripMenuItem_Click);
            // 
            // жанрToolStripMenuItem
            // 
            this.жанрToolStripMenuItem.Name = "жанрToolStripMenuItem";
            this.жанрToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.жанрToolStripMenuItem.Text = "Жанр";
            this.жанрToolStripMenuItem.Click += new System.EventHandler(this.жанрToolStripMenuItem_Click);
            // 
            // сотрудникToolStripMenuItem
            // 
            this.сотрудникToolStripMenuItem.Name = "сотрудникToolStripMenuItem";
            this.сотрудникToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.сотрудникToolStripMenuItem.Text = "Сотрудник";
            this.сотрудникToolStripMenuItem.Click += new System.EventHandler(this.сотрудникToolStripMenuItem_Click);
            // 
            // записьToolStripMenuItem
            // 
            this.записьToolStripMenuItem.Name = "записьToolStripMenuItem";
            this.записьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.записьToolStripMenuItem.Text = "Запись";
            this.записьToolStripMenuItem.Click += new System.EventHandler(this.записьToolStripMenuItem_Click);
            // 
            // tESTToolStripMenuItem
            // 
            this.tESTToolStripMenuItem.Name = "tESTToolStripMenuItem";
            this.tESTToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tESTToolStripMenuItem.Text = "TEST";
            this.tESTToolStripMenuItem.Visible = false;
            this.tESTToolStripMenuItem.Click += new System.EventHandler(this.tESTToolStripMenuItem_Click);
            // 
            // отчётыToolStripMenuItem
            // 
            this.отчётыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.записиИсполнителя1ToolStripMenuItem,
            this.записиМеждуДатамиToolStripMenuItem,
            this.сотрудникКварталыToolStripMenuItem,
            this.максЖанрыToolStripMenuItem,
            this.максИсполнителиToolStripMenuItem,
            this.записиПоЖанрамToolStripMenuItem});
            this.отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem";
            this.отчётыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчётыToolStripMenuItem.Text = "Отчёты";
            // 
            // записиИсполнителя1ToolStripMenuItem
            // 
            this.записиИсполнителя1ToolStripMenuItem.Name = "записиИсполнителя1ToolStripMenuItem";
            this.записиИсполнителя1ToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.записиИсполнителя1ToolStripMenuItem.Text = "Записи исполнителя";
            this.записиИсполнителя1ToolStripMenuItem.Click += new System.EventHandler(this.записиИсполнителя1ToolStripMenuItem_Click);
            // 
            // записиМеждуДатамиToolStripMenuItem
            // 
            this.записиМеждуДатамиToolStripMenuItem.Name = "записиМеждуДатамиToolStripMenuItem";
            this.записиМеждуДатамиToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.записиМеждуДатамиToolStripMenuItem.Text = "Записи между датами";
            this.записиМеждуДатамиToolStripMenuItem.Click += new System.EventHandler(this.записиМеждуДатамиToolStripMenuItem_Click);
            // 
            // сотрудникКварталыToolStripMenuItem
            // 
            this.сотрудникКварталыToolStripMenuItem.Name = "сотрудникКварталыToolStripMenuItem";
            this.сотрудникКварталыToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.сотрудникКварталыToolStripMenuItem.Text = "Сотрудник — кварталы";
            this.сотрудникКварталыToolStripMenuItem.Click += new System.EventHandler(this.сотрудникКварталыToolStripMenuItem_Click);
            // 
            // максЖанрыToolStripMenuItem
            // 
            this.максЖанрыToolStripMenuItem.Name = "максЖанрыToolStripMenuItem";
            this.максЖанрыToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.максЖанрыToolStripMenuItem.Text = "Макс жанры";
            this.максЖанрыToolStripMenuItem.Click += new System.EventHandler(this.максЖанрыToolStripMenuItem_Click);
            // 
            // максИсполнителиToolStripMenuItem
            // 
            this.максИсполнителиToolStripMenuItem.Name = "максИсполнителиToolStripMenuItem";
            this.максИсполнителиToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.максИсполнителиToolStripMenuItem.Text = "Жанры исполнителей";
            this.максИсполнителиToolStripMenuItem.Click += new System.EventHandler(this.максИсполнителиToolStripMenuItem_Click);
            // 
            // записиПоЖанрамToolStripMenuItem
            // 
            this.записиПоЖанрамToolStripMenuItem.Name = "записиПоЖанрамToolStripMenuItem";
            this.записиПоЖанрамToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.записиПоЖанрамToolStripMenuItem.Text = "Сотрудники помесячно";
            this.записиПоЖанрамToolStripMenuItem.Click += new System.EventHandler(this.записиПоЖанрамToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(448, 207);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(448, 231);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Радиостанция Vladivostok FM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem таблицаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem исполнительToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem жанрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сотрудникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem записьToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem отчётыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem записиИсполнителя1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem записиМеждуДатамиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сотрудникКварталыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem максЖанрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem максИсполнителиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem записиПоЖанрамToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tESTToolStripMenuItem;
    }
}

