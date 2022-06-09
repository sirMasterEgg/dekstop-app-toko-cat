using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace toko_cat
{
    public partial class InventoryDelivery : Form
    {
        private int index;
        private int stokSebelum = -1;

        public InventoryDelivery()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeliveryStatus form = new DeliveryStatus();
            form.ShowDialog();
            form.Dispose();
            this.Show();

            refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReportInventory form = new ReportInventory();
            form.ShowDialog();
            form.Dispose();
        }

        private void refresh()
        {
            DataTable dt = new DataTable("item");
            MySqlCommand cmd = new MySqlCommand("select IT_ID as ID, IT_NAME as Nama, concat('Rp ', format(IT_PRICE, 0)) as Harga, IT_STOCK as Stok from item where IT_STATUS = 1", Connection.Conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void InventoryDelivery_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
            numericUpDown1.Enabled = false;
            button1.Enabled = false;

            refresh();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                numericUpDown1.Enabled = true;
                button1.Enabled = true;
                stokSebelum = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                numericUpDown1.Value = stokSebelum;
                index = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection.Conn.Open();
            MySqlCommand cmd = new MySqlCommand("update item set IT_STOCK = @itstock where IT_ID = @itid", Connection.Conn);
            cmd.Parameters.AddWithValue("@itstock", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@itid", index);
            cmd.ExecuteNonQuery();
            Connection.Conn.Close();

            MySqlCommand cmdTimeStamp = new MySqlCommand("INSERT INTO timestamp_stok(TS_IT_ID, TS_DATE, TS_VALUE, TS_STATUS) VALUES (@a, NOW(), @b, 1)");
            cmdTimeStamp.Parameters.AddWithValue("@a", index);
            cmdTimeStamp.Parameters.AddWithValue("@b", numericUpDown1.Value - stokSebelum);
            Connection.executeNonQuery(cmdTimeStamp);

            this.OnLoad(e);
        }
    }
}
