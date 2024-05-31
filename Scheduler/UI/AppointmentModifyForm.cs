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
            AppointmentModifyStartDatePicker.Value = _appointmentModel.Start.Date;
            AppointmentModifyStartTimePicker.Value = _appointmentModel.Start;
            AppointmentModifyEndDatePicker.Value = _appointmentModel.End.Date;
            AppointmentModifyEndTimePicker.Value = _appointmentModel.End;
        }

        private void AppointmentModifySaveButton_Click(object sender, EventArgs e)
        {
            _appointmentModel.Title = AppointmentModifyTitleTextBox.Text;
            _appointmentModel.Description = AppointmentModifyDescriptionTextBox.Text;
            _appointmentModel.Location = AppointmentModifyLocationTextBox.Text;
            _appointmentModel.Contact = AppointmentModifyContactComboxBox.Text;
            _appointmentModel.CustomerId = (int)AppointmentModifyContactComboxBox.SelectedValue;
            _appointmentModel.Type = AppointmentModifyTypeComboxBox.Text;
            _appointmentModel.URL = AppointmentModifyURLTextBox.Text;
            _appointmentModel.Start = AppointmentModifyStartDatePicker.Value.Date + AppointmentModifyStartTimePicker.Value.TimeOfDay;
            _appointmentModel.End = AppointmentModifyEndDatePicker.Value.Date + AppointmentModifyEndTimePicker.Value.TimeOfDay;

            // Modify the appointment
            AppointmentService.ModifyAppointment(_appointmentModel);
        }


        private void AppointmentModifyCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
