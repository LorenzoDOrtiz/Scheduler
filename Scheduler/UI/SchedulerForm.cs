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

        }

        private void CustomerAddButton_Click(object sender, System.EventArgs e)
        {
            var CustomerAddForm = new CustomerAddForm();
            CustomerAddForm.Show();
        }
    }
}
