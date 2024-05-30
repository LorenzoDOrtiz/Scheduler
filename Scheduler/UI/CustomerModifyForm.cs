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
            PopulateModifyFormFields();
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
    }
}
