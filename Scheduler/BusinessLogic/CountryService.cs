using MySql.Data.MySqlClient;
using Scheduler.DataAccess;
using Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Data;

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

        internal static List<string> GetCountryList()
        {
            var countryDataTable = CountryRepository.GetCountryDataTable();

            var countryList = new List<string>();

            foreach (DataRow row in countryDataTable.Rows)
            {
                countryList.Add(row["country"].ToString());
            }

            return countryList;
        }
    }
}
