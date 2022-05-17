using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace toko_cat
{
    public partial class HRCatatanSupervisor : Form
    {
        private int id;

        public HRCatatanSupervisor(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void HRCatatanSupervisor_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("note");
            MySqlCommand cmd = new MySqlCommand("select date_format(NO_CREATION_DATETIME, '%Y-%m-%d %H:%i:%s') as Tanggal, NO_TEXT as Catatan from note where NO_US_ID = @id", Connection.Conn);
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
