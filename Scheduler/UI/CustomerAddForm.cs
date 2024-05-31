using Scheduler.BusinessLogic;
using System.Windows.Forms;

namespace Scheduler.UI
{
    public partial class CustomerAddForm : Form
    {
        public CustomerAddForm()
        {
            InitializeComponent();
            PopulateComboBoxes();
            ClearComboBoxSelection();
        }

        private void PopulateComboBoxes()
        {
            // Populate City combo box
            CustomerAddCityComboBox.DataSource = CityService.GetCityList();
            CustomerAddCityComboBox.DisplayMember = "CityName";
            CustomerAddCityComboBox.ValueMember = "CityId";

            // Populate Country combo box
            CustomerAddCountryComboBox.DataSource = CountryService.GetCountryList();
            CustomerAddCountryComboBox.DisplayMember = "Name";
            CustomerAddCountryComboBox.ValueMember = "CountryId";
        }

        private void ClearComboBoxSelection()
        {
            // Clear City and Country combo box selection
            CustomerAddCityComboBox.SelectedIndex = -1;
            CustomerAddCountryComboBox.SelectedIndex = -1;
        }

        private void CustomerAddSaveButton_Click(object sender, System.EventArgs e)
        {
            // Retrieve input values from the form
            var customerName = CustomerAddNameTextBox.Text;
            var address = CustomerAddAddressTextBox.Text;
            var cityId = (int)CustomerAddCityComboBox.SelectedValue;
            var postalCode = CustomerAddPostalCodeTextBox.Text;
            var countryId = (int)CustomerAddCountryComboBox.SelectedValue;
            var phone = CustomerAddPhoneTextBox.Text;

            // Call the CustomerService method to create a new customer
            CustomerService.CreateCustomer(customerName, address, cityId, postalCode, countryId, phone);

            // Optionally, you can close the form after saving
            this.Close();
        }
    }
}
