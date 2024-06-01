using Scheduler.BusinessLogic;
using Scheduler.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Scheduler.UI
{
    public partial class CustomerModifyForm : Form
    {
        private readonly CustomerModel existingCustomerModel;
        private readonly AddressModel existingAddressModel;
        private readonly CityModel existingCityModel;
        private readonly CountryModel existingCountryModel;

        public CustomerModifyForm(CustomerModel customer, AddressModel address, CityModel city, CountryModel country)
        {
            existingCustomerModel = customer;
            existingAddressModel = address;
            existingCityModel = city;
            existingCountryModel = country;
            InitializeComponent();
            PopulateCountryComboBox();
            PopulateModifyFormFields();
        }

        private void CustomerModifyForm_Load(object sender, EventArgs e)
        {
            PopulateCityComboBox();
        }
        private void PopulateCountryComboBox()
        {
            var countryList = CountryService.GetCountryList();
            CustomerModifyCountryComboBox.DataSource = countryList;
            CustomerModifyCountryComboBox.DisplayMember = "Name";
            CustomerModifyCountryComboBox.ValueMember = "CountryId";
        }

        private void CustomerModifyCountryComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var countryId = (int)CustomerModifyCountryComboBox.SelectedValue;

            var cityList = CityService.GetCityList(countryId);
            CustomerModifyCityComboBox.DataSource = cityList;
            CustomerModifyCityComboBox.DisplayMember = "CityName";
            CustomerModifyCityComboBox.ValueMember = "CityId";
        }
        private void PopulateCityComboBox()
        {
            var countryId = (int)CustomerModifyCountryComboBox.SelectedValue;

            var cityList = CityService.GetCityList(countryId);
            CustomerModifyCityComboBox.DataSource = cityList;
            CustomerModifyCityComboBox.DisplayMember = "CityName";
            CustomerModifyCityComboBox.ValueMember = "CityId";

            // Select the appropriate city
            CustomerModifyCityComboBox.SelectedValue = existingAddressModel.CityId;
        }

        private void PopulateModifyFormFields()
        {
            CustomerModifyNameTextBox.Text = existingCustomerModel.CustomerName;
            CustomerModifyAddressTextBox.Text = existingAddressModel.Address;
            CustomerModifyCityComboBox.SelectedValue = existingAddressModel.CityId;
            CustomerModifyPostalCodeTextBox.Text = existingAddressModel.PostalCode;
            CustomerModifyCountryComboBox.SelectedValue = existingCityModel.CountryId;
            CustomerModifyPhoneTextBox.Text = existingAddressModel.Phone;
        }

        private bool ValidateFormInputs()
        {
            if (string.IsNullOrEmpty(CustomerModifyNameTextBox.Text) || CustomerModifyNameTextBox.Text.Any(Char.IsDigit))
            {
                MessageBox.Show(this, "Please enter a valid customer name.", "Invalid form field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!InputValidation.IsAddressValid(CustomerModifyAddressTextBox.Text))
            {
                MessageBox.Show(this, "Please enter a valid address.", "Invalid form field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!CustomerModifyPostalCodeTextBox.MaskFull)
            {
                MessageBox.Show(this, "Please enter a valid postal code.", "Invalid form field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!CustomerModifyPhoneTextBox.MaskFull)
            {
                MessageBox.Show(this, "Please enter a valid phone number.", "Invalid form field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (CustomerModifyCityComboBox.SelectedIndex == -1)
            {
                MessageBox.Show(this, "Please select a city.", "Invalid form field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (CustomerModifyCountryComboBox.SelectedIndex == -1)
            {
                MessageBox.Show(this, "Please select a country.", "Invalid form field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void CustomerModifySaveButton_Click(object sender, System.EventArgs e)
        {
            if (!ValidateFormInputs())
            {
                return;
            }

            var existingCustomerId = existingCustomerModel.CustomerId;
            var newCustomerName = CustomerModifyNameTextBox.Text;
            var newAddressLine = CustomerModifyAddressTextBox.Text;
            var newCityId = (int)CustomerModifyCityComboBox.SelectedValue;
            var newCityName = CustomerModifyCityComboBox.SelectedItem.ToString();
            var newPostalCode = CustomerModifyPostalCodeTextBox.Text;
            var newCountryId = (int)CustomerModifyCountryComboBox.SelectedValue;
            var newPhoneNumber = CustomerModifyPhoneTextBox.Text;

            CustomerService.ModifyCustomer(existingCustomerModel, existingAddressModel, newCustomerName, newAddressLine, newCityId, newCityName, newPostalCode, newCountryId, newPhoneNumber);
            this.Close();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void CustomerModifyNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (CustomerModifyNameTextBox.Text.Any(Char.IsDigit))
            {
                CustomerModifyNameTextBox.BackColor = Color.DarkRed;
            }
            else
            {
                CustomerModifyNameTextBox.BackColor = SystemColors.Window;
            }
        }

        private void CustomerModifyAddressTextBox_Leave(object sender, EventArgs e)
        {
            if (!InputValidation.IsAddressValid(CustomerModifyAddressTextBox.Text))
            {
                CustomerModifyAddressTextBox.BackColor = Color.DarkRed;
            }
            else
            {
                CustomerModifyAddressTextBox.BackColor = SystemColors.Window;
            }
        }

        private void CustomerModifyPostalCodeTextBox_Enter(object sender, EventArgs e)
        {
            MaskedTextBoxBehavior.ModifyMaskedTextBoxBehavior(this, sender);

        }

        private void CustomerModifyPhoneTextBox_Enter(object sender, EventArgs e)
        {
            MaskedTextBoxBehavior.ModifyMaskedTextBoxBehavior(this, sender);

        }
    }
}
