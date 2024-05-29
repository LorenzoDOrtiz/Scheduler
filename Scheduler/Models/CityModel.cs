using Scheduler.BusinessLogic;
using System;

namespace Scheduler.Models
{
    internal class CityModel
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now.ToUniversalTime();
        public string CreatedBy { get; set; } = UserManager.GetCurrentUser().UserName;
        public string LastUpdateBy { get; set; } = UserManager.GetCurrentUser().UserName;
    }
}



