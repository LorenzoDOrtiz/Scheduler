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
        private CustomerModel customerModel;
        private AddressModel addressModel;
        private CityModel cityModel;
        private CountryModel countryModel;

        public CustomerModifyForm(CustomerModel customer, AddressModel address, CityModel city, CountryModel country)
        {
            customerModel = customer;
            addressModel = address;
            cityModel = city;
            countryModel = country;
            InitializeComponent();
            PopulateComboBoxes();
            PopulateModifyFormFields();
        }

        private void PopulateComboBoxes()
        {
            //var cityList = CityService.GetCityList();
            //CustomerModifyCityComboBox.DataSource = cityList;
            CustomerModifyCityComboBox.DisplayMember = "CityName";
            CustomerModifyCityComboBox.ValueMember = "CityId";

            //var countryList = CountryService.GetCountryList(countryId);
            //CustomerModifyCountryComboBox.DataSource = countryList;
            CustomerModifyCountryComboBox.DisplayMember = "Name";
            CustomerModifyCountryComboBox.ValueMember = "CountryId";
        }


        private void PopulateModifyFormFields()
        {
            CustomerModifyNameTextBox.Text = customerModel.CustomerName;
            CustomerModifyAddressTextBox.Text = addressModel.Address;
            CustomerModifyCityComboBox.SelectedValue = addressModel.CityId; // Bind to address.CityId
            CustomerModifyPostalCodeTextBox.Text = addressModel.PostalCode;
            CustomerModifyCountryComboBox.SelectedValue = cityModel.CountryId;
            CustomerModifyPhoneTextBox.Text = addressModel.Phone;
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
            var customerId = customerModel.CustomerId;
            var customerName = CustomerModifyNameTextBox.Text;
            var addressLine = CustomerModifyAddressTextBox.Text;
            var cityId = (int)CustomerModifyCityComboBox.SelectedValue;
            var postalCode = CustomerModifyPostalCodeTextBox.Text;
            var countryId = (int)CustomerModifyCountryComboBox.SelectedValue;
            var phoneNumber = CustomerModifyPhoneTextBox.Text;

            CustomerService.ModifyCustomer(customerId, customerName, addressLine, postalCode, phoneNumber, cityId, countryId);
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
