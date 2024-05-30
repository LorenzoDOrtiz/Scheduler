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
        }

        private void PopulateComboBoxes()
        {
            AppointmentAddContactComboxBox.DataSource = CustomerService.GetCustomerTable();
            AppointmentAddTypeComboxBox.DataSource = AppointmentService.GetAppointmentTypeTable();
        }
        private void AppointmentAddSaveButton_Click(object sender, EventArgs e)
        {
            var customerId = AppointmentService.GetContactCustomerId(AppointmentAddContactComboxBox.Text);
            var userId = UserManager.GetCurrentUser().UserId;
            var title = AppointmentAddTitleTextBox.Text;
            var description = AppointmentAddDescriptionTextBox.Text;
            var location = AppointmentAddLocationTextBox.Text;
            var contact = AppointmentAddContactComboxBox.Text;
            var type = AppointmentAddTypeComboxBox.Text;
            var url = AppointmentAddURLTextBox.Text;
            var startDate = AppointmentAddStartDatePicker.Value.ToUniversalTime();
            var startTime = AppointmentAddStartTimePicker.Value.ToUniversalTime();
            var start = TimeManager.GetStartTime(startDate, startTime);
            var endDate = AppointmentAddEndDatePicker.Value;
            var endTime = AppointmentAddEndTimePicker.Value;
            var end = TimeManager.GetEndTime(endDate, endTime);

            AppointmentService.CreateApointment(customerId, userId, title, description, location, contact, type, url, start, end);

            this.Close();
        }
    }
}
