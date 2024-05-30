using System.Collections.Generic;
using System.Data;

namespace Scheduler.DataAccess
{
    internal class CountryRepository
    {
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
    }
}
