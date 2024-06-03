using Scheduler.BusinessLogic;
using Scheduler.Localization;
using Scheduler.Logging;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Scheduler.UI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            InitializeLocalization();
        }

        private void InitializeLocalization()
        {
            var twoLetterISO = LocalizationManager.GetUserTwoLetterISOLanguageName();
            LocalizationManager.SetCulture(twoLetterISO);
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
                MessageBox.Show(this, LocalizationManager.GetString("EmptyUsernameOrPasswordPrompt"), "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Perform login validation
            if (LoginValidation.IsValidLogin(username, password))
            {
                // Set the dialog result to OK to indicate successful login
                DialogResult = DialogResult.OK;

                UserManager.CreateUser(username, password);
                UserManager.SetCurrentUserId(username, password);
                LoginLogging.LogUserLogin($"Successful login with the username: {UserManager.GetCurrentUser().UserName}");
            }
            else
            {
                // Failed login
                MessageBox.Show(this, LocalizationManager.GetString("InvalidLoginPrompt"), "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoginLogging.LogUserLogin($"Failed login with the username: {username}");

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://www.linkedin.com/in/lorenzodortiz/";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(LocalizationManager.GetString("UnableToOpenLink", ex.Message));
            }
        }
    }
}

