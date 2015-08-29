using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invitation
{
    class Utilities
    {
        public static double ConvertDegreeToRadiance(double degree)
        {
            return degree * (Math.PI / 180.0);
        }
    }
}
