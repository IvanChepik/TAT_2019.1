namespace Points
{
    public struct Point
    {
        public int XCoordinate { get; }

        public int YCoordinate { get; }

        public int ZCoordinate { get; }

        public Point(int xCoordinate, int yCoordinate, int zCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            ZCoordinate = zCoordinate;
        }
    }
}
