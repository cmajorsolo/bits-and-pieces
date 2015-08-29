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
            IRetreiveFile retriver = new GetJsonText();
            ICalculate calc = new CalculateDistance();
            GetCustomersCloseToIntercom getCustomerLists = new GetCustomersCloseToIntercom();
            Console.WriteLine("Please type in your customers json file location");
            string jsonFileLocation = Console.ReadLine();

            List<Customer> customers = getCustomerLists.RetrieveCustomers(retriver,jsonFileLocation);
            List<Customer> requiredCustomers = getCustomerLists.GetRequiredCustomers(calc, customers);
            Console.WriteLine();
            Console.WriteLine("Customers within 100k from our office are listed below: ");
            foreach (Customer c in requiredCustomers)
            {
                Console.WriteLine(c.ToString());
            }
            Console.Read();
        }
    }
}
