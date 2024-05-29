using Scheduler.BuisnessLogic;
using System;
using System.Windows.Forms;

namespace Scheduler.UI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private string username;
        private string password;

        private void loginButton_Click(object sender, EventArgs e)
        {
            username = usernameTextbox.Text;
            password = passwordTextbox.Text;

            // Perform login validation
            if (LoginValidation.IsValidLogin(username, password))
            {
                // Set the dialog result to OK to indicate successful login
                DialogResult = DialogResult.OK;
            }
            else
            {
                // Failed login
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }


    }
}
