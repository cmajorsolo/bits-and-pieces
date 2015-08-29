using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invitation
{
    public class GetCustomersCloseToIntercom
    {
        public GetCustomersCloseToIntercom(){}

        public List<Customer> RetrieveCustomers(IRetreiveFile retriever, string filePath)
        {
            List<Customer> customers = retriever.GetCustomersFromJsonFile(filePath);
            if (customers == null)
            {
                return null;
            }
            return customers;
        }

        public List<Customer> GetRequiredCustomers(ICalculate calc,List<Customer> customers)
        {
            List<Customer> customersAround = new List<Customer> { };
            const double intercomLatitude = 53.3381985;
            const double intercomeLongitude = -6.2592576;
            // loop throught the customers list and return those are within 100km from the Intercom office
            for (int i = 0; i < customers.Count; i++)
            {
                if (calc.Calculate(customers[i].Latitude, customers[i].Longitude, intercomLatitude, intercomeLongitude) < 100 && calc.Calculate(customers[i].Latitude, customers[i].Longitude, intercomLatitude, intercomeLongitude) != 0.0)
                {
                    customersAround.Add(customers[i] as Customer);
                }
            }
            customersAround = customersAround.OrderBy(c => c.ID).ToList(); //order the list by ID

            return customersAround;
        }
    }
}
