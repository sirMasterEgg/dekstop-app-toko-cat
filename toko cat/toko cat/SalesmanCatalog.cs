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
    public partial class SalesmanCatalog : Form
    {
        public static int salesBelumDiClose = 1;
        public SalesmanCatalog()
        {
            InitializeComponent();
            loadDgv();
        }

        private void loadDgv()
        {
            String select = @"SELECT IT_ID AS 'ID', IT_NAME AS 'Nama Item', 
                            IT_PRICE AS 'Harga', IT_STOCK AS 'Stock' FROM item
                            WHERE IT_STATUS = 1;";

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = select;

            DataTable dt = Connection.executeAdapter(cmd);

            dataGridView1.DataSource = dt;

            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void catalogToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
            this.Hide();
            SalesmanHistory hist = new SalesmanHistory();

            hist.StartPosition = FormStartPosition.CenterScreen;

            hist.ShowDialog();
            hist.Dispose();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void SalesmanCatalog_Load(object sender, EventArgs e)
        {

        }

        private void SalesmanCatalog_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
