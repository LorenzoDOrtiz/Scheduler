using MySql.Data.MySqlClient;
using Scheduler.Models;
using System.Collections.Generic;
using System.Data;

namespace Scheduler.DataAccess
{
    internal class CityRepository
    {
        public static DataTable GetCityDataTable(int cityId)
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

        public static DataTable GetAllCities()
        {
            var query = "SELECT cityId, city FROM city";
            var cityDataTable = MySQLCRUD.GetDataTable(query);

            return cityDataTable;
        }

        public static void UpdateCity(CityModel city, MySqlTransaction transaction)
        {
            string query = "UPDATE city SET countryId = @CountryId, lastUpdateBy = @LastUpdateBy WHERE cityId = @CityId";
            var cmd = MySQLCRUD.CreateCommand(query, transaction);
            var parameters = new Dictionary<string, object>
            {
                { "@CountryId", city.CountryId },
                { "@LastUpdateBy", city.LastUpdateBy },
                { "@CityId", city.CityId }
            };
            MySQLCRUD.AddParameters(parameters, cmd);
            cmd.ExecuteNonQuery();
        }
    }
}
