namespace RestServiceDistanceCalculator.Controllers
{
    using System;
    using Models;
    using System.Web.Http;

    [RoutePrefix("points")]
    public class PointsController : ApiController
    {
        [Route("CalcDistance")]
        [HttpGet]
        public double CalcDistance(int startX, int startY, 
            int endX, int endY)
        {
            Point startPoint = new Point(startX, startY),
                  endPoint = new Point(endX, endY);

            int deltaX = startPoint.X - endPoint.X,
                deltaY = startPoint.Y - endPoint.Y;
            var pointsDistance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            return pointsDistance;
        }
    }
}
