using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace Scheduler.DataAccess
{
    internal class CountryRepository
    {
        public static DataTable GetCountryDataTable(int countryId)
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

        public static DataTable GetAllCountries()
        {
            var query = "SELECT countryId, country FROM country";
            var countryDataTable = MySQLCRUD.GetDataTable(query);
            return countryDataTable;
        }


    }
}
