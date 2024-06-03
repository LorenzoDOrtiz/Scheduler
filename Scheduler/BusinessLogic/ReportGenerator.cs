using System.Collections.Generic;
using System.Linq;

namespace Scheduler.BusinessLogic
{
    public class ReportGenerator
    {
        // Report: Number of Appointment Types
        public static List<object> GetAppointmentTypesByMonth()
        {
            var usersAndAppointments = AppointmentService.GetUserAppointmentListForReports(); // Fetch fresh data

            var report = usersAndAppointments
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
            var usersAndAppointments = AppointmentService.GetUserAppointmentListForReports(); // Fetch fresh data

            var report = usersAndAppointments
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

        public static List<object> GetCustomerCountByCountry()
        {
            var customersAndCountry = CustomerService.GetCustomerCountryListForReports(); // Fetch fresh data

            var report = customersAndCountry
                .GroupBy(c => c.CountryName)
                .Select(g => new
                {
                    Country = g.Key,
                    Count = g.Count()
                })
                .ToList();

            return report.Cast<object>().ToList();
        }
    }
}
