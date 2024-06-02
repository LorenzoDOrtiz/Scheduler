using Scheduler.BusinessLogic;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Scheduler.UI
{
    public partial class ReportForm : Form
    {
        private ReportGenerator reportGenerator;

        public ReportForm()
        {
            InitializeComponent();
            UserComboBox.Visible = false;
            ReportSelectionComboBox.SelectedIndex = -1;

            ReportSelectionComboBox.DataSource = new List<string> { "Appointment types by month", "User Schedule", "Customers by city", "Customers by country" };

            var appointments = AppointmentService.GetAppointmentListForReports();
            var users = UserService.GetUserListForReports();

            reportGenerator = new ReportGenerator(appointments, users);
        }

        private void ReportSelectionComboBox_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            if (ReportSelectionComboBox.SelectedItem.ToString() == "Appointment types by month")
            {

                DGVReport.DataSource = reportGenerator.GetAppointmentTypesByMonth();
            }

        }
    }
}
