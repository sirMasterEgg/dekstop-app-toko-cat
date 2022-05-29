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
            this.tambahKomentarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
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
            this.dgvSupervisor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSupervisor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSupervisor.ColumnHeadersHeight = 34;
            this.dgvSupervisor.Location = new System.Drawing.Point(0, 26);
            this.dgvSupervisor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvSupervisor.MultiSelect = false;
            this.dgvSupervisor.Name = "dgvSupervisor";
            this.dgvSupervisor.ReadOnly = true;
            this.dgvSupervisor.RowHeadersVisible = false;
            this.dgvSupervisor.RowHeadersWidth = 62;
            this.dgvSupervisor.RowTemplate.Height = 28;
            this.dgvSupervisor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSupervisor.Size = new System.Drawing.Size(1396, 667);
            this.dgvSupervisor.TabIndex = 0;
            this.dgvSupervisor.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSupervisor_CellDoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tambahJadwalToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1217, 30);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tambahJadwalToolStripMenuItem
            // 
            this.tambahJadwalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tambahJadwalToolStripMenuItem1,
            this.reportToolStripMenuItem1,
            this.tambahKomentarToolStripMenuItem});
            this.tambahJadwalToolStripMenuItem.Name = "tambahJadwalToolStripMenuItem";
            this.tambahJadwalToolStripMenuItem.Size = new System.Drawing.Size(60, 28);
            this.tambahJadwalToolStripMenuItem.Text = "&Menu";
            // 
            // tambahJadwalToolStripMenuItem1
            // 
            this.tambahJadwalToolStripMenuItem1.Name = "tambahJadwalToolStripMenuItem1";
            this.tambahJadwalToolStripMenuItem1.Size = new System.Drawing.Size(213, 26);
            this.tambahJadwalToolStripMenuItem1.Text = "&Tambah Jadwal";
            this.tambahJadwalToolStripMenuItem1.Click += new System.EventHandler(this.tambahJadwalToolStripMenuItem1_Click);
            // 
            // reportToolStripMenuItem1
            // 
            this.reportToolStripMenuItem1.Name = "reportToolStripMenuItem1";
            this.reportToolStripMenuItem1.Size = new System.Drawing.Size(213, 26);
            this.reportToolStripMenuItem1.Text = "&Report";
            this.reportToolStripMenuItem1.Click += new System.EventHandler(this.reportToolStripMenuItem1_Click);
            // 
            // tambahKomentarToolStripMenuItem
            // 
            this.tambahKomentarToolStripMenuItem.Name = "tambahKomentarToolStripMenuItem";
            this.tambahKomentarToolStripMenuItem.Size = new System.Drawing.Size(213, 26);
            this.tambahKomentarToolStripMenuItem.Text = "Tambah &Komentar";
            this.tambahKomentarToolStripMenuItem.Click += new System.EventHandler(this.tambahKomentarToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 699);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "* Double click untuk absen";
            // 
            // Supervisor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 599);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvSupervisor);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Supervisor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.ToolStripMenuItem tambahKomentarToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}