using MySql.Data.MySqlClient;
using Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Scheduler.DataAccess
{
    internal class AppointmentRepository
    {
        public static void InsertAppointment(AppointmentModel appointment)
        {
            try
            {
                DBConnection.ConfirmDataBaseConnection();

                string query = "INSERT INTO appointment (customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdateBy) " +
                               "VALUES (@CustomerId, @UserId, @Title, @Description, @Location, @Contact, @Type, @Url, @Start, @End, @CreateDate, @CreatedBy, @LastUpdateBy)";
                var cmd = MySQLCRUD.CreateCommand(query);
                var parameters = new Dictionary<string, object>()
                {
                    {"@CustomerId", appointment.CustomerId},
                    {"@UserId", appointment.UserId},
                    {"@Title", appointment.Title},
                    {"@Description", appointment.Description},
                    {"@Location", appointment.Location},
                    {"@Contact", appointment.Contact},
                    {"@Type", appointment.Type},
                    {"@Url", appointment.URL},
                    {"@Start", appointment.Start},
                    {"@End", appointment.End},
                    {"@CreateDate", appointment.CreateDate},
                    {"@CreatedBy", appointment.CreatedBy},
                    {"@LastUpdateBy", appointment.LastUpdateBy}
                };
                MySQLCRUD.AddParameters(parameters, cmd);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new DataAccessException("Inserting appointment failed", ex);
            }
        }


        public static void UpdateAppointment(AppointmentModel appointmentModel, string contact)
        {
            try
            {
                DBConnection.ConfirmDataBaseConnection();

                string query = "UPDATE appointment SET customerId = @CustomerId, title = @Title, description = @Description, location = @Location, contact = @Contact, type = @Type, url = @URL, start = @Start, end = @End " +
                                           "WHERE appointmentId = @AppointmentId";

                // Convert start and end times to UTC
                DateTime startUtc = appointmentModel.Start.ToUniversalTime();
                DateTime endUtc = appointmentModel.End.ToUniversalTime();

                var cmd = MySQLCRUD.CreateCommand(query);
                var parameters = new Dictionary<string, object>
                {
                    { "@AppointmentId", appointmentModel.AppointmentId },
                    { "@CustomerId", appointmentModel.CustomerId },
                    { "@Title", appointmentModel.Title },
                    { "@Description", appointmentModel.Description },
                    { "@Location", appointmentModel.Location },
                    { "@Contact", contact },
                    { "@Type", appointmentModel.Type },
                    { "@URL", appointmentModel.URL },
                    { "@Start", startUtc },
                    { "@End", endUtc }
                };
                MySQLCRUD.AddParameters(parameters, cmd);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new DataAccessException("Updating appointment failed", ex);
            }
        }


        public static void DeleteAppointment(int selectedAppointmentId)
        {
            try
            {
                DBConnection.ConfirmDataBaseConnection();

                string query = "DELETE FROM appointment WHERE appointmentId = @AppointmentId";
                var cmd = MySQLCRUD.CreateCommand(query);
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                        { "@AppointmentId", selectedAppointmentId }
                    };

                MySQLCRUD.AddParameters(parameters, cmd);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new DataAccessException("Deleting appointment failed", ex);
            }
        }

        public static DataTable GetAppointmentTypeDataTable()
        {
            var query = "SELECT DISTINCT type FROM appointment";

            var customerDataTable = MySQLCRUD.GetDataTable(query);

            return customerDataTable;
        }

        public static DataTable GetAppointmentDataTable()
        {
            var query = "SELECT appointmentId, title, location, contact, type, start, end FROM appointment";
            var appointmentDataTable = MySQLCRUD.GetDataTable(query);

            // Convert the start and end times to local time
            foreach (DataRow row in appointmentDataTable.Rows)
            {
                DateTime utcStart = (DateTime)row["start"];
                DateTime utcEnd = (DateTime)row["end"];
                TimeZoneInfo localTimeZone = TimeZoneInfo.Local;
                row["start"] = TimeZoneInfo.ConvertTimeFromUtc(utcStart, localTimeZone);
                row["end"] = TimeZoneInfo.ConvertTimeFromUtc(utcEnd, localTimeZone);
            }

            return appointmentDataTable;
        }


        public static DataTable GetAppointmentDataTable(int appointmentId)
        {
            var query = "SELECT * FROM appointment WHERE appointmentId = @AppointmentId";
            var parameters = new Dictionary<string, object>
            {
                { "@AppointmentId", appointmentId }
            };
            var appointmentDataTable = MySQLCRUD.GetDataTable(query, parameters);

            return appointmentDataTable;
        }

        public static DataTable GetUserAppointmentDataTableForReports()
        {
            var query = @"SELECT user.userId, user.userName, appointment.title, appointment.contact, appointment.type, appointment.start, appointment.end
                                FROM appointment
                                INNER JOIN user ON appointment.userId = user.userId";

            var userAppointmentDataTable = MySQLCRUD.GetDataTable(query);

            return userAppointmentDataTable;
        }


        public static AppointmentModel GetUpcomingAppointment(int currentUserId)
        {
            var nowUtc = DateTime.UtcNow;
            var fifteenMinutesFromNowUtc = nowUtc.AddMinutes(15);

            var query = "SELECT * FROM appointment WHERE userId = @UserId AND start BETWEEN @Now AND @FifteenMinutesFromNow LIMIT 1";
            var parameters = new Dictionary<string, object>
            {
                { "@UserId", currentUserId },
                { "@Now", nowUtc },
                { "@FifteenMinutesFromNow", fifteenMinutesFromNowUtc }
            };

            var dt = MySQLCRUD.GetDataTable(query, parameters);

            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                return new AppointmentModel
                {
                    Title = row["title"].ToString(),
                    Contact = row["contact"].ToString(),
                    Start = Convert.ToDateTime(row["start"]),
                    End = Convert.ToDateTime(row["end"]),
                };
            }

            return null;
        }


        public static bool HasOverlappingAppointments(int appointmentId, DateTime startUtc, DateTime endUtc)
        {
            try
            {
                var query = "SELECT COUNT(*) FROM appointment WHERE appointmentId != @AppointmentId AND (@StartUtc < end AND @EndUtc > start)";

                var parameters = new Dictionary<string, object>
        {
            { "@AppointmentId", appointmentId },
            { "@StartUtc", startUtc },
            { "@EndUtc", endUtc }
        };

                var dt = MySQLCRUD.GetDataTable(query, parameters);
                return dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0;
            }
            catch (MySqlException ex)
            {
                throw new DataAccessException("MySQL error checking for overlapping appointments", ex);
            }
        }



    }
}

