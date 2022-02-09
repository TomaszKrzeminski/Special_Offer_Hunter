
using System;
using System.Collections.Generic;
using System.Linq;



namespace Special_Offer_Hunter.Models
{
    public static class ExtensionMethods
    {
        public static double CalculateDistance(Location point1, Location point2)
        {
            var d1 = point1.Latitude * (Math.PI / 180.0);
            var num1 = point1.Longitude * (Math.PI / 180.0);
            var d2 = point2.Latitude * (Math.PI / 180.0);
            var num2 = point2.Longitude * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) +
                     Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);
            return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
        }
        public static IQueryable<Shop> ShopIsInDistance(this IQueryable<Shop> @this, double Distance, Location location)
        {

            var d1 = location.Latitude * (Math.PI / 180.0);
            var num1 = location.Longitude * (Math.PI / 180.0);
            List<Shop> except = new List<Shop>();


            foreach (var item in @this)
            {


                double distance = ExtensionMethods.CalculateDistance(item.Location, location);

                //Location loc = item.Location;

                //var d2 = loc.Latitude * (Math.PI / 180.0);
                //var num2 = loc.Longitude * (Math.PI / 180.0) - num1;
                //var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) +
                //         Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);

                //double distance = 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));

                if (distance > Distance)
                {
                    except.Add(item);
                }



            }


            var x = @this.Except(except);

            return x.AsQueryable();

        }

    }
}
