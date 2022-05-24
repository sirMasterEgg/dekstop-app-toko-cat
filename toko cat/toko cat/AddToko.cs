using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace toko_cat
{
    public partial class AddToko : Form
    {
        public AddToko()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd;
            var conn = Connection.Conn;
            int id = hitungTokoID();
            
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            
            try
            {
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into toko (TOKO_ID, TOKO_NAME) values (@id, @name);";
                cmd.Parameters.Add(new MySqlParameter("@id", id));
                cmd.Parameters.Add(new MySqlParameter("@name", textBox1.Text));

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

        private int hitungTokoID()
        {
            var conn = Connection.Conn;
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            var cmd = new MySqlCommand();
            cmd.Connection = conn;

            conn.Open();

            cmd.CommandText = "select max(TOKO_ID) from toko;";

            string lastId = cmd.ExecuteScalar().ToString();

            conn.Close();
            return (lastId == "") ? 1 : Int32.Parse(lastId) + 1;
        }
    }
}
