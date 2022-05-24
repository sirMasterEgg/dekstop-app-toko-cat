using MySql.Data.MySqlClient;
using System;
using System.Data;
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

        private void generateFunctionIDHtrans()
        {
            try
            {
                Connection.openConn();

                MySqlScript script = new MySqlScript(Connection.Conn);

                script.Query = @"CREATE OR REPLACE
                                FUNCTION `db_toko_cat`.`generateIDHtrans`()
                                RETURNS VARCHAR(50)
                                BEGIN
	                            DECLARE idBesar INT;
	                            DECLARE banyak_htrans INT;
	
	                            SELECT COUNT(*) INTO banyak_htrans FROM htrans_item;
	
	                            IF (banyak_htrans > 0) THEN
		                            SELECT ht_id INTO idBesar FROM htrans_item ORDER BY ht_id DESC LIMIT 1;
	                            ELSE 
		                            SET idBesar = 0;
	                            END IF;
	
	                            RETURN idBesar+1;
                                END$$";
                script.Delimiter = @"$$";
                script.Execute();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());
            }
        }

        private void generateFunctionIDDtrans()
        {
            try
            {
                Connection.openConn();

                MySqlScript script = new MySqlScript(Connection.Conn);

                script.Query = @"CREATE OR REPLACE
                                FUNCTION `db_toko_cat`.`generateIDDtrans`()
                                RETURNS VARCHAR(50)
                                BEGIN
	                            DECLARE idBesar INT;
	                            DECLARE banyak_dtrans INT;
	
	                            SELECT COUNT(*) INTO banyak_dtrans FROM dtrans_item;
	
	                            IF (banyak_dtrans > 0) THEN
		                            SELECT dt_id INTO idBesar FROM dtrans_item ORDER BY dt_id DESC LIMIT 1;
	                            ELSE 
		                            SET idBesar = 0;
	                            END IF;
	
	                            RETURN idBesar+1;
                                END$$";
                script.Delimiter = @"$$";
                script.Execute();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());
            }
        }

        private void generateFunctionCountAbsen()
        {
            try
            {
                Connection.openConn();

                MySqlScript script = new MySqlScript(Connection.Conn);

                script.Query = @"CREATE OR REPLACE
                                FUNCTION `db_toko_cat`.`generateCountAbsen`(
	                            idUser INT(11)
                                )
                                RETURNS INT
                                BEGIN
	                            DECLARE banyakAbsen INT;
	
	                            SELECT COUNT(*) INTO banyakAbsen FROM absen 
	                            WHERE ab_us_id = idUser AND DATE(ab_date) = DATE(NOW());
	
	                            RETURN banyakAbsen;
                                END$$";
                script.Delimiter = @"$$";
                script.Execute();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());
            }
        }

        private void generateFuntionDTSubtotal()
        {
            try
            {
                Connection.openConn();

                MySqlScript script = new MySqlScript(Connection.Conn);

                script.Query = @"CREATE OR REPLACE
                                FUNCTION `db_toko_cat`.`getDTSubtotal`(id INT, amount INT)
                                RETURNS INT(11)
    
                                BEGIN
	                            DECLARE res INT DEFAULT 0;
	                            SELECT IT_PRICE INTO res FROM item WHERE IT_ID = id;
	                            SET res = res * amount;
	                            RETURN res;
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
                generateFunctionCountAbsen();
                this.Hide();
                Form form = new Supervisor();
                form.ShowDialog();
                form.Dispose();
                this.Show();
            }
            else if (dt.Rows[0]["US_TY_ID"].ToString() == "2") // Salesperson
            {
                generateFunctionInvoice();
                generateFunctionIDHtrans();
                generateFunctionIDDtrans();

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
                generateFuntionDTSubtotal();
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)96)
            {
                textBox1.Text = "user1";
                textBox2.Text = "user1";
                button1.PerformClick();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)96)
            {
                textBox1.Text = "user1";
                textBox2.Text = "user1";
                button1.PerformClick();
            }
        }
    }
}
