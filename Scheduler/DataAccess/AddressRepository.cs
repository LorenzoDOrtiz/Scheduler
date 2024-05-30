﻿using MySql.Data.MySqlClient;
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

        internal static DataTable GetAddressDataTable(int addressId)
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

        internal static void UpdateAddress(AddressModel address, MySqlTransaction transaction)
        {
            string query = "UPDATE address SET address = @AddressLine, postalCode = @PostalCode, phone = @PhoneNumber, lastUpdateBy = @LastUpdateBy WHERE cityId = @CityId";
            var cmd = MySQLCRUD.CreateCommand(query, transaction);
            var parameters = new Dictionary<string, object>
            {
                    { "@AddressLine", address.Address },
                    { "@PostalCode", address.PostalCode },
                    { "@PhoneNumber", address.Phone },
                    { "@LastUpdateBy", address.LastUpdateBy },
                    { "@CityId", address.CityId },
            };
            MySQLCRUD.AddParameters(parameters, cmd);
            cmd.ExecuteNonQuery();
        }
    }
}
