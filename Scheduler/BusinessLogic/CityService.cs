using Scheduler.DataAccess;
using Scheduler.Models;
using System;

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
    }
}
