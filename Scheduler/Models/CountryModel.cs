using Scheduler.BusinessLogic;
using System;

namespace Scheduler.Models
{
    internal class CountryModel
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now.ToUniversalTime();
        public string CreatedBy { get; set; } = UserManager.GetCurrentUser().UserName;
        public string LastUpdateBy { get; set; } = UserManager.GetCurrentUser().UserName;
    }
}



