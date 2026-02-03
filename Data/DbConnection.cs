
using Microsoft.Data.Sqlite;

namespace adonetdatabase.Data
{
    public class DbConnection
    {
        private string _connetionString;

        public DbConnection()
        {
            _connetionString = "Data Source=MyDatabase.db;";
        }

        public SqliteConnection GetConnection()
        {
            var connection = new SqliteConnection(_connetionString);
            connection.Open();
            return connection;
        }
    }
}