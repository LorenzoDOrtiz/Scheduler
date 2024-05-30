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
            PopulateCustomerDataGridView();
        }

        private void PopulateCustomerDataGridView()
        {
            DGVCustomers.DataSource = CustomerRepository.GetCustomerDataTable();
            DGVCustomers.Columns["customerId"].Visible = false;
            DGVCustomers.Columns["customerName"].HeaderText = "Customer Name";
            DGVCustomers.Columns["address"].HeaderText = "Address";
            DGVCustomers.Columns["phone"].HeaderText = "Phone Number";
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
                    var customer = CustomerService.GetCustomer(selectedCustomerRowCustomerId);//
                    var address = AddressService.GetAddress(customer.AddressId); //
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

    }
}
