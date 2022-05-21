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
    public partial class Admin : Form
    {
        DataTable dtOrders, dtOrderDetails, dtHistory;
        MySqlDataAdapter da;
        int orderIndex, detailIndex;
        public Admin()
        {
            InitializeComponent();
            da = new MySqlDataAdapter();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            loadOrders();
            loadHistory();
        }

        private void loadOrders()
        {
            dtOrders = new DataTable();
            
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT h.HT_INVOICE_NUMBER as 'Invoice', t.TOKO_NAME as 'Nama Toko' FROM htrans_item h JOIN toko t ON t.toko_id = h.ht_to_id WHERE ht_status = 1";

            Connection.executeNonQuery(cmd);

            da.SelectCommand = cmd;
            da.Fill(dtOrders);
            dataGridView1.DataSource = dtOrders;
        }

        private void loadOrderDetails(int index)
        {
            dtOrderDetails = new DataTable();

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT d.DT_ID AS 'ID', i.IT_NAME AS 'Item', d.DT_AMOUNT AS 'Jumlah', i.IT_STOCK AS 'Stok' FROM dtrans_item d JOIN item i ON i.IT_ID = d.DT_IT_ID WHERE d.DT_HT_ID = " + index;

            Connection.executeNonQuery(cmd);

            da.SelectCommand = cmd;
            da.Fill(dtOrderDetails);
            dataGridView2.DataSource = dtOrderDetails;
            dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT HT_ID FROM htrans_item WHERE HT_INVOICE_NUMBER = " + dtOrders.Rows[e.RowIndex][0].ToString();

            MySqlDataReader reader = Connection.executeReader(cmd);

            reader.Read();
            int index = reader.GetInt32(0);
            loadOrderDetails(index);
            orderIndex = index;

            button1.Enabled = true;
            button2.Enabled = true;
            button4.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (orderIndex >= 0) {
                Connection.Conn.Open();
                MySqlCommand cmd = new MySqlCommand("update htrans_item set HT_STATUS = 2 where HT_ID = @id", Connection.Conn);

                cmd.Parameters.AddWithValue("@id", orderIndex);
                cmd.ExecuteNonQuery();
                Connection.Conn.Close();
                loadOrders();
                MessageBox.Show("Order telah di Accept");

                button1.Enabled = false;
                button2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (orderIndex >= 0)
            {
                Connection.Conn.Open();
                MySqlCommand cmd = new MySqlCommand("update htrans_item set HT_STATUS = 0 where HT_ID = @id", Connection.Conn);

                cmd.Parameters.AddWithValue("@id", orderIndex);
                cmd.ExecuteNonQuery();
                Connection.Conn.Close();
                loadOrders();
                MessageBox.Show("Order telah di Decline");

                button1.Enabled = false;
                button2.Enabled = false;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            numericUpDown1.Value = Convert.ToInt32(dtOrderDetails.Rows[e.RowIndex][2]);
            detailIndex = Convert.ToInt32(dtOrderDetails.Rows[e.RowIndex][0]);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminAddOrderItem form = new AdminAddOrderItem();
            form.ShowDialog();
            loadOrderDetails(orderIndex);
        }

        private void loadHistory()
        {
            dtHistory = new DataTable();

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT h.HT_INVOICE_NUMBER as 'Invoice', t.TOKO_NAME as 'Nama Toko' FROM htrans_item h JOIN toko t ON t.toko_id = h.ht_to_id";

            Connection.executeNonQuery(cmd);

            da.SelectCommand = cmd;
            da.Fill(dtHistory);
            dataGridView4.DataSource = dtHistory;
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Connection.Conn.Open();
            MySqlCommand cmd = new MySqlCommand("update dtrans_item set DT_AMOUNT = @amount where DT_ID = @id", Connection.Conn);
            cmd.Parameters.AddWithValue("@amount", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@id", detailIndex);
            cmd.ExecuteNonQuery();
            Connection.Conn.Close();
            loadOrderDetails(orderIndex);

            MessageBox.Show("Stok item telah di Update");
        }
    }
}
