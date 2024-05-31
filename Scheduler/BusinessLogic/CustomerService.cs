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
        public static void CreateCustomer(string customerName, string address, int cityId, string postalCode, int countryId, string phone)
        {
            // Begin the transaction
            using (var transaction = DBConnection.Conn.BeginTransaction())
            {
                try
                {
                    // Insert Address
                    AddressModel addressModel = new AddressModel
                    {
                        Address = address,
                        CityId = cityId,
                        PostalCode = postalCode,
                        Phone = phone,
                    };
                    int addressId = AddressRepository.InsertAddress(addressModel, transaction);
                    addressModel.AddressId = addressId;

                    // Insert Customer
                    CustomerModel customer = new CustomerModel
                    {
                        CustomerName = customerName,
                        AddressId = addressModel.AddressId,
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

        public static void ModifyCustomer(int customerId, string customerName, string addressLine,
            string postalCode, string phoneNumber, int cityId, int countryId)
        {
            using (var transaction = DBConnection.Conn.BeginTransaction())
            {
                try
                {
                    var customer = GetCustomer(customerId, transaction);
                    var address = AddressService.GetAddress(customer.AddressId, transaction);
                    var city = CityService.GetCity(address.CityId, transaction);
                    var country = CountryService.GetCountry(city.CountryId, transaction);

                    // Update Country if necessary
                    if (city.CountryId != countryId)
                    {
                        city.CountryId = countryId; // Update city.CountryId if countryId changed
                        CityRepository.UpdateCity(city, transaction);
                    }

                    // Update Address if necessary
                    if (address.Address != addressLine || address.PostalCode != postalCode || address.Phone != phoneNumber || address.CityId != cityId)
                    {
                        address.Address = addressLine;
                        address.PostalCode = postalCode;
                        address.Phone = phoneNumber;
                        address.CityId = cityId; // Only update CityId in the Address table
                        AddressRepository.UpdateAddress(address, transaction);
                    }

                    // Update Customer
                    if (customer.CustomerName != customerName)
                    {
                        customer.CustomerName = customerName;
                        customer.AddressId = address.AddressId;
                        CustomerRepository.UpdateCustomer(customer, transaction);
                    }

                    transaction.Commit();
                    MessageBox.Show("Customer record modified successfully!");
                }
                catch (MySqlException ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Transaction Failed: " + ex.Message);
                }
            }
        }





    }
}
