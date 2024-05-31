using MySql.Data.MySqlClient;
using Scheduler.DataAccess;
using Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Scheduler.BusinessLogic
{
    public class CountryService
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

        public static CountryModel GetCountry(int countryId, MySqlTransaction transaction)
        {
            var countryDataTable = CountryRepository.GetCountryDataTable(countryId, transaction);

            if (countryDataTable.Rows.Count == 0)
            {
                throw new Exception("Country not found.");
            }

            var countryRow = countryDataTable.Rows[0];

            var country = new CountryModel
            {
                CountryId = Convert.ToInt32(countryRow["countryId"]),
                Name = countryRow["country"].ToString()
            };

            return country;
        }

        internal static List<CountryModel> GetCountryList()
        {
            var countryDataTable = CountryRepository.GetAllCountries();

            var countryList = new List<CountryModel>();

            foreach (DataRow row in countryDataTable.Rows)
            {
                var country = new CountryModel
                {
                    CountryId = Convert.ToInt32(row["countryId"]),
                    Name = row["country"].ToString()
                };
                countryList.Add(country);
            }
            return countryList;
        }




    }
}
