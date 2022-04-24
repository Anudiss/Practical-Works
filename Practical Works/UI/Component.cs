using System;
using static Practical_Works.UI.ConsoleExtented;

namespace Practical_Works.UI
{
    abstract class Component
    {
        public int ID { get; }
        private bool _focus;

        public bool IsFocus
        {
            get => _focus;
            private set => _focus = value;
        }
        public Point Position { get; private set; }
        public Point Size { get; private set; }

        public Component(Point position, Point size)
        {
            Position = position;
            Size = size;
        }

        public abstract void Draw();

        public void Translate(int dx, int dy) => Position += (dx, dy);
        public void SetPosition(int x, int y) => Position = (x, y);
        public void Focus() => _focus = true;
        public void Unfocus() => _focus = false;
        public void RepairBorder(Component parent, Component child)
        {
            if (parent == child)
                return;
            Rectangle parentBounds = parent;
            Rectangle childBounds = child;

            if (Math.Max(parentBounds.A.x, childBounds.B.x) - Math.Min(parentBounds.A.x, childBounds.B.x) > parent.Size.x + child.Size.x)
                return;

            if (Math.Max(parentBounds.A.y, childBounds.D.y) - Math.Min(parentBounds.A.y, childBounds.D.y) > parent.Size.y + child.Size.y)
                return;

            if (childBounds.A.x == parentBounds.A.x)
            {
                if (childBounds.A.y > parentBounds.A.y)
                    Write(childBounds.A, "├");
                if (childBounds.D.y < parentBounds.D.y)
                    Write(childBounds.D - (0, 1), "├");
            }
            if (childBounds.B.x == parentBounds.B.x)
            {
                if (childBounds.B.y > parentBounds.B.y)
                    Write(childBounds.B, "┤");
                if (childBounds.C.y < parentBounds.C.y)
                    Write(childBounds.C - (-1, 1), "┤");
            }
            if (childBounds.A.y == parentBounds.A.y)
            {
                if (childBounds.A.x > parentBounds.A.x)
                    Write(childBounds.A, "┬");
                if (childBounds.B.x < parentBounds.B.x)
                    Write(childBounds.B + (1, 0), "┬");
            }
            if (childBounds.D.y == parentBounds.D.y)
            {
                if (childBounds.D.x > parentBounds.D.x)
                    Write(childBounds.D + (0, -1), "┴");
                if (childBounds.C.x < parentBounds.C.x)
                    Write(childBounds.C + (1, -1), "┴");
            }
            if (childBounds.A.x == parentBounds.B.x)
            {
                if (parentBounds.A.y < childBounds.A.y)
                    Write(childBounds.A, "├");
                else
                    Write(parentBounds.A, "├");
            }
            if (childBounds.A.y == parentBounds.D.y)
            {
                if (parentBounds.D.x < childBounds.A.x)
                    Write(childBounds.A, "┬");
                else
                    Write(parentBounds.D, "┬");

                if (parentBounds.C.x < childBounds.B.x)
                    Write(childBounds.B, "┴");
                else
                    Write(parentBounds.C, "┴");
            }
        }
    }
}
