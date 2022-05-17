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
        public SupervisorAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (dateTimePicker1.Value < DateTime.Today)
            {
                MessageBox.Show("Tanggal pilihan lebih kecil dari hari ini!");
                return;
            }

            MySqlCommand cmd;
            var conn = Connection.Conn;
            int id = hitungVisitID();

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            string idSales = (comboBox2.SelectedItem as dynamic).Value;
            string idToko = (comboBox1.SelectedItem as dynamic).Value;

            try
            {
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into visit (V_ID, V_TOKO_ID, V_TANGGAL, V_STATUS, V_US_ID) values (@id, @tokoid, @tanggal, @status, @userid);";
                cmd.Parameters.Add(new MySqlParameter("@id", id));
                cmd.Parameters.Add(new MySqlParameter("@tokoid", idToko));
                cmd.Parameters.Add(new MySqlParameter("@tanggal", dateTimePicker1.Value));
                cmd.Parameters.Add(new MySqlParameter("@status", "0"));
                cmd.Parameters.Add(new MySqlParameter("@userid", idSales));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Berhasil Ditambahkan!");
                this.Close();
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
            comboBox1.Items.Clear();
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

            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";

            while (reader.Read())
            {
                comboBox1.Items.Add(new { Text = reader.GetString(1), Value = reader.GetString(0) });

            }
            conn.Close();
            comboBox1.SelectedIndex = 0;
        }

        private void loadSales()
        {
            comboBox2.Items.Clear();
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

            comboBox2.DisplayMember = "Text";
            comboBox2.ValueMember = "Value";

            while (reader.Read())
            {
                comboBox2.Items.Add(new { Text = reader.GetString(1), Value = reader.GetString(0) });

            }
            conn.Close();
            comboBox2.SelectedIndex = 0;
        }

        private void SupervisorAdd_Load(object sender, EventArgs e)
        {
            loadToko();
            loadSales();
        }
    }
}
