// Problem 3. Static class
// Write a static class with a static method to calculate the distance between two points in the 3D space.

namespace Point3DStructure
{
    using System;

    public static class DistanceCalculator
    {
        public static double CalcDistance(Point3D firstPoint, Point3D secondPoint)
        {
            return Math.Sqrt(((secondPoint.X - firstPoint.X) * (secondPoint.X - firstPoint.X)) +
                             ((secondPoint.Y - firstPoint.Y) * (secondPoint.Y - firstPoint.Y)) +
                             ((secondPoint.Z - firstPoint.Z) * (secondPoint.Z - firstPoint.Z)));
        }
    }
}
