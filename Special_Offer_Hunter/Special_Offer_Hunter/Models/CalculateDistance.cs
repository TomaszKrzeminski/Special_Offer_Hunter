using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Special_Offer_Hunter.Models
{
    public interface CalculateDistance
    {

        double GetDistance(Location point1, Location point2);
        //List<Location> FindCoordinates(double latitude, double longitude, double range);
    }



    public class CalcutateDistanceNet : CalculateDistance
    {


      //public  List<Location> FindCoordinates( double lat,double lon, double range)
      //  {
      //      CalculateDistance distance = new CalcutateDistanceNet();
           
            
      //      double distancex = 7;
      //      double r_earth = 6378;
      //      double PI = Math.PI;
      //      double latitude = lat + (distancex / r_earth) * (180 / PI);
      //      double longitude = lon + (distancex / r_earth) * (180 / PI) / Math.Cos(latitude * PI / 180);

      //      double latitude2 = lat + (-distancex / r_earth) * (180 / PI);
      //      double longitude2 = lon + (-distancex / r_earth) * (180 / PI) / Math.Cos(latitude * PI / 180);

      //      Location l2 = new Location() { Latitude = latitude, Longitude = lon };
      //      Location l3 = new Location() { Latitude = lat, Longitude = longitude };

      //      Location l4 = new Location() { Latitude = latitude2, Longitude = lon };
      //      Location l5 = new Location() { Latitude = lat, Longitude = longitude2 };

      //      Location l1 = new Location() { Latitude = lat, Longitude = lon };


      //      double distancexxx = distance.GetDistance(l1, l2);
      //      double distancexxcxxx = distance.GetDistance(l1, l3);

      //      double distancexdsxx = distance.GetDistance(l1, l4);
      //      double distancexxdscxxx = distance.GetDistance(l1, l5);
      //  //}



        public double GetDistance(Location point1, Location point2)
        {
            var d1 = point1.Latitude * (Math.PI / 180.0);
            var num1 = point1.Longitude * (Math.PI / 180.0);
            var d2 = point2.Latitude * (Math.PI / 180.0);
            var num2 = point2.Longitude * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) +
                     Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);        
                
             double distance=   6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));

            return distance / 1000;
        }
    }
}
