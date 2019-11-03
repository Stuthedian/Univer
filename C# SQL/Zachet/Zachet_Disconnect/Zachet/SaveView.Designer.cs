namespace Zachet
{
    partial class SaveView
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.исполнительToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.записьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.жанрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сотрудникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.исполнительToolStripMenuItem,
            this.жанрToolStripMenuItem,
            this.сотрудникToolStripMenuItem,
            this.записьToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 114);
            // 
            // исполнительToolStripMenuItem
            // 
            this.исполнительToolStripMenuItem.Name = "исполнительToolStripMenuItem";
            this.исполнительToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.исполнительToolStripMenuItem.Text = "Исполнитель";
            this.исполнительToolStripMenuItem.Click += new System.EventHandler(this.исполнительToolStripMenuItem_Click);
            // 
            // записьToolStripMenuItem
            // 
            this.записьToolStripMenuItem.Name = "записьToolStripMenuItem";
            this.записьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.записьToolStripMenuItem.Text = "Запись";
            this.записьToolStripMenuItem.Click += new System.EventHandler(this.записьToolStripMenuItem_Click);
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
            // SaveView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(797, 490);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IsMdiContainer = true;
            this.Name = "SaveView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SaveView";
            this.Load += new System.EventHandler(this.SaveView_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem исполнительToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem жанрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сотрудникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem записьToolStripMenuItem;
    }
}