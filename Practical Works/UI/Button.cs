using System;
using static Practical_Works.UI.ConsoleExtented;

namespace Practical_Works.UI
{
    class Button : Component
    {
        public string Text { get; private set; }

        private Action<Button> OnClick;

        public Button(Point position, string text) : base(position, (text.Length + 2, 3))
        {
            Text = text;
        }

        public Button(Point position, Point size, string text) : base(position, size)
        {
            Text = text;
        }

        public override void Draw()
        {
            // ┌ ┐ └ ┘ ─ │ ₽ ├ ┤ ┬ ┴ ┼
            Console.ResetColor();

            if (IsFocus)
                SetColors(Colors.FocusColor, Colors.BackgroundColor);
            else
                SetColors(Colors.TextColor, Colors.BackgroundColor);

            Write(Position, $"┌{"─".Reapet(Size.x)}┐");
            Write(Position + (0, 1), $"│{Text.Center(Size.x)}│");
            Write(Position + (0, 2), $"└{"─".Reapet(Size.x)}┘");

            Console.ResetColor();
        }

        public void AddClickListener(Action<Button> listener) => OnClick = listener;
        public void RemoveClickListener() => OnClick = null;

        public void Click() => OnClick?.Invoke(this);

    }
}
