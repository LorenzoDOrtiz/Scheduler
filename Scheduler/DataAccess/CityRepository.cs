using MySql.Data.MySqlClient;
using Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Scheduler.DataAccess
{
    internal class CityRepository
    {

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

        internal static DataTable GetCityDataTable(int cityId)
        {
            var query = "SELECT * FROM city WHERE cityId = @CityId";

            var parameters = new Dictionary<string, object>
            {
                { "@CityId", cityId }
            };
            // Load data from database
            var cityDataTable = MySQLCRUD.GetDataTable(query, parameters);

            return cityDataTable;
        }
    }
}
