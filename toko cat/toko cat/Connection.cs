using MySql.Data.MySqlClient;

namespace toko_cat
{
    static class Connection
    {
        private static MySqlConnection conn = new MySqlConnection($"server=localhost; user id=root; password=; database=db_toko_cat");

        public static MySqlConnection Conn { get => conn; set => conn = value; }
    }
}
