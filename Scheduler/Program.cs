using Scheduler.DataAccess;
using Scheduler.UI;
using System;
using System.Windows.Forms;

namespace Scheduler
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create the login form when the application is opened 
            LoginForm loginForm = new LoginForm();
            // Dialog result is set to OK there is a valid login, so we can check it before opening DB and SchedulerForm
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Open DB connection when login is successful 
                DBConnection.OpenConnection();
                // Start our SchedulerForm as the main thread only when the loginForm
                Application.Run(new SchedulerForm());
                // Close DB connection when SchedulerForm is closed 
                DBConnection.CloseConnection();
            }
        }
    }
}
