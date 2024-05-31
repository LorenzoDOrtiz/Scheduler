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
            DateTime startTime = AppointmentAddStartTimePicker.Value.ToUniversalTime();
            DateTime start = DateTime.Parse(TimeManager.GetStartTime(startDate, startTime));
            DateTime endDate = AppointmentAddEndDatePicker.Value;
            DateTime endTime = AppointmentAddEndTimePicker.Value;
            var end = DateTime.Parse(TimeManager.GetEndTime(endDate, endTime));

            AppointmentService.CreateApointment(customerId, userId, title, description, location, contact, type, url, start, end);

            this.Close();
        }

        private void AppointmentAddCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
