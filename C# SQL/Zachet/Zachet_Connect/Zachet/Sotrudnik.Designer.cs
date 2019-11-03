namespace Zachet
{
    partial class Sotrudnik
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Exitbutton = new System.Windows.Forms.Button();
            this.Delbutton = new System.Windows.Forms.Button();
            this.Editbutton = new System.Windows.Forms.Button();
            this.Addbutton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cod_sotr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.im = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.otch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Exitbutton);
            this.panel2.Controls.Add(this.Delbutton);
            this.panel2.Controls.Add(this.Editbutton);
            this.panel2.Controls.Add(this.Addbutton);
            this.panel2.Location = new System.Drawing.Point(521, 12);
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cod_sotr,
            this.fam,
            this.im,
            this.otch,
            this.dr,
            this.pol});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(503, 144);
            this.dataGridView1.TabIndex = 13;
            // 
            // cod_sotr
            // 
            this.cod_sotr.HeaderText = "cod_sotr";
            this.cod_sotr.Name = "cod_sotr";
            this.cod_sotr.ReadOnly = true;
            this.cod_sotr.Visible = false;
            // 
            // fam
            // 
            this.fam.HeaderText = "Фамилия";
            this.fam.Name = "fam";
            this.fam.ReadOnly = true;
            // 
            // im
            // 
            this.im.HeaderText = "Имя";
            this.im.Name = "im";
            this.im.ReadOnly = true;
            // 
            // otch
            // 
            this.otch.HeaderText = "Отчество";
            this.otch.Name = "otch";
            this.otch.ReadOnly = true;
            // 
            // dr
            // 
            this.dr.HeaderText = "День рождения";
            this.dr.Name = "dr";
            this.dr.ReadOnly = true;
            // 
            // pol
            // 
            this.pol.HeaderText = "Пол";
            this.pol.Name = "pol";
            this.pol.ReadOnly = true;
            // 
            // Sotrudnik
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(627, 169);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Sotrudnik";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сотрудник";
            this.Load += new System.EventHandler(this.Sotrudnik_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Exitbutton;
        private System.Windows.Forms.Button Delbutton;
        private System.Windows.Forms.Button Editbutton;
        private System.Windows.Forms.Button Addbutton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_sotr;
        private System.Windows.Forms.DataGridViewTextBoxColumn fam;
        private System.Windows.Forms.DataGridViewTextBoxColumn im;
        private System.Windows.Forms.DataGridViewTextBoxColumn otch;
        private System.Windows.Forms.DataGridViewTextBoxColumn dr;
        private System.Windows.Forms.DataGridViewTextBoxColumn pol;
    }
}