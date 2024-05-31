using Scheduler.BusinessLogic;
using Scheduler.Models;
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
            var cityList = CityService.GetCityList();
            CustomerModifyCityComboBox.DataSource = cityList;
            CustomerModifyCityComboBox.DisplayMember = "CityName";
            CustomerModifyCityComboBox.ValueMember = "CityId";

            var countryList = CountryService.GetCountryList();
            CustomerModifyCountryComboBox.DataSource = countryList;
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
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
