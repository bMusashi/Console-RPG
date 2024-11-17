using Console_RPG.Entities;
using Console_RPG.Items;

namespace Console_RPG.Assistant
{
    internal class Events
    {
        private static List<Weapons> Weapons = new()
        {
            new (Game.currentLanguageStrings["DaggerName"], Game.currentLanguageStrings["DaggerDescription"],4),
            new (Game.currentLanguageStrings["AncientIronFalcataName"], Game.currentLanguageStrings["AncientIronFalcataDescription"],2),
            new (Game.currentLanguageStrings["IronFalcataName"], Game.currentLanguageStrings["IronFalcataDescription"],4),
            new (Game.currentLanguageStrings["SteelClaymoreName"], Game.currentLanguageStrings["SteelClaymoreDescription"], 6),
            new (Game.currentLanguageStrings["RadiantName"], Game.currentLanguageStrings["RadiantDescription"], 8),
            new (Game.currentLanguageStrings["SerpentMen'sSerpentinaName"], Game.currentLanguageStrings["SerpentMen'sSerpentinaDescription"], 6),
            new (Game.currentLanguageStrings["ScimitarName"], Game.currentLanguageStrings["ScimitarDescription"], 4),
            new (Game.currentLanguageStrings["EclipseName"], Game.currentLanguageStrings["EclipseDescription"], 8),
            new (Game.currentLanguageStrings["AxeName"], Game.currentLanguageStrings["AxeDescription"], 4),
            new (Game.currentLanguageStrings["DevastatorName"], Game.currentLanguageStrings["DevastatorDescription"], 8),
            new (Game.currentLanguageStrings["JawCutterName"], Game.currentLanguageStrings["JawCutterDescription"], 8)
        };
        private static List<Armors> Armors = new()
        {
            new (Game.currentLanguageStrings["TatteredClothesName"], Game.currentLanguageStrings["TatteredClothesDescription"], 2),
            new (Game.currentLanguageStrings["LeatherBreastplateName"], Game.currentLanguageStrings["LeatherBreastplateDescription"], 4),
            new (Game.currentLanguageStrings["Explorer'sJacketName"], Game.currentLanguageStrings["Explorer'sJacketDescription"], 4),
            new (Game.currentLanguageStrings["IronChainmailName"], Game.currentLanguageStrings["IronChainmailDescription"], 6),
            new (Game.currentLanguageStrings["PlateArmorName"], Game.currentLanguageStrings["PlateArmorDescription"], 8),
            new (Game.currentLanguageStrings["BlackMantleName"], Game.currentLanguageStrings["BlackMantleDescription"], 6)
        };
        private static List<Keys> Keys = new()
        {
            new (Game.currentLanguageStrings["RustyKeyName"], Game.currentLanguageStrings["RustyKeyDescription"]),
            new (Game.currentLanguageStrings["RuinsKeyName"], Game.currentLanguageStrings["RuinsKeyDescription"]),
            new (Game.currentLanguageStrings["SealKeyName"], Game.currentLanguageStrings["SealKeyDescription"]),
            new (Game.currentLanguageStrings["GreatAncientKeyName"], Game.currentLanguageStrings["GreatAncientKeyDescription"]),
            new (Game.currentLanguageStrings["ConfinementKeyName"], Game.currentLanguageStrings["ConfinementKeyDescription"]),
            new (Game.currentLanguageStrings["ChestKeyName"], Game.currentLanguageStrings["ChestKeyDescription"])
        };
        private static List<Potions> Potions = new()
        {
            new (Game.currentLanguageStrings["SmallCalendulaPotionName"], Game.currentLanguageStrings["SmallCalendulaPotionDescription"], 15),
            new (Game.currentLanguageStrings["MediumCalendulaPotionName"], Game.currentLanguageStrings["MediumCalendulaPotionDescription"],25),
            new (Game.currentLanguageStrings["LargeCalendulaPotionName"], Game.currentLanguageStrings["LargeCalendulaPotionDescription"],50),
            new (Game.currentLanguageStrings["SmallEphedraPotionName"], Game.currentLanguageStrings["SmallEphedraPotionDescription"],15),
            new (Game.currentLanguageStrings["MediumEphedraPotionName"],Game.currentLanguageStrings["MediumEphedraPotionDescription"], 25),
            new (Game.currentLanguageStrings["LargeEphedraPotionName"], Game.currentLanguageStrings["LargeEphedraPotionDescription"],50),
        };
        private static List<Foods> Foods = new()
        {
            new (Game.currentLanguageStrings["GiantRatMeatName"], Game.currentLanguageStrings["GiantRatMeatDescription"], "Bad", 15),
            new (Game.currentLanguageStrings["CookedGiantRatMeatName"], Game.currentLanguageStrings["CookedGiantRatMeatDescription"], "Good", 10),
            new (Game.currentLanguageStrings["BlackBreadName"], Game.currentLanguageStrings["BlackBreadDescription"], "Good", 10),
            new (Game.currentLanguageStrings["CheeseWedgeName"], Game.currentLanguageStrings["CheeseWedgeDescription"], "Excellent", 20),
            new (Game.currentLanguageStrings["ApplesName"], Game.currentLanguageStrings["ApplesDescription"], "Good", 10),
            new (Game.currentLanguageStrings["FishName"], Game.currentLanguageStrings["FishDescription"], "Bad", 15),
            new (Game.currentLanguageStrings["RoastedFishName"], Game.currentLanguageStrings["RoastedFishDescription"], "Good", 10),
            new (Game.currentLanguageStrings["GoldenAppleName"], Game.currentLanguageStrings["GoldenAppleDescription"], "Excellent", 20)
        };
        private static List<Miscellaneous> Miscellaneous = new()
        {
            new (Game.currentLanguageStrings["NecklaceName"], Game.currentLanguageStrings["NecklaceDescription"]),
            new (Game.currentLanguageStrings["GoldenNecklaceName"], Game.currentLanguageStrings["GoldenNecklaceDescription"]),
            new (Game.currentLanguageStrings["AncientPaintingName"], Game.currentLanguageStrings["AncientPaintingDescription"]),
            new (Game.currentLanguageStrings["Children'sStorybookName"], Game.currentLanguageStrings["Children'sStorybookDescription"]),
            new (Game.currentLanguageStrings["AncientDragonScaleName"], Game.currentLanguageStrings["AncientDragonScaleDescription"]),
            new (Game.currentLanguageStrings["DriedRootsName"], Game.currentLanguageStrings["DriedRootsDescription"]),
            new (Game.currentLanguageStrings["StrangeStoneName"], Game.currentLanguageStrings["StrangeStoneDescription"]),
            new (Game.currentLanguageStrings["RingName"], Game.currentLanguageStrings["RingDescription"]),
            new (Game.currentLanguageStrings["LockpickName"], Game.currentLanguageStrings["LockpickDescription"]),
        };
        private static List<Notes> Notes = new()
        {            
            new (Game.currentLanguageStrings["NoteEscapeName"], Game.currentLanguageStrings["NoteEscapeDescription"]),
            new (Game.currentLanguageStrings["NoteWarningName"], Game.currentLanguageStrings["NoteWarningDescription"]),
            new (Game.currentLanguageStrings["NoteInquiryName"], Game.currentLanguageStrings["NoteInquiryDescription"]),
            new (Game.currentLanguageStrings["NoteJourneyName"], Game.currentLanguageStrings["NoteJourneyDescription"]),                                  
            new (Game.currentLanguageStrings["NoteExpeditionName"], Game.currentLanguageStrings["NoteExpeditionDescription"]),
            new (Game.currentLanguageStrings["NoteBloodstainedName"], Game.currentLanguageStrings["NoteBloodstainedDescription"])
        };
        internal static void GameEventChests(Player player, string[,] map, string currentMap, string element)
        {
            switch (currentMap)
            {
                case "Catacombs":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 38:
                            Sound.SFXPlayer("ChestSFX.wav");
                            player.FoundItem(Armors[0]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 85:
                            Sound.SFXPlayer("ChestSFX.wav");
                            player.FoundItem(Potions[0]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                    }
                    break;
                case "Abandoned_Fortress":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 43:
                            if (player.Inventory.Contains(Miscellaneous[8]))
                            {
                                Sound.SFXPlayer("ChestSFX.wav");
                                player.RemoveItem(Miscellaneous[8]);
                                player.FoundItem(Weapons[4]);
                                Render.KillObject(player.X, player.Y, element, map, currentMap);
                            }
                            else
                            {
                                GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventIt’sLockedText"]);
                            }
                            break;
                    }
                    break;
                case "Ruins":
                    break;
                case "Old_Crypt":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 57:
                            if (player.Inventory.Contains(Keys[5]))
                            {
                                Sound.SFXPlayer("ChestSFX.wav");
                                player.RemoveItem(Keys[5]);
                                player.FoundItem(Weapons[3]);
                                Render.KillObject(player.X, player.Y, element, map, currentMap);
                            }
                            else
                            {
                                GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventIt’sLockedText"]);
                            }
                            break;
                    }
                    break;
                case "Serpent_Man_Dungeon":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 42:
                            if (player.Inventory.Contains(Keys[5]))
                            {
                                Sound.SFXPlayer("ChestSFX.wav");
                                player.RemoveItem(Keys[5]);
                                player.FoundItem(Weapons[5]);
                                Render.KillObject(player.X, player.Y, element, map, currentMap);
                            }
                            else
                            {
                                GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventIt’sLockedText"]);
                            }
                            break;
                    }
                    break;
                case "Bandits_Domain":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 48:
                            if (player.Inventory.Contains(Keys[5]))
                            {
                                Sound.SFXPlayer("ChestSFX.wav");
                                player.RemoveItem(Keys[5]);
                                player.FoundItem(Armors[4]);
                                Render.KillObject(player.X, player.Y, element, map, currentMap);
                            }
                            else
                            {
                                GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventIt’sLockedText"]);
                            }
                            break;
                        case 70:
                            if (player.Inventory.Contains(Keys[5]))
                            {
                                Sound.SFXPlayer("ChestSFX.wav");
                                player.RemoveItem(Keys[5]);
                                player.FoundItem(Weapons[7]);
                                Render.KillObject(player.X, player.Y, element, map, currentMap);
                            }
                            else
                            {
                                GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventIt’sLockedText"]);
                            }
                            break;
                    }
                    break;
                case "Underground_Passage":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 47:
                            if (player.Inventory.Contains(Keys[5]))
                            {
                                Sound.SFXPlayer("ChestSFX.wav");
                                player.RemoveItem(Keys[5]);
                                player.FoundItem(Weapons[10]);
                                Render.KillObject(player.X, player.Y, element, map, currentMap);
                            }
                            else
                            {
                                GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventIt’sLockedText"]);
                            }
                            break;                        
                    }
                    break;
                case "Ancient_Dragon_Cave":
                    break;
                case "Confinement":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 21:
                            if (player.Inventory.Contains(Keys[5]))
                            {
                                Sound.SFXPlayer("ChestSFX.wav");
                                player.RemoveItem(Keys[5]);
                                player.FoundItem(Weapons[9]);
                                Render.KillObject(player.X, player.Y, element, map, currentMap);
                            }
                            else
                            {
                                GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventIt’sLockedText"]);
                            }
                            break;
                    }
                    break;
            }
        }
        internal static void GameEventBattles(Player player, string[,] map, string currentMap, string element) //Acredito que funcionou.
        {
            Enemy Target;
            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventTheBattleWillBegin"]);

            int[] ReturnsFromEnemySumPosition = new int[3];

            switch (currentMap)
            {
                case "Catacombs":
                    ReturnsFromEnemySumPosition = EnemySumPosition(player.Y, player.X, map, element);                    
                    switch (ReturnsFromEnemySumPosition[2])
                    {
                        case 48:
                            Target = new GiantRat();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 44:
                            Target = new Skeleton();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 72:
                            Target = new Skeleton();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 84:
                            Target = new GiantRat();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                    }
                    break;
                case "Abandoned_Fortress":
                    ReturnsFromEnemySumPosition = EnemySumPosition(player.Y, player.X, map, element);
                    switch (ReturnsFromEnemySumPosition[2])
                    {
                        case 75:
                            Target = new Undead();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 81:
                            Target = new Thief();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 22:
                            Target = new Thief();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 43:
                            Target = new Thief();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                    }
                    break;
                case "Ruins":
                    ReturnsFromEnemySumPosition = EnemySumPosition(player.Y, player.X, map, element);
                    switch (ReturnsFromEnemySumPosition[2])
                    {
                        case 55:
                            Target = new Bandit();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 33:
                            Target = new Bandit();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 87:
                            Target = new Bandit();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 68:
                            Target = new Undead();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 20:
                            Target = new Undead();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                    }
                    break;
                case "Old_Crypt":
                    ReturnsFromEnemySumPosition = EnemySumPosition(player.Y, player.X, map, element);
                    switch (ReturnsFromEnemySumPosition[2])
                    {
                        case 22:
                            Target = new Skeleton();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 71:
                            Target = new Thief();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 49:
                            Target = new Thief();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 84:
                            Target = new Skeleton();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 62:
                            Target = new Skeleton();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                    }
                    break;
                case "Serpent_Man_Dungeon":
                    ReturnsFromEnemySumPosition = EnemySumPosition(player.Y, player.X, map, element);
                    switch (ReturnsFromEnemySumPosition[2])
                    {
                        case 83:
                            Target = new SerpentMan();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 60:
                            Target = new SerpentMan();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 30:
                            Target = new SerpentMan();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 44:
                            Target = new SerpentMan();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 71:
                            Target = new Skeleton();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 26:
                            Target = new Undead();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                    }
                    break;
                case "Bandits_Domain":
                    ReturnsFromEnemySumPosition = EnemySumPosition(player.Y, player.X, map, element);
                    switch (ReturnsFromEnemySumPosition[2])
                    {
                        case 77:
                            Target = new Skeleton();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 36:
                            Target = new Bandit();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 67:
                            Target = new Bandit();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 71:
                            Target = new Bandit();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 84:
                            Target = new Bandit();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 53:
                            Target = new Bandit();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 32:
                            Target = new BanditMarauder();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                    }
                    break;
                case "Underground_Passage":
                    ReturnsFromEnemySumPosition = EnemySumPosition(player.Y, player.X, map, element);
                    switch (ReturnsFromEnemySumPosition[2])
                    {
                        case 49:
                            Target = new Skeleton();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 77:
                            Target = new GiantRat();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 76:
                            Target = new GiantRat();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 48:
                            Target = new Skeleton();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;                        
                    }
                    break;
                case "Ancient_Dragon_Cave":
                    ReturnsFromEnemySumPosition = EnemySumPosition(player.Y, player.X, map, element);
                    switch (ReturnsFromEnemySumPosition[2])
                    {
                        case 72:
                            Target = new UndeadDragon();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;                        
                    }
                    break;
                case "Confinement":
                    ReturnsFromEnemySumPosition = EnemySumPosition(player.Y, player.X, map, element);
                    switch (ReturnsFromEnemySumPosition[2])
                    {
                        case 60:
                            Target = new MadWarrior();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            Render.ModifyMap(69, 6, "!", map, currentMap);
                            Render.ModifyMap(71, 10, "─", map, currentMap);
                            Render.ModifyMap(72, 10, "─", map, currentMap);
                            break;
                    }
                    break;
            }
        }
        internal static void GameEventInterestPoints(Player player, string[,] map, string currentMap, string element)
        {
            switch (currentMap)
            {
                case "Catacombs":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 27:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventCatacombsInterestPointOne"]);
                            break;
                        case 31:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventCatacombsInterestPointTwo"]);
                            break;
                        case 30:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventCatacombsInterestPointThree"]);
                            break;
                        case 55:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventCatacombsInterestPointFour"]);
                            break;
                        case 67:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventCatacombsInterestPointFive"]);
                            break;
                        case 83:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventCatacombsInterestPointSix"]);
                            break;
                        case 84:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventCatacombsInterestPointSeven"]);
                            break;
                        case 94:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventCatacombsInterestPointEight"]);
                            break;
                    }
                    break;
                case "Abandoned_Fortress":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {                            
                        case 14:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventAbandonedFortressInterestPointOne"]);
                            break;
                        case 59:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventAbandonedFortressInterestPointTwo"]);
                            break;
                        case 93:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventAbandonedFortressInterestPointThree"]);
                            break;
                        case 70:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventAbandonedFortressInterestPointFour"]);
                            break;
                    }
                    break;
                case "Ruins":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 33:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventRuinsInterestPointOne"]);
                            break;                        
                        case 49:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventRuinsInterestPointTwo"]);
                            break;
                        case 55:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventRuinsInterestPointThree"]);
                            if (!player.Skills.Contains(Game.currentLanguageStrings["PlayerSkillThrust"]))
                            {
                                player.TakeSkill(Game.currentLanguageStrings["PlayerSkillThrust"]);
                                GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventNewTechniqueLearned"]);
                            }
                            break;
                    }
                    break;
                case "Old_Crypt":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 27:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventOldCryptInterestPointOne"]);
                            break;
                        case 46:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventOldCryptInterestPointTwo"]);
                            break;
                        case 49:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventOldCryptInterestPointThree"]);
                            break;
                        case 60:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventOldCryptInterestPointFour"]);
                            break;
                        case 92:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventOldCryptInterestPointFive"]);
                            break;
                    }
                    break;
                case "Serpent_Man_Dungeon":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 40:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventSerpentManDungeonInterestPointOne"]);
                            if (!player.Skills.Contains(Game.currentLanguageStrings["PlayerSkillMoonSlash"]))
                            {
                                player.TakeSkill(Game.currentLanguageStrings["PlayerSkillMoonSlash"]);
                                GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventNewTechniqueLearned"]);
                            }
                            break;
                        case 55:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventSerpentManDungeonInterestPointTwo"]);
                            break;
                        case 35:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventSerpentManDungeonInterestPointThree"]);
                            break;                        
                    }
                    break;
                case "Bandits_Domain":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 30:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventBanditsDomainInterestPointOne"]);
                            break;
                        case 72:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventBanditsDomainInterestPointTwo"]);
                            break;                        
                    }
                    break;
                case "Underground_Passage":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 30:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventUndergroundPassageInterestPointOne"]);
                            break;                        
                    }
                    break;
                case "Ancient_Dragon_Cave":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 62:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventAncientDragonCaveInterestPointOne"]);
                            break;
                        case 52:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventAncientDragonCaveInterestPointOne"]);
                            break;
                        case 74:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventAncientDragonCaveInterestPointTwo"]);
                            break;
                        case 41:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventAncientDragonCaveInterestPointThree"]);
                            break;
                        case 42:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventAncientDragonCaveInterestPointThree"]);
                            break;
                        case 77:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventAncientDragonCaveInterestPointFour"]);
                            if (!player.Inventory.Contains(Notes[5]))
                            {
                                Sound.SFXPlayer("ItemPickupSFX.wav");
                                player.FoundItem(Notes[5]);
                            }                            
                            if (!player.Skills.Contains(Game.currentLanguageStrings["PlayerSkillGodRays"]))
                            {
                                player.TakeSkill(Game.currentLanguageStrings["PlayerSkillGodRays"]);
                                GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventNewTechniqueLearned"]);
                            }
                            break;
                    }
                    break;
                case "Confinement":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 54:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventConfinementInterestPointOne"]);
                            break;
                        case 91:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventConfinementInterestPointTwo"]);
                            if (!player.Skills.Contains(Game.currentLanguageStrings["PlayerSkillBloodThrust"]))
                            {
                                player.TakeSkill(Game.currentLanguageStrings["PlayerSkillBloodThrust"]);
                                GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventNewTechniqueLearned"]);
                            }
                            break;
                        case 77:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventConfinementInterestPointThree"]);
                            break;
                        case 67:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventConfinementInterestPointFour"]);
                            break;                        
                    }
                    break;
            }
        }
        internal static void GameEventObjectivePoints(Player player, string[,] map, string currentMap, string element)
        {
            switch (currentMap)
            {
                case "Confinement":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 75:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventEndingTextOne"]);
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventEndingTextTwo"]);
                            player.TakeDamage(999);
                            GameConsole.ConsoleOutput($"{player.Name} {Game.currentLanguageStrings["EventEndingTextThree"]}");
                            Game.GameOver();
                            break;
                    }
                break;
            }
        }
        internal static void GameEventDoors(Player player, string[,] map, string currentMap, string element)
        {
            switch (currentMap)
            {
                case "Catacombs":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 13:
                            if (player.Inventory.Contains(Keys[0]))
                            {
                                Sound.SFXPlayer("DoorSFX.wav");                                
                                Render.KillObject(player.X, player.Y, element, map, currentMap);
                                player.RemoveItem(Keys[0]);
                            }
                            else
                            {
                                GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventIt’sLockedText"]);
                            }
                            break;
                        case 30:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 46:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventIt’sLockedText"]);
                            break;
                        case 58:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 41:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 55:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 74:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 75:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 78:
                            if (player.Inventory.Contains(Keys[4]))
                            {
                                Sound.SFXPlayer("DoorSFX.wav");                                
                                Render.KillObject(player.X, player.Y, element, map, currentMap);
                                player.RemoveItem(Keys[4]);
                            }
                            else
                            {
                                GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventIt’sLockedText"]);
                            }
                            break;
                        case 101:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                    }
                    break;
                case "Abandoned_Fortress":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 52:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 58:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 21:
                            if (player.Inventory.Contains(Keys[3]))
                            {
                                Sound.SFXPlayer("DoorSFX.wav");                                
                                Render.KillObject(player.X, player.Y, element, map, currentMap);
                                player.RemoveItem(Keys[3]);
                            }
                            else
                            {
                                GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventIt’sLockedText"]);
                            }
                            break;
                        case 63:
                            if (player.Y == 29)
                            {
                                Sound.SFXPlayer("DoorSFX.wav");
                                Render.KillObject(player.X, player.Y, element, map, currentMap);
                            }
                            else
                            {
                                GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventDoesn’tOpenFromThisSide"]);
                            }
                            break;
                        case 73:
                            if (player.Inventory.Contains(Keys[1]))
                            {
                                Sound.SFXPlayer("DoorSFX.wav");                                
                                Render.KillObject(player.X, player.Y, element, map, currentMap);
                                player.RemoveItem(Keys[1]);
                            }
                            else
                            {
                                GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventIt’sLockedText"]);
                            }
                            break;
                    }
                    break;
                case "Ruins":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 14:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 72:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 101:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 70:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 48:
                            if (player.Inventory.Contains(Keys[2]))
                            {
                                Sound.SFXPlayer("DoorSFX.wav");                                
                                Render.KillObject(player.X, player.Y, element, map, currentMap);
                                player.RemoveItem(Keys[2]);
                            }
                            else
                            {
                                GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventIt’sLockedText"]);
                            }
                            break;
                    }
                    break;
                case "Old_Crypt":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 29:
                            if (player.Y == 20)
                            {
                                Sound.SFXPlayer("DoorSFX.wav");
                                Render.KillObject(player.X, player.Y, element, map, currentMap);
                            }
                            else
                            {
                                GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventDoesn’tOpenFromThisSide"]);
                            }
                            break;
                        case 45:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 23:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 75:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 53:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 71:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                    }
                    break;
                case "Serpent_Man_Dungeon":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 72:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 73:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 89:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 103:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 69:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 46:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 45:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 22:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 17:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 38:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                    }
                    break;
                case "Bandits_Domain":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 21:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 22:
                            if(player.X == 14)
                            {
                                Sound.SFXPlayer("DoorSFX.wav");
                                Render.KillObject(player.X, player.Y, element, map, currentMap);
                            }
                            else
                            {
                                GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventDoesn’tOpenFromThisSide"]);
                            }
                            break;
                        case 93:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 44:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;                        
                    }
                    break;
                case "Underground_Passage":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {                        
                        case 58:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                    }
                    break;
                case "Ancient_Dragon_Cave":
                    break;
                case "Confinement":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 54:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 78:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 98:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventIt’sLockedText"]);
                            break;
                    }
                    break;
            }
        }
        internal static void GameEventItems(Player player, string[,] map, string currentMap, string element)
        {
            Sound.SFXPlayer("ItemPickupSFX.wav");
            switch (currentMap)
            {
                case "Catacombs":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 13:
                            player.FoundItem(Foods[2]);
                            player.FoundItem(Foods[2]);
                            player.FoundItem(Keys[0]);
                            player.FoundItem(Notes[0]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 30:
                            player.FoundItem(Weapons[1]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 50:
                            player.FoundItem(Potions[3]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 77:
                            player.FoundItem(Notes[1]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 88:
                            player.FoundItem(Miscellaneous[5]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 95:
                            player.FoundItem(Keys[5]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                    }
                    break;
                case "Abandoned_Fortress":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 15:
                            player.FoundItem(Weapons[2]);
                            player.FoundItem(Foods[1]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 71:
                            player.FoundItem(Foods[4]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 82:
                            player.FoundItem(Foods[6]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 92:
                            player.FoundItem(Armors[2]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 18:
                            player.FoundItem(Miscellaneous[0]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 49:
                            player.FoundItem(Potions[1]);
                            player.FoundItem(Potions[4]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 45:
                            player.FoundItem(Notes[2]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 51:
                            player.FoundItem(Keys[1]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                    }
                    break;
                case "Ruins":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 44:
                            player.FoundItem(Weapons[8]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 48:
                            player.FoundItem(Potions[0]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 51:
                            player.FoundItem(Miscellaneous[4]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 56:
                            player.FoundItem(Weapons[0]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 103:
                            player.FoundItem(Armors[1]);
                            player.FoundItem(Foods[3]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 17:
                            player.FoundItem(Keys[5]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 29:
                            player.FoundItem(Potions[4]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 60:
                            player.FoundItem(Potions[1]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 81:
                            player.FoundItem(Foods[2]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 75:
                            player.FoundItem(Foods[2]);
                            player.FoundItem(Foods[2]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                    }
                    break;
                case "Old_Crypt":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 109:
                            player.FoundItem(Armors[3]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 78:
                            player.FoundItem(Keys[3]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 79:
                            player.FoundItem(Keys[5]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 21:
                            player.FoundItem(Miscellaneous[8]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 62:
                            player.FoundItem(Foods[4]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 24:
                            player.FoundItem(Potions[0]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 6:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventSmallLeatherBag"]);
                            player.FoundItem(Potions[0]);
                            player.FoundItem(Potions[3]);
                            player.FoundItem(Potions[1]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                    }
                    break;
                case "Serpent_Man_Dungeon":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 34:
                            player.FoundItem(Weapons[6]);
                            player.FoundItem(Notes[3]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 63:
                            player.FoundItem(Keys[5]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 72:
                            player.FoundItem(Miscellaneous[1]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 100:
                            player.FoundItem(Potions[1]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 10:
                            player.FoundItem(Potions[4]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 91:
                            player.FoundItem(Foods[1]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 24:
                            player.FoundItem(Foods[5]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 82:
                            player.FoundItem(Potions[3]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 74:
                            player.FoundItem(Foods[6]);
                            player.FoundItem(Foods[6]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 11:
                            player.FoundItem(Potions[0]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                    }
                    break;
                case "Bandits_Domain":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 60:
                            player.FoundItem(Potions[2]);                                                       
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 86:
                            player.FoundItem(Foods[6]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 75:
                            player.FoundItem(Potions[1]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 52:
                            player.FoundItem(Potions[4]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 35:
                            player.FoundItem(Keys[2]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 30:
                            player.FoundItem(Foods[3]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 84:
                            player.FoundItem(Miscellaneous[3]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                    }
                    break;                    
                case "Underground_Passage":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 39:
                            GameConsole.ConsoleOutput(Game.currentLanguageStrings["EventLargeLeatherBag"]);
                            player.FoundItem(Potions[2]);
                            player.FoundItem(Potions[1]);
                            player.FoundItem(Potions[4]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 75:
                            player.FoundItem(Miscellaneous[7]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 80:
                            player.FoundItem(Keys[4]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;                                                
                    }
                    break;
                case "Ancient_Dragon_Cave":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 76:
                            player.FoundItem(Miscellaneous[6]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 73:
                            player.FoundItem(Notes[4]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                    }
                    break;
                case "Confinement":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 4:
                            player.FoundItem(Keys[5]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 76:
                            player.FoundItem(Armors[5]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 22:
                            player.FoundItem(Miscellaneous[2]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                    }
                    break;
            }
        }
        private static int ElementSumPosition(int pY, int pX, string[,] map, string element)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (map[pY - 1 + i, pX - 1 + j] == element)
                    {
                        return (pY - 1 + i) + (pX - 1 + j);
                    };
                }
            }
            return 0;
        }        
        private static int[] EnemySumPosition(int pY, int pX, string[,] map, string element)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (map[pY - 2 + j, pX - 4 + i] == element)
                    {
                        return [(pY - 2 + j), (pX - 4 + i), (pY - 2 + j) + (pX - 4 + i)];
                    };
                }
            }
            return [];
        }
    }
}