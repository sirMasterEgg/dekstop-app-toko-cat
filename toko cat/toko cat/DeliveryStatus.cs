using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace toko_cat
{
    public partial class DeliveryStatus : Form
    {
        private int index;

        public DeliveryStatus()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeliveryStatus_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            button1.Enabled = false;
            DataTable dt = new DataTable("htrans_item");
            MySqlCommand cmd = new MySqlCommand("select HT_ID as ID, US_NAME as Sales, TOKO_NAME as Toko, HT_DATE as \"Tanggal Transaksi\", HT_INVOICE_NUMBER as \"Nomor Invoice\", concat('Rp ', format(HT_TOTAL, 0)) as Total from htrans_item join toko on HT_TO_ID = TOKO_ID join user on HT_US_ID = US_ID where HT_STATUS = 2 order by HT_ID", Connection.Conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + " - " + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                index = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand cmdDtrans = new MySqlCommand();
            cmdDtrans.CommandText = "SELECT dt_it_id, dt_amount FROM dtrans_item WHERE dt_ht_id = "+index;

            DataTable dt = Connection.executeAdapter(cmdDtrans);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                MySqlCommand cmdTimeStamp = new MySqlCommand("INSERT INTO timestamp_stok(TS_IT_ID, TS_DATE, TS_VALUE, TS_STATUS) VALUES (@a, NOW(), @b, 2)");
                cmdTimeStamp.Parameters.AddWithValue("@a", dt.Rows[i][0].ToString());
                cmdTimeStamp.Parameters.AddWithValue("@b", dt.Rows[i][1].ToString());

                Connection.executeNonQuery(cmdTimeStamp);

                MySqlCommand cmdUpdate = new MySqlCommand();
                cmdUpdate.CommandText = "UPDATE item SET it_stock = it_stock - @a WHERE it_id = @b";
                cmdUpdate.Parameters.AddWithValue("@a", dt.Rows[i][1].ToString());
                cmdUpdate.Parameters.AddWithValue("@b", dt.Rows[i][0].ToString());

                Connection.executeNonQuery(cmdUpdate);
            }

            MySqlCommand cmd = new MySqlCommand("update htrans_item set HT_STATUS = 3 where HT_ID = @htid");
            cmd.Parameters.AddWithValue("@htid", index);
            Connection.executeNonQuery(cmd);

            this.OnLoad(e);
        }
    }
}
