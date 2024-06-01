using MySql.Data.MySqlClient;
using Scheduler.DataAccess;
using Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Scheduler.BusinessLogic
{
    internal class CityService
    {
        public static CityModel GetCity(int cityId)
        {
            var cityDataTable = CityRepository.GetCityDataTable(cityId);
            var cityRow = cityDataTable.Rows[0];

            // Create customer model
            var city = new CityModel
            {
                CityId = cityId,
                CityName = cityRow["city"].ToString(),
                CountryId = Convert.ToInt32(cityRow["countryId"]),
                CreateDate = Convert.ToDateTime(cityRow["createDate"]),
                CreatedBy = cityRow["createdBy"].ToString(),
                LastUpdateBy = cityRow["lastUpdateBy"].ToString()
            };
            return city;
        }

        public static CityModel GetCity(int cityId, MySqlTransaction transaction)
        {
            var cityDataTable = CityRepository.GetCityDataTable(cityId, transaction);

            if (cityDataTable.Rows.Count == 0)
            {
                throw new Exception("City not found.");
            }

            var cityRow = cityDataTable.Rows[0];

            var city = new CityModel
            {
                CityId = Convert.ToInt32(cityRow["cityId"]),
                CityName = cityRow["city"].ToString(),
                CountryId = Convert.ToInt32(cityRow["countryId"])
            };

            return city;
        }

        internal static List<CityModel> GetCityList(int countryId)
        {
            var cityDataTable = CityRepository.GetAllCities(countryId);

            var cityList = new List<CityModel>();

            foreach (DataRow row in cityDataTable.Rows)
            {
                var city = new CityModel
                {
                    CityId = Convert.ToInt32(row["cityId"]),
                    CityName = row["city"].ToString()
                };
                cityList.Add(city);
            }
            return cityList;
        }


        internal static int GetCountryId(int cityId)
        {
            var cityDataTable = CityRepository.GetCityDataTable(cityId);

            // Correct the column name to "countryId"
            var countryId = Convert.ToInt32(cityDataTable.Rows[0]["countryId"]);

            return countryId;
        }
    }
}
