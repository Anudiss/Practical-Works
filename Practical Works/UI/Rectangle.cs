namespace Practical_Works.UI
{
    class Rectangle
    {
        public Point A { get; private set; }
        public Point B { get => (C.x, A.y); }
        public Point C { get; private set; }
        public Point D { get => (A.x, C.y); }

        public Rectangle(Point a, Point c)
        {
            A = a;
            C = c;
        }

        public bool Contains(Point p) => (A.x > p.x || A.y > p.y || C.x < p.x || C.y < p.y) == false;

        public static implicit operator Rectangle(Component component) => new(component.Position, component.Position + component.Size);
    }
}
