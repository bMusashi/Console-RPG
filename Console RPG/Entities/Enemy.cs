using Console_RPG.Assistant;

namespace Console_RPG.Entities
{
    internal class Enemy : Entity
    {
        internal string EnemySprite { get; set; } = string.Empty;
        public int ExperienceGiven { get; protected set; }
        private readonly Random rnd = new();        
        public Enemy()
        {

        }

        internal override void BattleInformation()
        {
            int HpPercentage = Convert.ToInt32(Convert.ToDouble(CurrentHealthPoints) / Convert.ToDouble(CurrentMaxHealthPoints) * 100);            

            SetCursorPosition(112, 26);
            Write(Name);

            SetCursorPosition(112, 28);
            Write($"{Game.currentLanguageStrings["BattleInformationHP"]}: {CurrentHealthPoints}/{CurrentMaxHealthPoints}");            
            Menu.PercentageBar(HpPercentage, 21, 107, 29, ConsoleColor.DarkRed);

            SetCursorPosition(107, 31);
            if (EquipedWeapon.Name != Game.currentLanguageStrings["BattleInformationEmpty"]) Write(EquipedWeapon.Name.Substring(0, (EquipedWeapon.Name.Length < 9) ? EquipedWeapon.Name.Length : 9)); else Write($"  {Game.currentLanguageStrings["BattleInformationEmpty"]}  ");

            SetCursorPosition(119, 31);
            if (EquipedArmor.Name != Game.currentLanguageStrings["BattleInformationEmpty"]) Write(EquipedArmor.Name.Substring(0, (EquipedArmor.Name.Length < 9) ? EquipedArmor.Name.Length : 9)); else Write($"  {Game.currentLanguageStrings["BattleInformationEmpty"]}  ");
        }        
        internal void BattleAttackSkillMiss()
        {
            Render.ConsoleClear("                                  ", 5, 95, 34);            
            SetCursorPosition(95, 34);
            Write($"{Name} {Game.currentLanguageStrings["BattleAttackSkillMissText"]}!");
            SetCursorPosition(95, 38);
            Write(Game.currentLanguageStrings["Continue"]);
            ReadKey();
        }
        internal int RatBite(Player target) //Ataque exclusivo do Giant Rat
        {
            double[] RBiteMultipliers = { 1.0, 1.0, 1.0, 1.5, 1.5, 1.5, 1.5, 1.5, 2.0, 2.0 }; // 30 50 20
            int StaminaCost = 2;

            if (CurrentStaminaPoints >= StaminaCost)
            {
                CurrentStaminaPoints -= StaminaCost;
                //int damage = Convert.ToInt32((StaminaCost / 2) + (DamageCalculator() * (DamageFormulaValues[rnd.Next(DamageFormulaValues.Length)] + 0.2)) - target.DefenseCalculator());
                int damage = Convert.ToInt32(DamageCalculator() * (RBiteMultipliers[rnd.Next(RBiteMultipliers.Length)] + 0.2) - target.DefenseCalculator());
                if (damage <= 0) damage = 1;
                Battle.BattleCastText(Name, Game.currentLanguageStrings["EnemySkillBiteName"], damage);
                return damage;
            }
            else
            {                
                return 255;
            }
        }
        internal int UndeadBite(Player target) //Ataque exclusivo do Undead
        {
            double[] UBiteMultipliers = { 1.8, 1.8, 1.8, 1.8, 1.8, 1.8, 2.3, 2.3, 2.3, 2.3 }; // 60 40
            int StaminaCost = 4;

            if (CurrentStaminaPoints >= StaminaCost)
            {
                CurrentStaminaPoints -= StaminaCost;
                //int damage = Convert.ToInt32((StaminaCost / 2) + (DamageCalculator() * (DamageFormulaValues[rnd.Next(DamageFormulaValues.Length)] + 0.4)) - target.DefenseCalculator());
                int damage = Convert.ToInt32(DamageCalculator() * (UBiteMultipliers[rnd.Next(UBiteMultipliers.Length)] + 0.4) - target.DefenseCalculator());
                if (damage <= 0) damage = 1;
                Battle.BattleCastText(Name, Game.currentLanguageStrings["EnemySkillBiteName"], damage);
                return damage;
            }
            else
            {
                return 255;
            }
        }
        internal int Smash(Player target) //Ataque exclusivo do Bandido Saqueador
        {
            double[] SmashMultipliers = { 1.0, 1.5, 1.5, 1.5, 1.5, 1.5, 1.5, 1.5, 2.0, 2.0 }; // 10 70 20
            int StaminaCost = 2;

            if (CurrentStaminaPoints >= StaminaCost)
            {
                CurrentStaminaPoints -= StaminaCost;
                //int damage = Convert.ToInt32((StaminaCost / 2) + (DamageCalculator() * (DamageFormulaValues[rnd.Next(DamageFormulaValues.Length)] + 0.2)) - target.DefenseCalculator());
                int damage = Convert.ToInt32(DamageCalculator() * (SmashMultipliers[rnd.Next(SmashMultipliers.Length)] + 0.2) - target.DefenseCalculator());
                if (damage <= 0) damage = 1;
                Battle.BattleCastText(Name, Game.currentLanguageStrings["EnemySkillSmashName"], damage);
                return damage;
            }
            else
            {
                return 255;
            }
        }
        internal int BodyCrush(Player target) //Ataque exclusivo do Bandido Saqueador
        {
            double[] BodyCrushMultipliers = { 1.8, 1.8, 1.8, 1.8, 1.8, 1.8, 2.3, 2.3, 2.3, 2.3 }; // 60 40
            int StaminaCost = 4;

            if (CurrentStaminaPoints >= StaminaCost)
            {
                CurrentStaminaPoints -= StaminaCost;
                //int damage = Convert.ToInt32((StaminaCost / 2) + (DamageCalculator() * (DamageFormulaValues[rnd.Next(DamageFormulaValues.Length)] + 0.4)) - target.DefenseCalculator());
                int damage = Convert.ToInt32(DamageCalculator() * (BodyCrushMultipliers[rnd.Next(BodyCrushMultipliers.Length)] + 0.4) - target.DefenseCalculator());
                if (damage <= 0) damage = 1;
                Battle.BattleCastText(Name, Game.currentLanguageStrings["EnemySkillBodyCrushName"], damage);
                return damage;
            }
            else
            {
                return 255;
            }
        }
        internal int BodySlam(Player target) //Ataque exclusivo do Guerreiro Louco
        {
            double[] BodySlamMultipliers = { 1.8, 1.8, 1.8, 1.8, 2.3, 2.3, 2.3, 2.3, 2.3, 2.3 }; // 40 60
            int StaminaCost = 6;

            if (CurrentStaminaPoints >= StaminaCost)
            {
                CurrentStaminaPoints -= StaminaCost;
                //int damage = Convert.ToInt32((StaminaCost / 2) + (DamageCalculator() * (DamageFormulaValues[rnd.Next(DamageFormulaValues.Length)] + 0.6)) - target.DefenseCalculator());
                int damage = Convert.ToInt32(DamageCalculator() * (BodySlamMultipliers[rnd.Next(BodySlamMultipliers.Length)] + 0.6) - target.DefenseCalculator());
                if (damage <= 0) damage = 1;
                Battle.BattleCastText(Name, Game.currentLanguageStrings["EnemySkillBodySlamName"], damage);
                return damage;
            }
            else
            {
                return 255;
            }
        }
        internal int DragonBite(Player target) //Ataque exclusivo do Undead Dragon
        {
            double[] DragonBiteMultipliers = { 1.8, 1.8, 1.8, 1.8, 1.8, 2.3, 2.3, 2.3, 2.3, 2.3 }; // 50 50
            int StaminaCost = 5;

            if (CurrentStaminaPoints >= StaminaCost)
            {
                CurrentStaminaPoints -= StaminaCost;
                //int damage = Convert.ToInt32((StaminaCost / 2) + (DamageCalculator() * (DamageFormulaValues[rnd.Next(DamageFormulaValues.Length)] + 0.5)) - target.DefenseCalculator());
                int damage = Convert.ToInt32(DamageCalculator() * (DragonBiteMultipliers[rnd.Next(DragonBiteMultipliers.Length)] + 0.5) - target.DefenseCalculator());
                if (damage <= 0) damage = 1;
                Battle.BattleCastText(Name, Game.currentLanguageStrings["EnemySkillBiteName"], damage);
                return damage;
            }
            else
            {
                return 255;
            }
        }
        internal int TailWhipping(Player target) //Ataque exclusivo do Undead Dragon
        {
            double[] TailWhippingMultipliers = { 1.8, 1.8, 1.8, 1.8, 2.3, 2.3, 2.3, 2.3, 2.3, 2.3 }; // 40 60
            int StaminaCost = 6;

            if (CurrentStaminaPoints >= StaminaCost)
            {
                CurrentStaminaPoints -= StaminaCost;
                //int damage = Convert.ToInt32((StaminaCost / 2) + (DamageCalculator() * (DamageFormulaValues[rnd.Next(DamageFormulaValues.Length)] + 0.6)) - target.DefenseCalculator());
                int damage = Convert.ToInt32(DamageCalculator() * (TailWhippingMultipliers[rnd.Next(TailWhippingMultipliers.Length)] + 0.6) - target.DefenseCalculator());
                if (damage <= 0) damage = 1;
                Battle.BattleCastText(Name, Game.currentLanguageStrings["EnemySkillTailWhippingName"], damage);
                return damage;
            }
            else
            {
                return 255;
            }
        }
        internal int FireBreath(Player target) //Ataque exclusivo do Undead Dragon
        {
            double[] FireBreathMultipliers = { 1.8, 1.8, 1.8, 2.3, 2.3, 2.3, 2.3, 2.3, 2.3, 2.3 }; // 30 70
            int StaminaCost = 7;

            if (CurrentStaminaPoints >= StaminaCost)
            {
                CurrentStaminaPoints -= StaminaCost;
                //int damage = Convert.ToInt32((StaminaCost / 2) + (DamageCalculator() * (DamageFormulaValues[rnd.Next(DamageFormulaValues.Length)] + 0.7)) - target.DefenseCalculator());
                int damage = Convert.ToInt32(DamageCalculator() * (FireBreathMultipliers[rnd.Next(FireBreathMultipliers.Length)] + 0.7) - target.DefenseCalculator());
                if (damage <= 0) damage = 1;
                Battle.BattleCastText(Name, Game.currentLanguageStrings["EnemySkillFireBreathName"], damage);
                return damage;
            }
            else
            {
                return 255;
            }
        }
    }
}
