namespace Scheduler.Models
{
    public class CustomerDTO
    {
        public CustomerModel Customer { get; set; }
        public AddressModel Address { get; set; }
        public CityModel City { get; set; }
        public CountryModel Country { get; set; }
    }
}