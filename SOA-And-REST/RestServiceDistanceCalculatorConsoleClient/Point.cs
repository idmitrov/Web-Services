namespace RestServiceDistanceCalculatorConsoleClient
{
    public class Point
    {
        public Point()
        {
        }

        public Point(int posX, int posY)
        {
            this.X = posX;
            this.Y = posY;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
