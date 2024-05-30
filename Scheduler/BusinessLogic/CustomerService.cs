using MySql.Data.MySqlClient;
using Scheduler.DataAccess;
using Scheduler.Models;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Scheduler.BusinessLogic
{
    internal class CustomerService
    {
        public static void CreateCustomer(string customerName, string address1, string cityName, string postalCode, string countryName, string phone)
        {
            // Open the static connection if it's not already open
            if (DBConnection.Conn.State == System.Data.ConnectionState.Closed)
            {
                DBConnection.OpenConnection();
            }

            // Begin the transaction
            using (var transaction = DBConnection.Conn.BeginTransaction())
            {
                try
                {
                    // Insert Country
                    CountryModel country = new CountryModel
                    {
                        Name = countryName

                    };
                    int countryId = DataService.InsertCountry(country, transaction);
                    country.CountryId = countryId;

                    // Insert City
                    CityModel city = new CityModel
                    {
                        CityName = cityName,
                        CountryId = country.CountryId
                    };
                    int cityId = DataService.InsertCity(city, transaction);
                    city.CityId = cityId;

                    // Insert Address
                    AddressModel address = new AddressModel
                    {
                        Address = address1,
                        CityId = city.CityId,
                        PostalCode = postalCode,
                        Phone = phone
                    };
                    int addressId = DataService.InsertAddress(address, transaction);
                    address.AddressId = addressId;

                    // Insert Customer
                    CustomerModel customer = new CustomerModel
                    {
                        CustomerName = customerName,
                        AddressId = address.AddressId
                    };
                    DataService.InsertCustomer(customer, transaction);

                    // Commit the transaction
                    transaction.Commit();
                    MessageBox.Show("Customer record created successfully!");
                }
                catch (MySqlException ex)
                {
                    // Rollback the transaction if any operation fails
                    transaction.Rollback();
                    MessageBox.Show("Transaction Failed: " + ex.Message);
                }
            }
        }

        public static List<string> GetCustomerTable()
        {
            var customerDataTable = CustomerRepository.GetContactNamesDataTable();

            var customerList = new List<string>();

            foreach (DataRow row in customerDataTable.Rows)
            {
                customerList.Add(row["customerName"].ToString());
            }

            return customerList;
        }
    }
}
