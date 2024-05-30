using System.Collections.Generic;
using System.Data;

namespace Scheduler.DataAccess
{
    internal class CustomerRepository
    {
        internal static DataTable GetContactNamesDataTable()
        {
            return MySQLCRUD.GetDataTable("SELECT customerName FROM customer");
        }

        internal static DataTable GetCustomerDataTable(string contactComboBoxText)
        {
            var query = "SELECT customerId FROM customer WHERE customerName = @ContactUserName";

            var parameters = new Dictionary<string, object>
            {
                { "@ContactUserName", contactComboBoxText }
            };

            // Load data from database
            var customerDataTable = MySQLCRUD.GetDataTable(query, parameters);

            return customerDataTable;
        }
    }
}
