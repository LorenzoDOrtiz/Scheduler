using Scheduler.BusinessLogic;
using Scheduler.Models;
using System;
using System.Windows.Forms;

namespace Scheduler.UI
{
    public partial class AppointmentModifyForm : Form
    {
        AppointmentModel _appointmentModel;
        public AppointmentModifyForm(AppointmentModel appointmentModel)
        {
            _appointmentModel = appointmentModel;
            InitializeComponent();
            PopulateModifyFormFields();
            PopulateComboBoxes();
        }

        private void PopulateComboBoxes()
        {
            var contactList = CustomerService.GetContactList();
            AppointmentModifyContactComboxBox.DataSource = contactList;
            AppointmentModifyContactComboxBox.DisplayMember = "CustomerName";
            AppointmentModifyContactComboxBox.ValueMember = "CustomerId";

            // Set the selected value to the contact's CustomerId
            AppointmentModifyContactComboxBox.SelectedValue = _appointmentModel.CustomerId;
            AppointmentModifyTypeComboxBox.DataSource = AppointmentService.GetAppointmentTypeTable();
            AppointmentModifyTypeComboxBox.SelectedItem = _appointmentModel.Type;
        }

        private void PopulateModifyFormFields()
        {
            AppointmentModifyTitleTextBox.Text = _appointmentModel.Title;
            AppointmentModifyDescriptionTextBox.Text = _appointmentModel.Description;
            AppointmentModifyLocationTextBox.Text = _appointmentModel.Location;
            AppointmentModifyURLTextBox.Text = _appointmentModel.URL;
            // Convert start and end times to local time
            AppointmentModifyStartDatePicker.Value = _appointmentModel.Start.ToLocalTime();
            AppointmentModifyStartTimePicker.Value = _appointmentModel.Start.ToLocalTime();
            AppointmentModifyEndDatePicker.Value = _appointmentModel.End.ToLocalTime();
            AppointmentModifyEndTimePicker.Value = _appointmentModel.End.ToLocalTime();
        }


        private bool ValidateFormInputs()
        {
            if (string.IsNullOrEmpty(AppointmentModifyTitleTextBox.Text))
            {
                MessageBox.Show(this, "Please enter a valid title.", "Invalid form field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (AppointmentModifyContactComboxBox.SelectedIndex == -1)
            {
                MessageBox.Show(this, "Please select a contact.", "Invalid form field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (AppointmentModifyTypeComboxBox.SelectedIndex == -1)
            {
                MessageBox.Show(this, "Please select an appointment type.", "Invalid form field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!TimeManager.ValidAppointmentDateTime(AppointmentModifyStartDatePicker, AppointmentModifyStartTimePicker, AppointmentModifyEndDatePicker, AppointmentModifyEndTimePicker, _appointmentModel.AppointmentId))
            {
                return false;
            }
            return true;
        }

        private void AppointmentModifySaveButton_Click(object sender, EventArgs e)
        {
            if (!ValidateFormInputs())
            {
                return;
            }

            _appointmentModel.Title = AppointmentModifyTitleTextBox.Text;
            _appointmentModel.Description = AppointmentModifyDescriptionTextBox.Text;
            _appointmentModel.Location = AppointmentModifyLocationTextBox.Text;


            // Get the selected contact's CustomerModel
            if (AppointmentModifyContactComboxBox.SelectedItem is CustomerModel selectedCustomer)
            {
                _appointmentModel.CustomerId = selectedCustomer.CustomerId;
            }
            else
            {
                MessageBox.Show(this, "Please select a valid contact.", "Invalid form field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _appointmentModel.Type = AppointmentModifyTypeComboxBox.Text;
            _appointmentModel.URL = AppointmentModifyURLTextBox.Text;
            _appointmentModel.Start = AppointmentModifyStartDatePicker.Value.Date + AppointmentModifyStartTimePicker.Value.TimeOfDay;
            _appointmentModel.End = AppointmentModifyEndDatePicker.Value.Date + AppointmentModifyEndTimePicker.Value.TimeOfDay;

            // Modify the appointment
            AppointmentService.ModifyAppointment(_appointmentModel, selectedCustomer.CustomerName); // Use selected contact's name
            this.Close();
        }




        private void AppointmentModifyCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AppointmentModifyAddCustomerButton_Click(object sender, EventArgs e)
        {
            var customerAddForm = new CustomerAddForm();
            customerAddForm.ShowDialog(this);
        }

        private void AppointmentModifyForm_Activated(object sender, EventArgs e)
        {
            PopulateComboBoxes();
        }
    }
}
