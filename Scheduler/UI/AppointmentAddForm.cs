using Scheduler.BusinessLogic;
using System;
using System.Windows.Forms;

namespace SchedulerUI.UI
{
    public partial class AppointmentAddForm : Form
    {
        public AppointmentAddForm()
        {
            InitializeComponent();
            PopulateComboBoxes();
            ClearComboBoxSelection();
        }

        private void PopulateComboBoxes()
        {
            AppointmentAddContactComboxBox.DataSource = CustomerService.GetCustomerTable();
            AppointmentAddTypeComboxBox.DataSource = AppointmentService.GetAppointmentTypeTable();
        }
        private void ClearComboBoxSelection()
        {
            AppointmentAddContactComboxBox.SelectedIndex = -1;
            AppointmentAddTypeComboxBox.SelectedIndex = -1;
        }

        private bool ValidateFormInputs()
        {
            if (string.IsNullOrEmpty(AppointmentAddTitleTextBox.Text))
            {
                MessageBox.Show(this, "Please enter a valid title.", "Invalid form field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (AppointmentAddContactComboxBox.SelectedIndex == -1)
            {
                MessageBox.Show(this, "Please select a contact.", "Invalid form field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (AppointmentAddTypeComboxBox.SelectedIndex == -1 && string.IsNullOrEmpty(AppointmentAddTypeComboxBox.Text))
            {
                MessageBox.Show(this, "Please select or enter an appointment type.", "Invalid form field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!TimeManager.ValidAppointmentDateTime(AppointmentAddStartDatePicker, AppointmentAddStartTimePicker, AppointmentAddEndDatePicker, AppointmentAddEndTimePicker))
            {
                return false;
            }
            return true;
        }


        private void AppointmentAddSaveButton_Click(object sender, EventArgs e)
        {
            if (!ValidateFormInputs())
            {
                return;
            }

            var customerId = AppointmentService.GetContactCustomerId(AppointmentAddContactComboxBox.Text);
            var userId = UserManager.GetCurrentUser().UserId;
            var title = AppointmentAddTitleTextBox.Text;
            var description = AppointmentAddDescriptionTextBox.Text;
            var location = AppointmentAddLocationTextBox.Text;
            var contact = AppointmentAddContactComboxBox.Text;
            var type = AppointmentAddTypeComboxBox.Text;
            var url = AppointmentAddURLTextBox.Text;
            var startDate = AppointmentAddStartDatePicker.Value;
            var startTime = AppointmentAddStartTimePicker.Value;
            var endDate = AppointmentAddEndDatePicker.Value;
            var endTime = AppointmentAddEndTimePicker.Value;

            DateTime start = new DateTime(startDate.Year, startDate.Month, startDate.Day, startTime.Hour, startTime.Minute, startTime.Second, DateTimeKind.Local);
            DateTime end = new DateTime(endDate.Year, endDate.Month, endDate.Day, endTime.Hour, endTime.Minute, endTime.Second, DateTimeKind.Local);

            DateTime startUtc = start.ToUniversalTime();
            DateTime endUtc = end.ToUniversalTime();

            AppointmentService.CreateAppointment(customerId, userId, title, description, location, contact, type, url, startUtc, endUtc);
            this.Close();
        }

        private void AppointmentAddCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
