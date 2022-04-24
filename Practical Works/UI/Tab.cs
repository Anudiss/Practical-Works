using System;
using System.Collections.Generic;
using System.Linq;
using static Practical_Works.UI.ConsoleExtented;

namespace Practical_Works.UI
{
    class Tab : Component, IContainer
    {
        private readonly List<Component> _components = new();
        private int _componentIndex = -1;

        public int ComponentIndex
        {
            get => _componentIndex;
            private set
            {
                if (value < 0)
                    _componentIndex = (_components.Count + value);
                else
                    _componentIndex = value % _components.Count;
            }
        }

        public Component FocusComponent
        {
            get => _components[_componentIndex];
        }

        public Tab(Point position, Point size, params Component[] components) : base(position, size)
        {
            _components.AddRange(components);
        }

        public Tab(params Component[] components) 
            : base((components.Min(e => e.Position.x), components.Min(e => e.Position.y)),
                   (components.Max(e => e.Position.x + e.Size.x) - components.Min(e => e.Position.x), 
                    components.Max(e => e.Position.y + e.Size.y) - components.Min(e => e.Position.y)))
        {
            _components.AddRange(components);
        }

        public override void Draw()
        {
            // ┌ ┐ └ ┘ ─ │ ₽ ├ ┤ ┬ ┴ ┼
            Console.ResetColor();

            Write(Position, $"┌{"─".Reapet(Size.x)}┐");
            for (int i = 1; i < Size.y - 1; i++)
                Write(Position + (0, i), $"│{" ".Reapet(Size.x)}│");
            Write(Position + (0, Size.y - 1), $"└{"─".Reapet(Size.x)}┘");

            foreach (var component in _components)
            {
                component.Draw();
                foreach (var child in _components)
                    RepairBorder(component, child);
                RepairBorder(this, component);
            }
            
            Console.ResetColor();
        }

        public void FocusNext()
        {
            throw new NotImplementedException();
        }

        public void FocusPrevious()
        {
            throw new NotImplementedException();
        }
    }
}
