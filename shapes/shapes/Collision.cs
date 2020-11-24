using System;

namespace shapes
{
    public static class Collision
    {
        /// <summary>
        /// Checks if two shapes are interseting
        /// </summary>
        /// <returns></returns>
        public static bool DetectIntersection(Rectangle rectangleOne, Rectangle rectangleTwo)
        {
            Point rectangleOneTopLeft = rectangleOne._topLeft;
            Point rectangleTwoTopLeft = rectangleTwo._topLeft;

            if (rectangleOneTopLeft._x + rectangleOne.width >= rectangleTwoTopLeft._x &&    // rectangle one right edge past rectangle two left
                rectangleOneTopLeft._x <= rectangleTwoTopLeft._x + rectangleTwo.width &&    // rectangle one left edge past rectangle two right
                rectangleOneTopLeft._y + rectangleOne.height >= rectangleTwoTopLeft._y &&   // rectangle one top edge past rectangle two bottom
                rectangleOneTopLeft._y <= rectangleTwoTopLeft._y + rectangleTwo.height)     // rectangle one bottom edge past rectangle two top
            {
                return true;
            }
            else
                return false;
        }

        public static bool DetectIntersection(Circle circleOne, Circle circleTwo)
        {
            Point shapeCenter = circleOne.GetCenter();
            Point testShapeCenter = circleTwo.GetCenter();
            // X1 squared - X2 squared + Y1 squared - Y2 squared
            float totalRadiusSqr = ((circleOne._radius + circleTwo._radius) * (circleOne._radius + circleTwo._radius));

            if (GetDistanceSquared(shapeCenter, testShapeCenter) < totalRadiusSqr)
                return true; // intersection
            else
                return false;
        }

        public static bool DetectIntersection(Rectangle rectangle, Circle circle)
        {
            return DetectIntersection(circle, rectangle);
        }

        public static bool DetectIntersection(Circle circle, Rectangle rectangle)
        {
            Point circleCenter = circle.GetCenter();
            Point rectangleTopLeft = rectangle._topLeft;

            float testX = circleCenter._x;
            float testY = circleCenter._y;

            // Find Closest edge
            if (circleCenter._x < rectangleTopLeft._x)
                testX = rectangleTopLeft._x;        // left edge
            else if (circleCenter._x > rectangleTopLeft._x + rectangle.width)
                testX = rectangleTopLeft._x + rectangle.width;     // right edge

            if (circleCenter._y < rectangleTopLeft._y)
                testY = rectangleTopLeft._y;        // top edge
            else if (circleCenter._y > rectangleTopLeft._y + rectangle.height)
                testY = rectangleTopLeft._y + rectangle.height;     // bottom edge

            float distX = circleCenter._x - testX;
            float distY = circleCenter._y - testY;

            float distanceSqr = (distX * distX) + (distY * distY);
            float totalRadiusSqr = circle._radius * circle._radius;

            if (distanceSqr < totalRadiusSqr)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Gets the distance between two points 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static float GetDistanceSquared(Point a, Point b)
        {
            return ((a._x - b._x) * (a._x - b._x)) + ((a._y - b._y) * (a._y - b._y));
        }
    }
}
