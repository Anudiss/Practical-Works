namespace Practical_Works.UI
{
    class Point
    {
        public readonly int x, y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.x + p2.x, p1.y + p2.y);
        }

        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.x - p2.x, p1.y - p2.y);
        }

        public static implicit operator (int x, int y)(Point p)
        {
            return (p.x, p.y);
        }

        public static implicit operator Point((int x, int y) point)
        {
            return new Point(point.x, point.y);
        }
    }
}
