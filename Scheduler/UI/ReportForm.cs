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
            ReportSelectionComboBox.DataSource = new List<string> { "Appointment types by month", "User Schedule", "Customers by country" };
            ReportSelectionComboBox.SelectedIndex = -1;
        }

        private void RefreshReport()
        {
            switch (ReportSelectionComboBox.SelectedItem.ToString())
            {
                case "Appointment types by month":
                    UserComboBox.Visible = false;
                    DGVReport.DataSource = ReportGenerator.GetAppointmentTypesByMonth();
                    DGVReport.Columns["Count"].HeaderText = "Appointment Count";
                    break;
                case "User Schedule":
                    UserComboBox.SelectedIndex = -1;
                    UserComboBox.Visible = true;
                    DGVReport.DataSource = null;
                    break;
                case "Customers by country":
                    UserComboBox.Visible = false;
                    DGVReport.DataSource = ReportGenerator.GetCustomerCountByCountry();
                    DGVReport.Columns["Count"].HeaderText = "Customer Count";
                    break;
            }
        }

        private void ReportSelectionComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            RefreshReport();
        }

        private void UserComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var userId = Convert.ToInt32(UserComboBox.SelectedValue);
            DGVReport.DataSource = ReportGenerator.GetUserSchedule(userId);
            DGVReport.Columns["UserName"].HeaderText = "User Name";
        }

        private void DGVReport_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Only do the cell formatting when Appointment types by month is selected
            if (ReportSelectionComboBox.SelectedItem.ToString() == "Appointment types by month")
            {
                // Check if the column being formatted is the "Month" column and if it exists (doesn't exist until after datasource is set)
                var monthColumn = DGVReport.Columns["Month"];
                if (monthColumn != null && e.ColumnIndex == monthColumn.Index)
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

        private void ReportRefreshButton_Click(object sender, EventArgs e)
        {
            int? selectedUserId = null;

            // Store the selected user ID if the "User Schedule" report is currently selected
            if (ReportSelectionComboBox.SelectedItem.ToString() == "User Schedule" && UserComboBox.SelectedIndex != -1)
            {
                selectedUserId = Convert.ToInt32(UserComboBox.SelectedValue);
            }

            if (ReportSelectionComboBox.SelectedIndex != -1)
            {
                RefreshReport();
            }

            // Re-select the user if the "User Schedule" report is currently selected
            if (selectedUserId.HasValue && ReportSelectionComboBox.SelectedItem.ToString() == "User Schedule")
            {
                UserComboBox.SelectedValue = selectedUserId.Value;
                DGVReport.DataSource = ReportGenerator.GetUserSchedule(selectedUserId.Value);
                DGVReport.Columns["UserName"].HeaderText = "User Name";
            }
        }

        private void DGVReport_DataSourceChanged(object sender, EventArgs e)
        {
            DGVReport.ClearSelection();
        }
    }
}
