using Scheduler.DataAccess;
using Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Scheduler.BusinessLogic
{
    internal class AppointmentService
    {
        public static void CreateAppointment(int customerId, int userId, string title, string description, string location, string contact, string type, string url, DateTime start, DateTime end)
        {
            try
            {
                // Create Appointment
                AppointmentModel appointment = new AppointmentModel
                {
                    CustomerId = customerId,
                    UserId = userId,
                    Title = title,
                    Description = description,
                    Location = location,
                    Contact = contact,
                    Type = type,
                    URL = url,
                    Start = start,
                    End = end
                };
                // Insert Appointment
                AppointmentRepository.InsertAppointment(appointment);
                MessageBox.Show("Appointment created successfully!", "Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                MessageBox.Show("Adding appointment failed: " + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static void ModifyAppointment(AppointmentModel appointmentModel)
        {
            try
            {
                AppointmentRepository.UpdateAppointment(appointmentModel);
                MessageBox.Show("Appointment modified successfully!", "Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (DataAccessException ex)
            {
                MessageBox.Show("Appointment modification failed: " + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static int GetContactCustomerId(string contactComboBoxText)
        {
            var customerDataTable = CustomerRepository.GetCustomerIdDataTable(contactComboBoxText);
            var customerDataRow = customerDataTable.AsEnumerable().First();
            var customerId = customerDataRow.Field<int>("customerId");
            return customerId;
        }

        public static List<string> GetAppointmentTypeTable()
        {
            var appointmentTypeDataTable = AppointmentRepository.GetAppointmentTypeDataTable();

            var appointmentTypeList = new List<string>();

            foreach (DataRow row in appointmentTypeDataTable.Rows)
            {
                appointmentTypeList.Add(row["type"].ToString());
            }

            return appointmentTypeList;
        }
        internal static AppointmentModel GetAppointment(int selectedAppointmentRowId)
        {
            var appointmentDataTable = AppointmentRepository.GetAppointmentDataTable(selectedAppointmentRowId);
            var appointmentRow = appointmentDataTable.Rows[0];

            var appointment = new AppointmentModel
            {
                AppointmentId = Convert.ToInt32(appointmentRow["appointmentId"]),
                CustomerId = Convert.ToInt32(appointmentRow["customerId"]),
                UserId = Convert.ToInt32(appointmentRow["userId"]),
                Title = appointmentRow["title"].ToString(),
                Description = appointmentRow["description"].ToString(),
                Location = appointmentRow["location"].ToString(),
                Contact = appointmentRow["contact"].ToString(),
                Type = appointmentRow["type"].ToString(),
                URL = appointmentRow["url"].ToString(),
                Start = Convert.ToDateTime(appointmentRow["start"]),
                End = Convert.ToDateTime(appointmentRow["end"])

            };
            return appointment;
        }
    }
}
