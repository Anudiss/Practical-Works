using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using static System.ConsoleColor;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;

namespace Practical_Works
{
    class Menu
    {
        public const int Width = 120;
        public const int DescriptionLength = Width / 3;

        public static int CreateMenu(string title, List<(string Name, PracticalWork MainClass)> choose)
        {
            CursorVisible = false;
            int selected = 0;
            int max = choose.Count;

            ConsoleKey key;
            do
            {
                Clear();
                ResetColor();
                WriteLine(title);

                for (int i = 0; i < choose.Count; i++)
                {
                    if (i == selected)
                    {
                        BackgroundColor = ConsoleColor.White;
                        ForegroundColor = ConsoleColor.Black;
                    }

                    WriteLine($"\t{choose[i].Name}");
                    ResetColor();
                }

                key = ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                    selected--;
                else if (key == ConsoleKey.DownArrow)
                    selected++;
                else if (key == ConsoleKey.Escape)
                    return -1;

                HoldInside(ref selected, max);
            } while (key != ConsoleKey.Enter);

            CursorVisible = true;
            return selected;
        }

        public static int CreateMenu(string title, List<(string Name, string Description, Action Method)> choose)
        {
            CursorVisible = false;
            int selected = 0;
            int max = choose.Count;
            bool descriptionShow = false;

            ConsoleKey key;
            do
            {
                Clear();
                ResetColor();
                WriteLine(title);

                for (int i = 0; i < choose.Count; i++)
                {
                    if (i == selected)
                    {
                        BackgroundColor = ConsoleColor.White;
                        ForegroundColor = ConsoleColor.Black;
                    }

                    WriteLine($"  {choose[i].Name}");
                    ResetColor();
                }

                if (descriptionShow)
                {
                    int maxLength = choose.Max(e => $"  {e.Name}".Length);
                    int x = maxLength + 3;
                    string description = choose[selected].Description;

                    string[] descriptionPresent = Regex.Split(description, @"\s+");
                    int length = 0;
                    descriptionPresent = descriptionPresent.Aggregate((a, b) =>
                    {
                        string newString = $"{a} {b}";
                        if (newString.Length - length < DescriptionLength)
                            return newString;
                        length = newString.Length;
                        return $"{a}\n{b}";
                    }).Split("\n");

                    SetCursorPosition(left: x - 2, selected + 1);
                    Write($"-");
                    for (int i = 0; i < descriptionPresent.Length; i++)
                    {
                        CursorLeft = x;
                        WriteLine($"{descriptionPresent[i]}");
                    }
                }

                key = ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                    selected--;
                else if (key == ConsoleKey.DownArrow)
                    selected++;
                else if (key == ConsoleKey.RightArrow)
                    descriptionShow = !descriptionShow;
                else if (key == ConsoleKey.Escape)
                    return -1;

                HoldInside(ref selected, max);
            } while (key != ConsoleKey.Enter);

            CursorVisible = true;
            return selected;
        }

        public static void ShowErrorMenu(string title, string text, int maxLength = 50)
        {
            CursorVisible = false;
            string[] textPresent = Regex.Split(text, @"\s+");
            int length = 0;
            textPresent = textPresent.Aggregate((a, b) =>
            {
                string newString = $"{a} {b}";
                if (newString.Length - length < maxLength)
                    return newString;
                length = newString.Length;
                return $"{a}\n{b}";
            }).Split("\n");

            int width = maxLength, height = textPresent.Length + 1;
            int x = (WindowWidth - width) / 2,
                y = (WindowHeight - height) / 2;
            string empty = string.Join("", Enumerable.Repeat(" ", width));

            ForegroundColor = ConsoleColor.White;
            BackgroundColor = ConsoleColor.Red;

            CursorLeft = x;
            CursorTop = y;
            Write(empty);

            CursorLeft = x + (width - title.Length) / 2;
            Write(title);

            ForegroundColor = ConsoleColor.Black;
            BackgroundColor = ConsoleColor.Gray;
            for(int i = 0; i < textPresent.Length; i++)
            {
                CursorTop = y + i + 1;
                CursorLeft = x;
                Write(empty);

                CursorLeft = x;
                Write(textPresent[i]);
            }
            CursorLeft = x;
            CursorTop = y + textPresent.Length + 1;
            Write(empty);

            ReadKey();
            ResetColor();
            CursorVisible = true;
        }

        public static void CreateTextMenu(string title, string text, int x, int y, int maxLength = 50)
        {
            string[] paragraph = Regex.Split(text, @"\n+");
            string[][] lines = new string[paragraph.Length][];
            for (int i = 0; i < paragraph.Length; i++)
            {
                int length = 0;
                lines[i] = Regex.Split(paragraph[i], @"\s")
                                .Select(e => e == "" ? " " : e)
                                .Aggregate((a, b) =>
                                {
                                    string newString;
                                    if (a == " " || b == " ")
                                        newString = $"{a}{b}";
                                    else
                                        newString = $"{a} {b}";
                                    if (newString.Length - length <= maxLength)
                                        return newString;
                                    length = newString.Length;
                                    return $"{a}\n{b}";
                                })
                                .Split("\n");
            }

            int width = maxLength, height = lines.Sum(e => e.Length) + 1;
            x = Math.Max(0, Math.Min(x, 120));
            y = Math.Max(0, Math.Min(y, 30));

            string empty = string.Join("", Enumerable.Repeat(" ", maxLength));

            BackgroundColor = White;
            ForegroundColor = Black;

            CursorLeft = x;
            CursorTop = y;
            Write(empty);
            CursorTop = y;
            CursorLeft = x + (maxLength - title.Length) / 2;
            Write(title);

            ForegroundColor = Black;
            BackgroundColor = Gray;
            int lineCounter = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    CursorTop = y + lineCounter++ + 1;
                    CursorLeft = x;
                    Write(empty);

                    CursorLeft = x;
                    Write(lines[i][j]);

                }
            }

            ResetColor();
        }

        public static IEnumerable<string> CreateInputMenu(string title, int width = 50, params string[] inputFields)
        {
            CursorVisible = false;
            int count = inputFields.Length;
            string[] inputs = new string[count];
            int maxLength = inputFields.Max(e => $"{e}: ".Length);

            int height = 2 + count * 2;
            int x = (WindowWidth - width) / 2, y = (WindowHeight - height) / 2;

            string empty = string.Join("", Enumerable.Repeat(" ", width));

            ForegroundColor = ConsoleColor.Black;
            BackgroundColor = ConsoleColor.White;
            CursorTop = y;
            CursorLeft = x;
            Write(empty);
            CursorLeft = x + width / 2 - title.Length / 2;
            Write(title);

            int i = 0;
            foreach (var field in inputFields)
            {
                BackgroundColor = ConsoleColor.Gray;
                CursorLeft = x;
                CursorTop = y + i * 2 + 1;
                Write(empty);

                CursorLeft = x;
                Write($"{field}: ");

                CursorLeft = x;
                CursorTop++;
                Write(empty);

                i++;
            }

            i = 0;
            foreach (var field in inputFields)
            {
                CursorLeft = x + maxLength;
                CursorTop = y + i * 2 + 1;

                CursorVisible = true;
                inputs[i] = ReadLine();

                CursorVisible = false;
                i++;
            }
            ResetColor();
            Clear();
            CursorVisible = true;
            return inputs;
        }

        public static IEnumerable<object> CreateInputMenu(string title, int width = 50, params (string title, InputType type)[] inputFields)
        {
            string double_pattern = @"\d+(,\d+)?";
            string int_pattern = @"\d+";
            string roman_pattern = @"[^IVXCMDL]+";
            string binary_pattern = @"[^10]+";
            string[] values = new string[inputFields.Length];
            object[] input = new object[values.Length];
            bool isValid = true;
            while(isValid == true)
            {
                values = CreateInputMenu(title, width, inputFields.Select(e => e.title).ToArray()).ToArray();
                for (int i = 0; i < inputFields.Length; i++)
                {
                    if (isValid == false)
                        break;
                    InputType type = inputFields[i].type;
                    switch (type)
                    {
                        case InputType.Double:
                            values[i] = Regex.Replace(values[i], @"\.", ",");
                            if (Regex.IsMatch(values[i], double_pattern) == false)
                            {
                                ShowErrorMenu("Ошибка ввода", "Ожидается тип Double");
                                isValid = false;
                                break;
                            }
                            input[i] = double.Parse(values[i]);
                            break;
                        case InputType.Int:
                            if (Regex.IsMatch(values[i], int_pattern) == false)
                            {
                                ShowErrorMenu("Ошибка ввода", "Ожидается тип Int32");
                                isValid = false;
                                break;
                            }
                            input[i] = int.Parse(values[i]);
                            break;
                        case InputType.String:
                            input[i] = values[i];
                            break;
                        case InputType.Roman:
                            if (Regex.IsMatch(values[i].ToUpper(), roman_pattern) == true)
                            {
                                ShowErrorMenu("Ошибка ввода", "Ожидаются римские цифры");
                                isValid = false;
                                break;
                            }

                            input[i] = values[i].ToUpper();
                            break;
                        case InputType.Binary:
                            if (Regex.IsMatch(values[i], binary_pattern))
                            {
                                ShowErrorMenu("Ошибка ввода", "Ожидается число в двоичной системе счисления");
                                isValid = false;
                                break;
                            }

                            input[i] = values[i];
                            break;
                    }
                }
                isValid = !isValid;
            }
            return input;
        }

        public static IEnumerable<string> CreateInputMenu(string title, params string[] inputFields)
        {
            return CreateInputMenu(title, 50, inputFields);
        }

        public static IEnumerable<object> CreateInputMenu(string title, params (string title, InputType type)[] inputFields)
        {
            return CreateInputMenu(title, 50, inputFields);
        }

        public static void CreateFolderView(string path)
        {
            CursorVisible = false;
            int cols = 5;
            List<(string name, bool isFolder)> content = LoadFolderContent(path);
            int selected = 0;

            DrawFolderContent(content, selected);

            ConsoleKeyInfo key;
            do
            {
                key = ReadKey(true);

                if (key.Key == ConsoleKey.LeftArrow)
                    selected--;
                else if (key.Key == ConsoleKey.RightArrow)
                    selected++;
                else if (key.Key == ConsoleKey.Enter)
                {
                    (string name, bool isFolder) = content[selected];
                    if (isFolder)
                        CreateFolderView($"{path}/{name}");
                    else
                        CreateFileEditor($"{path}/{name}");
                    CursorVisible = false;
                }
                else if (key.Key == ConsoleKey.N && key.Modifiers.HasFlag(ConsoleModifiers.Control))
                {
                    string name = CreateInputMenu("Создание файла", 50, "Название").First();
                    if (Regex.IsMatch(name, @"[\w^\.]+\.[\w^\.]+"))
                    {
                        string newFile = $"{path}/{name}";
                        if (File.Exists(newFile) == false)
                            File.Create(newFile).Close();
                        else
                            CreateConfirmMenu("Внимание", "Такой файл уже существует", 50, "Ок");
                    }
                    else 
                    {
                        string newDirectory = $"{path}/{name}";
                        if (Directory.Exists(newDirectory) == false)
                            Directory.CreateDirectory(newDirectory);
                        else
                            CreateConfirmMenu("Внимание", "Такая папка уже существует", 50, "Ок");
                    }

                    content = LoadFolderContent(path).OrderBy(e => e.name).ToList();
                    selected = 0;
                    CursorVisible = false;
                }
                else if (key.Key == ConsoleKey.Delete)
                {
                    string deletePath = $"{path}/{content[selected].name}";
                    int answer = CreateConfirmMenu("Удаление", $"Уверены, что хотите удалить {content[selected].name}", 50, "Да", "Нет");
                    if (answer == 0)
                    {
                        if (content[selected].isFolder)
                        {
                            Directory.Delete(deletePath, true);
                        }
                        else
                        {
                            File.Delete(deletePath);
                        }
                    }

                    content = LoadFolderContent(path).OrderBy(e => e.name).ToList();
                    selected = 0;
                }

                HoldInside(ref selected, content.Count);

                DrawFolderContent(content, selected);

            } while (key.Key != ConsoleKey.Escape);
            CursorVisible = true;
        }

        public static void CreateFileEditor(string path)
        {
            string[] extensions = { ".txt" };
            FileInfo file = new(path);
            if (extensions.Contains(file.Extension) == false)
            {
                CreateConfirmMenu("Внимание", "Этот тип файлов не поддерживается", 50, "Ок");
                return;
            }
            CursorVisible = true;
            StringBuilder lines = new();
            using (var reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                    lines.AppendLine(line);
            }
            int offset = 4;
            string empty = string.Join("", Enumerable.Repeat(" ", Width - offset - 1));
            ResetColor();
            ConsoleKeyInfo key;
            (int x, int y) = (0, 0);
            do
            {
                ResetColor();
                Clear();
                WriteLine(file.Name);
                string[] linesSplit = lines.ToString().Split("\n");
                for (int i = 0; i < linesSplit.Length; i++)
                {
                    CursorLeft = 0;
                    CursorTop = i + 1;
                    BackgroundColor = ConsoleColor.Black;
                    ForegroundColor = ConsoleColor.White;
                    Write($"{i + 1, 3} ");

                    BackgroundColor = ConsoleColor.White;
                    ForegroundColor = ConsoleColor.Black;
                    CursorLeft = offset;
                    Write(empty);
                    CursorLeft = offset;
                    if (linesSplit[i].Length >= Width)
                        WriteLine(linesSplit[i][0..(Width)]);
                    else
                        WriteLine(linesSplit[i]);
                }
                SetCursorPosition(x + offset, y + 1);

                key = ReadKey(true);

                if (key.Key == ConsoleKey.LeftArrow)
                {
                    x--;
                    int linesLength = linesSplit[y].Length;
                    if (x > linesLength)
                    {
                        x = 0;
                        y++;
                        if (y < 0)
                            y = 0;
                        else if (y >= linesSplit.Length)
                            y = linesSplit.Length - 1;
                    }
                    else if (x < 0)
                    {
                        y--;
                        if (y < 0)
                            y = 0;
                        else if (y >= linesSplit.Length)
                            y = linesSplit.Length - 1;
                        x = linesSplit[y].Length;
                    }
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    x++;
                    int linesLength = linesSplit[y].Length;
                    if (x > linesLength)
                    {
                        x = 0;
                        y++;
                        if (y < 0)
                            y = 0;
                        else if (y >= linesSplit.Length)
                            y = linesSplit.Length - 1;
                    }
                    else if (x < 0)
                    {
                        y--;
                        if (y < 0)
                            y = 0;
                        else if (y >= linesSplit.Length)
                            y = linesSplit.Length - 1;
                        x = linesSplit[y].Length;
                    }
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    y--;
                    if (y < 0)
                        y = 0;
                    else if (y >= linesSplit.Length)
                        y = linesSplit.Length - 1;

                    int linesLength = linesSplit[y].Length;
                    if (x > linesLength)
                        x = linesLength;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    y++;
                    if (y < 0)
                        y = 0;
                    else if (y >= linesSplit.Length)
                        y = linesSplit.Length - 1;

                    int linesLength = linesSplit[y].Length;
                    if (x > linesLength)
                        x = linesLength;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    int answer = CreateConfirmMenu("Сохранить и выйти?", "Сохранить?", 50, "Да", "Нет", "Отмена");
                    if (answer == 0)
                    {
                        SaveFile(path, lines);
                        break;
                    } 
                    else if (answer == 1)
                    {
                        break;
                    }
                }
                else
                {
                    int i = linesSplit.Where((e, i) => i < y).Sum(e => e.Length) + x 
                            + linesSplit.Where((e, i) => i < y).Count();
                    char[] chars = GetChars(key);
                    if (i <= lines.Length && i >= 0)
                    {
                        if (key.Key == ConsoleKey.Backspace && i - 1 >= 0)
                        {
                            lines.Remove(i - 1, 1);
                            x--;
                            if (x < 0)
                            {
                                y--;
                                if (y < 0)
                                    y = 0;
                                else if (y >= linesSplit.Length)
                                    y = linesSplit.Length - 1;
                                int length = linesSplit[y].Length;
                                x = length;
                            }
                        }
                        else
                        {
                            lines.Insert(i, chars);
                            if (key.Key == ConsoleKey.Enter)
                            {
                                x = 0;
                                y++;
                            }
                            else
                                x += chars.Length;
                        }
                    }
                    else
                        if (key.Key != ConsoleKey.Backspace)
                        {
                            lines.Append(GetChars(key));
                            if (key.Key == ConsoleKey.Enter)
                            {
                                x = 0;
                                y++;
                            } 
                            else
                                x += chars.Length;
                    }

                }

            } while (true);
        }

        private static void SaveFile(string path, StringBuilder content)
        {
            using (var writer = new StreamWriter(path))
            {
                writer.Write(content);
                writer.Close();
            }
        }

        private static char[] GetChars(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.Enter)
                return "\n".ToCharArray();
            if (key.Key == ConsoleKey.Tab)
                return "    ".ToCharArray();

            return new char[] { key.KeyChar };
        }

        public static int CreateConfirmMenu(string title, string text, int maxLength = 50, params string[] buttons)
        {
            string[] paragraph = Regex.Split(text, @"\n+");
            string[][] lines = new string[paragraph.Length][];
            for(int i = 0; i < paragraph.Length; i++)
            {
                int length = 0;
                lines[i] = Regex.Split(paragraph[i], @"\s")
                                .Select(e => e == "" ? " " : e)
                                .Aggregate((a, b) =>
                                {
                                    string newString;
                                    if (a == " " || b == " ")
                                        newString = $"{a}{b}";
                                    else
                                        newString = $"{a} {b}";
                                    if (newString.Length - length <= maxLength)
                                        return newString;
                                    length = newString.Length;
                                    return $"{a}\n{b}";
                                })
                                .Split("\n");
            }

            int width = maxLength, height = lines.Sum(e => e.Length) + 1;
            int x = (WindowWidth - width) / 2,
                y = (WindowHeight - height) / 2;
            string empty = string.Join("", Enumerable.Repeat(" ", width));

            ForegroundColor = Black;
            BackgroundColor = White;

            CursorLeft = x;
            CursorTop = y;
            Write(empty);

            CursorLeft = x + (width - title.Length) / 2;
            Write(title);

            ForegroundColor = Black;
            BackgroundColor = Gray;
            int lineCounter = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    CursorTop = y + lineCounter++ + 1;
                    CursorLeft = x;
                    Write(empty);

                    CursorLeft = x;
                    Write(lines[i][j]);

                }
            }
            CursorLeft = x;
            CursorTop = y + lines.Sum(e => e.Length) + 1;
            Write(empty);

            int selected = 0;
            ConsoleKeyInfo key;
            do
            {
                CursorLeft = x;
                CursorTop = y + lines.Sum(e => e.Length) + 2;
                Write(empty);

                int buttonsLength = buttons.Sum(e => e.Length);
                CursorLeft = x + (maxLength - buttonsLength - buttons.Length * 2);
                for (int i = 0; i < buttons.Length; i++)
                {
                    if (selected == i)
                        BackgroundColor = ConsoleColor.White;

                    Write($"{buttons[i]}");

                    BackgroundColor = ConsoleColor.Gray;
                    Write("  ");
                }

                key = ReadKey(true);

                if (key.Key == ConsoleKey.LeftArrow)
                    selected--;
                else if (key.Key == ConsoleKey.RightArrow)
                    selected++;

                HoldInside(ref selected, buttons.Length);

            } while (key.Key != ConsoleKey.Enter);

            ResetColor();
            return selected;
        }

        public static int CreateConfirmMenu(string title, string text, params string[] buttons)
        {
            return CreateConfirmMenu(title, text, 50, buttons);
        }

        private static List<(string name, bool isFolder)> LoadFolderContent(string path)
        {
            List<(string name, bool isFolder)> content = new();
            DirectoryInfo root = new(path);
            string[] directories = root.GetDirectories().Select(e => e.Name).ToArray();
            string[] files = root.GetFiles().Select(e => e.Name).ToArray();

            foreach (var directory in directories)
                content.Add((directory, true));
            foreach (var file in files)
                content.Add((file, false));

            return content.OrderBy(e => e.name).ToList();
        }

        private static void DrawFolderContent(List<(string name, bool isFolder)> content, int selected)
        {
            Clear();
            int cols = 5;
            int width = 24, height = 10;
            for (int i = 0; i < content.Count; i++)
            {
                int x = (i % cols) * width;
                int y = (i / cols) * height;
                (string name, bool isFolder) = content[i];

                if (i == selected)
                    FillRectangle(x, y, width, height, ConsoleColor.Gray);
                if (isFolder)
                    DrawFolder(x, y, name);
                else
                    DrawFile(x + (width - 16) / 2, y, name);
            }
        }

        private static void FillRectangle(int x, int y, int width, int height, ConsoleColor color)
        {
            BackgroundColor = color;
            for (int i = 0; i < height; i++)
                DrawLine(x, y + i, width, color);
            ResetColor();
        }

        private static void DrawFolder(int x, int y, string name)
        {
            int width = 24, height = 9;
            int offset = 1;

            DrawLine(offset + x + 1, y, 21 - 4, ConsoleColor.DarkYellow);
            DrawLine(offset + x, y + 1, 8 - offset * 2, ConsoleColor.Yellow);
            DrawLine(offset + x + 6, y + 1, 15 - offset * 2, ConsoleColor.DarkYellow);
            DrawLine(offset + x, y + 2, 22 - offset * 2, ConsoleColor.Yellow);
            SetPixel(x + 22 - offset * 2, y + 2, ConsoleColor.DarkYellow);
            DrawLine(offset + x, y + 3, 24 - offset * 2, ConsoleColor.Yellow);
            DrawLine(offset + x, y + 4, 24 - offset * 2, ConsoleColor.Yellow);
            DrawLine(offset + x, y + 5, 24 - offset * 2, ConsoleColor.Yellow);
            DrawLine(offset + x, y + 6, 24 - offset * 2, ConsoleColor.Yellow);
            DrawLine(offset + x, y + 7, 24 - offset * 2, ConsoleColor.Yellow);
            DrawLine(offset + x, y + 8, 23 - offset * 2, ConsoleColor.Yellow);

            int textX = x + (width - name.Length) / 2;
            if (textX < 0)
                textX = 0;
            else if (textX + name.Length / 2 >= 120)
                textX = 120 - name.Length / 2 - 1;
            CursorLeft = textX;
            CursorTop = y + height;
            Write(name);
        }

        private static void DrawFile(int x, int y, string name)
        {
            int width = 16, height = 9;

            DrawLine(x, y, 13, ConsoleColor.DarkGray);
            DrawLine(x + 13, y + 1, 2, ConsoleColor.DarkGray);
            DrawLine(x + 2, y + 2, 8, ConsoleColor.DarkGray);
            DrawLine(x + 2, y + 4, 10, ConsoleColor.DarkGray);
            DrawLine(x + 2, y + 6, 8, ConsoleColor.DarkGray);
            DrawLine(x + 1, y + 8, 14, ConsoleColor.DarkGray);

            SetPixel(x, y + 1, ConsoleColor.DarkGray);
            SetPixel(x, y + 2, ConsoleColor.DarkGray);
            SetPixel(x + 15, y + 2, ConsoleColor.DarkGray);
            SetPixel(x, y + 3, ConsoleColor.DarkGray);
            SetPixel(x + 15, y + 3, ConsoleColor.DarkGray);
            SetPixel(x, y + 4, ConsoleColor.DarkGray);
            SetPixel(x + 15, y + 4, ConsoleColor.DarkGray);
            SetPixel(x, y + 5, ConsoleColor.DarkGray);
            SetPixel(x + 15, y + 5, ConsoleColor.DarkGray);
            SetPixel(x, y + 6, ConsoleColor.DarkGray);
            SetPixel(x + 15, y + 6, ConsoleColor.DarkGray);
            SetPixel(x + 11, y + 6, ConsoleColor.DarkGray);
            SetPixel(x, y + 7, ConsoleColor.DarkGray);
            SetPixel(x + 15, y + 7, ConsoleColor.DarkGray);

            int textX = x + (width - name.Length) / 2;
            if (textX < 0)
                textX = 0;
            else if (textX + name.Length / 2 >= 120)
                textX = 120 - name.Length / 2 - 1;
            CursorLeft = textX;
            CursorTop = y + height;
            Write(name);

        }

        private static void SetPixel(int x, int y, ConsoleColor color)
        {
            CursorLeft = x;
            CursorTop = y;
            BackgroundColor = color;
            Write(" ");
            ResetColor();
        }

        private static void DrawLine(int x, int y, int length, ConsoleColor color)
        {
            CursorLeft = x;
            CursorTop = y;
            BackgroundColor = color;
            Write(string.Join("", Enumerable.Repeat(" ", length)));
            ResetColor();
        }

        private static void HoldInside(ref int selected, int max)
        {
            if (selected < 0)
                selected = max + selected;
            if (selected >= max)
                selected -= max;
        }

    }

    enum InputType
    {
        Double, Int, String, Roman, Binary
    }
}
