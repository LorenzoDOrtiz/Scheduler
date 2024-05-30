using Scheduler.BusinessLogic;
using System;

namespace Scheduler.Models
{
    internal class AppointmentModel
    {
        public int AppointmentId { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public string Type { get; set; }
        public string URL { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now.ToUniversalTime();
        public string CreatedBy { get; set; } = UserManager.GetCurrentUser().UserName;
        public string LastUpdateBy { get; set; } = UserManager.GetCurrentUser().UserName;
    }
}


