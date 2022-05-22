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
        private DataTable dtSupervisorTemp;
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
    }
}
