using System;

namespace Practical_Works.UI
{
    static class ConsoleExtented
    {
        public static void Write(Point position, string text)
        {
            Console.CursorLeft = position.x;
            Console.CursorTop = position.y;
            Console.Write(text);
        }

        public static void SetColors(ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
        }
    }
}
