using MySql.Data.MySqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Scheduler.DataAccess
{
    internal static class DBConnection
    {
        // Get the connection string from the app.config file which is git ignored
        private static string connectionString = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
        // Create a new static sql connection that we will use for the entirety of our application life
        public static MySqlConnection Conn { get; private set; } = new MySqlConnection(connectionString);

        public static void OpenConnection()
        {
            try
            {
                Conn.Open();
                MessageBox.Show("Connection is open");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"SQL Exception: {ex.Message}");
            }

        }

        public static void CloseConnection()
        {
            try
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
                Conn = null;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"SQL Exception: {ex.Message}");
            }

        }
    }
}
