namespace toko_cat
{
    partial class Supervisor
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
            this.dgvSupervisor = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tambahJadwalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tambahJadwalToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupervisor)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSupervisor
            // 
            this.dgvSupervisor.AllowUserToAddRows = false;
            this.dgvSupervisor.AllowUserToDeleteRows = false;
            this.dgvSupervisor.AllowUserToResizeColumns = false;
            this.dgvSupervisor.AllowUserToResizeRows = false;
            this.dgvSupervisor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSupervisor.ColumnHeadersHeight = 34;
            this.dgvSupervisor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSupervisor.Location = new System.Drawing.Point(0, 33);
            this.dgvSupervisor.MultiSelect = false;
            this.dgvSupervisor.Name = "dgvSupervisor";
            this.dgvSupervisor.ReadOnly = true;
            this.dgvSupervisor.RowHeadersVisible = false;
            this.dgvSupervisor.RowHeadersWidth = 62;
            this.dgvSupervisor.RowTemplate.Height = 28;
            this.dgvSupervisor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSupervisor.Size = new System.Drawing.Size(1570, 834);
            this.dgvSupervisor.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tambahJadwalToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1570, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tambahJadwalToolStripMenuItem
            // 
            this.tambahJadwalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tambahJadwalToolStripMenuItem1,
            this.reportToolStripMenuItem1});
            this.tambahJadwalToolStripMenuItem.Name = "tambahJadwalToolStripMenuItem";
            this.tambahJadwalToolStripMenuItem.Size = new System.Drawing.Size(73, 29);
            this.tambahJadwalToolStripMenuItem.Text = "&Menu";
            // 
            // tambahJadwalToolStripMenuItem1
            // 
            this.tambahJadwalToolStripMenuItem1.Name = "tambahJadwalToolStripMenuItem1";
            this.tambahJadwalToolStripMenuItem1.Size = new System.Drawing.Size(270, 34);
            this.tambahJadwalToolStripMenuItem1.Text = "&Tambah Jadwal";
            this.tambahJadwalToolStripMenuItem1.Click += new System.EventHandler(this.tambahJadwalToolStripMenuItem1_Click);
            // 
            // reportToolStripMenuItem1
            // 
            this.reportToolStripMenuItem1.Name = "reportToolStripMenuItem1";
            this.reportToolStripMenuItem1.Size = new System.Drawing.Size(233, 34);
            this.reportToolStripMenuItem1.Text = "&Report";
            // 
            // Supervisor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1570, 867);
            this.Controls.Add(this.dgvSupervisor);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Supervisor";
            this.Text = "Supervisor";
            this.Load += new System.EventHandler(this.Supervisor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupervisor)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSupervisor;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tambahJadwalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tambahJadwalToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem1;
    }
}