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
    }
}
