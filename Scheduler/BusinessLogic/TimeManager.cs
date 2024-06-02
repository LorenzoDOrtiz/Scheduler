using Scheduler.DataAccess;
using System;
using System.Data;
using System.Windows.Forms;

namespace Scheduler.BusinessLogic
{
    internal class TimeManager
    {
        public static bool ValidAppointmentDateTime(DateTimePicker startDatePicker, DateTimePicker startTimePicker, DateTimePicker endDatePicker, DateTimePicker endTimePicker)
        {
            DateTime startDate = startDatePicker.Value;
            DateTime startTime = startTimePicker.Value;
            DateTime endDate = endDatePicker.Value;
            DateTime endTime = endTimePicker.Value;

            // Combine the dates and times
            DateTime start = new DateTime(startDate.Year, startDate.Month, startDate.Day, startTime.Hour, startTime.Minute, startTime.Second, DateTimeKind.Local);
            DateTime end = new DateTime(endDate.Year, endDate.Month, endDate.Day, endTime.Hour, endTime.Minute, endTime.Second, DateTimeKind.Local);

            // Convert to UTC
            DateTime startUtc = start.ToUniversalTime();
            DateTime endUtc = end.ToUniversalTime();

            // Convert UTC times to Eastern Standard Time
            TimeZoneInfo estTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime startEst = TimeZoneInfo.ConvertTimeFromUtc(startUtc, estTimeZone);
            DateTime endEst = TimeZoneInfo.ConvertTimeFromUtc(endUtc, estTimeZone);

            // Check if the appointment is within business hours (9 AM to 5 PM EST) and on weekdays
            if (startEst.Hour < 9 || (startEst.Hour >= 17 && startEst.Minute > 0) ||
                endEst.Hour < 9 || (endEst.Hour >= 17 && endEst.Minute > 0) ||
                startEst.DayOfWeek == DayOfWeek.Saturday || startEst.DayOfWeek == DayOfWeek.Sunday ||
                endEst.DayOfWeek == DayOfWeek.Saturday || endEst.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("Appointment time must be between 9 AM and 5 PM EST on weekdays.", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check if end time is after start time
            if (endEst <= startEst)
            {
                MessageBox.Show("End time must be after start time.", "Invalid Time Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                // Check for overlapping appointments
                if (AppointmentRepository.HasOverlappingAppointments(startUtc, endUtc))
                {
                    MessageBox.Show("There is already an appointment scheduled within the specified time range.", "Overlap Detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (DataAccessException ex)
            {
                MessageBox.Show("MySQL Error while checking for overlapping appointments. " + ex.Message, "MySQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }


        public static DataTable ConvertDataTableWithUtcTimesToLocalTime(DataTable dataTableUtcTimes)
        {
            var utcDataTable = dataTableUtcTimes;

            foreach (DataRow row in dataTableUtcTimes.Rows)
            {
                DateTime utcStart = (DateTime)row["start"];
                DateTime utcEnd = (DateTime)row["end"];
                TimeZoneInfo localTimeZone = TimeZoneInfo.Local;
                row["start"] = TimeZoneInfo.ConvertTimeFromUtc(utcStart, localTimeZone);
                row["end"] = TimeZoneInfo.ConvertTimeFromUtc(utcEnd, localTimeZone);
            }

            return utcDataTable;
        }

    }
}
