using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invitation
{
    public interface ICalculate
    {
        double Calculate(double p1Latitude, double p1Longitude, double p2Latitude, double p2Longitude);
    }
}
