using System;

namespace Scheduler.Models
{
    public class AppointmentModel
    {
        public int AppointmentId { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } = "";
        public string Location { get; set; }
        public string Contact { get; set; }
        public string Type { get; set; }
        public string URL { get; set; } = "";
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now.ToUniversalTime();
        public string CreatedBy { get; set; }
        public string LastUpdateBy { get; set; }
        public string UserName { get; set; } // adding username property here to use it for the user appointment report
    }
}
