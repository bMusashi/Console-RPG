using Console_RPG.Items;
using Console_RPG.Assistant;

namespace Console_RPG.Entities
{
    internal abstract class Entity
    {
        //Name
        internal string Name { get; set; }
        //Level
        internal int CurrentLevel { get; set; }
        internal int MaximumLevelPossible { get; set; }
        //Health Points
        internal int BaseHealthPoints { get; set; }
        internal int MaximumPossibleHealthPoints { get; set; }
        internal int CurrentHealthPoints { get; set; }
        internal int CurrentMaxHealthPoints { get; set; }
        //Stamina
        internal int BaseStaminaPoints { get; set; }
        internal int MaximumPossibleStaminaPoints { get; set; }
        internal int CurrentStaminaPoints { get; set; }
        internal int CurrentMaxStaminaPoints { get; set; }
        //Damage
        internal int BaseDamagePoints { get; set; }        
        //Defence
        internal int BaseDefensePoints { get; set; }        
        //Inventory
        internal List<Item> Inventory { get; set; }
        internal Weapons EquipedWeapon { get; set; } = new Weapons("Vazio", string.Empty, 0);
        internal Armors EquipedArmor { get; set; } = new Armors("Vazio", string.Empty, 0);
        //Attacks
        internal string[] Attacks { get; set; } = new string[2];
        //Skills
        internal List<string> Skills { get; set; } = [];

        Random rnd = new();
        //private readonly double[] DamageFormulaValues = [1.2, 1.2, 1.2, 1.5, 1.5, 1.5, 1.5, 1.5, 2.0, 2.0];

        public bool IsAlive()
        {
            return (CurrentHealthPoints > 0);
        }
        internal void TakeDamage(int damageRecieved) //Recieve Damage
        {
            CurrentHealthPoints -= damageRecieved;
            if (CurrentHealthPoints < 0) CurrentHealthPoints = 0;
        }
        internal void BattleTurnIndicator()
        {
            SetCursorPosition(95,38);
            Write($"Turno do {Name}... ");
            Thread.Sleep(1000);
        }
        //Stats Calculation
        public int HealthCalculator() //Heath
        {
            CurrentHealthPoints = BaseHealthPoints + (MaximumPossibleHealthPoints - BaseHealthPoints) * CurrentLevel / MaximumLevelPossible;
            CurrentMaxHealthPoints = CurrentHealthPoints;

            return CurrentHealthPoints;
        }
        internal void LevelUpStatsCalculator()
        {
            CurrentMaxHealthPoints = BaseHealthPoints + (MaximumPossibleHealthPoints - BaseHealthPoints) * CurrentLevel / MaximumLevelPossible;
            RecieveHealthPoints(40 * CurrentMaxHealthPoints / 100);
            CurrentMaxStaminaPoints = BaseStaminaPoints + (MaximumPossibleStaminaPoints - BaseStaminaPoints) * CurrentLevel / MaximumLevelPossible;
            RecieveStaminaPoints(50 * CurrentMaxStaminaPoints / 100);
        }
        public int StaminaCalculator() //Stamina
        {
            CurrentStaminaPoints = BaseStaminaPoints + (MaximumPossibleStaminaPoints - BaseStaminaPoints) * CurrentLevel / MaximumLevelPossible;
            CurrentMaxStaminaPoints = CurrentStaminaPoints;

            return CurrentStaminaPoints;
        }
        public int DamageCalculator() //Damage
        {
            return BaseDamagePoints + EquipedWeapon.Damage;             
        }
        public int DefenseCalculator() //Defense
        {
            return BaseDefensePoints + EquipedArmor.Defense;             
        }
        //Healing
        public void RecieveHealthPoints(int healingAmount) //Health
        {
            CurrentHealthPoints += healingAmount;
            if (CurrentHealthPoints > CurrentMaxHealthPoints)
            {
                CurrentHealthPoints = CurrentMaxHealthPoints;
            }            
        }
        public void RecieveStaminaPoints(int healingAmount) //Stamina
        {
            CurrentStaminaPoints += healingAmount;
            if (CurrentStaminaPoints > CurrentMaxStaminaPoints)
            {
                CurrentStaminaPoints = CurrentMaxStaminaPoints;
            }            
        }
        //Attacks
        internal int LightAttack(Entity target)
        {
            double[] LightAttackMultipliers = { 1.2, 1.2, 1.2, 1.2, 1.5, 1.5, 1.5, 1.5, 2.0, 2.0 }; // 40 40 20
            int StaminaCost = 2;                    

            if (CurrentStaminaPoints >= StaminaCost)
            {
                CurrentStaminaPoints -= StaminaCost;
                //int damage = Convert.ToInt32((StaminaCost / 2) + (DamageCalculator() * DamageFormulaValues[rnd.Next(DamageFormulaValues.Length)]) - target.DefenseCalculator());
                int damage = Convert.ToInt32(DamageCalculator() * (LightAttackMultipliers[rnd.Next(LightAttackMultipliers.Length)] + 0.1) - target.DefenseCalculator());
                if (damage <= 0) damage = 1;
                Battle.BattleCastText(Name, "Ataque Leve", damage);
                return damage;
            }
            else
            {                
                return 255;
            }                
        }
        internal int HeavyAttack(Entity target)
        {
            double[] HeavyAttackMultipliers = { 1.7, 1.7, 1.7, 1.7, 1.7, 1.7, 2.2, 2.2, 2.2, 2.2 }; // 60 40
            int StaminaCost = 4;

            if (CurrentStaminaPoints >= StaminaCost)
            {
                CurrentStaminaPoints -= StaminaCost;
                //int damage = Convert.ToInt32((StaminaCost / 2) + (DamageCalculator() * (DamageFormulaValues[rnd.Next(DamageFormulaValues.Length)] + 0.2)) - target.DefenseCalculator());
                int damage = Convert.ToInt32(DamageCalculator() * (HeavyAttackMultipliers[rnd.Next(HeavyAttackMultipliers.Length)] + 0.2) - target.DefenseCalculator());
                if (damage <= 0) damage = 1;
                Battle.BattleCastText(Name, "Ataque Pesado", damage);
                return damage;
            }
            else
            {                
                return 255;
            }
        }
        //Skills
        internal int QuickStrike(Entity target)
        {
            double[] QuickStrikeMultipliers = { 1.0, 1.5, 1.5, 1.5, 1.5, 1.5, 1.5, 1.5, 2.0, 2.0 }; // 10 70 20
            int StaminaCost = 3;

            if (CurrentStaminaPoints >= StaminaCost)
            {
                CurrentStaminaPoints -= StaminaCost;
                //int damage = Convert.ToInt32((StaminaCost / 2) + (DamageCalculator() * (DamageFormulaValues[rnd.Next(DamageFormulaValues.Length)] + 0.3)) - target.DefenseCalculator());
                int damage = Convert.ToInt32(DamageCalculator() * (QuickStrikeMultipliers[rnd.Next(QuickStrikeMultipliers.Length)] + 0.3) - target.DefenseCalculator());
                if (damage <= 0) damage = 1;
                Battle.BattleCastText(Name, "Golpe Rápido", damage);
                return damage;
            }
            else
            {                
                return 255;
            }           
            
        }
        internal int Thrust(Entity target)
        {
            double[] ThrustMultipliers = { 1.0, 1.5, 1.5, 1.5, 1.5, 1.5, 1.5, 2.0, 2.0, 2.0 }; // 10 60 30
            int StaminaCost = 3;

            if (CurrentStaminaPoints >= StaminaCost)
            {
                CurrentStaminaPoints -= StaminaCost;
                //int damage = Convert.ToInt32((StaminaCost / 2) + (DamageCalculator() * (DamageFormulaValues[rnd.Next(DamageFormulaValues.Length)] + 0.3)) - target.DefenseCalculator());                
                int damage = Convert.ToInt32(DamageCalculator() * (ThrustMultipliers[rnd.Next(ThrustMultipliers.Length)] + 0.3) - target.DefenseCalculator());
                if (damage <= 0) damage = 1;
                Battle.BattleCastText(Name, "Estocada", damage);
                return damage;
            }
            else
            {                
                return 255;
            }
        }
        internal int MoonSlash(Entity target)
        {
            double[] MoonSlashMultipliers = { 1.8, 1.8, 1.8, 1.8, 1.8, 1.8, 2.3, 2.3, 2.3, 2.3 }; // 60 40
            int StaminaCost = 5;

            if (CurrentStaminaPoints >= StaminaCost)
            {
                CurrentStaminaPoints -= StaminaCost;
                //int damage = Convert.ToInt32((StaminaCost / 2) + (DamageCalculator() * (DamageFormulaValues[rnd.Next(DamageFormulaValues.Length)] + 0.5)) - target.DefenseCalculator());
                int damage = Convert.ToInt32(DamageCalculator() * (MoonSlashMultipliers[rnd.Next(MoonSlashMultipliers.Length)] + 0.5) - target.DefenseCalculator());
                if (damage <= 0) damage = 1;
                Battle.BattleCastText(Name, "Corte da Lua", damage);
                return damage;
            }
            else
            {                
                return 255;
            }            
        }
        internal int Lacerate(Entity target)
        {
            double[] LacerateMultipliers = { 1.8, 1.8, 1.8, 1.8, 1.8, 2.3, 2.3, 2.3, 2.3, 2.3 }; // 50 50
            int StaminaCost = 5;

            if (CurrentStaminaPoints >= StaminaCost)
            {
                CurrentStaminaPoints -= StaminaCost;
                //int damage = Convert.ToInt32((StaminaCost / 2) + (DamageCalculator() * (DamageFormulaValues[rnd.Next(DamageFormulaValues.Length)] + 0.5)) - target.DefenseCalculator());
                int damage = Convert.ToInt32(DamageCalculator() * (LacerateMultipliers[rnd.Next(LacerateMultipliers.Length)] + 0.5) - target.DefenseCalculator());
                if (damage <= 0) damage = 1;
                Battle.BattleCastText(Name, "Dilacerar", damage);
                return damage;
            }
            else
            {
                return 255;
            }
        }
        internal int GodRays()
        {
            int StaminaCost = 45;

            if (CurrentStaminaPoints >= StaminaCost)
            {
                CurrentStaminaPoints -= StaminaCost;
                int damage = 999;
                Battle.BattleCastText(Name, "Raios Divinos", damage);
                return damage;
            }
            else
            {
                return 255;
            }            
        }
        internal abstract void BattleInformation();
    }
}
