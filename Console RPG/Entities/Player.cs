using Console_RPG.Assistant;
using Console_RPG.Items;
namespace Console_RPG.Entities
{
    internal class Player : Entity
    {
        //Movimentação no cenário.
        internal int X { get; set; }
        internal int Y { get; set; }
        internal static string PlayerMarker = "P";
        internal static ConsoleColor PlayerColor = ConsoleColor.Blue;
        //Experiencia
        internal int Experience { get; set; }
        internal int ExperienceToNextLevel { get; set; }
        //Lista de Técnicas
        internal string EquipedSkill { get; private set; } = "Vazio";
        internal Player(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;

            Name = "Torny";

            CurrentLevel = 1;
            MaximumLevelPossible = 10;

            BaseHealthPoints = 12;
            MaximumPossibleHealthPoints = 100;

            BaseStaminaPoints = 10;
            MaximumPossibleStaminaPoints = 50;

            BaseDamagePoints = 1;
            BaseDefensePoints = 1;

            Experience = 0;            

            Inventory = new List<Item>();
            Attacks[0] = "Ataque Leve";
            Attacks[1] = "Ataque Pesado";

            TakeSkill("Golpe Rápido");

            HealthCalculator();
            StaminaCalculator();
            DamageCalculator();
            DefenseCalculator();
            ExperienceCalculator();

            CurrentHealthPoints = 10;
            CurrentStaminaPoints = 7;
            
        }
        internal void Draw()
        {
            ForegroundColor = PlayerColor;
            SetCursorPosition(X, Y);
            Write(PlayerMarker);
            ResetColor();
        }
        internal void DrawPosition()
        {
            SetCursorPosition(81, 37);
            Write($"X: {X} Y: {Y}");
        }
        internal void RecieveExperience(int experienceDroped)
        {
            Experience += experienceDroped;
            Render.ConsoleClear("                                  ", 5, 95, 34);
            SetCursorPosition(95, 34);
            Write($"{experienceDroped} pontos de experiência recebida.");
            SetCursorPosition(95, 38);
            Write("Continuar...");
            ReadKey();
        }
        internal void StatsMenu()
        {
            Render.Draw(LevelParser.ParseFileToArray("Text_Files\\Inventory&Skills&Stats_Box.txt"), 80, 0);
            int playerHpPercentage = Convert.ToInt32(Convert.ToDouble(CurrentHealthPoints) / Convert.ToDouble(CurrentMaxHealthPoints) * 100);
            int playerSpPercentage = Convert.ToInt32(Convert.ToDouble(CurrentStaminaPoints) / Convert.ToDouble(CurrentMaxStaminaPoints) * 100);

            SetCursorPosition(101, 1);
            Write("[Status]");

            SetCursorPosition(81, 3);
            Write($"Nível: {CurrentLevel} Experiência: {Experience} / {ExperienceToNextLevel}");            

            SetCursorPosition(81, 5);
            Write($"Vida: {CurrentHealthPoints} / {CurrentMaxHealthPoints}");
            SetCursorPosition(81, 6);
            Write("[                                              ]");
            Menu.PercentageBar(playerHpPercentage, 46, 82, 6, ConsoleColor.DarkRed);

            SetCursorPosition(81, 7);
            Write($"Energia: {CurrentStaminaPoints} / {CurrentMaxStaminaPoints}");
            SetCursorPosition(81, 8);
            Write("[                                              ]");
            Menu.PercentageBar(playerSpPercentage, 46, 82, 8, ConsoleColor.DarkGreen);

            SetCursorPosition(81, 10);
            Write($"Dano: {DamageCalculator()}");
            SetCursorPosition(81, 11);
            Write($"Arma: {EquipedWeapon.Name}");

            SetCursorPosition(81, 13);
            Write($"Defesa: {DefenseCalculator()}");
            SetCursorPosition(81, 14);
            Write($"Armadura: {EquipedArmor.Name}");

            bool AvaliableMenu = true;
            while (AvaliableMenu)
            {
                ForegroundColor = ConsoleColor.White;                
                SetCursorPosition(102, 16);
                Write("[Sair]");
                ResetColor();

                ConsoleKeyInfo PressedKey;
                do
                {
                    PressedKey = ReadKey(true);

                } while (KeyAvailable);

                switch (PressedKey.Key)
                {
                    case ConsoleKey.Enter:
                    case ConsoleKey.Escape:
                        AvaliableMenu = false;
                        Render.ConsoleClear("                                                  ", 18, 80, 0);
                        break;
                }
            }
        }
        internal void InventoryMenu()
        {
            Render.Draw(LevelParser.ParseFileToArray("Text_Files\\Inventory&Skills&Stats_Box.txt"), 80, 0);
            SetCursorPosition(99, 1);
            Write("[Inventário]");

            bool AvaliableMenu = true;
            int SelectedIndex = 0;

            int IndexPag = 0;
            List<Item> ShowedItems = new List<Item>();

            while (AvaliableMenu)
            {
                Render.ConsoleClear("                                              ", 13, 81, 3);
                foreach (Item item in Inventory)
                {
                    if (IndexPag == 0 && item.GetType().ToString() == "Console_RPG.Items.Weapons")
                    {
                        ShowedItems.Add(item);
                    }
                    else if (IndexPag == 1 && item.GetType().ToString() == "Console_RPG.Items.Armors")
                    {
                        ShowedItems.Add(item);
                    }
                    else if (IndexPag == 2 && item.GetType().ToString() == "Console_RPG.Items.Keys")
                    {
                        ShowedItems.Add(item);
                    }
                    else if (IndexPag == 3 && item.GetType().ToString() == "Console_RPG.Items.Potions")
                    {
                        ShowedItems.Add(item);
                    }
                    else if (IndexPag == 4 && item.GetType().ToString() == "Console_RPG.Items.Foods")
                    {
                        ShowedItems.Add(item);
                    }
                    else if (IndexPag == 5 && item.GetType().ToString() == "Console_RPG.Items.Miscellaneous")
                    {
                        ShowedItems.Add(item);
                    }
                    else if (IndexPag == 6 && item.GetType().ToString() == "Console_RPG.Items.Notes")
                    {
                        ShowedItems.Add(item);
                    }
                }

                for (int i = 0; i < 13; i++)
                {
                    string prefix = (i == SelectedIndex) ? ">" : " ";
                    SetCursorPosition(81, 3 + i);
                    try
                    {
                        if (ShowedItems[0 + i].Name == EquipedWeapon.Name || ShowedItems[0 + i].Name == EquipedArmor.Name)
                        {
                            Write($"{prefix} {ShowedItems[0 + i].Name}");
                            ForegroundColor = ConsoleColor.Yellow;
                            Write(" <Equipado>");
                            ResetColor();
                        }
                        else Write($"{prefix} {ShowedItems[0 + i].Name}");
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Write($"");
                    }
                }

                if (ShowedItems.Count > 0) ItemDescription(ShowedItems[SelectedIndex]);
                else Render.ConsoleClear("                                                  ", 11, 80, 18);

                SetCursorPosition(81, 16);
                Write("[<]                                          [>]");

                string type;
                switch (IndexPag)
                {
                    case 0:
                        type = "Armas";
                        SetCursorPosition(101, 16);
                        Write($"[{type}]");
                        break;
                    case 1:
                        type = "Armaduras";
                        SetCursorPosition(99, 16);
                        Write($"[{type}]");
                        break;
                    case 2:
                        type = "Chaves";
                        SetCursorPosition(101, 16);
                        Write($"[{type}]");
                        break;
                    case 3:
                        type = "Poções";
                        SetCursorPosition(101, 16);
                        Write($"[{type}]");
                        break;
                    case 4:
                        type = "Comidas";
                        SetCursorPosition(100, 16);
                        Write($"[{type}]");
                        break;
                    case 5:
                        type = "Diversos";
                        SetCursorPosition(100, 16);
                        Write($"[{type}]");
                        break;
                    case 6:
                        type = "Notas";
                        SetCursorPosition(102, 16);
                        Write($"[{type}]");
                        break;
                }

                ConsoleKeyInfo PressedKey;
                do
                {
                    PressedKey = ReadKey(true);

                } while (KeyAvailable);

                switch (PressedKey.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (IndexPag > 0)
                        {
                            SelectedIndex = 0;
                            IndexPag--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (IndexPag < 6)
                        {
                            SelectedIndex = 0;
                            IndexPag++;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (SelectedIndex > 0) SelectedIndex--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (SelectedIndex < ShowedItems.Count - 1) SelectedIndex++;
                        break;
                    case ConsoleKey.Escape:
                        Render.ConsoleClear("                                                  ", 29, 80, 0);
                        AvaliableMenu = false;
                        break;
                    case ConsoleKey.Enter:
                        try
                        {
                            switch (ShowedItems[SelectedIndex].GetType().ToString())
                            {
                                case "Console_RPG.Items.Weapons":
                                case "Console_RPG.Items.Armors":
                                    EquipItem(ShowedItems[SelectedIndex]);
                                    break;
                                case "Console_RPG.Items.Potions":
                                case "Console_RPG.Items.Foods":
                                    UseItem(ShowedItems[SelectedIndex]);
                                    if (SelectedIndex == ShowedItems.Count - 1) SelectedIndex--;
                                    break;
                            }
                        }
                        catch
                        {

                        }
                        break;
                }
                ShowedItems.Clear();
            }
        }
        private static void ItemDescription(Item item)
        {
            item.ItemDescription();
        }
        internal void SkillsMenu()
        {
            Render.Draw(LevelParser.ParseFileToArray("Text_Files\\Inventory&Skills&Stats_Box.txt"), 80, 0);
            SetCursorPosition(99, 1);
            Write("[Técnicas]");

            bool AvaliableSkillMenu = true;
            int SelectedIndex = 0;
            do
            {
                Render.ConsoleClear("                          ", 13, 81, 3);                
                for (int i = 0; i < Skills.Count; i++)
                {
                    string prefix = (i == SelectedIndex) ? ">" : " ";
                    SetCursorPosition(81, 3 + i + i);
                    if (Skills[i] == EquipedSkill)
                    {
                        Write($"{prefix} {Skills[i]}");
                        ForegroundColor = ConsoleColor.Yellow;
                        Write(" <Equipado>");
                        ResetColor();
                    }
                    else Write($"{prefix} {Skills[i]}");
                }
                ResetColor();

                try
                {
                    switch (Skills[SelectedIndex])
                    {
                        case "Golpe Rápido":
                        case "Estocada":
                            SetCursorPosition(81, 14);
                            Write("[Custo de Energia: 3]");
                            break;
                        case "Corte da Lua":
                        case "Dilacerar":
                            SetCursorPosition(81, 14);
                            Write("[Custo de Energia: 5]");
                            break;
                        case "Raios Divinos":
                            SetCursorPosition(81, 14);
                            Write("[Custo de Energia: 40]");
                            break;
                    }
                }
                catch { }

                ForegroundColor = (SelectedIndex == Skills.Count) ? ConsoleColor.White : ConsoleColor.DarkGray;
                SetCursorPosition(102, 16);
                Write("[Sair]");
                ResetColor();

                ConsoleKeyInfo PressedKey;
                do
                {
                    PressedKey = ReadKey(true);
                } while (KeyAvailable);

                switch (PressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        SelectedIndex--;
                        if (SelectedIndex < 0) SelectedIndex = 0;
                        break;
                    case ConsoleKey.DownArrow:
                        SelectedIndex++;
                        if (SelectedIndex > Skills.Count) SelectedIndex = Skills.Count;
                        break;
                    case ConsoleKey.Enter:
                        try
                        {
                            EquipSkill(Skills[SelectedIndex]);
                        }
                        catch
                        {
                            AvaliableSkillMenu = false;
                            Render.ConsoleClear("                                                  ", 18, 80, 0);
                        }
                        break;
                    case ConsoleKey.Escape:
                        AvaliableSkillMenu = false;
                        Render.ConsoleClear("                                                  ", 18, 80, 0);
                        break;
                }
            } while (AvaliableSkillMenu);
        }
        internal void LevelUp()
        {
            if (Experience >= ExperienceToNextLevel && CurrentLevel < 10)
            {
                Experience -= ExperienceToNextLevel;
                CurrentLevel++;
                if (CurrentLevel % 2 == 0)
                {
                    BaseDamagePoints++;
                    BaseDefensePoints++;
                }                
                LevelUpStatsCalculator();
                ExperienceCalculator();

                Render.ConsoleClear("                                  ", 5, 95, 34);
                SetCursorPosition(95, 34);
                Write($"Seus atributos fisicos aumentaram!");
                SetCursorPosition(95, 38);
                Write("Continuar...");
                ReadKey();
            }
        }
        internal void ExperienceCalculator()
        {
            ExperienceToNextLevel = Convert.ToInt32((0 + CurrentLevel * 15) * 1.33);
        }
        internal void FoundItem(Item item)
        {
            Inventory.Add(item);
            GameConsole.ConsoleOutput($"{item.Name} foi adicionado ao inventário.");
        }
        internal void RemoveItem(Item item)
        {
            Inventory.Remove(item);
            GameConsole.ConsoleOutput($"{item.Name} foi removido do inventário.");
        }
        internal void EquipItem(Item item)
        {
            if (EquipedWeapon != item && item.GetType().ToString() == "Console_RPG.Items.Weapons")
            {
                Sound.SFXPlayer("EquipItemSFX.wav");
                EquipedWeapon = (Weapons)item;
            }
            else if (EquipedArmor != item && item.GetType().ToString() == "Console_RPG.Items.Armors")
            {
                Sound.SFXPlayer("EquipItemSFX.wav");
                EquipedArmor = (Armors)item;
            }
        }
        internal void UseItem(Item item)
        {
            if (item.GetType().ToString() == "Console_RPG.Items.Potions")
            {
                Sound.SFXPlayer("DrinkPotionSFX.wav");
                Potions p = (Potions)item;
                if (item.Name.Contains("Calêndula"))
                {
                    RecieveHealthPoints(p.HealingPotion());
                    Inventory.Remove(item);
                }
                else if (item.Name.Contains("Ephedra"))
                {
                    RecieveStaminaPoints(p.AdrenalinePotion());
                    Inventory.Remove(item);
                }
            }
            else if (item.GetType().ToString() == "Console_RPG.Items.Foods")
            {
                Sound.SFXPlayer("EatingSFX.wav");
                Foods f = (Foods)item;
                switch (f.Quality)
                {
                    case "Bad":
                        TakeDamage(f.FoodPoisoning());
                        Inventory.Remove(item);
                        if (CurrentHealthPoints <= 0) Game.GameOver();
                        break;
                    case "Good":
                        RecieveHealthPoints(f.FoodHealing());
                        RecieveStaminaPoints(f.FoodRecovery());
                        Inventory.Remove(item);
                        break;
                    case "Excellent":
                        RecieveHealthPoints(f.FoodHealing());
                        RecieveStaminaPoints(f.FoodRecovery());
                        Inventory.Remove(item);
                        break;
                }
            }
        }
        internal void UseItemBattle(Potions potion)
        {
            if (potion.Name.Contains("Calêndula"))
            {
                RecieveHealthPoints(potion.HealingPotion());
                Inventory.Remove(potion);

                Render.ConsoleClear("                                  ", 5, 95, 34);
                string text = $"Você usou {potion.Name} e recuperou {potion.HealAmount} pontos de vida!";
                SetCursorPosition(95, 34);
                Write($"{text[..34]}");
                SetCursorPosition(95, 35);
                if (text[34..].StartsWith(' ')) Write($"{text[35..]}"); else Write($"{text[34..]}");
                SetCursorPosition(95, 38);
                Write("Continuar...");
                ReadKey();
            }
            else if (potion.Name.Contains("Ephedra"))
            {
                RecieveStaminaPoints(potion.AdrenalinePotion());
                Inventory.Remove(potion);

                Render.ConsoleClear("                                  ", 5, 95, 34);
                string text = $"Você usou {potion.Name} e recuperou {potion.HealAmount} pontos de Energia!";
                SetCursorPosition(95, 34);
                Write($"{text[..34]}");
                SetCursorPosition(95, 35);
                if (text[34..].StartsWith(' ')) Write($"{text[35..]}"); else Write($"{text[34..]}");
                SetCursorPosition(95, 38);
                Write("Continuar...");
                ReadKey();
            }
        }
        internal void EquipSkill(string skill)
        {
            EquipedSkill = skill;
        }
        internal void TakeSkill(string skill)
        {
            Skills.Add(skill);
        }
        internal override void BattleInformation()
        {
            int HpPercentage = Convert.ToInt32(Convert.ToDouble(CurrentHealthPoints) / Convert.ToDouble(CurrentMaxHealthPoints) * 100);
            int SpPercentage = Convert.ToInt32(Convert.ToDouble(CurrentStaminaPoints) / Convert.ToDouble(CurrentMaxStaminaPoints) * 100);

            SetCursorPosition(82, 26);
            Write(Name);

            SetCursorPosition(81, 28);
            Write($"PV: {CurrentHealthPoints}/{CurrentMaxHealthPoints}");
            Menu.PercentageBar(HpPercentage, 9, 82, 29, ConsoleColor.DarkRed);

            SetCursorPosition(93, 28);
            Write($"PE: {CurrentStaminaPoints}/{CurrentMaxStaminaPoints}");
            Menu.PercentageBar(SpPercentage, 9, 94, 29, ConsoleColor.DarkGreen);

            SetCursorPosition(82, 31);
            if (EquipedWeapon.Name != "Vazio") Write(EquipedWeapon.Name.Substring(0, (EquipedWeapon.Name.Length < 9) ? EquipedWeapon.Name.Length : 9)); else Write("  Vazio  ");

            SetCursorPosition(94, 31);
            if (EquipedArmor.Name != "Vazio") Write(EquipedArmor.Name.Substring(0, (EquipedArmor.Name.Length < 9) ? EquipedArmor.Name.Length : 9)); else Write("  Vazio  ");
        }
    }
}
