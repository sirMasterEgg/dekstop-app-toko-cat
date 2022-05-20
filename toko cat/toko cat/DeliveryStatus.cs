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

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a report...");
        }

        private void DeliveryStatus_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            button1.Enabled = false;
            DataTable dt = new DataTable("htrans_item");
            MySqlCommand cmd = new MySqlCommand("select HT_ID as ID, TOKO_NAME as Toko, HT_INVOICE_NUMBER as \"Nomor Invoice\", concat('Rp ', format(HT_TOTAL, 0)) as Total from htrans_item join toko on HT_TO_ID = TOKO_ID where HT_STATUS = 2 order by HT_ID", Connection.Conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + " - " + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                index = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection.Conn.Open();
            MySqlCommand cmd = new MySqlCommand("update htrans_item set HT_STATUS = 3 where HT_ID = @htid", Connection.Conn);
            cmd.Parameters.AddWithValue("@htid", index);
            cmd.ExecuteNonQuery();
            Connection.Conn.Close();
            this.OnLoad(e);
        }
    }
}
