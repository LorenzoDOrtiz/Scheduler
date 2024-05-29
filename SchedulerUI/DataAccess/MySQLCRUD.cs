using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace Scheduler.DataAccess
{
    internal class MySQLCRUD
    {
        public static DataTable GetDateTable(string query, Dictionary<string, object> parameters = null)
        {
            DataTable dt = new DataTable();

            using (var cmd = new MySqlCommand(query, DBConnection.Conn))
            {
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                    }
                }
                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
    }
}
