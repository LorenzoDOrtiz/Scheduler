using MySql.Data.MySqlClient;
using Scheduler.Models;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

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
                    {"@End", appointment.End },
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

        public static void UpdateAppointment(AppointmentModel appointmentModel)
        {
            try
            {
                DBConnection.ConfirmDataBaseConnection();

                string query = "UPDATE appointment SET customerId = @CustomerId, title = @Title, description = @Description, location = @Location, contact = @Contact, type = @Type, url = @URL, start = @Start, end = @End " +
                                           "WHERE appointmentId = @AppointmentId";
                var cmd = MySQLCRUD.CreateCommand(query);
                var parameters = new Dictionary<string, object>
            {
                    { "@AppointmentId", appointmentModel.AppointmentId },
                    { "@CustomerId", appointmentModel.CustomerId },
                    { "@Title", appointmentModel.Title },
                    { "@Description", appointmentModel.Description },
                    { "@Location", appointmentModel.Location },
                    { "@Contact", appointmentModel.Contact },
                    { "@Type", appointmentModel.Type },
                    { "@URL", appointmentModel.URL },
                    { "@Start", appointmentModel.Start },
                    { "@End", appointmentModel.End }
            };
                MySQLCRUD.AddParameters(parameters, cmd);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Appointment record modified successfully!", "Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
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







    }
}

