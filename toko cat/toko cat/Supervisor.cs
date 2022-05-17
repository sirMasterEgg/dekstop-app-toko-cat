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
    public partial class Supervisor : Form
    {
        private MySqlConnection conn = Connection.Conn;
        private MySqlDataAdapter da;
        private MySqlCommand cmd;
        private DataTable dtSupervisor;
        public Supervisor()
        {
            InitializeComponent();
        }

        private void Supervisor_Load(object sender, EventArgs e)
        {
            loadDataGrid();
        }

        private void loadDataGrid()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            dtSupervisor = new DataTable();
            cmd = new MySqlCommand();
            da = new MySqlDataAdapter();

            cmd.Connection = conn;

            cmd.CommandText = @"select date_format(v.V_TANGGAL, '%W, %d %M %Y') as 'Jadwal Visit', t.TOKO_NAME as 'Toko Tujuan', u.US_NAME as 'Nama Sales', if(v.V_STATUS = 0, 'Belum dikunjungi', 'Sudah dikunjungi') as Status from visit v
                join toko t on t.TOKO_ID = v.V_TOKO_ID
                join user u on u.US_ID = v.V_US_ID";
            conn.Open();
            cmd.ExecuteReader();
            conn.Close();
            da.SelectCommand = cmd;
            da.Fill(dtSupervisor);

            dgvSupervisor.DataSource = null;
            dgvSupervisor.DataSource = dtSupervisor;

            foreach (DataGridViewColumn column in dgvSupervisor.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            
            dgvSupervisor.ClearSelection();
        }

        private void tambahJadwalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SupervisorAdd add = new SupervisorAdd();
            add.ShowDialog();
            loadDataGrid();
        }
    }
}
