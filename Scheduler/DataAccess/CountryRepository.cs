using MySql.Data.MySqlClient;
using Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Scheduler.DataAccess
{
    internal class CountryRepository
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

        internal static void UpdateCountry(CountryModel country, CityModel city, MySqlTransaction transaction)
        {
            string query = "UPDATE country SET country = @CountryName, lastUpdateBy = @LastUpdateBy WHERE countryId = @CityCountryId";
            var cmd = MySQLCRUD.CreateCommand(query, transaction);
            var parameters = new Dictionary<string, object>
                {
                    { "@CountryName", country.Name },
                    { "@LastUpdateBy", country.LastUpdateBy },
                    { "@CityCountryId", city.CountryId }
                };
            MySQLCRUD.AddParameters(parameters, cmd);
            cmd.ExecuteNonQuery();
        }
        internal static DataTable GetCountryDataTable(int countryId)
        {
            var query = "SELECT * FROM country WHERE countryId = @CountryId";

            var parameters = new Dictionary<string, object>
            {
                { "@CountryId", countryId }
            };
            // Load data from database
            var countryDataTable = MySQLCRUD.GetDataTable(query, parameters);

            return countryDataTable;
        }

        public static DataTable GetCountryDataTable(int countryId, MySqlTransaction transaction)
        {
            string query = "SELECT * FROM country WHERE countryId = @CountryId";

            var parameters = new Dictionary<string, object>
            {
                { "@CountryId", countryId }
            };

            return MySQLCRUD.GetDataTable(query, parameters, transaction);
        }

        public static DataTable GetCountryDataTable()
        {
            var query = "SELECT DISTINCT country FROM country";

            var countryDataTable = MySQLCRUD.GetDataTable(query);

            return countryDataTable;
        }

    }
}
