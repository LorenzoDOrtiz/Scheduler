using Scheduler.Models;
using System.Collections.Generic;
using System.Linq;

namespace Scheduler.BusinessLogic
{
    public class ReportGenerator
    {
        private List<AppointmentModel> appointments;
        private List<UserModel> users;

        public ReportGenerator(List<AppointmentModel> appointments, List<UserModel> users)
        {
            this.appointments = appointments;
            this.users = users;
        }

        // Report: Number of Appointment Types
        public List<object> GetAppointmentTypesByMonth()
        {
            var report = appointments
                .GroupBy(a => new { a.Start.Year, a.Start.Month, a.Type })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    Type = g.Key.Type,
                    Count = g.Count()
                })
                .ToList();

            return report.Cast<object>().ToList();
        }
    }
}
