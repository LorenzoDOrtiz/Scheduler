namespace Scheduler.BusinessLogic
{
    internal class CustomerLogic
    {

        // Get Address ID
        // Create Customer

        public static int CreateCustomer()
        {

            var addressId = AddressLogic.CreateAddress();
            return addressId;
        }

    }
}
