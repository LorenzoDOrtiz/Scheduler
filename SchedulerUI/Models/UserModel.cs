using System;

namespace Scheduler.Models
{
    internal class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        string Password { get; set; }
        int Active { get; set; }
        DateTime CreateDate { get; set; }
        string CreatedBy { get; set; }
        DateTime LastUpdate { get; set; }
        string LastUpdateBy { get; set; }

        public UserModel(string userName, string password, int active, DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdateBy)
        {
            UserName = userName;
            Password = password;
            Active = active;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdateBy = lastUpdateBy;
        }
        public void SetUserId(int userId)
        {
            UserId = userId;
        }
    }
}
