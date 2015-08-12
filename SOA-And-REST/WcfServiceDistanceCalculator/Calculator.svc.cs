namespace WcfServiceDistanceCalculator
{
    using System;

    public class CalculatorService : ICalculator
    {
        public double CalcDistance(Point startPoint, Point endPoint)
        {
            int deltaX = startPoint.X - endPoint.X,
                deltaY = startPoint.Y - endPoint.Y;
            var pointsDistance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            return pointsDistance;
        }
    }
}
