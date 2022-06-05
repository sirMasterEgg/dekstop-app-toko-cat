using System;
using System.Data;
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
        private DataTable dtSupervisorTemp;
        public Supervisor()
        {
            InitializeComponent();
        }

        private void Supervisor_Load(object sender, EventArgs e)
        {
            loadDataGrid();
            loadSales();
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

            cmd.CommandText = @"SELECT V_ID        AS 'ID Kunjungan',
                                       t.TOKO_NAME AS 'Toko Tujuan',
                                       d.DA_NAME   AS 'Hari Visit',
                                       u.US_NAME   AS 'Nama Sales',
                                       IF(generateCountAbsen(u.US_ID)=0,'Belum Dikunjungi', 'Sudah Dikunjungi') AS 'Absen'
                                FROM visit v
                                         LEFT JOIN USER u ON u.US_ID = v.V_US_ID
                                         LEFT JOIN toko t ON t.TOKO_ID = v.V_TOKO_ID
                                         LEFT JOIN DAY d ON v.V_DA_ID = d.DA_ID
                                         LEFT JOIN absen a ON u.US_ID = a.AB_US_ID
                                WHERE (d.DA_ID + 7) % 7 = DATE_FORMAT(NOW(), '%w');";
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

            cmd.CommandText = @"SELECT V_ID        AS 'ID Kunjungan',
                                       t.TOKO_NAME AS 'Toko Tujuan',
                                       d.DA_NAME   AS 'Hari Visit',
                                       u.US_NAME   AS 'Nama Sales',
                                       u.US_ID     AS 'ID Sales',
                                       IF(generateCountAbsen(u.US_ID)=0,'Belum Dikunjungi', 'Sudah Dikunjungi') AS 'Absen'
                                FROM visit v
                                         LEFT JOIN USER u ON u.US_ID = v.V_US_ID
                                         LEFT JOIN toko t ON t.TOKO_ID = v.V_TOKO_ID
                                         LEFT JOIN DAY d ON v.V_DA_ID = d.DA_ID
                                         LEFT JOIN absen a ON u.US_ID = a.AB_US_ID
                                WHERE (d.DA_ID + 7) % 7 = DATE_FORMAT(NOW(), '%w');";
            dtSupervisorTemp = Connection.executeAdapter(cmd);

        }
        
        private void loadDataGrid(bool isFilter, string id)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            dtSupervisor = new DataTable();
            cmd = new MySqlCommand();
            da = new MySqlDataAdapter();

            cmd.Connection = conn;

            cmd.CommandText = @"SELECT V_ID        AS 'ID Kunjungan',
                                       t.TOKO_NAME AS 'Toko Tujuan',
                                       d.DA_NAME   AS 'Hari Visit',
                                       u.US_NAME   AS 'Nama Sales',
                                       IF(generateCountAbsen(u.US_ID)=0,'Belum Dikunjungi', 'Sudah Dikunjungi') AS 'Absen'
                                FROM visit v
                                         LEFT JOIN USER u ON u.US_ID = v.V_US_ID
                                         LEFT JOIN toko t ON t.TOKO_ID = v.V_TOKO_ID
                                         LEFT JOIN DAY d ON v.V_DA_ID = d.DA_ID
                                         LEFT JOIN absen a ON u.US_ID = a.AB_US_ID
                                WHERE (d.DA_ID + 7) % 7 = DATE_FORMAT(NOW(), '%w') and u.US_ID = @id;";
            conn.Open();
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new MySqlParameter("@id", id));
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

            cmd.CommandText = @"SELECT V_ID        AS 'ID Kunjungan',
                                       t.TOKO_NAME AS 'Toko Tujuan',
                                       d.DA_NAME   AS 'Hari Visit',
                                       u.US_NAME   AS 'Nama Sales',
                                       u.US_ID     AS 'ID Sales',
                                       IF(generateCountAbsen(u.US_ID)=0,'Belum Dikunjungi', 'Sudah Dikunjungi') AS 'Absen'
                                FROM visit v
                                         LEFT JOIN USER u ON u.US_ID = v.V_US_ID
                                         LEFT JOIN toko t ON t.TOKO_ID = v.V_TOKO_ID
                                         LEFT JOIN DAY d ON v.V_DA_ID = d.DA_ID
                                         LEFT JOIN absen a ON u.US_ID = a.AB_US_ID
                                WHERE (d.DA_ID + 7) % 7 = DATE_FORMAT(NOW(), '%w') and u.US_ID = @id;";
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new MySqlParameter("@id", id));
            dtSupervisorTemp = Connection.executeAdapter(cmd);

        }

        private void tambahJadwalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SupervisorAdd add = new SupervisorAdd();
            add.ShowDialog();
            loadDataGrid();
        }

        private void tambahKomentarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesStatus status = new SalesStatus();
            status.ShowDialog();
        }

        private void dgvSupervisor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idDGV = e.RowIndex;
            MySqlCommand cmd;
            var conn = Connection.Conn;
            int id = hitungAbsenID();

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into absen (AB_ID, AB_US_ID, AB_DATE) values (@id, @userid, now());";
                cmd.Parameters.Add(new MySqlParameter("@id", id));
                cmd.Parameters.Add(new MySqlParameter("@userid", dtSupervisorTemp.Rows[idDGV]["ID Sales"].ToString()));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Sudah Absen!");
                loadDataGrid();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private int hitungAbsenID()
        {
            var conn = Connection.Conn;
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            var cmd = new MySqlCommand();
            cmd.Connection = conn;

            conn.Open();

            cmd.CommandText = "select max(AB_ID) from absen;";

            string lastId = cmd.ExecuteScalar().ToString();

            conn.Close();
            return (lastId == "") ? 1 : Int32.Parse(lastId) + 1;
        }

        private void reportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SupervisorReportForm newForm = new SupervisorReportForm();
            newForm.ShowDialog();
            newForm.Dispose();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbsales.SelectedIndex == 0)
            {
                loadDataGrid();
            }
            else
            {
                loadDataGrid(true, (cbsales.SelectedItem as dynamic).Value);
            }
        }

        private void loadSales()
        {
            cbsales.Items.Clear();
            var conn = Connection.Conn;
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            var cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select US_ID, US_NAME from user where US_TY_ID = (select TY_ID from type where TY_NAME = 'Salesperson');";
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            cbsales.DisplayMember = "Text";
            cbsales.ValueMember = "Value";

            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            cbsales.Items.Add(new { Text = "(Semua)", Value = "0" });
            
            while (reader.Read())
            {
                cbsales.Items.Add(new { Text = reader.GetString(1), Value = reader.GetString(0) });
                data.Add(reader.GetString(1));
            }
            conn.Close();

            cbsales.AutoCompleteCustomSource = data;

            cbsales.SelectedIndex = 0;
        }

        private void lembarAbsenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbsenForm newForm = new AbsenForm();
            newForm.ShowDialog();
            this.Show();
        }
    }
}
