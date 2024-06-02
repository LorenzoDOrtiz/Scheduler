using Scheduler.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace Scheduler.UI
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();

            // Load users into ComboBox
            UserComboBox.Visible = false;
            UserComboBox.DataSource = UserService.GetUserListForReportsComboBox();
            UserComboBox.DisplayMember = "UserName";
            UserComboBox.ValueMember = "UserId";
            UserComboBox.SelectedIndex = -1;

            // Populate report selection ComboBox
            ReportSelectionComboBox.DataSource = new List<string> { "Appointment types by month", "User Schedule", "Customers by city", "Customers by country" };
            ReportSelectionComboBox.SelectedIndex = -1;

        }

        private void ReportSelectionComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (ReportSelectionComboBox.SelectedItem.ToString())
            {
                case "Appointment types by month":
                    UserComboBox.Visible = false;
                    UserComboBox.SelectedIndex = -1;
                    DGVReport.DataSource = ReportGenerator.GetAppointmentTypesByMonth();
                    break;
                case "User Schedule":
                    UserComboBox.Visible = true;
                    DGVReport.DataSource = null;

                    break;

                // Handle other report types here
                default:
                    break;
            }
        }

        private void UserComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var userId = Convert.ToInt32(UserComboBox.SelectedValue);
            DGVReport.DataSource = ReportGenerator.GetUserSchedule(userId);

            DGVReport.Columns["UserName"].HeaderText = "User Name";
        }

        private void DGVReport_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if the column being formatted is a month column
            if (e.ColumnIndex == DGVReport.Columns["Month"].Index)
            {
                // Convert the numeric month value to its respective name
                if (e.Value != null && int.TryParse(e.Value.ToString(), out int monthValue))
                {
                    e.Value = DateTimeFormatInfo.CurrentInfo.GetMonthName(monthValue);
                    e.FormattingApplied = true; // Indicate that the formatting has been applied
                }
            }
        }
    }
}
