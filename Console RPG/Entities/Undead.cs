using Console_RPG.Items;

namespace Console_RPG.Entities
{
    internal class Undead : Enemy
    {
        internal Undead()
        {
            Name = Game.currentLanguageStrings["EnemyUndeadName"];
            EnemySprite = "Text_Files\\Enemies_Sprite\\Undead.txt";

            CurrentLevel = 2;
            MaximumLevelPossible = 5;

            BaseHealthPoints = 15;
            MaximumPossibleHealthPoints = 40;

            BaseStaminaPoints = 15;
            MaximumPossibleStaminaPoints = 70;

            BaseDamagePoints = 4;
            BaseDefensePoints = 2;

            ExperienceGiven = 20;

            HealthCalculator();
            StaminaCalculator();
            DamageCalculator();
            DefenseCalculator();

            EquipedWeapon = new Weapons(Game.currentLanguageStrings["IronFalcataName"], "", 4);
            EquipedArmor = new Armors(Game.currentLanguageStrings["LeatherBreastplateName"], "", 4);            
        }
    }
}
