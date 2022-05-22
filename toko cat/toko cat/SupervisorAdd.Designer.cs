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
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 420);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hari Kunjungan :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 452);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Toko Tujuan :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 486);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sales :";
            // 
            // cbtoko
            // 
            this.cbtoko.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbtoko.FormattingEnabled = true;
            this.cbtoko.Location = new System.Drawing.Point(161, 449);
            this.cbtoko.Name = "cbtoko";
            this.cbtoko.Size = new System.Drawing.Size(245, 28);
            this.cbtoko.TabIndex = 4;
            // 
            // cbsales
            // 
            this.cbsales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbsales.FormattingEnabled = true;
            this.cbsales.Location = new System.Drawing.Point(161, 483);
            this.cbsales.Name = "cbsales";
            this.cbsales.Size = new System.Drawing.Size(245, 28);
            this.cbsales.TabIndex = 5;
            // 
            // btntambah
            // 
            this.btntambah.Location = new System.Drawing.Point(13, 528);
            this.btntambah.Name = "btntambah";
            this.btntambah.Size = new System.Drawing.Size(142, 42);
            this.btntambah.TabIndex = 6;
            this.btntambah.Text = "Tambah Data";
            this.btntambah.UseVisualStyleBackColor = true;
            this.btntambah.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(412, 449);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 28);
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
            this.dgvKunjungan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKunjungan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKunjungan.Location = new System.Drawing.Point(12, 12);
            this.dgvKunjungan.Name = "dgvKunjungan";
            this.dgvKunjungan.ReadOnly = true;
            this.dgvKunjungan.RowHeadersVisible = false;
            this.dgvKunjungan.RowHeadersWidth = 62;
            this.dgvKunjungan.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvKunjungan.RowTemplate.Height = 28;
            this.dgvKunjungan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKunjungan.Size = new System.Drawing.Size(937, 384);
            this.dgvKunjungan.TabIndex = 8;
            this.dgvKunjungan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKunjungan_CellClick);
            // 
            // cbhari
            // 
            this.cbhari.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbhari.FormattingEnabled = true;
            this.cbhari.Location = new System.Drawing.Point(161, 415);
            this.cbhari.Name = "cbhari";
            this.cbhari.Size = new System.Drawing.Size(245, 28);
            this.cbhari.TabIndex = 9;
            // 
            // btnupdate
            // 
            this.btnupdate.Enabled = false;
            this.btnupdate.Location = new System.Drawing.Point(161, 528);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(142, 42);
            this.btnupdate.TabIndex = 10;
            this.btnupdate.Text = "Update Data";
            this.btnupdate.UseVisualStyleBackColor = true;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btndelete
            // 
            this.btndelete.Enabled = false;
            this.btndelete.Location = new System.Drawing.Point(309, 528);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(142, 42);
            this.btndelete.TabIndex = 11;
            this.btndelete.Text = "Delete Data";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(513, 415);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "ID Kunjungan : ";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(637, 412);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(161, 26);
            this.textBox1.TabIndex = 13;
            // 
            // btnclear
            // 
            this.btnclear.Location = new System.Drawing.Point(457, 529);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(142, 42);
            this.btnclear.TabIndex = 14;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // SupervisorAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 583);
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
            this.Name = "SupervisorAdd";
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