using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AimBot_CS2
{
    public static class Calculate
    {
        // This method calculates the yaw and pitch angles needed to aim from one point to another
        public static Vector2 CalculateAngles(Vector3 from, Vector3 to)
        {
            float yaw;
            float pitch;

            // Calculate the differences in X and Y coordinates
            float deltaX = to.X - from.X;
            float deltaY = to.Y - from.Y;
            // Calculate yaw angle using arctangent, convert to degrees
            yaw = (float)(Math.Atan2(deltaY, deltaX) * 180 / Math.PI);

            // Calculate the difference in Z coordinate
            float deltaZ = to.Z - from.Z;
            // Calculate the horizontal distance
            double distance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY,2));
            // Calculate pitch angle using arctangent, convert to degrees, and invert
            pitch = -(float)(Math.Atan2(deltaZ, distance) * 180 / Math.PI);

            // Return the calculated angles as a Vector2
            return new Vector2(yaw, pitch);
        }
    }
}