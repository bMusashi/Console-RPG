﻿using Console_RPG.Entities;
using Console_RPG.Items;
using System;
namespace Console_RPG.Assistant
{
    internal class Battle
    {
        private static readonly Random rnd = new();
        internal static void OneVersusOne(Player player, Enemy enemy)
        {
            do
            {
                //Player's Turn
                string[] Options = { Game.currentLanguageStrings["OneVersusOneOptionAttack"], Game.currentLanguageStrings["OneVersusOneOptionSkill"], Game.currentLanguageStrings["OneVersusOneOptionItem"] };
                bool AvailableOptionsMenu = true;
                int OptionsIndex = 0;
                int MissedTurn = 0;
                Render.Draw(LevelParser.ParseFileToArray("Text_Files\\Battle_Box.txt"), 80, 0);
                SetCursorPosition(101, 26);
                Write(Game.currentLanguageStrings["OneVersusOneBattlesText"]);
                SetCursorPosition(80, 30);
                Write(Game.currentLanguageStrings["│ Weapon    │ Armor     ││ Weapon      Armor     │"]);
                Render.Draw(LevelParser.ParseFileToArray(enemy.EnemySprite), 81, 1);
                while (AvailableOptionsMenu)
                {
                    player.BattleInformation();
                    enemy.BattleInformation();
                    for (int i = 0; i < Options.Length; i++)
                    {
                        ForegroundColor = (i == OptionsIndex) ? ConsoleColor.White : ConsoleColor.DarkGray;

                        switch (i)
                        {
                            case 0:
                                SetCursorPosition(83, 32);
                                break;
                            case 1:
                                SetCursorPosition(90, 32);
                                break;
                            case 2:
                                SetCursorPosition(98, 32);
                                break;
                        }
                        Write($"{Options[i]}");
                    }

                    ResetColor();

                    ConsoleKeyInfo PressedKey;
                    do
                    {
                        PressedKey = ReadKey(true);
                    } while (KeyAvailable);

                    switch (PressedKey.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            OptionsIndex--;
                            if (OptionsIndex < 0) OptionsIndex = 0;
                            break;
                        case ConsoleKey.RightArrow:
                            OptionsIndex++;
                            if (OptionsIndex > Options.Length - 1) OptionsIndex = Options.Length - 1;
                            break;
                        case ConsoleKey.Enter:
                            switch (OptionsIndex)
                            {
                                case 0:
                                    bool AvailableAttacksMenu = true;
                                    int AttacksIndex = 0;
                                    int SuccessAttack = 0;
                                    while (AvailableAttacksMenu)
                                    {
                                        Render.ConsoleClear("                                  ", 5, 95, 34);
                                        for (int i = 0; i < player.Attacks.Length; i++)
                                        {
                                            ForegroundColor = (i == AttacksIndex) ? ConsoleColor.White : ConsoleColor.DarkGray;
                                            SetCursorPosition(81, 34 + i);
                                            Write(player.Attacks[i]);
                                        }

                                        ResetColor();

                                        do
                                        {
                                            PressedKey = ReadKey(true);

                                        } while (KeyAvailable);

                                        switch (PressedKey.Key)
                                        {
                                            case ConsoleKey.UpArrow:
                                                AttacksIndex--;
                                                if (AttacksIndex < 0) AttacksIndex = 0;
                                                break;
                                            case ConsoleKey.DownArrow:
                                                AttacksIndex++;
                                                if (AttacksIndex > player.Attacks.Length - 1) AttacksIndex = player.Attacks.Length - 1;
                                                break;
                                            case ConsoleKey.Enter:
                                                switch (player.Attacks[AttacksIndex])
                                                {
                                                    case "Light Attack":
                                                    case "Ataque Ligero":
                                                    case "Ataque Leve":
                                                        player.BattleTurnIndicator();
                                                        SuccessAttack = player.LightAttack(enemy);                                                        
                                                        if (SuccessAttack == 255)
                                                        {
                                                            BattleSkillFail();
                                                            MissedTurn++;
                                                        }
                                                        if (SuccessAttack != 255) enemy.TakeDamage(SuccessAttack);
                                                        break;
                                                    case "Heavy Attack":
                                                    case "Ataque Pesado":
                                                        player.BattleTurnIndicator();
                                                        SuccessAttack = player.HeavyAttack(enemy);
                                                        if (SuccessAttack == 255)
                                                        {
                                                            BattleSkillFail();
                                                            MissedTurn++;
                                                        }
                                                        if (SuccessAttack != 255) enemy.TakeDamage(SuccessAttack);
                                                        break;
                                                }
                                                if (SuccessAttack != 255)
                                                {
                                                    AvailableAttacksMenu = false;
                                                    AvailableOptionsMenu = false;
                                                }
                                                break;
                                            case ConsoleKey.Escape:
                                                AttacksIndex = 0;
                                                AvailableAttacksMenu = false;
                                                Render.ConsoleClear("             ", 5, 81, 34);                                                
                                                break;
                                        }
                                        if (MissedTurn > 1)
                                        {
                                            AvailableAttacksMenu = false;
                                            AvailableOptionsMenu = false;
                                            BattleLostTurn(player.Name);
                                        }
                                    }
                                    break;
                                case 1:
                                    bool AvailableSkillsMenu = true;
                                    int SuccessSkill = 0;
                                    while (AvailableSkillsMenu && player.EquipedSkill != "Vazio")
                                    {
                                        Render.ConsoleClear("                                  ", 5, 95, 34);
                                        SetCursorPosition(81, 34);
                                        Write(player.EquipedSkill);

                                        do
                                        {
                                            PressedKey = ReadKey(true);

                                        } while (KeyAvailable);

                                        switch (PressedKey.Key)
                                        {
                                            case ConsoleKey.Enter:
                                                try
                                                {
                                                    switch (player.EquipedSkill)
                                                    {
                                                        case "Slash":
                                                        case "Golpe Rápido":
                                                            player.BattleTurnIndicator();
                                                            SuccessSkill = player.QuickStrike(enemy);
                                                            if (SuccessSkill == 255)
                                                            {
                                                                BattleSkillFail();
                                                                MissedTurn++;
                                                            }
                                                            if (SuccessSkill != 255) enemy.TakeDamage(SuccessSkill);
                                                            break;
                                                        case "Thrust":
                                                        case "Estocada":
                                                            player.BattleTurnIndicator();
                                                            SuccessSkill = player.Thrust(enemy);
                                                            if (SuccessSkill == 255)
                                                            {
                                                                BattleSkillFail();
                                                                MissedTurn++;
                                                            }
                                                            if (SuccessSkill != 255) enemy.TakeDamage(SuccessSkill);
                                                            break;
                                                        case "Moon Slash":
                                                        case "Corte de Luna":
                                                        case "Corte da Lua":
                                                            player.BattleTurnIndicator();
                                                            SuccessSkill = player.MoonSlash(enemy);
                                                            if (SuccessSkill == 255)
                                                            {
                                                                BattleSkillFail();
                                                                MissedTurn++;
                                                            }
                                                            if (SuccessSkill != 255) enemy.TakeDamage(SuccessSkill);
                                                            break;
                                                        case "Blood Thrust":
                                                        case "Desgarrar":
                                                        case "Dilacerar":
                                                            player.BattleTurnIndicator();
                                                            SuccessSkill = player.Lacerate(enemy);
                                                            if (SuccessSkill == 255)
                                                            {
                                                                BattleSkillFail();
                                                                MissedTurn++;
                                                            }
                                                            if (SuccessSkill != 255) enemy.TakeDamage(SuccessSkill);
                                                            break;
                                                        case "God Rays":
                                                        case "Rayos Divinos":
                                                        case "Raios Divinos":
                                                            player.BattleTurnIndicator();
                                                            SuccessSkill = player.GodRays();
                                                            if (SuccessSkill == 255)
                                                            {
                                                                BattleSkillFail();
                                                                MissedTurn++;
                                                            }
                                                            if (SuccessSkill != 255) enemy.TakeDamage(SuccessSkill);
                                                            break;
                                                    }
                                                    if (SuccessSkill != 255)
                                                    {
                                                        AvailableSkillsMenu = false;
                                                        AvailableOptionsMenu = false;
                                                    }
                                                }
                                                catch { }
                                                break;
                                            case ConsoleKey.Escape:
                                                AvailableSkillsMenu = false;
                                                Render.ConsoleClear("             ", 5, 81, 34);                                                
                                                break;
                                        }
                                        if (MissedTurn > 1)
                                        {
                                            AvailableSkillsMenu = false;
                                            AvailableOptionsMenu = false;
                                            BattleLostTurn(player.Name);
                                        }
                                    }
                                    break;
                                case 2:
                                    List<Potions> ShowedPotions = [];
                                    foreach (Item item in player.Inventory)
                                    {
                                        if (item.GetType().ToString() == "Console_RPG.Items.Potions") ShowedPotions.Add((Potions)item);
                                    }
                                    bool AvailableItemsMenu = true;
                                    int ItemIndex = 0;
                                    int ItemStartIndex = 0;
                                    int ItemEndIndex = 4;
                                    while (AvailableItemsMenu && ShowedPotions.Count > 0)
                                    {
                                        int j = 0;
                                        for (int i = ItemStartIndex; i <= ItemEndIndex; i++)
                                        {
                                            ForegroundColor = (i == ItemIndex) ? ConsoleColor.White : ConsoleColor.DarkGray;

                                            try
                                            {
                                                SetCursorPosition(81, 34 + j);
                                                string name = string.Empty;
                                                switch (ShowedPotions[i].Name)
                                                {
                                                    case "Small Calendula Potion":                                                        
                                                    case "Poción de Caléndula Pequeña":                                                        
                                                    case "Poção de Calêndula Pequena":
                                                        name = Game.currentLanguageStrings["BattleItemMenuSmallCalendulaPotionShort"];
                                                        break;
                                                    case "Medium Calendula Potion":                                                        
                                                    case "Poción de Caléndula Mediana":                                                        
                                                    case "Poção de Calêndula Média":
                                                        name = Game.currentLanguageStrings["BattleItemMenuMediumCalendulaPotionShort"];
                                                        break;
                                                    case "Large Calendula Potion":                                                        
                                                    case "Poción de Caléndula Grande":                                                        
                                                    case "Poção de Calêndula Grande":
                                                        name = Game.currentLanguageStrings["BattleItemMenuLargeCalendulaPotionShort"];
                                                        break;
                                                    case "Small Ephedra Potion":
                                                    case "Poción de Ephedra Pequeña":
                                                    case "Poção de Ephedra Pequena":
                                                        name = Game.currentLanguageStrings["BattleItemMenuSmallEphedraPotionShort"];
                                                        break;
                                                    case "Medium Ephedra Potion":
                                                    case "Poción de Ephedra Mediana":
                                                    case "Poção de Ephedra Média":
                                                        name = Game.currentLanguageStrings["BattleItemMenuMediumEphedraPotionShort"];
                                                        break;
                                                    case "Large Ephedra Potion":
                                                    case "Poción de Ephedra Grande":
                                                    case "Poção de Ephedra Grande":
                                                        name = Game.currentLanguageStrings["BattleItemMenuLargeEphedraPotionShort"];
                                                        break;
                                                }
                                                Write($"{name}");
                                                j++;
                                            }
                                            catch { }
                                        }
                                        ResetColor();

                                        do
                                        {
                                            PressedKey = ReadKey(true);

                                        } while (KeyAvailable);

                                        switch (PressedKey.Key)
                                        {
                                            case ConsoleKey.UpArrow:
                                                ItemIndex--;
                                                if (ItemIndex < ItemStartIndex && ItemIndex > -1)
                                                {
                                                    ItemStartIndex--;
                                                    ItemEndIndex--;
                                                }
                                                if (ItemIndex < 0) ItemIndex = 0;
                                                break;
                                            case ConsoleKey.DownArrow:
                                                ItemIndex++;
                                                if (ItemIndex > ItemEndIndex && ItemIndex < ShowedPotions.Count)
                                                {
                                                    ItemStartIndex++;
                                                    ItemEndIndex++;
                                                }
                                                if (ItemIndex > ShowedPotions.Count - 1) ItemIndex = ShowedPotions.Count - 1;
                                                break;
                                            case ConsoleKey.Enter:
                                                try
                                                {
                                                    if (ShowedPotions[ItemIndex].Name.Contains(Game.currentLanguageStrings["BattleItemPieceCalendula"]))
                                                    {
                                                        player.BattleTurnIndicator();
                                                        player.UseItemBattle(ShowedPotions[ItemIndex]);
                                                    }
                                                    else if (ShowedPotions[ItemIndex].Name.Contains(Game.currentLanguageStrings["BattleItemPieceEphedra"]))
                                                    {
                                                        player.BattleTurnIndicator();
                                                        player.UseItemBattle(ShowedPotions[ItemIndex]);
                                                    }
                                                    AvailableItemsMenu = false;
                                                    AvailableOptionsMenu = false;
                                                }
                                                catch
                                                {

                                                }
                                                break;
                                            case ConsoleKey.Escape:
                                                AvailableItemsMenu = false;
                                                Render.ConsoleClear("             ", 5, 81, 34);
                                                break;
                                        }
                                    }
                                    break;
                            }
                            break;
                    }
                }
                //Enemy's turn
                if (enemy.IsAlive())
                {
                    Render.Draw(LevelParser.ParseFileToArray("Text_Files//Battle_Box.txt"), 80, 0);
                    SetCursorPosition(101, 26);
                    Write(Game.currentLanguageStrings["OneVersusOneBattlesText"]);
                    SetCursorPosition(80, 30);
                    Write(Game.currentLanguageStrings["│ Weapon    │ Armor     ││ Weapon      Armor     │"]);
                    player.BattleInformation();
                    enemy.BattleInformation();
                    Render.Draw(LevelParser.ParseFileToArray(enemy.EnemySprite), 81, 1);
                    enemy.BattleTurnIndicator();
                    Thread.Sleep(2000);
                    int choice = rnd.Next(0, 99);
                    int SuccessAttack = 0;

                    switch (enemy.Name)
                    {
                        case "Giant Rat":
                        case "Rato Gigante":
                        case "Rata Gigante":
                            if (choice >= 0 && choice <= 89)
                            {
                                SuccessAttack = enemy.RatBite(player);
                                if (SuccessAttack != 255) player.TakeDamage(SuccessAttack);
                                else enemy.BattleAttackSkillMiss();
                            }
                            else enemy.BattleAttackSkillMiss();
                            break;
                        case "Skeleton":
                        case "Esqueleto":
                            if (choice >= 0 && choice <= 59)
                            {
                                SuccessAttack = enemy.LightAttack(player);
                                if (SuccessAttack != 255) player.TakeDamage(SuccessAttack);
                                else enemy.BattleAttackSkillMiss();
                            }
                            else if (choice >= 60 && choice <= 89)
                            {
                                SuccessAttack = enemy.QuickStrike(player);
                                if (SuccessAttack != 255) player.TakeDamage(SuccessAttack);
                                else enemy.BattleAttackSkillMiss();
                            }
                            else enemy.BattleAttackSkillMiss();
                            break;
                        case "Ladrão":
                        case "Thief":
                        case "Ladrón":
                            if (choice >= 0 && choice <= 29)
                            {
                                SuccessAttack = enemy.LightAttack(player);
                                if (SuccessAttack != 255) player.TakeDamage(SuccessAttack);
                                else enemy.BattleAttackSkillMiss();
                            }
                            else if (choice >= 30 && choice <= 59)
                            {
                                SuccessAttack = enemy.QuickStrike(player);
                                if (SuccessAttack != 255) player.TakeDamage(SuccessAttack);
                                else enemy.BattleAttackSkillMiss();
                            }
                            else if (choice >= 60 && choice <= 88)
                            {
                                SuccessAttack = enemy.Thrust(player);
                                if (SuccessAttack != 255) player.TakeDamage(SuccessAttack);
                                else enemy.BattleAttackSkillMiss();
                            }
                            else enemy.BattleAttackSkillMiss();
                            break;
                        case "Bandit":
                        case "Bandido":
                            if (choice >= 0 && choice <= 29)
                            {
                                SuccessAttack = enemy.LightAttack(player);
                                if (SuccessAttack != 255) player.TakeDamage(SuccessAttack);
                                else enemy.BattleAttackSkillMiss();
                            }
                            else if (choice >= 30 && choice <= 59)
                            {
                                SuccessAttack = enemy.HeavyAttack(player);
                                if (SuccessAttack != 255) player.TakeDamage(SuccessAttack);
                                else enemy.BattleAttackSkillMiss();
                            }
                            else if (choice >= 60 && choice <= 88)
                            {
                                SuccessAttack = enemy.QuickStrike(player);
                                if (SuccessAttack != 255) player.TakeDamage(SuccessAttack);
                                else enemy.BattleAttackSkillMiss();
                            }
                            else enemy.BattleAttackSkillMiss();
                            break;
                        case "Serpent Man":
                        case "Hombre Serpiente":
                        case "Homem Serpente":
                            if (choice >= 0 && choice <= 28)
                            {
                                SuccessAttack = enemy.LightAttack(player);
                                if (SuccessAttack != 255) player.TakeDamage(SuccessAttack);
                                else enemy.BattleAttackSkillMiss();
                            }
                            else if (choice >= 29 && choice <= 57)
                            {
                                SuccessAttack = enemy.HeavyAttack(player);
                                if (SuccessAttack != 255) player.TakeDamage(SuccessAttack);
                                else enemy.BattleAttackSkillMiss();
                            }
                            else if (choice >= 58 && choice <= 79)
                            {
                                SuccessAttack = enemy.QuickStrike(player);
                                if (SuccessAttack != 255) player.TakeDamage(SuccessAttack);
                                else enemy.BattleAttackSkillMiss();
                            }
                            else if (choice >= 80 && choice <= 89)
                            {
                                SuccessAttack = enemy.MoonSlash(player);
                                if (SuccessAttack != 255) player.TakeDamage(SuccessAttack);
                                else enemy.BattleAttackSkillMiss();
                            }
                            else enemy.BattleAttackSkillMiss();
                            break;
                        case "Undead":
                        case "Muerto Viviente":
                        case "Morto-Vivo":                        
                            if (choice >= 0 && choice <= 48)
                            {
                                SuccessAttack = enemy.HeavyAttack(player);
                                if (SuccessAttack != 255) player.TakeDamage(SuccessAttack);
                                else enemy.BattleAttackSkillMiss();
                            }
                            else if (choice >= 49 && choice <= 88)
                            {
                                SuccessAttack = enemy.UndeadBite(player);
                                if (SuccessAttack != 255) player.TakeDamage(SuccessAttack);
                                else enemy.BattleAttackSkillMiss();
                            }
                            else enemy.BattleAttackSkillMiss();
                            break;
                        case "Bandit Marauder":
                        case "Bandido Merodeador":
                        case "Bandido Saqueador":
                            if (choice >= 0 && choice <= 46)
                            {
                                SuccessAttack = enemy.HeavyAttack(player);
                                if (SuccessAttack != 255) player.TakeDamage(SuccessAttack);
                                else enemy.BattleAttackSkillMiss();
                            }
                            else if (choice >= 47 && choice <= 76)
                            {
                                SuccessAttack = enemy.Smash(player);
                                if (SuccessAttack != 255) player.TakeDamage(SuccessAttack);
                                else enemy.BattleAttackSkillMiss();
                            }
                            else if (choice >= 77 && choice <= 89)
                            {
                                SuccessAttack = enemy.BodyCrush(player);
                                if (SuccessAttack != 255) player.TakeDamage(SuccessAttack);
                                else enemy.BattleAttackSkillMiss();
                            }
                            else enemy.BattleAttackSkillMiss();
                            break;
                        case "Mad Warrior":
                        case "Guerrero Loco":
                        case "Guerreiro Louco":
                            if (choice >= 0 && choice <= 46)
                            {
                                SuccessAttack = enemy.HeavyAttack(player);
                                if (SuccessAttack != 255) player.TakeDamage(SuccessAttack);
                                else enemy.BattleAttackSkillMiss();
                            }
                            else if (choice >= 47 && choice <= 76)
                            {
                                SuccessAttack = enemy.Lacerate(player);
                                if (SuccessAttack != 255) player.TakeDamage(SuccessAttack);
                                else enemy.BattleAttackSkillMiss();
                            }
                            else if (choice >= 77 && choice <= 89)
                            {
                                SuccessAttack = enemy.BodySlam(player);
                                if (SuccessAttack != 255) player.TakeDamage(SuccessAttack);
                                else enemy.BattleAttackSkillMiss();
                            }
                            else enemy.BattleAttackSkillMiss();
                            break;
                        case "Undead Dragon":
                        case "Dragón Muerto Viviente":
                        case "Dragão Morto-Vivo":
                            if (choice >= 0 && choice <= 46)
                            {
                                SuccessAttack = enemy.DragonBite(player);
                                if (SuccessAttack != 255) player.TakeDamage(SuccessAttack);
                                else enemy.BattleAttackSkillMiss();
                            }
                            else if (choice >= 47 && choice <= 76)
                            {
                                SuccessAttack = enemy.TailWhipping(player);
                                if (SuccessAttack != 255) player.TakeDamage(SuccessAttack);
                                else enemy.BattleAttackSkillMiss();
                            }
                            else if (choice >= 77 && choice <= 89)
                            {
                                SuccessAttack = enemy.FireBreath(player);
                                if (SuccessAttack != 255) player.TakeDamage(SuccessAttack);
                                else enemy.BattleAttackSkillMiss();
                            }
                            else enemy.BattleAttackSkillMiss();
                            break;
                    }
                }

            }while (player.IsAlive() && enemy.IsAlive());
            if (player.IsAlive())
            {                
                Render.ConsoleClear("                     ", 2, 107, 28);
                enemy.BattleInformation();
                BattleWin(player.Name);
                player.RecieveExperience(enemy.ExperienceGiven);
                player.LevelUp();
                Render.ConsoleClear("                                                  ", 40, 80, 0);                
            }
            else
            {                
                Render.ConsoleClear("        ", 2, 82, 28);
                player.BattleInformation();
                BattleWin(enemy.Name);                
                Game.GameOver();
            }
        }
        internal static void BattleCastText(string entityName, string skillName, int damage)
        {
            Render.ConsoleClear("                                  ", 5, 95, 34);            
            string text = $"{entityName} {Game.currentLanguageStrings["BattleCastTextPartOne"]} {skillName}, {Game.currentLanguageStrings["BattleCastTextPartTwo"]} {damage} {Game.currentLanguageStrings["BattleCastTextPartThree"]}!";

            SetCursorPosition(95, 34);
            Write($"{text[..34]}");
            SetCursorPosition(95, 35);
            if (text[34..].StartsWith(' ')) Write($"{text[35..]}"); else Write($"{text[34..]}");
            SetCursorPosition(95, 38);
            Write(Game.currentLanguageStrings["Continue"]);
            Thread.Sleep(500);
            ReadKey();
        }
        internal static void BattleSkillFail()
        {
            Render.ConsoleClear("                                  ", 5, 95, 34);
            SetCursorPosition(95, 34);
            Write(Game.currentLanguageStrings["BattleSkillFailInsufficientEnergy"]);
            SetCursorPosition(95, 38);
            Write(Game.currentLanguageStrings["Continue"]);
            ReadKey();
        }
        internal static void BattleLostTurn(string name)
        {
            Render.ConsoleClear("                                  ", 1, 95, 34);            
            SetCursorPosition(95, 34);
            Write($"{name} {Game.currentLanguageStrings["BattleLostTurnMissedTheTurn"]}.");
            SetCursorPosition(95, 38);
            Write(Game.currentLanguageStrings["Continue"]);
            ReadKey();
        }
        internal static void BattleWin(string name)
        {
            Render.ConsoleClear("                                  ", 5, 95, 34);            
            SetCursorPosition(95, 34);
            Write($"{name} {Game.currentLanguageStrings["BattleWinWonTheBattle"]}!");
            SetCursorPosition(95, 38);
            Write(Game.currentLanguageStrings["Continue"]);
            ReadKey();
        }
    }
}
