using Console_RPG.Assistant;
using Console_RPG.Entities;
namespace Console_RPG.Items
{
    internal class Potions : Item
    {
        internal int HealAmount {  get; set; }
        public Potions(string name, string description, int healAmount) : base()
        {
            Name = name;
            Description = description;
            HealAmount = healAmount;
        }
        internal int HealingPotion()
        {
            return HealAmount;
        }
        internal int AdrenalinePotion()
        {
            return HealAmount;
        }
        internal override void ItemDescription()
        {
            Render.ConsoleClear("                                                  ", 11, 80, 18);            
            Render.Draw(LevelParser.ParseFileToArray("Text_Files\\Console_Box.txt"), 80, 18);
            SetCursorPosition(81, 19);
            Write($"Nome: {Name}");

            SetCursorPosition(81,21);
            if (Name.Contains("Calêndula")) Write($"Vida recuperada: {HealAmount} pontos."); else Write($"Energia recuperada: {HealAmount} pontos.");

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
