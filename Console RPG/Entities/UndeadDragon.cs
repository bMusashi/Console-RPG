using Console_RPG.Items;

namespace Console_RPG.Entities
{
    internal class UndeadDragon : Enemy
    {
        internal UndeadDragon()
        {
            Name = Game.currentLanguageStrings["EnemyUndeadDragonName"];
            EnemySprite = "Text_Files\\Enemies_Sprite\\Undead_Dragon.txt";

            CurrentLevel = 5;
            MaximumLevelPossible = 5;

            BaseHealthPoints = 15;
            MaximumPossibleHealthPoints = 70;

            BaseStaminaPoints = 15;
            MaximumPossibleStaminaPoints = 80;

            BaseDamagePoints = 15;
            BaseDefensePoints = 7;

            ExperienceGiven = 148;

            HealthCalculator();
            StaminaCalculator();
            DamageCalculator();
            DefenseCalculator();            
        }
    }
}
