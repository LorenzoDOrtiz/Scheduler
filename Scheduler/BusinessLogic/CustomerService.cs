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

                    MessageBox.Show("Customer created successfully!", "Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (DataAccessException ex)
                {
                    // Rollback the transaction if any operation fails
                    transaction.Rollback();
                    MessageBox.Show("Customer creation failed!: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    // Rollback the transaction if any operation fails
                    transaction.Rollback();
                    MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void ModifyCustomer(CustomerModel existingCustomerModel, AddressModel existingAddressModel, string newCustomerName, string newAddressLine, int newCityId, string newCityName, string newPostalCode, int newCountryId, string newPhoneNumber)
        {
            using (var transaction = DBConnection.Conn.BeginTransaction())
            {
                try
                {
                    if (existingAddressModel.CityId != newCityId)
                    {
                        var newAddressModel = existingAddressModel;

                        newAddressModel.CityId = newCityId;
                        newAddressModel.Address = newAddressLine;
                        newAddressModel.PostalCode = newPostalCode;
                        newAddressModel.Phone = newPhoneNumber;
                        // Update the address database table and get the new addressId back if there is one
                        AddressRepository.UpdateAddress(newAddressModel, transaction);
                    }

                    if (existingCustomerModel.CustomerName != newCustomerName)
                    {
                        var newCustomerModel = existingCustomerModel;
                        newCustomerModel.CustomerName = newCustomerName;
                        CustomerRepository.UpdateCustomer(newCustomerModel, transaction);
                    }

                    transaction.Commit();
                    MessageBox.Show("Customer modified successfully!", "Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (DataAccessException ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Customer modification failed!: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public static List<CustomerModel> GetContactList()
        {
            var contactDataTable = CustomerRepository.GetAllContacts();

            var contactList = new List<CustomerModel>();

            foreach (DataRow row in contactDataTable.Rows)
            {
                contactList.Add(new CustomerModel
                {
                    CustomerId = Convert.ToInt32(row["customerId"]),
                    CustomerName = row["customerName"].ToString()
                });
            }
            return contactList;
        }

        internal static List<CustomerModel> GetCustomerCountryListForReports()
        {
            var customerCountryDataTable = CustomerRepository.GetCustomerCountryDataTableForReports();
            var customerCountryList = new List<CustomerModel>();

            foreach (DataRow row in customerCountryDataTable.Rows)
            {
                var customer = new CustomerModel
                {
                    CustomerId = Convert.ToInt32(row["customerId"]),
                    AddressId = Convert.ToInt32(row["addressId"]),
                    CityId = Convert.ToInt32(row["cityId"]),
                    CountryId = Convert.ToInt32(row["countryId"]),
                    CountryName = row["country"].ToString()
                };

                customerCountryList.Add(customer);
            }

            return customerCountryList;
        }

    }
}
