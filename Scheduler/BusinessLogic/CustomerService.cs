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
                    int countryId = CountryRepository.InsertCountry(country, transaction);
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

        public static CustomerModel GetCustomer(int customerId, MySqlTransaction transaction)
        {
            var customerDataTable = CustomerRepository.GetCustomerDataTable(customerId, transaction);

            if (customerDataTable.Rows.Count == 0)
            {
                throw new Exception("Customer not found.");
            }

            var customerRow = customerDataTable.Rows[0];

            var customer = new CustomerModel
            {
                CustomerId = Convert.ToInt32(customerRow["customerId"]),
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

        public static void ModifyCustomer(int customerId, string customerName, string addressLine, string cityName, string postalCode, string countryName, string phoneNumber)
        {
            // Begin the transaction
            using (var transaction = DBConnection.Conn.BeginTransaction())
            {
                try
                {
                    // Get existing customer data
                    var customer = GetCustomer(customerId, transaction);
                    var address = AddressService.GetAddress(customer.AddressId, transaction);
                    var city = CityService.GetCity(address.CityId, transaction);
                    var country = CountryService.GetCountry(city.CountryId, transaction);


                    // Update Country if necessary
                    if (country.Name != countryName)
                    {
                        country.Name = countryName;
                        country.CountryId = city.CountryId;
                        CountryRepository.UpdateCountry(country, city, transaction);
                    }

                    // Update City if necessary
                    if (city.CityName != cityName)
                    {
                        city.CityName = cityName;
                        city.CountryId = country.CountryId;
                        CityRepository.UpdateCity(city, transaction);
                    }

                    // Update Address if necessary
                    if (address.Address != addressLine || address.PostalCode != postalCode || address.Phone != phoneNumber)
                    {
                        address.Address = addressLine;
                        address.PostalCode = postalCode;
                        address.Phone = phoneNumber;
                        address.CityId = city.CityId;
                        AddressRepository.UpdateAddress(address, transaction);
                    }

                    // Update Customer
                    if (customer.CustomerName != customerName)
                    {
                        customer.CustomerName = customerName;
                        customer.AddressId = address.AddressId;
                        CustomerRepository.UpdateCustomer(customer, transaction);
                    }

                    // Commit the transaction
                    transaction.Commit();
                    MessageBox.Show("Customer record modified successfully!");
                }
                catch (MySqlException ex)
                {
                    // Rollback the transaction if any operation fails
                    transaction.Rollback();
                    MessageBox.Show("Transaction Failed: " + ex.Message);
                }
            }
        }


    }
}
