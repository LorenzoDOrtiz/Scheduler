using Scheduler.BusinessLogic;
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

            // Input validation: check if username or password fields are empty
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and password fields cannot be empty. Please enter your credentials.");
                return;
            }

            // Perform login validation
            if (LoginValidation.IsValidLogin(username, password))
            {
                try
                {


                    // Set the dialog result to OK to indicate successful login
                    DialogResult = DialogResult.OK;

                    // Proceed with other post-login actions
                    UserManager.CreateUser(username, password);
                    UserManager.SetCurrentUserId(username, password);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Login failed: " + ex.Message);
                }
            }
            else
            {
                // Failed login
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }
    }
}

