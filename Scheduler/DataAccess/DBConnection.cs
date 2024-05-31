using MySql.Data.MySqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Scheduler.DataAccess
{
    internal static class DBConnection
    {
        // Get the connection string from the app.config file which is git ignored
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
        // Create a new static sql connection that we will use for the entirety of our application life
        public static MySqlConnection Conn { get; set; } = new MySqlConnection(connectionString);

        public static void OpenConnection()
        {
            try
            {
                Conn.Open();
                MessageBox.Show("Connection is open");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Connection failure: {ex.Message}", "Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show($"Connection failure: {ex.Message}", "Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public static void ConfirmDataBaseConnection()
        {
            if (DBConnection.Conn.State == System.Data.ConnectionState.Closed)
            {
                DBConnection.OpenConnection();
            }
        }
    }
}
