/*
 Version 1.0
 * This program takes in a customer file, calculate the distance between the customer and the Intercom office, returns a list 
 * of customers who are withim 100km from the Intercom office. 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invitation
{
    public class Program
    {
        static void Main(string[] args)
        {
            //read in the customers json file and generate a customers list
            Console.WriteLine("Please type in your customers json file location");
            string jsonFileLocation = Console.ReadLine();
            List<Customer> customers = GetTheCustomerList(jsonFileLocation);
            if (customers == null)
            {
                Console.WriteLine();
                Console.WriteLine("Please check the file path or the Json file format");
                Console.Read();
                return;
            }
            //print out the customers with in 100k from Intercom office on screen.
            Console.WriteLine();
            Console.WriteLine("Customers within 100k from our office are listed below: ");
            foreach (Customer c in GetTheCustomerAround(customers))
            {
               Console.WriteLine(c.ToString());
            }
            Console.Read();
        }
        
        // returns a list of customers from Json file
        public static List<Customer> GetTheCustomerList(string jsonFilePath)
        {
            return GetJsonText.GetCustomersFromJsonFile(jsonFilePath);
        }

        //calculate the distance between Intercom office and the customers. Get a list of customers who are within 100km from the office. 
        public static List<Customer> GetTheCustomerAround(List<Customer> customers)
        {
            List<Customer> customersAround = new List<Customer> { };
            // loop throught the customers list and return those are within 100km from the Intercom office
            for (int i = 0; i < customers.Count; i++)
            {
                if (CalculateTheDistanceBetweenCustomerAndIntercom(customers[i].Latitude, customers[i].Longitude) < 100)
                {
                    customersAround.Add(customers[i] as Customer);
                }
            }
            customersAround = customersAround.OrderBy(c => c.ID).ToList(); //order the list by ID

            return customersAround;
        }

        public static double CalculateTheDistanceBetweenCustomerAndIntercom(double custLatitude, double custLongitude)
        {
            //The GeoCooridnate of Intercome office
            const double intercomLatitude = 53.3381985;
            const double intercomeLongitude = -6.2592576;

            CalculateDistance calc = new CalculateDistance();
            return calc.Calculate(custLatitude, custLongitude, intercomLatitude, intercomeLongitude);
        }

        public static double CalculateTheDistanceBetweenCustomerAndIntercomWithBuiltInFunction(double custLatitude, double custLongitude)
        {
            //The GeoCooridnate of Intercome office
            const double intercomLatitude = 53.3381985;
            const double intercomeLongitude = -6.2592576;

            CalculateDistance calc = new CalculateDistance();
            return calc.CalculateWithBuiltInFucntion(custLatitude, custLongitude, intercomLatitude, intercomeLongitude); 
        }
    }
}
