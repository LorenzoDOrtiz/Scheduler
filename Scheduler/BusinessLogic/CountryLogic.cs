using Scheduler.DataAccess;
using Scheduler.Models;
using System;

namespace Scheduler.BusinessLogic
{
    internal class CountryLogic
    {
        // Create Country
        public static int CreateCountry(string countryName, DateTime createDate, string createdBy, string lastUpdateBy)
        {
            CountryModel country = new CountryModel(countryName, createDate, createdBy, lastUpdateBy);

            var transaction = MySQLCRUD.BeginTransaction();

            // create country model, execute scalar and get the country Id
            var countryId = CountryRepository.AddCountry(transaction, country.CountryName, country.CreateDate, country.CreatedBy, country.LastUpdateBy);
            // return countryid
            return countryId;
        }
    }
}
