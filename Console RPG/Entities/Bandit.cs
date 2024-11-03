﻿using Console_RPG.Items;

namespace Console_RPG.Entities
{
    internal class Bandit : Enemy
    {
        internal Bandit()
        {
            Name = "Bandido";
            EnemySprite = "Text_Files\\Enemies_Sprite\\Bandit.txt";

            CurrentLevel = 2;
            MaximumLevelPossible = 5;

            BaseHealthPoints = 5;
            MaximumPossibleHealthPoints = 40;

            BaseStaminaPoints = 5;
            MaximumPossibleStaminaPoints = 60;

            BaseDamagePoints = 3;
            BaseDefensePoints = 2;

            ExperienceGiven = 22;

            HealthCalculator();
            StaminaCalculator();
            DamageCalculator();
            DefenseCalculator();

            EquipedWeapon = new Weapons("Falcata de Ferro", "", 4);
            EquipedArmor = new Armors("Couraça de Couro", "", 4);            
        }
    }
}