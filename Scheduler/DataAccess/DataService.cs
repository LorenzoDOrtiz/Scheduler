using MySql.Data.MySqlClient;
using Scheduler.Models;
using System;
using System.Collections.Generic;

namespace Scheduler.DataAccess
{
    internal class DataService
    {
        public static int InsertCountry(CountryModel country, MySqlTransaction transaction)
        {
            string query = "INSERT INTO country (country, createDate, createdBy, lastUpdateBy) " +
                           "VALUES (@CountryName, @CreateDate, @CreatedBy, @LastUpdateBy); " +
                           "SELECT LAST_INSERT_ID();";
            var cmd = MySQLCRUD.CreateCommand(query, transaction);
            var parameters = new Dictionary<string, object>
                {
                    { "@CountryName", country.Name },
                    { "@CreateDate", country.CreateDate },
                    { "@CreatedBy", country.CreatedBy },
                    { "@LastUpdateBy", country.LastUpdateBy }
                };
            MySQLCRUD.AddParameters(parameters, cmd);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public static int InsertCity(CityModel city, MySqlTransaction transaction)
        {
            string query = "INSERT INTO city (city, countryId, createDate, createdBy, lastUpdateBy) " +
                           "VALUES (@CityName, @CountryId, @CreateDate, @CreatedBy, @LastUpdateBy); " +
                           "SELECT LAST_INSERT_ID();";
            var cmd = MySQLCRUD.CreateCommand(query, transaction);
            var parameters = new Dictionary<string, object>
                {
                    { "@CityName", city.CityName },
                    { "@CountryId", city.CountryId },
                    { "@CreateDate", city.CreateDate },
                    { "@CreatedBy", city.CreatedBy },
                    { "@LastUpdateBy", city.LastUpdateBy }
                };
            MySQLCRUD.AddParameters(parameters, cmd);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

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
    }
}