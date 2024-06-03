using Scheduler.BusinessLogic;
using System;

namespace Scheduler.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int AddressId { get; set; }
        public int Active { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now.ToUniversalTime();
        public string CreatedBy { get; set; } = UserManager.GetCurrentUser().UserName;
        public string LastUpdateBy { get; set; } = UserManager.GetCurrentUser().UserName;

        // Below properties are for the customer count by country report

        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}

