namespace Console_RPG.Entities
{
    internal class GiantRat : Enemy
    {
        internal GiantRat()
        {
            Name = Game.currentLanguageStrings["EnemyGiantRatName"];
            EnemySprite = "Text_Files\\Enemies_Sprite\\Giant_Rat.txt";

            CurrentLevel = 1;
            MaximumLevelPossible = 5;

            BaseHealthPoints = 5;
            MaximumPossibleHealthPoints = 30;

            BaseStaminaPoints = 5;
            MaximumPossibleStaminaPoints = 60;

            BaseDamagePoints = 3;
            BaseDefensePoints = 1;

            ExperienceGiven = 10;

            HealthCalculator();
            StaminaCalculator();
            DamageCalculator();
            DefenseCalculator();
        }
    }
}
