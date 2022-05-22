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
    public partial class SupervisorAdd : Form
    {
        private MySqlConnection conn = Connection.Conn;
        private MySqlDataAdapter da;
        private MySqlCommand cmd;
        private DataTable dtKunjungan;

        public SupervisorAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd;
            var conn = Connection.Conn;
            int id = hitungVisitID();

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            string idSales = (cbsales.SelectedItem as dynamic).Value;
            string idToko = (cbtoko.SelectedItem as dynamic).Value;
            string tujuan = (cbhari.SelectedItem as dynamic).Value;
            try
            {
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into visit (V_ID, V_TOKO_ID, V_DA_ID, V_STATUS, V_US_ID) values (@id, @tokoid, @day, @status, @userid);";
                cmd.Parameters.Add(new MySqlParameter("@id", id));
                cmd.Parameters.Add(new MySqlParameter("@tokoid", idToko));
                cmd.Parameters.Add(new MySqlParameter("@day", tujuan));
                cmd.Parameters.Add(new MySqlParameter("@status", "1"));
                cmd.Parameters.Add(new MySqlParameter("@userid", idSales));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Berhasil Ditambahkan!");
                clear();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private int hitungVisitID()
        {
            var conn = Connection.Conn;
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            var cmd = new MySqlCommand();
            cmd.Connection = conn;

            conn.Open();

            cmd.CommandText = "select max(V_ID) from visit;";

            string lastId = cmd.ExecuteScalar().ToString();

            conn.Close();
            return (lastId == "") ? 1 : Int32.Parse(lastId) + 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddToko at = new AddToko();
            at.ShowDialog();
            loadToko();
        }

        private void loadToko()
        {
            cbtoko.Items.Clear();
            var conn = Connection.Conn;
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            var cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * from toko";
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            cbtoko.DisplayMember = "Text";
            cbtoko.ValueMember = "Value";

            while (reader.Read())
            {
                cbtoko.Items.Add(new { Text = reader.GetString(1), Value = reader.GetString(0) });

            }
            conn.Close();
            cbtoko.SelectedIndex = 0;
        }

        private void loadID()
        {
            int id = hitungVisitID();
            textBox1.Text = id.ToString();
        }

        private void loadDay()
        {
            cbhari.Items.Clear();
            var conn = Connection.Conn;
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            var cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * from day";
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            cbhari.DisplayMember = "Text";
            cbhari.ValueMember = "Value";

            while (reader.Read())
            {
                cbhari.Items.Add(new { Text = reader.GetString(1), Value = reader.GetString(0) });
                
            }
            conn.Close();
            cbhari.SelectedIndex = 0;
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

            while (reader.Read())
            {
                cbsales.Items.Add(new { Text = reader.GetString(1), Value = reader.GetString(0) });

            }
            conn.Close();
            cbsales.SelectedIndex = 0;
        }

        private void loadDataGrid()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            dtKunjungan = new DataTable();
            cmd = new MySqlCommand();
            da = new MySqlDataAdapter();

            cmd.Connection = conn;

            cmd.CommandText = @"select V_ID        as 'ID Kunjungan',
                                       d.DA_NAME   as 'Hari Visit',
                                       t.TOKO_NAME as 'Toko Tujuan',
                                       u.US_NAME   as 'Nama Sales'
                                from visit v
                                         join user u on u.US_ID = v.V_US_ID
                                         join toko t on t.TOKO_ID = v.V_TOKO_ID
                                         join day d on v.V_DA_ID = d.DA_ID
                                order by DA_ID;
                                ";
            conn.Open();
            cmd.ExecuteReader();
            conn.Close();
            da.SelectCommand = cmd;
            da.Fill(dtKunjungan);

            dgvKunjungan.DataSource = null;
            dgvKunjungan.DataSource = dtKunjungan;

            foreach (DataGridViewColumn column in dgvKunjungan.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgvKunjungan.ClearSelection();
        }

        private void SupervisorAdd_Load(object sender, EventArgs e)
        {
            loadToko();
            loadSales();
            loadDay();
            loadDataGrid();
            loadID();
        }

        private int indexSelected = -1;
        private void dgvKunjungan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexSelected = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvKunjungan.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                for (int i = 0; i < cbhari.Items.Count; i++)
                {
                    var toko = (cbhari.Items[i] as dynamic);
                    if (toko.Text == row.Cells[1].Value.ToString())
                    {
                        cbhari.SelectedIndex = i;
                        break;
                    }
                }
                for (int i = 0; i < cbtoko.Items.Count; i++)
                {
                    var toko = (cbtoko.Items[i] as dynamic);
                    if (toko.Text == row.Cells[2].Value.ToString())
                    {
                        cbtoko.SelectedIndex = i;
                        break;
                    }
                }
                for (int i = 0; i < cbsales.Items.Count; i++)
                {
                    var toko = (cbsales.Items[i] as dynamic);
                    if (toko.Text == row.Cells[3].Value.ToString())
                    {
                        cbsales.SelectedIndex = i;
                        break;
                    }
                }
                btntambah.Enabled = false;
                btndelete.Enabled = true;
                btnupdate.Enabled = true;
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void clear()
        {
            loadToko();
            loadSales();
            loadDay();
            loadDataGrid();
            loadID();
            btntambah.Enabled = true;
            btndelete.Enabled = false;
            btnupdate.Enabled = false;
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd;
            var conn = Connection.Conn;
            int id = Convert.ToInt32(textBox1.Text);

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            string idSales = (cbsales.SelectedItem as dynamic).Value;
            string idToko = (cbtoko.SelectedItem as dynamic).Value;
            string tujuan = (cbhari.SelectedItem as dynamic).Value;
            try
            {
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "update visit set V_TOKO_ID = @tokoid, V_DA_ID = @day, V_US_ID = @userid where V_ID = @id;";
                cmd.Parameters.Add(new MySqlParameter("@id", id));
                cmd.Parameters.Add(new MySqlParameter("@tokoid", idToko));
                cmd.Parameters.Add(new MySqlParameter("@day", tujuan));
                cmd.Parameters.Add(new MySqlParameter("@userid", idSales));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Berhasil Diubah!");
                clear();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd;
            var conn = Connection.Conn;
            int id = Convert.ToInt32(textBox1.Text);

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            
            try
            {
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "delete from visit where V_ID = @id;";
                cmd.Parameters.Add(new MySqlParameter("@id", id));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Berhasil Dihapus!");
                clear();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }
    }
}
