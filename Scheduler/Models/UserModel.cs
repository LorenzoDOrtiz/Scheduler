using System;

namespace Scheduler.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now.ToUniversalTime();
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; } = DateTime.Now.ToUniversalTime();
        public string LastUpdateBy { get; set; }
    }
}
