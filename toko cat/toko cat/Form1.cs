using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace toko_cat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkButton(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("user");
            MySqlCommand cmd = new MySqlCommand("select * from user where US_USERNAME = @ususername and US_PASSWORD = @uspassword", Connection.Conn);
            cmd.Parameters.AddWithValue("@ususername", textBox1.Text);
            cmd.Parameters.AddWithValue("@uspassword", textBox2.Text);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("User tidak ditemukan!");
                return;
            }
            if (dt.Rows[0]["US_TY_ID"].ToString() == "1") // Sales Supervisor
            {
                this.Hide();
                Form form = new Supervisor();
                form.ShowDialog();
                form.Dispose();
                this.Show();
            }
            else if (dt.Rows[0]["US_TY_ID"].ToString() == "2") // Salesperson
            {
                this.Hide();
                Form form = new SalesmanCatalog();
                form.ShowDialog();
                form.Dispose();
                this.Show();
            }
            else if (dt.Rows[0]["US_TY_ID"].ToString() == "3") // Admin
            {
                this.Hide();
                Form form = new Admin();
                form.ShowDialog();
                form.Dispose();
                this.Show();
            }
            else if (dt.Rows[0]["US_TY_ID"].ToString() == "4") // Inventory and Delivery Manager
            {
                this.Hide();
                Form form = new InventoryDelivery();
                form.ShowDialog();
                form.Dispose();
                this.Show();
            }
            else if (dt.Rows[0]["US_TY_ID"].ToString() == "5") // Human Resource
            {
                this.Hide();
                Form form = new HumanResource();
                form.ShowDialog();
                form.Dispose();
                this.Show();
            }
        }
    }
}
