using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace toko_cat
{
    public partial class HumanResource : Form
    {
        private int mode;

        public HumanResource()
        {
            InitializeComponent();
        }

        private void generateID(object sender, EventArgs e)
        {
            if (mode == 1)
            {
                if (textBox2.Text != "" || textBox3.Text != "" || textBox4.Text != "" || textBox5.Text != "" || textBox6.Text != "" || textBox7.Text != "" || comboBox1.SelectedIndex != -1 || numericUpDown1.Value != 0 || radioButton1.Checked || radioButton2.Checked)
                {
                    if (textBox1.Text == "")
                    {
                        DataTable dt = new DataTable("user");
                        MySqlCommand cmd = new MySqlCommand("select US_ID + 1 from user order by US_ID desc limit 1", Connection.Conn);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                        if (dt.Rows.Count == 0)
                        {
                            textBox1.Text = "1";
                        }
                        else
                        {
                            textBox1.Text = dt.Rows[0][0].ToString();
                        }
                    }
                }
                else
                {
                    textBox1.Text = "";
                }
            }
        }

        private bool valid()
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || comboBox1.SelectedIndex == -1 || numericUpDown1.Value == 0 || !radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Semua field harus terisi!");
                return false;
            }
            Regex re = new Regex(@"^.+[@].+[.].+$");
            if (!re.IsMatch(textBox5.Text))
            {
                MessageBox.Show("Email tidak valid!");
                return false;
            }
            re = new Regex(@"^[\d]*$");
            if (!re.IsMatch(textBox6.Text))
            {
                MessageBox.Show("Nomor telepon tidak valid!");
                return false;
            }
            return true;
        }

        private void HumanResource_Load(object sender, EventArgs e)
        {
            button4.PerformClick();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mode = 0;
            DataTable dt1 = new DataTable("user");
            MySqlCommand cmd1 = new MySqlCommand("select US_ID as ID, US_USERNAME as Username, US_PASSWORD as Password, US_NAME as Nama, US_EMAIL as Email, US_PHONE as \"Nomor Telepon\", US_ADDRESS as Alamat, TY_NAME as Tipe, concat('Rp ', format(US_SALARY, 0)) as Gaji, if(US_STATUS = 1, 'Aktif', 'Tidak Aktif') as Status from user join type on US_TY_ID = TY_ID order by US_ID", Connection.Conn);
            MySqlDataAdapter da1 = new MySqlDataAdapter(cmd1);
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            DataTable dt2 = new DataTable("type");
            MySqlCommand cmd2 = new MySqlCommand("select * from type", Connection.Conn);
            MySqlDataAdapter da2 = new MySqlDataAdapter(cmd2);
            da2.Fill(dt2);
            comboBox1.DataSource = dt2;
            comboBox1.ValueMember = "TY_ID";
            comboBox1.DisplayMember = "TY_NAME";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox1.SelectedIndex = -1;
            numericUpDown1.Value = 0;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = true;
            button5.Enabled = false;
            button6.Enabled = true;
            mode = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (valid())
            {
                Connection.Conn.Open();
                MySqlCommand cmd = new MySqlCommand("insert into user(US_ID, US_USERNAME, US_PASSWORD, US_NAME, US_EMAIL, US_PHONE, US_ADDRESS, US_TY_ID, US_SALARY, US_STATUS) values(@usid, @ususername, @uspassword, @usname, @usemail, @usphone, @usaddress, @ustyid, @ussalary, @usstatus)", Connection.Conn);
                cmd.Parameters.AddWithValue("@usid", textBox1.Text);
                cmd.Parameters.AddWithValue("@ususername", textBox2.Text);
                cmd.Parameters.AddWithValue("@uspassword", textBox3.Text);
                cmd.Parameters.AddWithValue("@usname", textBox4.Text);
                cmd.Parameters.AddWithValue("@usemail", textBox5.Text);
                cmd.Parameters.AddWithValue("@usphone", textBox6.Text);
                cmd.Parameters.AddWithValue("@usaddress", textBox7.Text);
                cmd.Parameters.AddWithValue("@ustyid", comboBox1.SelectedValue);
                cmd.Parameters.AddWithValue("@ussalary", numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@usstatus", radioButton1.Checked ? 1 : 0);
                cmd.ExecuteNonQuery();
                Connection.Conn.Close();
                button4.PerformClick();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                mode = 2;
                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = true;
                button5.Enabled = true;
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                comboBox1.SelectedIndex = comboBox1.FindStringExact(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
                numericUpDown1.Value = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString().Replace("Rp ", "").Replace(",", ""));
                if (dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString() == "Aktif")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (valid())
            {
                Connection.Conn.Open();
                MySqlCommand cmd = new MySqlCommand("update user set US_USERNAME = @ususername, US_PASSWORD = @uspassword, US_NAME = @usname, US_EMAIL = @usemail, US_PHONE = @usphone, US_ADDRESS = @usaddress, US_TY_ID = @ustyid, US_SALARY = @ussalary, US_STATUS = @usstatus where US_ID = @usid", Connection.Conn);
                cmd.Parameters.AddWithValue("@usid", textBox1.Text);
                cmd.Parameters.AddWithValue("@ususername", textBox2.Text);
                cmd.Parameters.AddWithValue("@uspassword", textBox3.Text);
                cmd.Parameters.AddWithValue("@usname", textBox4.Text);
                cmd.Parameters.AddWithValue("@usemail", textBox5.Text);
                cmd.Parameters.AddWithValue("@usphone", textBox6.Text);
                cmd.Parameters.AddWithValue("@usaddress", textBox7.Text);
                cmd.Parameters.AddWithValue("@ustyid", comboBox1.SelectedValue);
                cmd.Parameters.AddWithValue("@ussalary", numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@usstatus", radioButton1.Checked ? 1 : 0);
                cmd.ExecuteNonQuery();
                Connection.Conn.Close();
                button4.PerformClick();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.Conn.Open();
                MySqlCommand cmd = new MySqlCommand("delete from user where US_ID = @usid", Connection.Conn);
                cmd.Parameters.AddWithValue("@usid", textBox1.Text);
                cmd.ExecuteNonQuery();
                Connection.Conn.Close();
                button4.PerformClick();
            }
            catch
            {
                Connection.Conn.Close();
                MessageBox.Show("User tidak dapat dihapus!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HRCatatanSupervisor form = new HRCatatanSupervisor(Convert.ToInt32(textBox1.Text));
            form.ShowDialog();
            form.Dispose();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a report...");
        }
    }
}
