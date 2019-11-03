namespace Zachet
{
    partial class Ispolnitel
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.Exitbutton = new System.Windows.Forms.Button();
            this.Delbutton = new System.Windows.Forms.Button();
            this.Editbutton = new System.Windows.Forms.Button();
            this.Addbutton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Exitbutton);
            this.panel2.Controls.Add(this.Delbutton);
            this.panel2.Controls.Add(this.Editbutton);
            this.panel2.Controls.Add(this.Addbutton);
            this.panel2.Location = new System.Drawing.Point(235, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(101, 144);
            this.panel2.TabIndex = 12;
            // 
            // Exitbutton
            // 
            this.Exitbutton.Location = new System.Drawing.Point(5, 108);
            this.Exitbutton.Name = "Exitbutton";
            this.Exitbutton.Size = new System.Drawing.Size(93, 31);
            this.Exitbutton.TabIndex = 3;
            this.Exitbutton.Text = "Выход";
            this.Exitbutton.UseVisualStyleBackColor = true;
            this.Exitbutton.Click += new System.EventHandler(this.Exitbutton_Click);
            // 
            // Delbutton
            // 
            this.Delbutton.Location = new System.Drawing.Point(5, 73);
            this.Delbutton.Name = "Delbutton";
            this.Delbutton.Size = new System.Drawing.Size(93, 31);
            this.Delbutton.TabIndex = 2;
            this.Delbutton.Text = "Удалить";
            this.Delbutton.UseVisualStyleBackColor = true;
            this.Delbutton.Click += new System.EventHandler(this.Delbutton_Click);
            // 
            // Editbutton
            // 
            this.Editbutton.Location = new System.Drawing.Point(5, 38);
            this.Editbutton.Name = "Editbutton";
            this.Editbutton.Size = new System.Drawing.Size(93, 31);
            this.Editbutton.TabIndex = 1;
            this.Editbutton.Text = "Изменить";
            this.Editbutton.UseVisualStyleBackColor = true;
            this.Editbutton.Click += new System.EventHandler(this.Editbutton_Click);
            // 
            // Addbutton
            // 
            this.Addbutton.Location = new System.Drawing.Point(5, 3);
            this.Addbutton.Name = "Addbutton";
            this.Addbutton.Size = new System.Drawing.Size(93, 31);
            this.Addbutton.TabIndex = 0;
            this.Addbutton.Text = "Добавить";
            this.Addbutton.UseVisualStyleBackColor = true;
            this.Addbutton.Click += new System.EventHandler(this.Addbutton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(217, 144);
            this.listBox1.TabIndex = 13;
            // 
            // Ispolnitel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(341, 167);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Ispolnitel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Исполнитель";
            this.Load += new System.EventHandler(this.Ispolnitel_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Exitbutton;
        private System.Windows.Forms.Button Delbutton;
        private System.Windows.Forms.Button Editbutton;
        private System.Windows.Forms.Button Addbutton;
        private System.Windows.Forms.ListBox listBox1;
    }
}