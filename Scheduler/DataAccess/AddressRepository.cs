using MySql.Data.MySqlClient;
using Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Scheduler.DataAccess
{
    internal class AddressRepository
    {
        public static int InsertAddress(AddressModel address, MySqlTransaction transaction)
        {
            try
            {
                DBConnection.ConfirmDataBaseConnection();

                string query = "INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdateBy) " +
                               "VALUES (@Address, @Address2, @CityId, @PostalCode, @Phone, @CreateDate, @CreatedBy, @LastUpdateBy); " +
                               "SELECT LAST_INSERT_ID();";
                var cmd = MySQLCRUD.CreateCommand(query, transaction);
                var parameters = new Dictionary<string, object>
                {
                    { "@Address", address.Address },
                    { "@Address2", address.Address2 },
                    { "@CityId", address.CityId },
                    { "@PostalCode", address.PostalCode },
                    { "@Phone", address.Phone },
                    { "@CreateDate", address.CreateDate },
                    { "@CreatedBy", address.CreatedBy },
                    { "@LastUpdateBy", address.LastUpdateBy }
                };
                MySQLCRUD.AddParameters(parameters, cmd);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (MySqlException ex)
            {
                throw new DataAccessException("Inserting address failed", ex);
            }
        }

        public static void UpdateAddress(AddressModel newAddressModel, MySqlTransaction transaction)
        {
            try
            {
                DBConnection.ConfirmDataBaseConnection();

                string query = "UPDATE address SET cityId = @CityId, address = @Address, postalCode = @PostalCode, phone = @Phone, lastUpdateBy = @LastUpdateBy WHERE addressId = @AddressId";
                var cmd = MySQLCRUD.CreateCommand(query, transaction);
                var parameters = new Dictionary<string, object>
                {
                    { "@CityId", newAddressModel.CityId },
                    { "@Address", newAddressModel.Address },
                    { "@PostalCode", newAddressModel.PostalCode },
                    { "@Phone", newAddressModel.Phone },
                    { "@LastUpdateBy", newAddressModel.LastUpdateBy },
                    { "@AddressId", newAddressModel.AddressId }
                };
                MySQLCRUD.AddParameters(parameters, cmd);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new DataAccessException("Updating address failed", ex);
            }

        }

        public static DataTable GetAddressDataTable(int addressId)
        {
            var query = "SELECT * FROM address WHERE addressId = @AddressId";

            var parameters = new Dictionary<string, object>
            {
                { "@AddressId", addressId }
            };
            // Load data from database
            var addressDataTable = MySQLCRUD.GetDataTable(query, parameters);

            return addressDataTable;
        }

        public static DataTable GetAddressDataTable(int addressId, MySqlTransaction transaction)
        {
            string query = "SELECT * FROM address WHERE addressId = @AddressId";

            var parameters = new Dictionary<string, object>
            {
                { "@AddressId", addressId }
            };

            return MySQLCRUD.GetDataTable(query, parameters, transaction);
        }



    }
}
