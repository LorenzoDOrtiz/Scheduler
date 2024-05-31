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
        }

        private void PopulateModifyFormFields()
        {
            AppointmentModifyTitleTextBox.Text = _appointmentModel.Title;
            AppointmentModifyDescriptionTextBox.Text = _appointmentModel.Description;
            AppointmentModifyLocationTextBox.Text = _appointmentModel.Location;
            AppointmentModifyContactComboxBox.DataSource = CustomerService.GetCustomerTable();
            AppointmentModifyContactComboxBox.SelectedItem = _appointmentModel.Contact;
            AppointmentModifyTypeComboxBox.DataSource = AppointmentService.GetAppointmentTypeTable();
            AppointmentModifyTypeComboxBox.SelectedItem = _appointmentModel.Type;
            AppointmentModifyURLTextBox.Text = _appointmentModel.URL;
            AppointmentModifyStartDatePicker.Value = _appointmentModel.Start.Date;
            AppointmentModifyStartTimePicker.Value = _appointmentModel.Start;
            AppointmentModifyEndDatePicker.Value = _appointmentModel.End.Date;
            AppointmentModifyEndTimePicker.Value = _appointmentModel.End;
        }

        private void AppointmentModifySaveButton_Click(object sender, EventArgs e)
        {

        }

        private void AppointmentModifyCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
