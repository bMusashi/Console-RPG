using Console_RPG.Items;
namespace Console_RPG.Entities
{
    internal class Skeleton : Enemy
    {
        internal Skeleton()
        {
            Name = "Esqueleto";
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

            EquipedWeapon = new Weapons("Falcata de Ferro Antiga", "", 2);
            EquipedArmor = new Armors("Roupas Esfarrapadas", "", 2);
        }
    }
}
