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

        public static DataTable GetCityDataTable(int cityId, MySqlTransaction transaction)
        {
            string query = "SELECT * FROM city WHERE cityId = @CityId";

            var parameters = new Dictionary<string, object>
            {
                { "@CityId", cityId }
            };

            return MySQLCRUD.GetDataTable(query, parameters, transaction);
        }

        internal static DataTable GetCityDataTable()
        {
            var query = "SELECT DISTINCT city FROM city";

            var cityDataTable = MySQLCRUD.GetDataTable(query);

            return cityDataTable;
        }


        internal static void UpdateCity(CityModel city, MySqlTransaction transaction)
        {
            string query = "UPDATE city SET city = @CityName, countryId = @CountryId, lastUpdateBy = @LastUpdateBy WHERE countryID = @CountryId";
            var cmd = MySQLCRUD.CreateCommand(query, transaction);
            var parameters = new Dictionary<string, object>
            {
                    { "@CityName", city.CityName },
                    { "@CountryId", city.CountryId },
                    { "@LastUpdateBy", city.LastUpdateBy }
                };
            MySQLCRUD.AddParameters(parameters, cmd);
            cmd.ExecuteNonQuery();
        }
    }
}
