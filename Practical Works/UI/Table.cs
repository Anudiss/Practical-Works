using System;
using System.Linq;
using System.Collections.Generic;
using static Practical_Works.UI.ConsoleExtented;

namespace Practical_Works.UI
{
    class Table : Component
    {
        private int _offset = 0;

        public (string title, int width)[] Headers { get; }
        public List<TableElement> Rows { get; } = new();
        public int FocusRowIndex
        {
            get => _offset;
            private set
            {
                _offset = value < 0 ? Rows.Count + value : value % Rows.Count;
                Console.Title = $"{_offset}";
            }
        }
        public int MaxRows { get; }

        public Table(Point position, Point size, params (string title, int width)[] headers) : base(position, size)
        {
            Headers = headers;
            MaxRows = (size.y - 2) / 2;
        }

        public override void Draw()
        {
            // ┌ ┐ └ ┘ ─ │ ₽ ├ ┤ ┬ ┴ ┼
            Console.ResetColor();

            #region Table header drawing
            Write(Position, $"┌{"─".Reapet(Size.x - 2)}┐");

            string[] titles = Headers.Select(e => e.title).ToArray();
            int[] widths = Headers.Select(e => e.width).ToArray();

            for (int i = 0; i < titles.Length; i++)
            {
                Write(Position + (widths[0..i].Sum(), 1), $"|{titles[i].Center(widths[i])}");
            }

            Write(Position + (Size.x - 1, 1), "|");
            Write(Position + (0, 2), $"└{"─".Reapet(Size.x - 2)}┘");

            for (int i = 1; i < widths.Length; i++)
            {
                Write(Position + (widths[..i].Sum(), 0), "┬");
                Write(Position + (widths[..i].Sum(), 2), "┴");
            }
            #endregion

            #region Rows drawing
            var visibleRows = Rows.Where((e, i) => i >= FocusRowIndex && i < FocusRowIndex + MaxRows);

            foreach ((TableElement row, int index) in visibleRows) 
            {
                Point rowPosition = Position + (0, 2 + (index - FocusRowIndex) * 2);
                string[] values = row.ToStringArray();

                Write(rowPosition, $"├{"─".Reapet(Size.x - 2)}┤");

                if (index == FocusRowIndex)
                    Console.BackgroundColor = Colors.FocusColor;
                for (int i = 0; i < values.Length; i++)
                {
                    Write(rowPosition + (widths[0..i].Sum(), 1), $"{values[i].Center(widths[i])}");
                    Write(rowPosition + (widths[0..i].Sum(), 1), $"{index}");
                }
                Console.BackgroundColor = Colors.BackgroundColor;

                Write(rowPosition + (Size.x - 1, 1), "|");
                Write(rowPosition + (0, 2), $"└{"─".Reapet(Size.x - 2)}┘");

                for (int i = 1; i < widths.Length; i++)
                {
                    Write(rowPosition + (widths[..i].Sum(), 0), "┼");
                    Write(rowPosition + (widths[..i].Sum(), 2), "┴");
                }
            }

            #endregion
            Console.ResetColor();
        }

        public void AddRow(TableElement row) => Rows.Add(row);
        public void RemoveRow(int index) => Rows.RemoveAt(index);
        public void ScrollUp() => FocusRowIndex--;
        public void ScrollDown() => FocusRowIndex++;
    }
}
