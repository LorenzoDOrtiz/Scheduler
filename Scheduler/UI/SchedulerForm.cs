using Scheduler.BusinessLogic;
using Scheduler.DataAccess;
using SchedulerUI.UI;
using System;
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
    }
}
