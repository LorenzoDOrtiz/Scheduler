using Scheduler.BusinessLogic;
using System.Windows.Forms;

namespace Scheduler.UI
{
    public partial class CustomerAddForm : Form
    {
        public CustomerAddForm()
        {
            InitializeComponent();
        }

        private void CustomerAddSaveButton_Click(object sender, System.EventArgs e)
        {
            var customerName = CustomerAddNameTextBox.Text;
            var address1 = CustomerAddAddressTextBox.Text;
            var cityName = CustomerAddCityComboxBox.Text;
            var postalCode = CustomerAddPostalCodeTextBox.Text;
            var countryName = CustomerAddCountryComboBox.Text;
            var phone = CustomerAddPhoneTextBox.Text;

            CustomerService.CreateCustomer(customerName, address1, cityName, postalCode, countryName, phone);
        }
    }
}
