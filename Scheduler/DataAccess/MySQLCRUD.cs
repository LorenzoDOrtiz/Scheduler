using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace Scheduler.DataAccess
{
    internal class MySQLCRUD
    {

        public static MySqlCommand CreateCommand(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, DBConnection.Conn);
            return cmd;
        }

        public static MySqlCommand CreateCommand(string query, MySqlTransaction transaction)
        {
            MySqlCommand cmd = new MySqlCommand(query, DBConnection.Conn, transaction);
            return cmd;
        }

        public static void AddParameters(Dictionary<string, object> parameters, MySqlCommand cmd)
        {
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
            }
        }

        public static DataTable GetDataTable(string query, Dictionary<string, object> parameters = null)
        {
            DataTable dt = new DataTable();

            MySqlCommand cmd = CreateCommand(query);

            AddParameters(parameters, cmd);

            var adapter = new MySqlDataAdapter(cmd);

            adapter.Fill(dt);

            return dt;
        }


    }
}
