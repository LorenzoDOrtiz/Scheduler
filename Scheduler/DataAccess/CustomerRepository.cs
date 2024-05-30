using MySql.Data.MySqlClient;
using Scheduler.Models;
using System.Collections.Generic;
using System.Data;

namespace Scheduler.DataAccess
{
    internal class CustomerRepository
    {

        public static void InsertCustomer(CustomerModel customer, MySqlTransaction transaction)
        {
            string query = "INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdateBy) " +
                           "VALUES (@CustomerName, @AddressId, @Active, @CreateDate, @CreatedBy, @LastUpdateBy);";
            var cmd = MySQLCRUD.CreateCommand(query, transaction);
            var parameters = new Dictionary<string, object>
                {
                    {"@CustomerName", customer.CustomerName},
                    {"@AddressId", customer.AddressId},
                    {"@Active", customer.Active},
                    {"@CreateDate", customer.CreateDate},
                    {"@CreatedBy", customer.CreatedBy},
                    {"@LastUpdateBy", customer.LastUpdateBy},
                };
            MySQLCRUD.AddParameters(parameters, cmd);
            cmd.ExecuteNonQuery();
        }
        internal static DataTable GetContactNamesDataTable()
        {
            return MySQLCRUD.GetDataTable("SELECT customerName FROM customer");
        }

        internal static DataTable GetCustomerDataTable()
        {
            var query = "SELECT customer.customerId, customer.customerName, address.address, city.city, address.postalCode, country.country, address.phone " +
                              "FROM customer " +
                                "INNER JOIN address " +
                                    "ON customer.addressId = address.addressId " +
                                "INNER JOIN city " +
                                    "ON address.cityId = city.cityId " +
                                "INNER JOIN country " +
                                    "ON city.countryId = country.countryId";


            // Load data from database
            var customerDataTable = MySQLCRUD.GetDataTable(query);

            return customerDataTable;
        }

        public static DataTable GetCustomerDataTable(int customerId, MySqlTransaction transaction)
        {
            string query = "SELECT * FROM customer WHERE customerId = @CustomerId";

            var parameters = new Dictionary<string, object>
            {
                { "@CustomerId", customerId }
            };

            return MySQLCRUD.GetDataTable(query, parameters, transaction);
        }

        internal static DataTable GetCustomerDataTable(int selectedCustomerRowCustomerId)
        {
            var query = "SELECT * FROM customer WHERE customerId = @CustomerId";

            var parameters = new Dictionary<string, object>
            {
                { "@CustomerId", selectedCustomerRowCustomerId }
            };
            // Load data from database
            var customerDataTable = MySQLCRUD.GetDataTable(query, parameters);

            return customerDataTable;
        }

        internal static DataTable GetCustomerIdDataTable(string contactComboBoxText)
        {
            var query = "SELECT customerId FROM customer WHERE customerName = @ContactUserName";

            var parameters = new Dictionary<string, object>
            {
                { "@ContactUserName", contactComboBoxText }
            };

            // Load data from database
            var customerDataTable = MySQLCRUD.GetDataTable(query, parameters);

            return customerDataTable;
        }

        internal static void UpdateCustomer(CustomerModel customer, MySqlTransaction transaction)
        {
            string query = "UPDATE customer SET customerName = @CustomerName, lastUpdateBy = @LastUpdateBy WHERE addressId = @AddressId";
            var cmd = MySQLCRUD.CreateCommand(query, transaction);
            var parameters = new Dictionary<string, object>
            {
                    { "@CustomerName", customer.CustomerName },
                    { "@LastUpdateBy", customer.LastUpdateBy },
                    { "@AddressId", customer.AddressId }
                };
            MySQLCRUD.AddParameters(parameters, cmd);
            cmd.ExecuteNonQuery();
        }
    }
}
