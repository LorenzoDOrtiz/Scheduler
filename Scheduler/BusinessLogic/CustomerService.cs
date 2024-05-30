using MySql.Data.MySqlClient;
using Scheduler.DataAccess;
using Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Scheduler.BusinessLogic
{
    internal class CustomerService
    {
        public static void CreateCustomer(string customerName, string address1, string cityName, string postalCode, string countryName, string phone)
        {
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
                    int countryId = CityRepository.InsertCountry(country, transaction);
                    country.CountryId = countryId;

                    // Insert City
                    CityModel city = new CityModel
                    {
                        CityName = cityName,
                        CountryId = country.CountryId
                    };
                    int cityId = CityRepository.InsertCity(city, transaction);
                    city.CityId = cityId;

                    // Insert Address
                    AddressModel address = new AddressModel
                    {
                        Address = address1,
                        CityId = city.CityId,
                        PostalCode = postalCode,
                        Phone = phone
                    };
                    int addressId = AddressRepository.InsertAddress(address, transaction);
                    address.AddressId = addressId;

                    // Insert Customer
                    CustomerModel customer = new CustomerModel
                    {
                        CustomerName = customerName,
                        AddressId = address.AddressId
                    };
                    CustomerRepository.InsertCustomer(customer, transaction);

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

        public static CustomerModel GetCustomer(int customerId)

        {
            var customerDataTable = CustomerRepository.GetCustomerDataTable(customerId);
            var customerRow = customerDataTable.Rows[0];

            // Create customer model
            var customer = new CustomerModel
            {
                CustomerId = customerId,
                CustomerName = customerRow["customerName"].ToString(),
                AddressId = Convert.ToInt32(customerRow["addressId"]),
                Active = Convert.ToInt32(customerRow["active"]),
                CreateDate = Convert.ToDateTime(customerRow["createDate"]),
                CreatedBy = customerRow["createdBy"].ToString(),
                LastUpdateBy = customerRow["lastUpdateBy"].ToString()
            };
            return customer;
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
