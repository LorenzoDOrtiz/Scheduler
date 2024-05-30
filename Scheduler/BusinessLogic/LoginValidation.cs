using Scheduler.DataAccess;
using System.Data;
using System.Linq;

namespace Scheduler.BusinessLogic
{
    public static class LoginValidation
    {
        public static bool IsValidLogin(string username, string password)
        {
            var userDataTable = UserRepository.CredentialsInUserTable(username, password);
            // If our query had a matching user (any DataRows from our DataTable), we use Any() to return true.

            return userDataTable.AsEnumerable().Any();
        }
    }
}
