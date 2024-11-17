using Console_RPG.Assistant;
using Console_RPG.Entities;
namespace Console_RPG.Items
{
    internal class Foods : Item
    {
        internal string Quality { get; set; }
        internal int EffectAmount { get; set; }        
        internal Foods(string name, string description, string quality, int effectAmount) : base()
        {
            Name = name;
            Description = description;   
            Quality = quality;
            EffectAmount = effectAmount;
        }
        internal int FoodPoisoning()
        {
            return EffectAmount;
        }
        internal int FoodHealing()
        {
            return EffectAmount;            
        }
        internal int FoodRecovery()
        {
            return EffectAmount - 3;
        }
        internal override void ItemDescription()
        {
            Render.ConsoleClear("                                                  ", 11, 80, 18);
            Render.Draw(LevelParser.ParseFileToArray("Text_Files\\Console_Box.txt"), 80, 18);
            SetCursorPosition(81, 19);
            Write($"{Game.currentLanguageStrings["InventoryTextName"]}: {Name}");            

            SetCursorPosition(81, 21);
            if (Quality.Contains("Bad")) Write(Game.currentLanguageStrings["InventoryTextQualityBad"]);
            else if (Quality.Contains("Good")) Write(Game.currentLanguageStrings["InventoryTextQualityGood"]);
            else Write(Game.currentLanguageStrings["InventoryTextQualityExcellent"]);

            SetCursorPosition(81, 23);
            Write($"{Game.currentLanguageStrings["InventoryTextDescription"]}: ");

            string[] DescriptionSplited = Description.Split('|');

            for (int i = 0; i < DescriptionSplited.Length; i++)
            {
                SetCursorPosition(81, 24 + i);
                Write($"{DescriptionSplited[i]}");
            }
        }
    }
}
