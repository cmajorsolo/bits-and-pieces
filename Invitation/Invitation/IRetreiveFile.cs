using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invitation
{
    public interface IRetreiveFile
    {
        List<Customer> GetCustomersFromJsonFile(string path);
    }
}
