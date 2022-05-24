namespace toko_cat
{
    partial class SupervisorAdd
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbtoko = new System.Windows.Forms.ComboBox();
            this.cbsales = new System.Windows.Forms.ComboBox();
            this.btntambah = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dgvKunjungan = new System.Windows.Forms.DataGridView();
            this.cbhari = new System.Windows.Forms.ComboBox();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnclear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKunjungan)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 336);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hari Kunjungan :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 362);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Toko Tujuan :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 389);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sales :";
            // 
            // cbtoko
            // 
            this.cbtoko.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbtoko.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbtoko.FormattingEnabled = true;
            this.cbtoko.Location = new System.Drawing.Point(143, 359);
            this.cbtoko.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbtoko.Name = "cbtoko";
            this.cbtoko.Size = new System.Drawing.Size(218, 24);
            this.cbtoko.TabIndex = 4;
            // 
            // cbsales
            // 
            this.cbsales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbsales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbsales.FormattingEnabled = true;
            this.cbsales.Location = new System.Drawing.Point(143, 386);
            this.cbsales.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbsales.Name = "cbsales";
            this.cbsales.Size = new System.Drawing.Size(218, 24);
            this.cbsales.TabIndex = 5;
            // 
            // btntambah
            // 
            this.btntambah.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btntambah.Location = new System.Drawing.Point(12, 422);
            this.btntambah.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btntambah.Name = "btntambah";
            this.btntambah.Size = new System.Drawing.Size(126, 34);
            this.btntambah.TabIndex = 6;
            this.btntambah.Text = "Tambah Data";
            this.btntambah.UseVisualStyleBackColor = true;
            this.btntambah.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(366, 359);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 22);
            this.button2.TabIndex = 7;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dgvKunjungan
            // 
            this.dgvKunjungan.AllowUserToAddRows = false;
            this.dgvKunjungan.AllowUserToDeleteRows = false;
            this.dgvKunjungan.AllowUserToResizeColumns = false;
            this.dgvKunjungan.AllowUserToResizeRows = false;
            this.dgvKunjungan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKunjungan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKunjungan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKunjungan.Location = new System.Drawing.Point(11, 10);
            this.dgvKunjungan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvKunjungan.Name = "dgvKunjungan";
            this.dgvKunjungan.ReadOnly = true;
            this.dgvKunjungan.RowHeadersVisible = false;
            this.dgvKunjungan.RowHeadersWidth = 62;
            this.dgvKunjungan.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvKunjungan.RowTemplate.Height = 28;
            this.dgvKunjungan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKunjungan.Size = new System.Drawing.Size(833, 307);
            this.dgvKunjungan.TabIndex = 8;
            this.dgvKunjungan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKunjungan_CellClick);
            // 
            // cbhari
            // 
            this.cbhari.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbhari.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbhari.FormattingEnabled = true;
            this.cbhari.Location = new System.Drawing.Point(143, 332);
            this.cbhari.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbhari.Name = "cbhari";
            this.cbhari.Size = new System.Drawing.Size(218, 24);
            this.cbhari.TabIndex = 9;
            // 
            // btnupdate
            // 
            this.btnupdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnupdate.Enabled = false;
            this.btnupdate.Location = new System.Drawing.Point(143, 422);
            this.btnupdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(126, 34);
            this.btnupdate.TabIndex = 10;
            this.btnupdate.Text = "Update Data";
            this.btnupdate.UseVisualStyleBackColor = true;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btndelete
            // 
            this.btndelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btndelete.Enabled = false;
            this.btndelete.Location = new System.Drawing.Point(275, 422);
            this.btndelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(126, 34);
            this.btndelete.TabIndex = 11;
            this.btndelete.Text = "Delete Data";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(456, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "ID Kunjungan : ";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(566, 330);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(144, 22);
            this.textBox1.TabIndex = 13;
            // 
            // btnclear
            // 
            this.btnclear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnclear.Location = new System.Drawing.Point(406, 423);
            this.btnclear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(126, 34);
            this.btnclear.TabIndex = 14;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // SupervisorAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 466);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.cbhari);
            this.Controls.Add(this.dgvKunjungan);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btntambah);
            this.Controls.Add(this.cbsales);
            this.Controls.Add(this.cbtoko);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SupervisorAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tambah Data Kunjungan";
            this.Load += new System.EventHandler(this.SupervisorAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKunjungan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbtoko;
        private System.Windows.Forms.ComboBox cbsales;
        private System.Windows.Forms.Button btntambah;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgvKunjungan;
        private System.Windows.Forms.ComboBox cbhari;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnclear;
    }
}