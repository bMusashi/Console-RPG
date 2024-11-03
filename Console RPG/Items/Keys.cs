﻿using Console_RPG.Assistant;

namespace Console_RPG.Items
{
    internal class Keys : Item
    {
        public Keys(string name, string description) : base()
        {
            Name = name;
            Description = description;
        }
        internal override void ItemDescription()
        {
            Render.ConsoleClear("                                                  ", 11, 80, 18);            
            Render.Draw(LevelParser.ParseFileToArray("Text_Files\\Console_Box.txt"), 80, 18);
            SetCursorPosition(81, 19);
            Write($"Nome: {Name}");            

            SetCursorPosition(81, 23);
            Write($"Descrição: ");

            string[] DescriptionSplited = Description.Split('|');

            for (int i = 0; i < DescriptionSplited.Length; i++)
            {
                SetCursorPosition(81, 24 + i);
                Write($"{DescriptionSplited[i]}");
            }
        }
    }
}