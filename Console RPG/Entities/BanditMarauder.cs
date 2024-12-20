﻿using Console_RPG.Items;

namespace Console_RPG.Entities
{
    internal class BanditMarauder : Enemy
    {
        internal BanditMarauder()
        {
            Name = Game.currentLanguageStrings["EnemyBanditMarauderName"];
            EnemySprite = "Text_Files\\Enemies_Sprite\\Bandit_Marauder.txt";

            CurrentLevel = 3;
            MaximumLevelPossible = 5;

            BaseHealthPoints = 5;
            MaximumPossibleHealthPoints = 50;

            BaseStaminaPoints = 5;
            MaximumPossibleStaminaPoints = 60;

            BaseDamagePoints = 6;
            BaseDefensePoints = 3;

            ExperienceGiven = 60;

            HealthCalculator();
            StaminaCalculator();
            DamageCalculator();
            DefenseCalculator();

            EquipedWeapon = new Weapons(Game.currentLanguageStrings["SteelClaymoreName"], "", 6);
            EquipedArmor = new Armors(Game.currentLanguageStrings["IronChainmailName"], "", 6);            
        }
    }
}
