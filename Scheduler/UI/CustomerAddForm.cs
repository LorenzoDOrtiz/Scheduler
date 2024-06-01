using Scheduler.BusinessLogic;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Scheduler.UI
{
    public partial class CustomerAddForm : Form
    {
        public CustomerAddForm()
        {
            InitializeComponent();
            PopulateCountryComboBox();
            ClearComboBoxSelection();
        }

        private void PopulateCountryComboBox()
        {
            var countryList = CountryService.GetCountryList();
            CustomerAddCountryComboBox.DataSource = countryList;
            CustomerAddCountryComboBox.DisplayMember = "Name";
            CustomerAddCountryComboBox.ValueMember = "CountryId";
        }

        private void CustomerAddCountryComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var countryId = (int)CustomerAddCountryComboBox.SelectedValue;

            CustomerAddCityComboBox.DataSource = CityService.GetCityList(countryId);
            CustomerAddCityComboBox.DisplayMember = "CityName"; // Display city names
            CustomerAddCityComboBox.ValueMember = "CityId"; // Use city IDs as values
        }
        private void CustomerAddCityComboBox_DropDown(object sender, EventArgs e)
        {

        }


        private void ClearComboBoxSelection()
        {
            CustomerAddCityComboBox.SelectedIndex = -1;
            CustomerAddCountryComboBox.SelectedIndex = -1;
        }

        private bool ValidateFormInputs()
        {
            if (string.IsNullOrEmpty(CustomerAddNameTextBox.Text) || CustomerAddNameTextBox.Text.Any(Char.IsDigit))
            {
                MessageBox.Show(this, "Please enter a valid customer name.", "Invalid form field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!InputValidation.IsAddressValid(CustomerAddAddressTextBox.Text))
            {
                MessageBox.Show(this, "Please enter a valid address.", "Invalid form field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!CustomerAddPostalCodeTextBox.MaskFull)
            {
                MessageBox.Show(this, "Please enter a valid postal code.", "Invalid form field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!CustomerAddPhoneTextBox.MaskFull)
            {
                MessageBox.Show(this, "Please enter a valid phone number.", "Invalid form field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (CustomerAddCityComboBox.SelectedIndex == -1)
            {
                MessageBox.Show(this, "Please select a city.", "Invalid form field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (CustomerAddCountryComboBox.SelectedIndex == -1)
            {
                MessageBox.Show(this, "Please select a country.", "Invalid form field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void CustomerAddSaveButton_Click(object sender, EventArgs e)
        {
            if (!ValidateFormInputs())
            {
                return; // Stop execution if validation fails
            }

            var customerName = CustomerAddNameTextBox.Text.Trim();
            var address = CustomerAddAddressTextBox.Text.Trim();
            var cityId = (int)CustomerAddCityComboBox.SelectedValue;
            var postalCode = CustomerAddPostalCodeTextBox.Text.Trim();
            var countryId = (int)CustomerAddCountryComboBox.SelectedValue;
            var phone = CustomerAddPhoneTextBox.Text.Trim();

            CustomerService.CreateCustomer(customerName, address, cityId, postalCode, countryId, phone);

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CustomerAddNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (CustomerAddNameTextBox.Text.Any(Char.IsDigit))
            {
                CustomerAddNameTextBox.BackColor = Color.DarkRed;
            }
            else
            {
                CustomerAddNameTextBox.BackColor = SystemColors.Window;
            }
        }

        private void CustomerAddAddressTextBox_Leave(object sender, EventArgs e)
        {
            if (!InputValidation.IsAddressValid(CustomerAddAddressTextBox.Text))
            {
                CustomerAddAddressTextBox.BackColor = Color.DarkRed;
            }
            else
            {
                CustomerAddAddressTextBox.BackColor = SystemColors.Window;
            }
        }

        private void CustomerAddPostalCodeTextBox_Enter(object sender, EventArgs e)
        {
            MaskedTextBoxBehavior.ModifyMaskedTextBoxBehavior(this, sender);
        }

        private void CustomerAddPhoneTextBox_Enter(object sender, EventArgs e)
        {
            MaskedTextBoxBehavior.ModifyMaskedTextBoxBehavior(this, sender);
        }


    }
}
