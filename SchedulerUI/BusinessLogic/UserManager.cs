using Scheduler.Models;

namespace Scheduler.BusinessLogic
{
    internal class UserManager
    {
        private static UserManager instance;
        private UserModel currentUser;



        public static UserManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserManager();
                }
                return instance;
            }
        }

        public void SetCurrentUser(UserModel user)
        {
            currentUser = user;
        }

        public UserModel GetCurrentUser()
        {
            return currentUser;
        }
    }
}
