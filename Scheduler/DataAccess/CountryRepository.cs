using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Scheduler.DataAccess
{
    internal class CountryRepository
    {
        public static int AddCountry(MySqlTransaction transaction, string countryName,
            DateTime createDate, string createdBy, string lastUpdateBy)
        {
            string query = "INSERT INTO country (country, createDate, createdBy, lastUpdateBy) " +
                "VALUES (@CountryName, @CreateDate, @CreatedBy, @lastUpdateBy); " +
                "SELECT LAST_INSERT_ID();";
            var parameters = new Dictionary<string, object>
                {
                    { "@CountryName", countryName },
                    { "@CreateDate", createDate },
                    { "@CreatedBy", createdBy },
                    { "@lastUpdateBy", lastUpdateBy }
                };
            return Convert.ToInt32(MySQLCRUD.ExecuteScalar(transaction, query, parameters));
        }
    }
}
