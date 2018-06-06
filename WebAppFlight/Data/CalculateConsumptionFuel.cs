using GeoCoordinatePortable;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
   public  class CalculateConsumptionFuel
    {
        private const double TakeOffEffort = 2;
        private const double FuelConsumption = 4.2;
        public static double CalculateDistance(GeoCoordinate pointA, GeoCoordinate pointB)
        {
            double dist = 0;
            if (pointA != null && pointB != null)
                dist =  pointA.GetDistanceTo(pointB);
            return dist;
           
        }
        public static double CalculateFuelConsumption(double distance, double flightTime)
        {
            return ((FuelConsumption * distance) / flightTime) + TakeOffEffort;
        }
    }
}
