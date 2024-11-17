using Console_RPG.Items;

namespace Console_RPG.Entities
{
    internal class Thief : Enemy
    {
        internal Thief()
        {
            Name = Game.currentLanguageStrings["EnemyThiefName"];
            EnemySprite = "Text_Files\\Enemies_Sprite\\Thief.txt";

            CurrentLevel = 1;
            MaximumLevelPossible = 5;

            BaseHealthPoints = 15;
            MaximumPossibleHealthPoints = 30;

            BaseStaminaPoints = 15;
            MaximumPossibleStaminaPoints = 70;

            BaseDamagePoints = 2;
            BaseDefensePoints = 1;

            ExperienceGiven = 18;

            HealthCalculator();
            StaminaCalculator();
            DamageCalculator();
            DefenseCalculator();

            EquipedWeapon = new Weapons(Game.currentLanguageStrings["DaggerName"], "", 4);
            EquipedArmor = new Armors(Game.currentLanguageStrings["Explorer'sJacketName"], "", 4);            
        }
    }
}
