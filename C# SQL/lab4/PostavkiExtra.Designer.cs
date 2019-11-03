namespace Lab4_Postavki
{
    partial class PostavkiExtra
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
            this.CurrentGridView = new System.Windows.Forms.DataGridView();
            this.EditedGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Delbutton = new System.Windows.Forms.Button();
            this.Cancelbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditedGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CurrentGridView
            // 
            this.CurrentGridView.AllowUserToAddRows = false;
            this.CurrentGridView.AllowUserToDeleteRows = false;
            this.CurrentGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CurrentGridView.Location = new System.Drawing.Point(13, 34);
            this.CurrentGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CurrentGridView.Name = "CurrentGridView";
            this.CurrentGridView.ReadOnly = true;
            this.CurrentGridView.RowHeadersVisible = false;
            this.CurrentGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CurrentGridView.Size = new System.Drawing.Size(360, 231);
            this.CurrentGridView.TabIndex = 1;
            // 
            // EditedGridView
            // 
            this.EditedGridView.AllowUserToAddRows = false;
            this.EditedGridView.AllowUserToDeleteRows = false;
            this.EditedGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EditedGridView.Location = new System.Drawing.Point(393, 34);
            this.EditedGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EditedGridView.Name = "EditedGridView";
            this.EditedGridView.ReadOnly = true;
            this.EditedGridView.RowHeadersVisible = false;
            this.EditedGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EditedGridView.Size = new System.Drawing.Size(360, 231);
            this.EditedGridView.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Текущие";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(393, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Изменённые";
            // 
            // Delbutton
            // 
            this.Delbutton.Location = new System.Drawing.Point(144, 273);
            this.Delbutton.Name = "Delbutton";
            this.Delbutton.Size = new System.Drawing.Size(98, 35);
            this.Delbutton.TabIndex = 8;
            this.Delbutton.Text = "Удалить";
            this.Delbutton.UseVisualStyleBackColor = true;
            this.Delbutton.Click += new System.EventHandler(this.Delbutton_Click);
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.Location = new System.Drawing.Point(524, 273);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(98, 35);
            this.Cancelbutton.TabIndex = 9;
            this.Cancelbutton.Text = "Отменить";
            this.Cancelbutton.UseVisualStyleBackColor = true;
            this.Cancelbutton.Click += new System.EventHandler(this.Cancelbutton_Click);
            // 
            // PostavshikiExtra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 342);
            this.Controls.Add(this.Cancelbutton);
            this.Controls.Add(this.Delbutton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EditedGridView);
            this.Controls.Add(this.CurrentGridView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PostavshikiExtra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PostavshikiExtra";
            this.Load += new System.EventHandler(this.PostavkiExtra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CurrentGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditedGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView CurrentGridView;
        private System.Windows.Forms.DataGridView EditedGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Delbutton;
        private System.Windows.Forms.Button Cancelbutton;
    }
}