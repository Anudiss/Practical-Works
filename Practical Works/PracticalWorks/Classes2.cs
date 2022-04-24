using static System.Console;
using Practical_Works.UI;
using System.Threading;

namespace Practical_Works.PracticalWorks
{
    class Classes2
    {
        // ┌ ┐ └ ┘ ─ │ ₽ ├ ┤ ┬ ┴ ┼

        public static void Task1()
        {
            Table table = new((5, 5), (60, 20), ("ID", 30), ("Balance", 30));
            BankAccount account = new(812838123, 9123);
            table.AddRow(account);
            table.AddRow(account);
            table.AddRow(account);
            table.AddRow(account);
            table.AddRow(account);
            table.AddRow(account);
            table.AddRow(account);
            table.AddRow(account);
            table.AddRow(account);
            table.AddRow(account);
            table.AddRow(account);
            table.AddRow(account);
            table.Draw();
            while (true)
            {
                Clear();
                table.ScrollDown();
                table.Draw();
                Thread.Sleep(1000);
            }
            ReadKey();

        }

        public static void Task2()
        {

        }

    }

    /*class Window
    {
        private Tab window;
        private Tab left;
        private Tab edit;
        private Table table;

        private Button bankAccounts, builing;
        private Button add;

        public Window()
        {
            Initialize();
            Loop();
        }

        private void Click(Button button)
        {
            if (button.GetHashCode() == add.GetHashCode())
                Title = "Add";
            else if (button.GetHashCode() == bankAccounts.GetHashCode())
                Title = "BankAccounts";
            else if (button.GetHashCode() == builing.GetHashCode())
                Title = "Building";
        }

        private void Loop()
        {
            ConsoleKeyInfo keyInfo;
            while (true)
            {
                Draw();
                keyInfo = ReadKey(true);
                ConsoleKey key = keyInfo.Key;
                if (key == ConsoleKey.UpArrow)
                {
                    if (table.IsFocus)
                    {
                        table.FocusPrevious();
                    }
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    if (table.IsFocus)
                    {
                        table.FocusNext();
                    }
                }
                else if (key == ConsoleKey.Tab)
                {
                    if (keyInfo.Modifiers.HasFlag(ConsoleModifiers.Shift))
                    {
                        window.FocusPrevious();
                    }
                    else
                    {
                        window.FocusNext();
                    }
                    IFocusable focusComponent = window.FocusComponent;
                    if (focusComponent.GetType() == typeof(Tab))
                    {
                        ((Tab)focusComponent).FocusComponent.Focus();
                    } 
                    else if (focusComponent.GetType() == typeof(Table))
                    {
                        ((Table)focusComponent).FocusComponent.Focus();
                    }
                }
                else if (key == ConsoleKey.LeftArrow)
                {
                    if (left.IsFocus)
                        left.FocusPrevious();
                    else if (edit.IsFocus)
                        edit.FocusPrevious();
                }
                else if (key == ConsoleKey.RightArrow)
                {
                    if (left.IsFocus)
                        left.FocusNext();
                    else if (edit.IsFocus)
                        edit.FocusNext();
                }
                else if (key == ConsoleKey.Enter)
                {
                    if (left.IsFocus || edit.IsFocus)
                    {
                        Button focusedButton;
                        if (left.IsFocus)
                            focusedButton = (Button)left.FocusComponent;
                        else
                            focusedButton = (Button)edit.FocusComponent;
                        focusedButton.Click();
                    }
                    else if (table.IsFocus)
                    {
                        Tuple tuple = (Tuple)table.FocusComponent;
                        Title = $"Changing - {tuple.Index}";
                    }
                }
            }
        }

        private void Initialize()
        {
            bankAccounts = new Button(position: (1, 0), text: "Банковские счета");
            bankAccounts.AddClickListener(Click);
            builing = new Button(position: (1, 4), text: "   Здания   ");
            builing.AddClickListener(Click);

            left = new Tab(bankAccounts, builing);

            add = new Button(position: (20, 0), text: "Добавить");
            add.AddClickListener(Click);

            edit = new Tab(add);

            table = new Table(position: (20, 4), width: WindowWidth - 20, ("Номер счёта", 0.7), ("Баланс", 0.3));
            BankAccount bankAccount1 = new(accountNumber: 1023012, balance: 20031);
            table.AddTuple(bankAccount1);
            table.AddTuple(bankAccount1);
            table.AddTuple(bankAccount1);
            table.AddTuple(bankAccount1);

            window = new Tab(left, edit, table);
            window.Focus();
        }

        private void Draw()
        {
            Clear();
            bankAccounts.Draw();
            builing.Draw();

            CursorLeft = 19;
            CursorTop = 0;
            for (int i = 0; i < WindowHeight; i++)
            {
                Write("│");
                CursorTop++;
                CursorLeft--;
            }

            CursorTop = 3;
            CursorLeft = 19;
            Write($"├{"─".Reapet(WindowWidth - 20)}");
            
            add.Draw();

            table.Draw();
            CursorLeft = 0;
            CursorTop = 0;
        }
    }

    class Tab : IFocusable
    {
        private List<IFocusable> _components = new();
        
        public int CurrentFocus { get; private set; } = -1;

        public IFocusable FocusComponent
        {
            get
            {
                if (CurrentFocus == -1)
                    return null;
                return _components[CurrentFocus];
            }
        }
        
        public bool IsFocus { get; private set; }

        public Tab(params IFocusable[] components)
        {
            _components.AddRange(components);
        }

        public void Add(IFocusable component) => _components.Add(component);

        public void FocusNext()
        {
            if (IsFocus == false)
                return;
            CurrentFocus++;
            CurrentFocus %= _components.Count;
            foreach (var component in _components)
                component.Unfocus();
            _components[CurrentFocus].Focus();
        }

        public void FocusPrevious()
        {
            if (IsFocus == false)
                return;
            CurrentFocus--;
            if (CurrentFocus < 0)
                CurrentFocus += _components.Count;
            foreach (var component in _components)
                component.Unfocus();
            _components[CurrentFocus].Focus();
        }

        public void Focus()
        {
            if (IsFocus)
                return;
            IsFocus = true;
            CurrentFocus = 0;
        }

        public void Unfocus()
        {
            if (IsFocus == false)
                return;
            IsFocus = false;
            CurrentFocus = -1;
            foreach (var component in _components)
                component.Unfocus();
        }
    }

    class Button : IFocusable
    {
        private string _text;
        private bool _focus = false;

        public Point Position { get; private set; }
        public int Width { get; private set; }
        public const int Height = 3;

        private Action<Button> OnClick;

        public Button(Point position, string text)
        {
            Position = position;
            _text = text;
        }

        public void Draw()
        {
            ResetColor();

            // ┌┐└┘─│
            ForegroundColor = Classes2.TextColor;
            if (_focus)
                BackgroundColor = Classes2.FocusColor;
            else
                BackgroundColor = Classes2.BackgroundColor;

            CursorLeft = Position.x;
            CursorTop = Position.y;
            Write($"┌{"─".Reapet(_text.Length)}┐");
            
            CursorLeft = Position.x;
            CursorTop = Position.y + 1;
            Write($"│{_text}│");

            CursorLeft = Position.x;
            CursorTop = Position.y + 2;
            Write($"└{"─".Reapet(_text.Length)}┘");

            ResetColor();
        }

        public void Click() => OnClick?.Invoke(this);

        public void AddClickListener(Action<Button> action) => OnClick = action;
        public void RemoveClickListener() => OnClick = null;

        public void Focus()
        {
            if (_focus)
                return;
            _focus = true;
            Draw();
        }

        public void Unfocus()
        {
            if (_focus == false)
                return;
            _focus = false;
            Draw();
        }
    }

    class InputField : IFocusable
    {
        private bool _focus = true;

        public bool IsFocus
        {
            get => _focus;
            private set => _focus = value;
        }

        public void Focus()
        {

        }

        public void Unfocus()
        {

        }
    }

    class Table : IFocusable
    {
        private List<Tuple> _lines = new();
        private int _offset;
        private Tab tab;

        public Point Position { get; private set; }
        public int Width { get; }
        public string[] Headers { get; }
        public int[] Widths { get; }
        public int Offset
        {
            get => _offset;
            private set
            {
                _offset = Math.Max(0, Math.Min(value, _lines.Count - Max));
            }
        }
        public int Max { get; }
        public bool IsFocus { get; private set; }
        public IFocusable FocusComponent { get => tab.FocusComponent; }

        public Table(Point position, int width, params string[] headers)
        {
            Headers = headers;
            Widths = Headers.Select(e => width / Headers.Length).ToArray();
            Position = position;
            Width = width;
            Max = (WindowHeight - position.y - 2) / 2 - 1;
            Max -= Max % 2;

            tab = new Tab();
        }

        public Table(Point position, int width, params (string header, double width)[] headers)
        {
            Position = position;
            Width = width;
            Headers = headers.Select(e => e.header).ToArray();
            Widths = headers.Select(e => (int)(e.width * width)).ToArray();
            Max = (WindowHeight - position.y - 2) / 2 - 1;
            Max -= Max % 2;

            tab = new Tab();
        }

        public void FocusNext()
        {
            if (IsFocus == false)
                return;
            tab.FocusNext();
            Offset = Math.Max(0, Math.Min(tab.CurrentFocus - Max + 1, Offset + Max - 1));
        }

        public void FocusPrevious()
        {
            if (IsFocus == false)
                return;
            tab.FocusPrevious();
            Offset = Math.Max(0, Math.Min(tab.CurrentFocus - Max + 1, Offset + Max - 1));
        }

        public void Focus()
        {
            if (IsFocus)
                return;
            IsFocus = true;
            tab.Focus();
        }

        public void Unfocus()
        {
            if (IsFocus == false)
                return;
            IsFocus = false;
            tab.Unfocus();
        }

        public void ScrollUp()
        {
            Offset++;
        }

        public void ScrollDown()
        {
            Offset--;
        }

        public void Draw()
        {
            // ┌ ┐ └ ┘ ─ │ ₽ ├ ┤ ┬ ┴ ┼
            ResetColor();

            ForegroundColor = Classes2.TextColor;
            BackgroundColor = Classes2.BackgroundColor;
            for(int i = 0; i < Headers.Length; i++)
            {
                int offset = (Widths[i] - Headers[i].Length) / 2;
                int x = Position.x + Widths.Where((e, index) => index < i).Sum();

                CursorLeft = x;
                CursorTop = Position.y;
                Write($"┬{"─".Reapet(Widths[i] - 1)}");

                CursorLeft = x;
                CursorTop = Position.y + 1;
                Write($"│{Headers[i].Center(Widths[i] - 1)}");

                CursorLeft = x;
                CursorTop = Position.y + 2;
                Write($"┴{"─".Reapet(Widths[i] - 1)}");
            }
            CursorLeft = Position.x;
            CursorTop = Position.y;
            Write("┌");
            CursorLeft = Position.x + Width - 1;
            Write("┐");
            CursorLeft = Position.x + Width - 1;
            CursorTop = Position.y + 1;
            Write("│");
            CursorLeft = Position.x;
            CursorTop = Position.y + 2;
            Write("└");
            CursorLeft = Position.x + Width - 1;
            Write("┘");

            IEnumerable<Tuple> lines = _lines.ToArray().Where((e, i) => i >= Offset && i < Offset + Max + 1);
            foreach (var line in lines)
                line.Draw(this);

            ForegroundColor = Classes2.TextColor;
            BackgroundColor = Classes2.BackgroundColor;

            CursorLeft = Position.x;
            CursorTop = Position.y + lines.Count() * 2 + 2;
            Write("└");
            for (int i = 0; i < Widths.Length; i++)
            {
                Write($"{"─".Reapet(Widths[i] - 1)}┴");
            }
            CursorLeft = Math.Min(Position.x + Widths.Sum(), WindowWidth - 1);
            CursorTop = Position.y + lines.Count() * 2 + 2;
            Write("┘");

            ResetColor();
            Write(" ");
        }

        public void AddTuple(string[] tuple)
        {
            Tuple t = new(_lines.Count, tuple);
            _lines.Add(t);
            tab.Add(t);
        }
    }

    class Tuple : IFocusable
    {
        private readonly string[] _values;
        private bool _focus = false;

        public int Index { get; }

        public Tuple(int index, params string[] values)
        {
            _values = values;
            Index = index;
        }

        public void Draw(Table table)
        {
            if (table.Widths.Length != _values.Length)
                throw new ArgumentOutOfRangeException();
            ResetColor();
            // ┌ ┐ └ ┘ ─ │ ₽ ├ ┤ ┬ ┴ ┼

            int index = Index - table.Offset;
            Point position = table.Position;
            for(int i = 0; i < _values.Length; i++)
            {
                ForegroundColor = Classes2.TextColor;
                BackgroundColor = Classes2.BackgroundColor;
                int offset = (table.Widths[i] - _values[i].Length) / 2;
                int y = position.y + index * 2 + 2;
                int x = position.x + table.Widths.Where((e, index) => index < i).Sum();
                CursorLeft = x;
                CursorTop = y;
                Write($"┼{"─".Reapet(table.Widths[i] - 1)}");
                CursorLeft = x;
                CursorTop = y + 1;
                if (_focus)
                    BackgroundColor = Classes2.FocusColor;
                Write($"│{_values[i].Center(table.Widths[i] - 1)}");
            }
            BackgroundColor = Classes2.BackgroundColor;
            CursorLeft = position.x + table.Width - 1;
            CursorTop = position.y + index * 2 + 2;
            Write("┤");
            CursorLeft = position.x;
            CursorTop = position.y + index * 2 + 2;
            Write("├");
            CursorTop = position.y + index * 2 + 3;
            CursorLeft = position.x + table.Width - 1;
            if (_focus)
                BackgroundColor = Classes2.FocusColor;
            Write("│");

            CursorLeft = position.x;
            CursorTop = position.y + index * 2 + 3;
            Write($"{Index}");

            ResetColor();
        }

        public void Focus()
        {
            if (_focus)
                return;
            _focus = true;
        }

        public void Unfocus()
        {
            if (_focus == false)
                return;
            _focus = false;
        }
    }*/

    class BankAccount : TableElement
    {
        private readonly ulong _accountNumber;
        private double _balance;

        public double Balance
        {
            get => _balance;
            set
            {
                if (value < 0)
                    return;
                _balance = value;
            }
        }

        public BankAccount(ulong accountNumber, double balance)
        {
            _accountNumber = accountNumber;
            _balance = balance;
        }

        public void TakeOut(double money)
        {
            if (_balance < money)
                return;
            _balance -= money;
        }

        public void PutIn(double money) => _balance += money;

        public override string[] ToStringArray()
        {
            return new string[] { $"{_accountNumber}", $"{Balance:0.00}" };
        }

        public static implicit operator string[](BankAccount account)
        {
            return new string[] { $"{account._accountNumber}", $"{account.Balance:0.00} ₸"};
        }
    }
}
