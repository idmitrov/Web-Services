namespace WcfServiceDistanceCalculatorConsoleClient
{
    using System;
    using DistanceService;

    class ConsoleClient
    {
        static void Main()
        {
            Point pointA = new Point(1, 2),
                  pointB = new Point(5, 3);

            var client = new CalculatorClient();
            var pointsDistance = client.CalcDistance(pointA, pointB);

            Console.WriteLine("Distance between point A and point B: {0}", pointsDistance);
        }
    }
}
