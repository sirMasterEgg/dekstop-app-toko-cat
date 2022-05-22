using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace toko_cat
{
    public partial class SalesmanHistory : Form
    {
        DataTable dtHtrans;
        int idxHtrans = -1;
        public SalesmanHistory()
        {
            InitializeComponent();
            loadDgvHtrans();
            updateDescription();
            enableButton();
        }

        private void loadDgvHtrans()
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"SELECT ht_invoice_number AS 'Invoice', toko_name AS 'Toko',
                                DATE_FORMAT(ht_date,'%d - %m - %Y') AS 'Tanggal Transaksi', ht_total AS 'Total', 
                                (CASE 
	                                WHEN ht_status = 1 THEN 'Menunggu Konfirmasi'
	                                WHEN ht_status = 2 THEN 'Menunggu Pengiriman'
	                                WHEN ht_status = 3 THEN 'Sudah Sampai'
	                                WHEN ht_status = 0 THEN 'Gagal'
                                END) AS 'Status'
                                FROM htrans_item
                                JOIN toko ON toko_id = ht_to_id
                                WHERE ht_us_id = "+Form1.idUserLogin+" ORDER BY ht_invoice_number";

            dtHtrans = Connection.executeAdapter(cmd);

            dgvHtrans.DataSource = dtHtrans;

            for (int i = 0; i < dgvHtrans.Columns.Count; i++)
            {
                if (i == 1) dgvHtrans.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                else dgvHtrans.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void loadDgvDtrans(int idHtrans)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"SELECT it_name AS 'Nama Barang', dt_amount AS 'Jumlah', dt_subtotal AS 'Subtotal'
                                FROM dtrans_item
                                JOIN item ON dt_it_id = it_id
                                WHERE dt_ht_id = " + idHtrans;

            dgvBarang.DataSource = Connection.executeAdapter(cmd);

            for (int i = 0; i < dgvBarang.Columns.Count; i++)
            {
                if (i == 0) dgvBarang.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                else dgvBarang.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void catalogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SalesmanCatalog cata = new SalesmanCatalog();

            cata.StartPosition = FormStartPosition.CenterScreen;

            cata.ShowDialog();
            cata.Dispose();
        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SalesmanOrder order = new SalesmanOrder();

            order.StartPosition = FormStartPosition.CenterScreen;

            order.ShowDialog();
            order.Dispose();
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SalesmanHistory_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void SalesmanHistory_Load(object sender, EventArgs e)
        {

        }

        private void updateDescription()
        {
            if (idxHtrans != -1)
            {
                namaToko.Text = dtHtrans.Rows[idxHtrans][1].ToString();
                invoice.Text = dtHtrans.Rows[idxHtrans][0].ToString();
                total.Text = dtHtrans.Rows[idxHtrans][3].ToString();
                status.Text = dtHtrans.Rows[idxHtrans][4].ToString();
                tglTrans.Text = dtHtrans.Rows[idxHtrans][2].ToString();

                MySqlCommand cmdIDh = new MySqlCommand();
                cmdIDh.CommandText = "SELECT ht_id FROM htrans_item WHERE ht_invoice_number = " + invoice.Text;
                int id = Connection.executeScalar(cmdIDh);


                loadDgvDtrans(id);
            }
            else
            {
                namaToko.Text = "-";
                invoice.Text = "-";
                total.Text = "0";
                status.Text = "-";
                tglTrans.Text = "";
            }
        }

        private void dgvHtrans_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idxHtrans = e.RowIndex;
            enableButton();

            updateDescription();
        }

        private void enableButton()
        {
            if (idxHtrans != -1)
            {
                btnInvoice.Enabled = true;
            }
            else btnInvoice.Enabled = false;
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            FormInvoice newForm = new FormInvoice(invoice.Text);
            newForm.StartPosition = FormStartPosition.CenterScreen;

            newForm.ShowDialog();
        }
    }
}
