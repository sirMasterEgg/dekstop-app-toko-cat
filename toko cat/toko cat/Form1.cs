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
        public static int idUserLogin;
        public static String namaUserLogin;

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

        private void generateFunctionInvoice()
        {
            try
            {
                Connection.openConn();

                MySqlScript script = new MySqlScript(Connection.Conn);

                script.Query = @"CREATE OR REPLACE
                                FUNCTION `db_toko_cat`.`generateInvoice`()
                                RETURNS VARCHAR(50)
                                BEGIN
	                            DECLARE hasil VARCHAR(50);
	
	                            DECLARE banyakInvoice INT;
	
	                            SELECT CONCAT('1',SUBSTR(YEAR(NOW()),3,2),
	                            IF(MONTH(NOW()) >= 10, MONTH(NOW()), CONCAT('0',MONTH(NOW()))),
	                            IF(DAY(NOW())>=10, DAY(NOW()), CONCAT('0',DAY(NOW()))),
	                            '1') INTO hasil;
	
	                            SELECT COUNT(*) INTO banyakInvoice FROM htrans_item WHERE ht_invoice_number LIKE CONCAT(hasil, '%');
		
	                            SET hasil = CONCAT(hasil,LPAD(banyakInvoice+1,3,'0'));
	
	                            RETURN hasil;
                                END$$";
                script.Delimiter = @"$$";
                script.Execute();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());
            }
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
                generateFunctionInvoice();

                idUserLogin = int.Parse(dt.Rows[0]["US_ID"].ToString());
                namaUserLogin = dt.Rows[0]["US_NAME"].ToString();
                this.Hide();

                SalesmanCatalog catalog = new SalesmanCatalog();

                catalog.StartPosition = FormStartPosition.CenterScreen;

                catalog.ShowDialog();
                catalog.Dispose();

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
