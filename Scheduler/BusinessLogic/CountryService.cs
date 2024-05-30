using Scheduler.DataAccess;
using Scheduler.Models;

namespace Scheduler.BusinessLogic
{
    internal class CountryService
    {
        public static CountryModel GetCountry(int countryId)
        {
            var countryDataTable = CountryRepository.GetCountryDataTable(countryId);
            var row = countryDataTable.Rows[0];

            return new CountryModel
            {
                CountryId = countryId,
                Name = row["country"].ToString()
            };
        }
    }
}
