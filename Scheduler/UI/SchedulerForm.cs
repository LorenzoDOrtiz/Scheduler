using SchedulerUI.UI;
using System.Windows.Forms;

namespace Scheduler.UI
{
    public partial class SchedulerForm : Form
    {
        public SchedulerForm()
        {
            InitializeComponent();
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
    }
}
