using Console_RPG.Items;
namespace Console_RPG.Entities
{
    internal class Skeleton : Enemy
    {
        internal Skeleton()
        {
            Name = Game.currentLanguageStrings["EnemySkeletonName"];
            EnemySprite = "Text_Files\\Enemies_Sprite\\Skeleton.txt";

            CurrentLevel = 1;
            MaximumLevelPossible = 5;

            BaseHealthPoints = 10;
            MaximumPossibleHealthPoints = 30;

            BaseStaminaPoints = 10;
            MaximumPossibleStaminaPoints = 65;

            BaseDamagePoints = 2;
            BaseDefensePoints = 1;

            ExperienceGiven = 14;

            HealthCalculator();
            StaminaCalculator();
            DamageCalculator();
            DefenseCalculator();

            EquipedWeapon = new Weapons(Game.currentLanguageStrings["AncientIronFalcataName"], "", 2);
            EquipedArmor = new Armors(Game.currentLanguageStrings["TatteredClothesName"], "", 2);
        }
    }
}
