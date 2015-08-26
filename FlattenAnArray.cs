/*
 Version 1.0
 *   This class provides a static method that flat an ArrayList 
 *   e.g. input {{1,2,{3}},4} -> {1,2,3,4}
 */

using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flatten
{
    public class FlattenAnArray
    {
        public static ArrayList Flat(ArrayList array)
        {
            ArrayList resultArray = new ArrayList();
            if (array == null)
                return null;
            else
            {
                foreach (var item in array)
                {
                    if (item is ArrayList)
                        resultArray.AddRange(Flat(item as ArrayList));
                    else
                        resultArray.Add(item);
                }
            }
            return resultArray;
        }
    }
}
