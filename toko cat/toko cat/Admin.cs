using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace toko_cat
{
    public partial class Admin : Form
    {
        DataTable dtOrders, dtOrderDetails, dtHistory, dtHistoryDetails, dtItems;
        MySqlDataAdapter da;
        int orderIndex, detailIndex, historyIndex, itemIndex;
        int idxPilihToko = -1;
        public Admin()
        {
            InitializeComponent();
            da = new MySqlDataAdapter();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            loadOrders();
            loadHistory();
            loadToko();
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
        private int hitungTokoID()
        {
            var conn = Connection.Conn;
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            var cmd = new MySqlCommand();
            cmd.Connection = conn;

            conn.Open();

            cmd.CommandText = "select max(TOKO_ID) from toko;";

            string lastId = cmd.ExecuteScalar().ToString();

            conn.Close();
            return (lastId == "") ? 1 : Int32.Parse(lastId) + 1;
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

        private void button10_Click(object sender, EventArgs e)
        {
            if (btnae.Text == "Add")
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "insert into toko (TOKO_NAME, TOKO_ALAMAT, TOKO_PHONE) values (@a, @b, @c);";
                cmd.Parameters.AddWithValue("@a", namatoko.Text);
                cmd.Parameters.AddWithValue("@b", alamattoko.Text);
                cmd.Parameters.AddWithValue("@c", telptoko.Text);

                Connection.executeNonQuery(cmd);

                idxPilihToko = -1;
                kosongkanData();
                updateButton();
            }
            else
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "update toko set toko_name = @a, toko_alamat = @b, toko_phone = @c where toko_id = @d";
                cmd.Parameters.AddWithValue("@a", namatoko.Text);
                cmd.Parameters.AddWithValue("@b", alamattoko.Text);
                cmd.Parameters.AddWithValue("@c", telptoko.Text);
                cmd.Parameters.AddWithValue("@d", dataGridView6[0, idxPilihToko].Value.ToString());

                Connection.executeNonQuery(cmd);

                idxPilihToko = -1;
                kosongkanData();
                updateButton();

            }
            loadToko();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            numericUpDown1.Value = Convert.ToInt32(dtOrderDetails.Rows[e.RowIndex][2]);
            detailIndex = Convert.ToInt32(dtOrderDetails.Rows[e.RowIndex][0]);

            button3.Enabled = true;
            button5.Enabled = true;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView6_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idxPilihToko = e.RowIndex;
            isiData();
            updateButton();
        }

        private void kosongkanData()
        {
            namatoko.Text = "";
            alamattoko.Text = "";
            telptoko.Text = "";
        }

        private void isiData()
        {
            if (idxPilihToko != -1)
            {
                namatoko.Text = dataGridView6[1, idxPilihToko].Value.ToString();
                alamattoko.Text = dataGridView6[2, idxPilihToko].Value.ToString();
                telptoko.Text = dataGridView6[3, idxPilihToko].Value.ToString();
            }
        }

        private void cekEnableButton()
        {
            if (namatoko.Text != "" || telptoko.Text != "" || alamattoko.Text != "")
            {
                btnae.Enabled = true;
            }
            else
            {
                btnae.Enabled = false;
            }

            if (idxPilihToko != -1) btndel.Enabled = true;
            else btndel.Enabled = false;
        }

        private void updateButton()
        {
            if (idxPilihToko == -1)
            {
                btnae.Text = "Add";
            }
            else
            {
                btnae.Text = "Edit";
            }

            cekEnableButton();
        }

        private void namatoko_TextChanged(object sender, EventArgs e)
        {
            cekEnableButton();
        }

        private void alamattoko_TextChanged(object sender, EventArgs e)
        {
            cekEnableButton();
        }

        private void telptoko_TextChanged(object sender, EventArgs e)
        {
            cekEnableButton();
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            if (idxPilihToko != -1)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "DELETE FROM toko WHERE toko_id = @a";
                cmd.Parameters.AddWithValue("@a", dataGridView6[0, idxPilihToko].Value.ToString());

                Connection.executeNonQuery(cmd);
            }
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void loadToko()
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT toko_id AS 'ID', toko_name AS 'Nama Toko', toko_alamat AS 'Alamat', toko_phone AS 'No. Telp' FROM toko";

            dataGridView6.DataSource = Connection.executeAdapter(cmd);

            for (int i = 0; i < dataGridView6.Columns.Count; i++)
            {
                if (i == 1 || i == 2) dataGridView6.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                else dataGridView6.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
    }
}
