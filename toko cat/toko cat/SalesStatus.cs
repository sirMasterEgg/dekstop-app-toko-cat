using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace toko_cat
{
    public partial class SalesStatus : Form
    {
        private int id;
        public SalesStatus()
        {
            InitializeComponent();
        }

        private void SalesStatus_Load(object sender, EventArgs e)
        {
            loadSales();
        }
        
        private void loadSales()
        {
            comboBox1.Items.Clear();
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

            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";
            
            while (reader.Read())
            {
                comboBox1.Items.Add(new { Text = reader.GetString(1), Value = reader.GetString(0) });
                
            }
            conn.Close();
            comboBox1.SelectedIndex = 0;
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

            cmd.CommandText = "select max(No_ID) from note;";

            string lastId = cmd.ExecuteScalar().ToString();

            conn.Close();
            return (lastId == "") ? 1 : Int32.Parse(lastId) + 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            MySqlCommand cmd;
            var conn = Connection.Conn;
            int visitID = hitungVisitID();

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            string userID = (comboBox1.SelectedItem as dynamic).Value;

            try
            {
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into note (NO_ID,NO_CREATION_DATETIME, NO_TEXT, NO_US_ID) values (@id, @tanggal, @text, @user);";
                cmd.Parameters.Add(new MySqlParameter("@id", visitID));
                cmd.Parameters.Add(new MySqlParameter("@tanggal", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                cmd.Parameters.Add(new MySqlParameter("@text", textBox1.Text));
                cmd.Parameters.Add(new MySqlParameter("@user", userID));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                this.Close();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }
    }
}
