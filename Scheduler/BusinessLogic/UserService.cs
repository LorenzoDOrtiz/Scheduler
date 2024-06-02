using Scheduler.DataAccess;
using Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Scheduler.BusinessLogic
{
    internal class UserService
    {
        internal static List<UserModel> GetUserListForReports()
        {
            var userDataTable = UserRepository.GetUserDataTableForReports();
            var userList = new List<UserModel>();

            foreach (DataRow row in userDataTable.Rows)
            {
                var user = new UserModel
                {
                    UserId = Convert.ToInt32(row["userId"]),
                    UserName = row["userName"].ToString()
                };

                userList.Add(user);
            }

            return userList;
        }
    }
}
