using Scheduler.Models;
using System.Collections.Generic;
using System.Linq;

namespace Scheduler.BusinessLogic
{
    public class ReportGenerator
    {
        private static List<AppointmentModel> appointments = AppointmentService.GetUserAppointmentListForReports();
        private static List<AppointmentModel> userAppointments = AppointmentService.GetUserAppointmentListForReports();

        // Report: Number of Appointment Types
        public static List<object> GetAppointmentTypesByMonth()
        {
            var report = appointments
                .GroupBy(a => new { a.Start.Year, a.Start.Month, a.Type })
                .Select(g => new
                {
                    g.Key.Year,
                    g.Key.Month,
                    g.Key.Type,
                    Count = g.Count()
                })
                .ToList();

            return report.Cast<object>().ToList();
        }

        public static List<object> GetUserSchedule(int userId)
        {
            var report = userAppointments
                .Where(a => a.UserId == userId)
                .Select(g => new
                {
                    g.UserName,
                    g.Title,
                    g.Contact,
                    g.Type,
                    g.Start,
                    g.End

                })
                .ToList();
            return report.Cast<object>().ToList();
        }
    }
}
