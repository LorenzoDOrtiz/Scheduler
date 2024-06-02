using System.Collections.Generic;
using System.Data;

namespace Scheduler.DataAccess
{
    internal class UserRepository
    {
        public static DataTable CredentialsInUserTable(string username, string password)
        {
            var query = "SELECT * FROM user WHERE userName = @UserName AND password = @Password";

            var parameters = new Dictionary<string, object>
            {
                { "@UserName", username },
                { "@Password", password }
            };

            // Load data from database
            var userDataTable = MySQLCRUD.GetDataTable(query, parameters);

            return userDataTable;

        }

        public static DataTable GetUserDataTable(string username, string password)
        {
            var query = "SELECT * FROM user WHERE userName = @UserName AND password = @Password";

            var parameters = new Dictionary<string, object>
            {
                { "@UserName", username },
                { "@Password", password }
            };

            // Load data from database
            var userDataTable = MySQLCRUD.GetDataTable(query, parameters);

            return userDataTable;
        }

        public static DataTable GetUserDataTableForReports()
        {
            var query = "SELECT * FROM user";

            var userDataTable = MySQLCRUD.GetDataTable(query);

            return userDataTable;
        }
    }
}
