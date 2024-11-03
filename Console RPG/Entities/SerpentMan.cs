using Console_RPG.Items;

namespace Console_RPG.Entities
{
    internal class SerpentMan : Enemy
    {
        internal SerpentMan()
        {
            Name = "Homem Serpente";
            EnemySprite = "Text_Files\\Enemies_Sprite\\Serpent_Man.txt";

            CurrentLevel = 2;
            MaximumLevelPossible = 5;

            BaseHealthPoints = 10;
            MaximumPossibleHealthPoints = 40;

            BaseStaminaPoints = 10;
            MaximumPossibleStaminaPoints = 65;

            BaseDamagePoints = 4;
            BaseDefensePoints = 2;

            ExperienceGiven = 24;

            HealthCalculator();
            StaminaCalculator();
            DamageCalculator();
            DefenseCalculator();

            EquipedWeapon = new Weapons("Serpentina dos Homens Serpentes", "", 6);
            EquipedArmor = new Armors("Explorer Armor", "", 4);            
        }
    }
}
