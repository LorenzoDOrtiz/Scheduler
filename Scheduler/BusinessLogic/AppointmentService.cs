using Scheduler.DataAccess;
using Scheduler.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Scheduler.BusinessLogic
{
    internal class AppointmentService
    {
        public static void CreateApointment(int customerId, int userId, string title, string description, string location, string contact, string type, string url, string start, string end)
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

        internal static int GetContactCustomerId(string contactComboBoxText)
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
    }
}
