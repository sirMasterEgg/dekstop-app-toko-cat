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
        DataTable dtOrders, dtOrderDetails, dtHistory, dtHistoryDetails, dtItems;
        MySqlDataAdapter da;
        int orderIndex, detailIndex, historyIndex, itemIndex;
        public Admin()
        {
            InitializeComponent();
            da = new MySqlDataAdapter();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            loadOrders();
            loadHistory();
            itemTabReset();
        }

        private void itemTabReset()
        {
            loadItems();
            int id = dtItems.Rows.Count + 1;
            textBox1.Text = id.ToString();
            textBox2.Text = "";
            textBox4.Text = "";
            comboBox1.SelectedIndex = 0;
            button6.Enabled = true;
            button7.Enabled = false;
            button8.Enabled = false;
        }

        private void loadItems()
        {
            dtItems = new DataTable();

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT IT_ID AS 'ID', IT_NAME AS 'Nama Item', IT_PRICE AS 'Harga Item', IT_STOCK AS 'Stok Item', if(IT_STATUS = 1, 'Aktif', 'Non-aktif') AS 'Status' FROM item";

            Connection.executeNonQuery(cmd);

            da.SelectCommand = cmd;
            da.Fill(dtItems);

            dataGridView3.DataSource = dtItems;
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
            Connection.Conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM item WHERE IT_ID = @id", Connection.Conn);

            cmd.Parameters.AddWithValue("@id", textBox1.Text);

            cmd.ExecuteNonQuery();
            Connection.Conn.Close();
            MessageBox.Show("Item telah dinon-aktifkan");

            itemTabReset();
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

                dtOrderDetails.Clear();
                dataGridView2.DataSource = dtOrderDetails;
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

                dtOrderDetails.Clear();
                dataGridView2.DataSource = dtOrderDetails;
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            textBox1.Text = dtItems.Rows[index][0].ToString();
            textBox2.Text = dtItems.Rows[index][1].ToString();
            textBox4.Text = dtItems.Rows[index][2].ToString();
            comboBox1.Text = dtItems.Rows[index][4].ToString();
            button6.Enabled = false;
            button7.Enabled = true;
            button8.Enabled = true;
            itemIndex = index+1;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            itemTabReset();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Connection.Conn.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO item(IT_ID, IT_NAME, IT_PRICE, IT_STOCK, IT_STATUS) VALUES(@id, @nama, @harga, 0, @status)", Connection.Conn);

            cmd.Parameters.AddWithValue("@id", itemIndex);
            cmd.Parameters.AddWithValue("@nama", textBox2.Text);
            cmd.Parameters.AddWithValue("@harga", textBox4.Text);
            cmd.Parameters.AddWithValue("@status", comboBox1.SelectedIndex);
            
            cmd.ExecuteNonQuery();
            Connection.Conn.Close();
            MessageBox.Show("Item telah ditambahkan");

            itemTabReset();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Connection.Conn.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE item SET IT_NAME = @nama, IT_PRICE = @harga, IT_STATUS = @status where IT_ID = @id", Connection.Conn);

            cmd.Parameters.AddWithValue("@id", itemIndex);
            cmd.Parameters.AddWithValue("@nama", textBox2.Text);
            cmd.Parameters.AddWithValue("@harga", textBox4.Text);
            cmd.Parameters.AddWithValue("@status", comboBox1.SelectedIndex);

            cmd.ExecuteNonQuery();
            Connection.Conn.Close();
            MessageBox.Show("Item telah diupdate");

            itemTabReset();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            numericUpDown1.Value = Convert.ToInt32(dtOrderDetails.Rows[e.RowIndex][2]);
            detailIndex = Convert.ToInt32(dtOrderDetails.Rows[e.RowIndex][0]);

            button3.Enabled = true;
            button5.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminAddOrderItem form = new AdminAddOrderItem(orderIndex);
            form.ShowDialog();
            loadOrderDetails(orderIndex);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Connection.Conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM dtrans_item WHERE DT_ID = @id", Connection.Conn);
            cmd.Parameters.AddWithValue("@id", detailIndex);
            cmd.ExecuteNonQuery();
            Connection.Conn.Close();
            loadOrderDetails(orderIndex);

            MessageBox.Show("Item telah di remove");

            button3.Enabled = false;
            button5.Enabled = false;
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

        private void loadHistoryDetails()
        {
            dtHistoryDetails = new DataTable();

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT d.DT_ID AS 'ID', i.IT_NAME AS 'Item', d.DT_AMOUNT AS 'Jumlah', i.IT_STOCK AS 'Stok' FROM dtrans_item d JOIN item i ON i.IT_ID = d.DT_IT_ID WHERE d.DT_HT_ID = " + historyIndex;

            Connection.executeNonQuery(cmd);

            da.SelectCommand = cmd;
            da.Fill(dtHistoryDetails);
            dataGridView5.DataSource = dtHistoryDetails;
            dataGridView5.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT HT_ID FROM htrans_item WHERE HT_INVOICE_NUMBER = " + dtHistory.Rows[e.RowIndex][0].ToString();

            MySqlDataReader reader = Connection.executeReader(cmd);

            reader.Read();
            int index = reader.GetInt32(0);
            loadOrderDetails(index);
            historyIndex = index;
            loadHistoryDetails();
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

            MessageBox.Show("Jumlah item telah di Update");
            button3.Enabled = false;
            button5.Enabled = false;
        }
    }
}
