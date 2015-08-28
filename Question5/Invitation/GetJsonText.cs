/*
 Version 1.0
 * This class provides a function that takes in the path of a customers Json file, and generates a customer list from the file.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Invitation
{
    class GetJsonText
    {
        public static List<Customer> GetCustomersFromJsonFile(string path)
        {
            if (path == null || path == "")
                return null;
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string json = sr.ReadToEnd();
                    List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(json);
                    return customers;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
