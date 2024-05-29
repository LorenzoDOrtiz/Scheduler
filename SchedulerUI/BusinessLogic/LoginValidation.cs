using Scheduler.DataAccess;

namespace Scheduler.BuisnessLogic
{
    public static class LoginValidation
    {
        public static bool IsValidLogin(string username, string password)
        {
            return UserRepository.CredentialsInUserTable(username, password);
        }


    }
}
