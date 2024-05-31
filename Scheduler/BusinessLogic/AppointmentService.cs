using Scheduler.DataAccess;
using Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Scheduler.BusinessLogic
{
    internal class AppointmentService
    {
        public static void CreateApointment(int customerId, int userId, string title, string description, string location, string contact, string type, string url, DateTime start, DateTime end)
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

        public static void ModifyAppointment(AppointmentModel appointmentModel)
        {
            AppointmentRepository.UpdateAppointment(appointmentModel);
        }
    }
}
