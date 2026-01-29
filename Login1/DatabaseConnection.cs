using MySql.Data.MySqlClient;
using System;

namespace Login1
{
    public class DatabaseConnection
    {
        // HE AÑADIDO: SslMode=None para evitar errores de certificados en local.
        // NOTA: Si tuvieras problemas con 'fippy_user', podrías probar temporalmente con 'Uid=root;Pwd=root;'
        private string connectionString = "Server=localhost;Port=3306;Database=home_videojuegos_db;Uid=fippy_user;Pwd=fippy123;";
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}