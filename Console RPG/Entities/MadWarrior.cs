using Console_RPG.Items;

namespace Console_RPG.Entities
{
    internal class MadWarrior : Enemy
    {
        internal MadWarrior()
        {
            Name = Game.currentLanguageStrings["EnemyMadWarriorName"];
            EnemySprite = "Text_Files\\Enemies_Sprite\\Mad_Warrior.txt";

            CurrentLevel = 4;
            MaximumLevelPossible = 5;

            BaseHealthPoints = 10;
            MaximumPossibleHealthPoints = 60;

            BaseStaminaPoints = 10;
            MaximumPossibleStaminaPoints = 70;

            BaseDamagePoints = 8;
            BaseDefensePoints = 5;

            ExperienceGiven = 98;

            HealthCalculator();
            StaminaCalculator();
            DamageCalculator();
            DefenseCalculator();           

            EquipedWeapon = new Weapons(Game.currentLanguageStrings["DevastatorName"], "", 8);
            EquipedArmor = new Armors(Game.currentLanguageStrings["PlateArmorName"], "", 8);
        }
    }
}
