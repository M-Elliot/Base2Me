using System;
using System.Collections.Generic;

namespace Base2Me.Utils
{
    public class ConsoleMenu
    {
        public List<ConsoleMenuItem> Items = new List<ConsoleMenuItem>();

        public ConsoleMenu()
        {
            //Manually add our MenuItems and assign values based on Settings
            Items.Add(new ConsoleMenuItem().AddItem<bool>("0. BunnyHop Enabled: ", SDK.Settings.BunnyHopEnabled));
            Items.Add(new ConsoleMenuItem().AddItem<ConsoleKey>("1. BunnyHop Key: ", SDK.Settings.BunnyHopKey));

            //Start our Menu Loop
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
                        break;

                    case ConsoleKey.DownArrow:
                        CurrentRow--;
                        if (CurrentRow < 0) { CurrentRow = Items.Count; }
                        break;

                    case ConsoleKey.RightArrow:
                        ChangeValue(CurrentRow, 1);
                        break;

                    case ConsoleKey.LeftArrow:
                        ChangeValue(CurrentRow, -1);
                        break;
                }
                Console.Clear();
            } while (MenuKey != ConsoleKey.Escape);

            //Push setting changes to live instance
            PushSettings();
        }

        public void PushSettings()
        {
            int fieldCount = 0;
            //iterate each field in our Settings Class
            foreach (var Setting in typeof(Settings).GetFields())
            {
                //Reflect new values to the current instance field
                Setting.SetValue(SDK.Settings, Items[fieldCount].SettingObject);
                fieldCount++;
            }
        }

        //This feels disgusting... forgive me father for I have sinned.
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
        }

        //Mega cool and edgy ASCII header for nostalgia
        private void WriteHeader()
        {
            Console.WriteLine(@"
   ___               ___  __  ___
  / _ )___ ____ ___ |_  |/  |/  /__
 / _  / _ `(_-</ -_) __// /|_/ / -_)
/____/\_,_/___/\__/____/_/  /_/\__/
The Open Source External C# CS:GO Base...
===================================");
            Console.WriteLine();
        }

        //Display each row with their appropriate formatting
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
    }

    public class ConsoleMenuItem
    {
        public int CurrentValue;
        public string OptionText { get; set; }
        public object SettingObject { get; set; }

        //Method to handle Generic Types and cast to Object Type
        public ConsoleMenuItem AddItem<T>(string OptText, T _Object)
        {
            OptionText = OptText;
            SettingObject = _Object;
            return this;
        }

        //Console friendly display format
        public string RowText()
        {
            return string.Format(OptionText + SettingObject.ToString());
        }
    }
}