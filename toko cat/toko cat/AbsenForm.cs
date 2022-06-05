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
    public partial class AbsenForm : Form
    {

        public AbsenForm()
        {
            InitializeComponent();
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

            AutoCompleteStringCollection data = new AutoCompleteStringCollection();

            while (reader.Read())
            {
                comboBox1.Items.Add(new { Text = reader.GetString(1), Value = reader.GetInt32(0) });
                data.Add(reader.GetString(1));
            }
            conn.Close();

            comboBox1.AutoCompleteCustomSource = data;

            comboBox1.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                int id = (comboBox1.SelectedItem as dynamic).Value;

                Absen rpt = new Absen();
                rpt.SetParameterValue("idUser", id);

                crystalReportViewer1.ReportSource = rpt;
            }
            else MessageBox.Show("Pilih sales terlebih dahulu !");
        }
    }
}
