using Scheduler.DataAccess;
using Scheduler.Models;
using System.Data;
using System.Linq;

namespace Scheduler.BusinessLogic
{
    public class UserManager
    {
        private static UserModel _currentUser;

        // Method to create and set the current user
        public static void CreateUser(string username, string password)
        {
            var userDataTable = UserRepository.GetUserDataTable(username, password);

            var userDataRow = userDataTable.AsEnumerable().First();

            var currentUser = new UserModel
            {

                UserName = userDataRow.Field<string>("userName"),
                Password = userDataRow.Field<string>("password"),

            };

            _currentUser = currentUser;
        }

        public static void SetCurrentUserId(string username, string password)
        {
            var userDataTable = UserRepository.GetUserDataTable(username, password);

            var userDataRow = userDataTable.AsEnumerable().First();

            _currentUser.UserId = userDataRow.Field<int>("userId");
        }

        // Method to retrieve the current user
        public static UserModel GetCurrentUser()
        {
            return _currentUser;
        }
    }
}
