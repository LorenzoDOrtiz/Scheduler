using MySql.Data.MySqlClient;
using Scheduler.Models;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Scheduler.DataAccess
{
    internal class AppointmentRepository
    {

        internal static DataTable GetAppointmentTypeDataTable()
        {
            var query = "SELECT DISTINCT type FROM appointment";

            var customerDataTable = MySQLCRUD.GetDataTable(query);

            return customerDataTable;
        }

        internal static void InsertAppointment(AppointmentModel appointment)
        {
            try
            {
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
                MessageBox.Show("Customer record created successfully!");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Adding customer failed: " + ex.Message);
            }

        }
    }
}
