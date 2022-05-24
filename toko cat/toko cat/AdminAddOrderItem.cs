using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace toko_cat
{
    public partial class AdminAddOrderItem : Form
    {
        int htransid;
        public AdminAddOrderItem(int htransid)
        {
            InitializeComponent();
            this.htransid = htransid; 
        }
        DataTable dt = new DataTable();
        MySqlDataAdapter da = new MySqlDataAdapter();
        MySqlCommand cmd = new MySqlCommand();
        int index;
        private void AdminAddOrderItem_Load(object sender, EventArgs e)
        {
            

            cmd.CommandText = "SELECT IT_ID AS 'ID', IT_NAME AS 'Nama Item', IT_PRICE AS 'Harga Item', IT_STOCK AS 'Stok Item' FROM item WHERE IT_STATUS = 1";

            Connection.executeNonQuery(cmd);

            da.SelectCommand = cmd;
            da.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button1.Enabled = true;
            numericUpDown1.Maximum = Convert.ToInt32(dt.Rows[e.RowIndex][3]);
            index = e.RowIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == 0)
                MessageBox.Show("Jumlah harus lebih dari 0");
            else
            {
                Connection.Conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO dtrans_item(DT_ID, DT_IT_ID, DT_AMOUNT, DT_SUBTOTAL, DT_HT_ID, DT_STATUS) VALUES(generateIDDtrans(), @itemid, @amount, getDTSubtotal(@itemid, @amount), @htransid, 1)", Connection.Conn);
                cmd.Parameters.AddWithValue("@itemid", dt.Rows[index][0]);
                cmd.Parameters.AddWithValue("@amount", numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@htransid", htransid);
                cmd.ExecuteNonQuery();
                Connection.Conn.Close();

                MessageBox.Show("Item telah di tambahkan");

                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
