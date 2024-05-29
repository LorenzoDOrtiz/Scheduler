using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Scheduler.DataAccess
{
    internal class UserRepository
    {
        public static bool CredentialsInUserTable(string username, string password)
        {
            var query = "SELECT * FROM user WHERE userName = @UserName AND password = @Password";

            var parameters = new Dictionary<string, object>
            {
                { "@UserName", username },
                { "@Password", password }
            };

            // Load data from database
            var userDataTable = MySQLCRUD.GetDateTable(query, parameters);

            // If our query had a matching user (any DataRows from our DataTable), we use Any() to return true.
            return userDataTable.AsEnumerable().Any();

        }
    }
}
