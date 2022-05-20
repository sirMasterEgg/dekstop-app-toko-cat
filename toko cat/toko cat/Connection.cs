using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace toko_cat
{
    static class Connection
    {
        private static MySqlConnection conn = new MySqlConnection($"server=localhost; user id=root; password=; database=db_toko_cat");

        public static MySqlConnection Conn { get => conn; set => conn = value; }

        public static void openConn()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error : " + ex.Message.ToString());
            }
        }

        public static void executeNonQuery(MySqlCommand cmd)
        {
            cmd.Connection = conn;

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }


            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static int executeScalar(MySqlCommand cmd)
        {
            cmd.Connection = conn;

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }


            conn.Open();
            int temp = int.Parse(cmd.ExecuteScalar().ToString());
            conn.Close();

            return temp;
        }

        public static String executeString(MySqlCommand cmd)
        {
            cmd.Connection = conn;

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            String temp = (String)cmd.ExecuteScalar();

            return temp;
        }

        public static DataTable executeAdapter(MySqlCommand cmd)
        {
            DataTable dt = new DataTable();

            cmd.Connection = conn;

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }


            conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dt);
            conn.Close();

            return dt;
        }

        public static MySqlDataReader executeReader(MySqlCommand cmd)
        {
            cmd.Connection = conn;

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }


            conn.Open();

            return cmd.ExecuteReader();
        }
    }
}
