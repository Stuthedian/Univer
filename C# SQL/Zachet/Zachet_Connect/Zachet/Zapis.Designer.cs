namespace Zachet
{
    partial class Zapis
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
            this.cod_zap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.naim_zapis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_isp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_janr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_sotr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Isp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Janr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sotr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.Exitbutton);
            this.panel2.Controls.Add(this.Delbutton);
            this.panel2.Controls.Add(this.Editbutton);
            this.panel2.Controls.Add(this.Addbutton);
            this.panel2.Location = new System.Drawing.Point(12, 162);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(398, 38);
            this.panel2.TabIndex = 12;
            // 
            // Exitbutton
            // 
            this.Exitbutton.Location = new System.Drawing.Point(302, 3);
            this.Exitbutton.Name = "Exitbutton";
            this.Exitbutton.Size = new System.Drawing.Size(93, 31);
            this.Exitbutton.TabIndex = 3;
            this.Exitbutton.Text = "Выход";
            this.Exitbutton.UseVisualStyleBackColor = true;
            this.Exitbutton.Click += new System.EventHandler(this.Exitbutton_Click);
            // 
            // Delbutton
            // 
            this.Delbutton.Location = new System.Drawing.Point(203, 3);
            this.Delbutton.Name = "Delbutton";
            this.Delbutton.Size = new System.Drawing.Size(93, 31);
            this.Delbutton.TabIndex = 2;
            this.Delbutton.Text = "Удалить";
            this.Delbutton.UseVisualStyleBackColor = true;
            this.Delbutton.Click += new System.EventHandler(this.Delbutton_Click);
            // 
            // Editbutton
            // 
            this.Editbutton.Location = new System.Drawing.Point(104, 3);
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
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
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
            this.cod_zap,
            this.naim_zapis,
            this.data,
            this.cod_isp,
            this.cod_janr,
            this.cod_sotr,
            this.Isp,
            this.Janr,
            this.Sotr});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(398, 144);
            this.dataGridView1.TabIndex = 13;
            // 
            // cod_zap
            // 
            this.cod_zap.HeaderText = "Column1";
            this.cod_zap.Name = "cod_zap";
            this.cod_zap.ReadOnly = true;
            this.cod_zap.Visible = false;
            this.cod_zap.Width = 78;
            // 
            // naim_zapis
            // 
            this.naim_zapis.HeaderText = "Запись";
            this.naim_zapis.Name = "naim_zapis";
            this.naim_zapis.ReadOnly = true;
            this.naim_zapis.Width = 89;
            // 
            // data
            // 
            this.data.HeaderText = "Дата";
            this.data.Name = "data";
            this.data.ReadOnly = true;
            this.data.Width = 73;
            // 
            // cod_isp
            // 
            this.cod_isp.HeaderText = "Column1";
            this.cod_isp.Name = "cod_isp";
            this.cod_isp.ReadOnly = true;
            this.cod_isp.Visible = false;
            this.cod_isp.Width = 97;
            // 
            // cod_janr
            // 
            this.cod_janr.HeaderText = "Column1";
            this.cod_janr.Name = "cod_janr";
            this.cod_janr.ReadOnly = true;
            this.cod_janr.Visible = false;
            this.cod_janr.Width = 97;
            // 
            // cod_sotr
            // 
            this.cod_sotr.HeaderText = "Column1";
            this.cod_sotr.Name = "cod_sotr";
            this.cod_sotr.ReadOnly = true;
            this.cod_sotr.Visible = false;
            this.cod_sotr.Width = 97;
            // 
            // Isp
            // 
            this.Isp.HeaderText = "Исполнитель";
            this.Isp.Name = "Isp";
            this.Isp.ReadOnly = true;
            this.Isp.Width = 136;
            // 
            // Janr
            // 
            this.Janr.HeaderText = "Жанр";
            this.Janr.Name = "Janr";
            this.Janr.ReadOnly = true;
            this.Janr.Width = 74;
            // 
            // Sotr
            // 
            this.Sotr.HeaderText = "Сотрудник";
            this.Sotr.Name = "Sotr";
            this.Sotr.ReadOnly = true;
            this.Sotr.Width = 116;
            // 
            // Zapis
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(428, 205);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximizeBox = false;
            this.Name = "Zapis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Запись";
            this.Load += new System.EventHandler(this.Zapis_Load);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn famDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn otchDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn drDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn polDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_zap;
        private System.Windows.Forms.DataGridViewTextBoxColumn naim_zapis;
        private System.Windows.Forms.DataGridViewTextBoxColumn data;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_isp;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_janr;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_sotr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Isp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Janr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sotr;
    }
}