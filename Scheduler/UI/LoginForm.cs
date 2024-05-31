using Scheduler.BusinessLogic;
using Scheduler.Localization;
using System;
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

                // Proceed with other post-login actions
                UserManager.CreateUser(username, password);
                UserManager.SetCurrentUserId(username, password);
            }
            else
            {
                // Failed login
                MessageBox.Show(this, LocalizationManager.GetString("InvalidLoginPrompt"), "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

