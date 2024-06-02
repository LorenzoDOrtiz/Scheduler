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
            try
            {
                DBConnection.ConfirmDataBaseConnection();

                string query = "INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdateBy) " +
                           "VALUES (@CustomerName, @AddressId, @Active, @CreateDate, @CreatedBy, @LastUpdateBy);";
                var cmd = MySQLCRUD.CreateCommand(query, transaction);
                var parameters = new Dictionary<string, object>
                {
                    { "@CustomerName", customer.CustomerName },
                    { "@AddressId", customer.AddressId },
                    { "@Active", customer.Active },
                    { "@CreateDate", customer.CreateDate },
                    { "@CreatedBy", customer.CreatedBy },
                    { "@LastUpdateBy", customer.LastUpdateBy },
                };
                MySQLCRUD.AddParameters(parameters, cmd);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new DataAccessException("Inserting customer failed", ex);
            }
        }

        public static void UpdateCustomer(CustomerModel customer, MySqlTransaction transaction)
        {
            try
            {
                DBConnection.ConfirmDataBaseConnection();

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
            catch (MySqlException ex)
            {
                throw new DataAccessException("Updating customer failed", ex);
            }

        }
        public static void DeleteCustomer(int selectedcustomerId)
        {
            try
            {
                DBConnection.ConfirmDataBaseConnection();

                // Delete customers associated appointments
                string deleteAssociatedAppointmentsQuery = "DELETE FROM appointment WHERE customerId = @CustomerId";
                var deleteAssociatedAppointmentsCMD = MySQLCRUD.CreateCommand(deleteAssociatedAppointmentsQuery);
                Dictionary<string, object> deleteAssociatedAppointmentsParameters = new Dictionary<string, object>()
                    {
                        { "@CustomerId", selectedcustomerId }
                    };

                MySQLCRUD.AddParameters(deleteAssociatedAppointmentsParameters, deleteAssociatedAppointmentsCMD);
                deleteAssociatedAppointmentsCMD.ExecuteNonQuery();

                // Delete customer
                string deleteCustomerQuery = "DELETE FROM customer WHERE customerId = @CustomerId";
                var deleteCustomerCMD = MySQLCRUD.CreateCommand(deleteCustomerQuery);
                Dictionary<string, object> deleteCustomerParameters = new Dictionary<string, object>()
                    {
                        { "@CustomerId", selectedcustomerId }
                    };

                MySQLCRUD.AddParameters(deleteCustomerParameters, deleteCustomerCMD);
                deleteCustomerCMD.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new DataAccessException("Deleting customer failed", ex);
            }
        }

        public static DataTable GetContactNamesDataTable()
        {
            return MySQLCRUD.GetDataTable("SELECT customerName FROM customer");
        }

        public static DataTable GetCustomerDataTable()
        {
            var query = "SELECT customer.customerId, customer.customerName, address.address, country.country, city.city, address.postalCode,  address.phone " +
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

        public static DataTable GetCustomerDataTable(int selectedCustomerRowCustomerId)
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

        public static DataTable GetCustomerIdDataTable(string contactComboBoxText)
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

        public static DataTable GetAllContacts()
        {
            var query = "SELECT customerId, customerName FROM customer";
            var customerDataTable = MySQLCRUD.GetDataTable(query);

            return customerDataTable;
        }
    }
}
