/*
 Version 1.0
 * This class provides a function Calculate that returns the distance between two GeoCoordinates.
 * There is also another liabrary System.Device.Location provides funcitons that could do same thing. It is implemeted in fuction CalculateWithBuiltInFucntion() below.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

namespace Invitation
{
    class CalculateDistance
    {
        public double Calculate(double p1Latitude, double p1Longitude, double p2Latitude, double p2Longitude)
        {
            double p1LatitudeInRadiance = ConvertDegreeToRadiance(p1Latitude);
            double p1LongitudeInRadiance = ConvertDegreeToRadiance(p1Longitude);
            double p2LatitudeInRadiance = ConvertDegreeToRadiance(p2Latitude);
            double p2LongitudeInRadiance = ConvertDegreeToRadiance(p2Longitude);

            ///*
            //      longitudeDistance = p2LongitudeInRadiance - p1LongitudeInRadiance
            //      LatitudeDistance = p2LatitudeInRadiance - p1LatitudeInRadiance
            //      a = (sin(LatitudeDistance/2))^2 + cos(p1LatitudeInRadiance) * cos(p2LatitudeInRadiance) * (sin(longitudeDistance/2))^2
            //      c = 2 * atan2(sqrt(a), sqrt(1-a)) 
            //      d = R * c
            //*/
            double longitudeDistance = p2LongitudeInRadiance - p1LongitudeInRadiance;
            double LatitudeDistance = p2LatitudeInRadiance - p1LatitudeInRadiance;
            double a = Math.Pow(Math.Sin(LatitudeDistance / 2.0), 2.0) + Math.Cos(p1LatitudeInRadiance) * Math.Cos(p2LatitudeInRadiance) * Math.Pow(Math.Sin(longitudeDistance / 2.0), 2.0);
            double c = 2.0 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1.0 - a));
            return 6371 * c;
         }

        public static double ConvertDegreeToRadiance(double degree)
        {
            return degree * (Math.PI / 180.0);
        }

        public double CalculateWithBuiltInFucntion(double p1Latitude, double p1Longitude, double p2Latitude, double p2Longitude)
        {
            var p1Coord = new GeoCoordinate(p1Latitude, p1Longitude);
            var p2Coord = new GeoCoordinate(p2Latitude, p2Longitude);
            return p1Coord.GetDistanceTo(p2Coord);
        }
    }
}
