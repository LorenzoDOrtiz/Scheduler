using Scheduler.BusinessLogic;
using Scheduler.DataAccess;
using SchedulerUI.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Scheduler.UI
{
    public partial class SchedulerForm : Form
    {
        public SchedulerForm()
        {
            InitializeComponent();
            PopulateAllAppointmentsDataGridView();
            PopulateCustomerDataGridView();
            PopulateDayAppointmentsDataGridView();
            MonthCalendar_DateSelected(null, null);

        }
        private void SchedulerForm_Shown(object sender, EventArgs e)
        {
            AppointmentService.AppointmentAlert();
        }

        private void PopulateCustomerDataGridView()
        {
            DGVCustomers.DataSource = CustomerRepository.GetCustomerDataTable();
            DGVCustomers.Columns["customerId"].Visible = false;
            DGVCustomers.Columns["customerName"].HeaderText = "Customer Name";
            DGVCustomers.Columns["address"].HeaderText = "Address";
            DGVCustomers.Columns["city"].HeaderText = "City";
            DGVCustomers.Columns["postalCode"].HeaderText = "Postal Code";
            DGVCustomers.Columns["country"].HeaderText = "Country";
            DGVCustomers.Columns["phone"].HeaderText = "Phone Number";
        }

        private void PopulateAllAppointmentsDataGridView()
        {
            DGVAppointments.DataSource = AppointmentRepository.GetAppointmentDataTable();
            DGVAppointments.Columns["appointmentId"].Visible = false;
            DGVAppointments.Columns["title"].HeaderText = "Title";
            DGVAppointments.Columns["location"].HeaderText = "Location";
            DGVAppointments.Columns["contact"].HeaderText = "Contact";
            DGVAppointments.Columns["type"].HeaderText = "Type";
            DGVAppointments.Columns["start"].HeaderText = "Start";
            DGVAppointments.Columns["end"].HeaderText = "End";
        }

        private void PopulateDayAppointmentsDataGridView()
        {
            DGVAppointments.Columns["title"].HeaderText = "Title";
            DGVAppointments.Columns["contact"].HeaderText = "Contact";
            DGVAppointments.Columns["type"].HeaderText = "Type";
            DGVAppointments.Columns["start"].HeaderText = "Start";
            DGVAppointments.Columns["end"].HeaderText = "End";
        }

        private bool ConfirmCustomerDelete()
        {
            string message = $"Are you sure you want to delete this customer? This will Delete all associated appointments.";
            DialogResult result = MessageBox.Show(message, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return result == DialogResult.Yes;
        }

        private bool ConfirmAppointmentDelete()
        {
            string message = $"Are you sure you want to delete this appointments?";
            DialogResult result = MessageBox.Show(message, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return result == DialogResult.Yes;
        }

        private void AppointmentAddButton_Click(object sender, System.EventArgs e)
        {
            var appointmentAddForm = new AppointmentAddForm();
            appointmentAddForm.Show();
        }

        private void CustomerAddButton_Click(object sender, System.EventArgs e)
        {
            var customerAddForm = new CustomerAddForm();
            customerAddForm.Show();
        }

        private void CustomerModifyButton_Click(object sender, System.EventArgs e)
        {
            var selectedCustomerRow = DGVCustomers.CurrentRow;

            if (selectedCustomerRow != null)
            {
                var selectedCustomerRowCustomerId = Convert.ToInt32(selectedCustomerRow.Cells["customerId"].Value);
                var customer = CustomerService.GetCustomer(selectedCustomerRowCustomerId);
                var address = AddressService.GetAddress(customer.AddressId);
                var city = CityService.GetCity(address.CityId);
                var country = CountryService.GetCountry(city.CountryId);

                var customerModifyForm = new CustomerModifyForm(customer, address, city, country);
                customerModifyForm.Show();
            }
            else
            {
                MessageBox.Show("No row is selected. Please select a row first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AppointmentModifyButton_Click(object sender, EventArgs e)
        {
            var selectedAppointmentRow = DGVAppointments.CurrentRow;

            if (selectedAppointmentRow != null)
            {
                var selectedAppointmentRowId = Convert.ToInt32(selectedAppointmentRow.Cells["appointmentId"].Value);
                var appointment = AppointmentService.GetAppointment(selectedAppointmentRowId);

                var appointmentModifyForm = new AppointmentModifyForm(appointment);
                appointmentModifyForm.Show();
            }
            else
            {
                MessageBox.Show("No row is selected. Please select a row first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AppointmentDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedAppointmentRow = DGVAppointments.CurrentRow;

                if (selectedAppointmentRow != null)
                {
                    var selectedAppointmentId = Convert.ToInt32(selectedAppointmentRow.Cells["appointmentId"].Value);
                    if (ConfirmAppointmentDelete())
                    {
                        AppointmentRepository.DeleteAppointment(selectedAppointmentId);
                        DGVAppointments.DataSource = AppointmentRepository.GetAppointmentDataTable();
                    }
                }
                else
                {
                    MessageBox.Show("No row is selected. Please select a row first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (DataAccessException ex)
            {
                MessageBox.Show("Deleting appointment failed: " + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomerDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedCustomerRow = DGVCustomers.CurrentRow;

                if (selectedCustomerRow != null)
                {
                    var selectedcustomerId = Convert.ToInt32(selectedCustomerRow.Cells["customerId"].Value);
                    if (ConfirmCustomerDelete())
                    {
                        CustomerRepository.DeleteCustomer(selectedcustomerId);
                        DGVCustomers.DataSource = CustomerRepository.GetCustomerDataTable();
                        DGVAppointments.DataSource = AppointmentRepository.GetAppointmentDataTable();
                    }
                }
                else
                {
                    MessageBox.Show("No row is selected. Please select a row first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (DataAccessException ex)
            {
                MessageBox.Show("Deleting customer failed: " + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Refresh the data grid views any time the form is entered
        private void SchedulerForm_Activated(object sender, EventArgs e)
        {
            DGVAppointments.DataSource = AppointmentRepository.GetAppointmentDataTable();
            DGVCustomers.DataSource = CustomerRepository.GetCustomerDataTable();
        }

        private void MonthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            // Get the selected date from the MonthCalendar
            var selectedDate = MonthCalendar.SelectionStart;

            // Format the selected date to a string in the desired format
            var selectedDateString = selectedDate.ToString("yyyy-MM-dd");

            // Construct the SQL query to get appointments for the selected date
            var query = "SELECT title, contact, type, start, end FROM appointment WHERE DATE(start) = @SelectedDate";

            // Use a dictionary to pass the parameter to the query for safety
            var parameters = new Dictionary<string, object>
            {
                { "@SelectedDate", selectedDate }
            };

            // Get the data table from the query and bind it to the DataGridView
            var dataTableUtcTimes = MySQLCRUD.GetDataTable(query, parameters);

            var dataTableLocalTimes = TimeManager.ConvertDataTableWithUtcTimesToLocalTime(dataTableUtcTimes);

            DGVCalendarAndRadio.DataSource = dataTableLocalTimes;

            // Uncheck the WeeklyRadioButton and MonthRadioButton
            WeeklyRadioButton.Checked = false;
            MonthRadioButton.Checked = false;
        }


        private void WeeklyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (WeeklyRadioButton.Checked)
            {
                var startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
                var endOfWeek = startOfWeek.AddDays(6);

                var query = "SELECT title, contact, type, start, end FROM appointment " +
                            "WHERE DATE(start) BETWEEN @StartOfWeek AND @EndOfWeek";

                var parameters = new Dictionary<string, object>
                {
                    { "@StartOfWeek", startOfWeek },
                    { "@EndOfWeek", endOfWeek }
                };

                var dataTableUtcTimes = MySQLCRUD.GetDataTable(query, parameters);

                var dataTableLocalTimes = TimeManager.ConvertDataTableWithUtcTimesToLocalTime(dataTableUtcTimes);


                DGVCalendarAndRadio.DataSource = dataTableLocalTimes;
            }
        }


        private void MonthRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (MonthRadioButton.Checked)
            {
                // Get the current month and year
                var currentMonth = DateTime.Today.Month;
                var currentYear = DateTime.Today.Year;

                // Get the first and last days of the current month
                var firstDayOfMonth = new DateTime(currentYear, currentMonth, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                // Format the dates as strings in the required format
                var formattedFirstDayOfMonth = firstDayOfMonth.ToString("yyyy-MM-dd");
                var formattedLastDayOfMonth = lastDayOfMonth.ToString("yyyy-MM-dd");

                // Construct the SQL query string
                var query = "SELECT title, contact, type, start, end FROM appointment " +
                            "WHERE DATE(start) BETWEEN @FirstDayOfMonth AND @LastDayOfMonth";

                // Use parameters to pass the dates
                var parameters = new Dictionary<string, object>
                {
                    { "@FirstDayOfMonth", firstDayOfMonth },
                    { "@LastDayOfMonth", lastDayOfMonth }
                };

                // Get the data table from the query and bind it to the DataGridView
                var dataTableUtcTimes = MySQLCRUD.GetDataTable(query, parameters);

                var dataTableLocalTimes = TimeManager.ConvertDataTableWithUtcTimesToLocalTime(dataTableUtcTimes);

                DGVCalendarAndRadio.DataSource = dataTableLocalTimes;
            }
        }

        private void generateReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var reportForm = new ReportForm();
            reportForm.Show();
        }

        private void DGVAppointments_DataSourceChanged(object sender, EventArgs e)
        {
            DGVAppointments.ClearSelection();
        }

        private void DGVCalendarAndRadio_DataSourceChanged(object sender, EventArgs e)
        {
            DGVCalendarAndRadio.ClearSelection();
        }

        private void DGVCustomers_DataSourceChanged(object sender, EventArgs e)
        {
            DGVCustomers.ClearSelection();
        }
    }
}
