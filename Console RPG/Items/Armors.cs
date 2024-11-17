using Console_RPG.Assistant;

namespace Console_RPG.Items
{
    internal class Armors : Item
    {
        internal int Defense {get; set; }        
        public Armors(string name, string description, int defense) : base()
        {
            Name = name;
            Description = description;
            Defense = defense;
        }

        internal override void ItemDescription()
        {
            Render.ConsoleClear("                                                  ", 11, 80, 18);
            Render.Draw(LevelParser.ParseFileToArray("Text_Files\\Console_Box.txt"), 80, 18);
            SetCursorPosition(81, 19);
            Write($"{Game.currentLanguageStrings["InventoryTextName"]}: {Name}");

            SetCursorPosition(81, 21);
            Write($"{Game.currentLanguageStrings["InventoryTextProtection"]}: {Defense}");

            SetCursorPosition(81, 23);
            Write($"{Game.currentLanguageStrings["InventoryTextDescription"]}: ");

            string[] DescriptionSplited = Description.Split('|');

            for (int i = 0;i < DescriptionSplited.Length;i++)
            {
                SetCursorPosition(81, 24 + i);
                Write($"{DescriptionSplited[i]}");
            }
        }
    }
}
