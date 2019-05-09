using System;
using System.Collections.Generic;

namespace Base2Me.Utils
{
    public class ConsoleMenuItem
    {
        public string OptionText { get; set; }
        public object SettingObject { get; set; }
        public int CurrentValue;

        public ConsoleMenuItem AddItem<T>(string OptText, T _Object)
        {
            OptionText = OptText;
            SettingObject = _Object;
            return this;
        }

        public string RowText()
        {
            return string.Format(OptionText + SettingObject.ToString());
        }
    }

    public class ConsoleMenu
    {
        public List<ConsoleMenuItem> Items = new List<ConsoleMenuItem>();

        public ConsoleMenu()
        {
            Items.Add(new ConsoleMenuItem().AddItem<bool>("0. BunnyHop Enabled: ", SDK.Settings.BunnyHopEnabled));
            Items.Add(new ConsoleMenuItem().AddItem<ConsoleKey>("1. BunnyHop Key: ", SDK.Settings.BunnyHopKey));

            Main();
        }

        public void Main()
        {
            ConsoleKey MenuKey;
            int CurrentRow = 0;
            do
            {
                WriteHeader();
                WriteMenu(CurrentRow);
                MenuKey = Console.ReadKey(true).Key;
                switch (MenuKey)
                {
                    case ConsoleKey.UpArrow:
                        CurrentRow++;
                        if (CurrentRow > Items.Count) { CurrentRow = 0; }
                        Console.Clear();
                        break;

                    case ConsoleKey.DownArrow:
                        CurrentRow--;
                        if (CurrentRow < 0) { CurrentRow = Items.Count; }
                        Console.Clear();
                        break;

                    case ConsoleKey.RightArrow:
                        ChangeValue(CurrentRow, 1);
                        break;

                    case ConsoleKey.LeftArrow:
                        ChangeValue(CurrentRow, -1);
                        break;
                }
            } while (MenuKey != ConsoleKey.Escape);

            //PUSH CONFIG UPDATE HERE
            PushSettings();
        }

        public void PushSettings()
        {
            int fieldCount = 0;
            foreach (var Setting in typeof(Settings).GetFields())
            {
                Setting.SetValue(SDK.Settings, Items[fieldCount].SettingObject);
                fieldCount++;
            }
        }

        private void WriteHeader()
        {
            Console.WriteLine(@"
   ___               ___  __  ___
  / _ )___ ____ ___ |_  |/  |/  /__
 / _  / _ `(_-</ -_) __// /|_/ / -_)
/____/\_,_/___/\__/____/_/  /_/\__/
  The Open-Source C# CS:GO Base...
===================================");
            Console.WriteLine();
        }

        private void WriteMenu(int CurrentRow)
        {
            for (int Row = 0; Row < Items.Count; Row++)
            {
                if (CurrentRow == Row)
                { Console.BackgroundColor = ConsoleColor.DarkGray; }
                else
                { Console.BackgroundColor = ConsoleColor.Black; }
                Console.WriteLine(Items[Row].RowText());
                Console.ResetColor();
            }
            Console.WriteLine("Press 'Esc' to leave settings...");
        }

        //This feels disgusting, forgive me father
        private void ChangeValue(int CurrentRow, int Direction)
        {
            Items[CurrentRow].CurrentValue += Direction;

            switch (Items[CurrentRow].SettingObject.GetType())
            {
                case Type BoolType when BoolType == typeof(bool):
                    Items[CurrentRow].SettingObject = !(bool)Items[CurrentRow].SettingObject;
                    break;

                case Type IntType when IntType == typeof(int):
                    Items[CurrentRow].SettingObject = (Direction + (int)Items[CurrentRow].SettingObject);
                    break;

                case Type KeyType when KeyType == typeof(ConsoleKey):
                    Items[CurrentRow].SettingObject = (ConsoleKey)Items[CurrentRow].CurrentValue;
                    break;

                case Type FloatType when FloatType == typeof(float):
                    Items[CurrentRow].SettingObject = ((float)Direction + (float)Items[CurrentRow].SettingObject);
                    break;
            }
            Console.Clear();
        }
    }
}