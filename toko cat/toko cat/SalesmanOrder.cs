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
    public partial class SalesmanOrder : Form
    {
        List<Barang> belanja = new List<Barang>();
        int idxBarangDipilih = -1;
        int idxBarangOrderDipilih = -1;
        int mode = 0; //Mode = 0 -> add, mode = 1 -> edit
        DataTable barang;
        DataTable tableBelanja = new DataTable();
        public SalesmanOrder()
        {
            InitializeComponent();
            loadAwal();
        }

        private void loadAwal()
        {
            loadToko();
            kosongkanData();
            loadDgvBarang();

            namaSales.Text = Form1.namaUserLogin;

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT generateInvoice();";

            invoice.Text = Connection.executeString(cmd);
        }

        private void kosongkanData()
        {
            belanja.Clear();
            loadDgvBelanja();

            namaBarang.Text = "";
            jumlahBarang.Value = 0;
            comboBox1.SelectedIndex = -1;
        }

        private void clearTambahBelanja()
        {
            idxBarangDipilih = -1;
            updateBarangPilih();

            if (mode == 0)
            {
                tambahBarang.Text = "Tambah";
                jumlahBarang.Value = 0;
            }
            else
            {
                tambahBarang.Text = "Edit";
                jumlahBarang.Value = belanja[idxBarangOrderDipilih].jumlah;
            }
        }

        private void loadToko()
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT * FROM toko";

            MySqlDataReader read = Connection.executeReader(cmd);

            comboBox1.Items.Clear();

            comboBox1.DisplayMember = "Nama";
            comboBox1.ValueMember = "Id";

            while (read.Read())
            {
                comboBox1.Items.Add(new { Nama = read.GetString(1), Id = read.GetInt32(0) });
            }
        }

        private void loadDgvBarang()
        {
            MySqlCommand cmdTable = new MySqlCommand();
            cmdTable.CommandText = @"SELECT IT_ID AS 'ID', IT_NAME AS 'Nama Item', 
                                IT_PRICE AS 'Harga', IT_STOCK AS 'Stock' FROM item
                                WHERE IT_STATUS = 1;";

            barang = Connection.executeAdapter(cmdTable);

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"SELECT IT_NAME AS 'Nama Item', 
                                IT_PRICE AS 'Harga', IT_STOCK AS 'Stock' FROM item
                                WHERE IT_STATUS = 1;";

            dgvBarang.DataSource = Connection.executeAdapter(cmd);

            for (int i = 0; i < dgvBarang.Columns.Count; i++)
            {
                if (i == 0) dgvBarang.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                else dgvBarang.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void loadDgvBelanja()
        {
            int totalBelanja = 0;
            if (belanja.Count == 0)
            {
                tableBelanja.Columns.Add("No");
                tableBelanja.Columns.Add("Nama Barang");
                tableBelanja.Columns.Add("Jumlah");
                tableBelanja.Columns.Add("Subtotal");
            }

            tableBelanja.Rows.Clear();

            for (int i = 0; i < belanja.Count; i++)
            {
                tableBelanja.Rows.Add(i+1,belanja[i].nama, belanja[i].jumlah, belanja[i].subtotal);
                totalBelanja += belanja[i].subtotal;
            }

            dgvBarangOrder.DataSource = tableBelanja;

            for (int i = 0; i < dgvBarangOrder.Columns.Count; i++)
            {
                if (i == 1) dgvBarangOrder.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                else dgvBarangOrder.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            total.Text = totalBelanja.ToString();
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

        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SalesmanHistory hist = new SalesmanHistory();

            hist.StartPosition = FormStartPosition.CenterScreen;

            hist.ShowDialog();
            hist.Dispose();
        }

        private void SalesmanOrder_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void updateBarangPilih()
        {
            if (idxBarangDipilih == -1 && idxBarangOrderDipilih == -1) namaBarang.Text = "";
            else if (idxBarangOrderDipilih != -1) namaBarang.Text = belanja[idxBarangOrderDipilih].nama;
            else namaBarang.Text = barang.Rows[idxBarangDipilih][1].ToString();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idxBarangDipilih = e.RowIndex;
            updateBarangPilih();
        }

        private void SalesmanOrder_Load(object sender, EventArgs e)
        {

        }

        private int cariUdahPernahBeli()
        {
            int ketemu = -1;

            for (int i = 0; i < belanja.Count; i++)
            {
                if (int.Parse(barang.Rows[idxBarangDipilih][0].ToString()) == belanja[i].id)
                {
                    ketemu = i;
                }
            }

            return ketemu;
        }

        private void tambahBarang_Click(object sender, EventArgs e)
        {
            if (mode == 0)
            {
                int idxKetemu = cariUdahPernahBeli();

                int stock = int.Parse(barang.Rows[idxBarangDipilih][3].ToString());

                if (idxKetemu != -1)
                {
                    if (jumlahBarang.Value + belanja[idxKetemu].jumlah <= stock )
                    {
                        belanja[idxKetemu].updateJumlah((int)jumlahBarang.Value + belanja[idxKetemu].jumlah);

                        loadDgvBelanja();

                        clearTambahBelanja();
                    }
                    else MessageBox.Show("Jumlah Barang Tidak Boleh Melebihi Stok !");
                }
                else
                {
                    if (stock >= jumlahBarang.Value)
                    {

                        int id = int.Parse(barang.Rows[idxBarangDipilih][0].ToString());
                        String nama = barang.Rows[idxBarangDipilih][1].ToString();
                        int price = int.Parse(barang.Rows[idxBarangDipilih][2].ToString());
                        belanja.Add(new Barang(id, nama, price, (int)jumlahBarang.Value));

                        loadDgvBelanja();

                        clearTambahBelanja();
                    }
                    else MessageBox.Show("Jumlah Barang Tidak Boleh Melebihi Stok !");
                }
            }
            else
            {
                int stock = int.Parse(barang.Rows[idxBarangDipilih][3].ToString());

                if (stock >= jumlahBarang.Value)
                {
                    belanja[idxBarangOrderDipilih].updateJumlah((int)jumlahBarang.Value);

                    loadDgvBelanja();

                    mode = 0;

                    clearTambahBelanja();
                }
                else MessageBox.Show("Jumlah Barang Tidak Boleh Melebihi Stok !");
            }
        }

        private void dgvBarangOrder_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idxBarangOrderDipilih = e.RowIndex;

            mode = 1;

            clearTambahBelanja();
        }
    }
}
