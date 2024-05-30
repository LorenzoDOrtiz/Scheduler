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
            CustomerModifyCityComboxBox.DataSource = CityService.GetCityList();
            CustomerModifyCountryComboBox.DataSource = CountryService.GetCountryList();
        }
        private void PopulateModifyFormFields()
        {
            CustomerModifyNameTextBox.Text = customerModel.CustomerName;
            CustomerModifyAddressTextBox.Text = addressModel.Address;
            CustomerModifyCityComboxBox.Text = cityModel.CityName;
            CustomerModifyPostalCodeTextBox.Text = addressModel.PostalCode;
            CustomerModifyCountryComboBox.Text = countryModel.Name;
            CustomerModifyPhoneTextBox.Text = addressModel.Phone;
        }

        private void CustomerModifySaveButton_Click(object sender, System.EventArgs e)
        {
            var customerName = CustomerModifyNameTextBox.Text;
            var addressLine = CustomerModifyAddressTextBox.Text;
            var cityName = CustomerModifyCityComboxBox.Text;
            var postalCode = CustomerModifyPostalCodeTextBox.Text;
            var countryName = CustomerModifyCountryComboBox.Text;
            var phoneNumber = CustomerModifyPhoneTextBox.Text;

            CustomerService.ModifyCustomer(customerModel.CustomerId, customerName, addressLine, cityName, postalCode, countryName, phoneNumber);
        }
    }
}
