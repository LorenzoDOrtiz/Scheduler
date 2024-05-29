using Scheduler.BusinessLogic;
using System;

namespace Scheduler.Models
{
    internal class AppointmentModel
    {
        public int AppointmentId { get; set; }
        public string CustomerId { get; set; }
        public string UserId { get; set; }
        public int Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public string Type { get; set; }
        public string URL { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now.ToUniversalTime();
        public string CreatedBy { get; set; } = UserManager.GetCurrentUser().UserName;
        public string LastUpdateBy { get; set; } = UserManager.GetCurrentUser().UserName;
    }
}


