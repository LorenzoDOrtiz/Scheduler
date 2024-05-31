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
            DGVAppointments.Columns["start"].HeaderText = "Start";
            DGVAppointments.Columns["end"].HeaderText = "End";
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
                try
                {
                    var selectedCustomerRowCustomerId = Convert.ToInt32(selectedCustomerRow.Cells["customerId"].Value);
                    var customer = CustomerService.GetCustomer(selectedCustomerRowCustomerId);
                    var address = AddressService.GetAddress(customer.AddressId);
                    var city = CityService.GetCity(address.CityId);
                    var country = CountryService.GetCountry(city.CountryId);

                    var customerModifyForm = new CustomerModifyForm(customer, address, city, country);
                    customerModifyForm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while fetching customer details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                try
                {
                    var selectedAppointmentRowId = Convert.ToInt32(selectedAppointmentRow.Cells["appointmentId"].Value);
                    var appointment = AppointmentService.GetAppointment(selectedAppointmentRowId);

                    var appointmentModifyForm = new AppointmentModifyForm(appointment);
                    appointmentModifyForm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while fetching appointment details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No row is selected. Please select a row first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
    }
}
