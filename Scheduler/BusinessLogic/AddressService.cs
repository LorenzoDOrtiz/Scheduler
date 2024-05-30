using MySql.Data.MySqlClient;
using Scheduler.DataAccess;
using Scheduler.Models;
using System;

namespace Scheduler.BusinessLogic
{
    internal class AddressService
    {
        public static AddressModel GetAddress(int addressId)
        {
            var addressDataTable = AddressRepository.GetAddressDataTable(addressId);
            var addressRow = addressDataTable.Rows[0];

            // Create address model
            var address = new AddressModel
            {
                AddressId = addressId,
                Address = addressRow["address"].ToString(),
                Address2 = addressRow["address2"].ToString(),
                CityId = Convert.ToInt32(addressRow["cityId"]),
                PostalCode = addressRow["postalCode"].ToString(),
                Phone = addressRow["phone"].ToString(),
                CreateDate = Convert.ToDateTime(addressRow["createDate"]),
                CreatedBy = addressRow["createdBy"].ToString(),
                LastUpdateBy = addressRow["lastUpdateBy"].ToString()
            };
            return address;
        }

        public static AddressModel GetAddress(int addressId, MySqlTransaction transaction)
        {
            var addressDataTable = AddressRepository.GetAddressDataTable(addressId, transaction);

            if (addressDataTable.Rows.Count == 0)
            {
                throw new Exception("Address not found.");
            }

            var addressRow = addressDataTable.Rows[0];

            var address = new AddressModel
            {
                AddressId = Convert.ToInt32(addressRow["addressId"]),
                Address = addressRow["address"].ToString(),
                CityId = Convert.ToInt32(addressRow["cityId"]),
                PostalCode = addressRow["postalCode"].ToString(),
                Phone = addressRow["phone"].ToString()
            };

            return address;
        }
    }
}
