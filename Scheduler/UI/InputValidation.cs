using System.Collections.Generic;
using System.Linq;

namespace Scheduler.UI
{
    public class InputValidation
    {

        public static List<string> ordinalSuffixes = new List<string>
        {
            "th",    // Ordinal suffix (e.g., 18th)
            "nd",    // Ordinal suffix (e.g., 2nd)
            "rd",    // Ordinal suffix (e.g., 3rd)
            "st"     // Ordinal suffix (e.g., 1st)
        };

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
            bool containsOrdinals = ordinalSuffixes.Any(suffix => lowercaseText.Contains(suffix.ToLower()));
            bool containsAddresses = addressSuffixes.Any(suffix => lowercaseText.Contains(suffix.ToLower()));
            return !string.IsNullOrEmpty(address) && (containsOrdinals && containsAddresses);
        }
    }
}
