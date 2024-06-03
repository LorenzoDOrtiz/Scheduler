using System.Collections.Generic;
using System.Linq;

namespace Scheduler.UI
{
    public class AddressValidation
    {
        public static List<string> addressSuffixes = new List<string>
        {
            "Ave",   // Avenue
            "Blvd",  // Boulevard
            "Cir",   // Circle
            "Ct",    // Court
            "Dr",    // Drive
            "Hwy",   // Highway
            "Ln",    // Lane
            "Pkwy",  // Parkway
            "Pl",    // Place
            "Rd",    // Road
            "St",    // Street
            "Ter",   // Terrace
            "Way",   // Way
            "Ally",  // Alley 
        };

        public static bool IsAddressValid(string address)
        {
            string lowercaseText = address.ToLower();
            bool containsAddresses = addressSuffixes.Any(suffix => lowercaseText.Contains(suffix.ToLower()));
            return !string.IsNullOrEmpty(address) && (containsAddresses);
        }
    }
}
