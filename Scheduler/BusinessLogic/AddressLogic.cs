namespace Scheduler.BusinessLogic
{
    internal class AddressLogic
    {
        // Get City ID
        // Create Address


        public static int CreateAddress()
        {

            var cityId = CityLogic.CreateCity();
            return cityId;
        }

    }
}

