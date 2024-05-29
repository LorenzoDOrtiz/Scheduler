using Scheduler.BusinessLogic;
using System;

namespace Scheduler.Models
{
    internal class AddressModel
    {
        public int AddressId { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; } = "";
        public int CityId { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now.ToUniversalTime();
        public string CreatedBy { get; set; } = UserManager.GetCurrentUser().UserName;
        public string LastUpdateBy { get; set; } = UserManager.GetCurrentUser().UserName;
    }
}
