using Console_RPG.Assistant;
using Console_RPG.Entities;
using Console_RPG.Items;
using System.Numerics;
//Projeto terminado com sucesso!
namespace Console_RPG
{
    internal class Game
    {
        internal static Player Torny;
        private readonly static Random rnd = new();
        private static string[,] Map;
        private static string CurrentMap;
        private static void Start()
        {
            //Restart Maps
            ResetMap("Catacombs");
            ResetMap("Abandoned_Fortress");
            ResetMap("Ruins");
            ResetMap("Old_Crypt");
            ResetMap("Serpent_Man_Dungeon");
            ResetMap("Bandits_Domain");
            ResetMap("Underground_Passage");
            ResetMap("Ancient_Dragon_Cave");
            ResetMap("Confinement");            
            //Reset Game
            Torny = new(2, 3);
            Map = LevelParser.ParseFileToArray($"Text_Files\\Maps\\Catacombs.txt");
            CurrentMap = "Catacombs";
            //Start Game
            GameLoop();
        }        
        private static void ResetMap(string MapName)
        {
            string[,] MapToRestore = LevelParser.ParseFileToArray($"Text_Files\\Maps_Backup\\{MapName}.txt");
            LevelParser.MatrixToText(MapToRestore, MapName);
        }
        internal static void StartScreen()
        {            
            Render.Draw(LevelParser.ParseFileToArray("Text_Files\\Start_Screen.txt"), 32, 11);
            string[] Options = ["Iniciar", "Como jogar", "Sair"];           
            int SelectedIndex = 1;
            bool AvaliableMenu = true;
            while(AvaliableMenu)
            {
                Render.ConsoleClear("                                                              ", 10, 56, 29);
                for (int i = 0; i < Options.Length; i++)
                {                    
                    ForegroundColor = (i == SelectedIndex) ? ConsoleColor.White : ConsoleColor.DarkGray;

                    SetCursorPosition(32, 31 + i + i);
                    Write($"{Options[i]}");

                    ResetColor();
                    if (SelectedIndex == 1)
                    {
                        SetCursorPosition(56, 29);
                        Write("Use as setas do teclado para se mover.");
                        SetCursorPosition(56, 30);
                        Write("Use 'Enter' para interagir com os elementos presentes no mapa.");
                        SetCursorPosition(56, 31);
                        Write("Descrição dos elementos do mapa:");                        
                        StartScreenAux(56, 32, ConsoleColor.Yellow, "C: Báu");
                        StartScreenAux(56, 33, ConsoleColor.Red, "E: Inimigo");
                        StartScreenAux(56, 34, ConsoleColor.White, "?: Ponto de Interesse");
                        StartScreenAux(56, 35, ConsoleColor.DarkYellow, "|: Porta");
                        StartScreenAux(56, 36, ConsoleColor.DarkYellow, "-: Porta");
                        StartScreenAux(56, 37, ConsoleColor.Cyan, ".: Item");
                        StartScreenAux(56, 38, ConsoleColor.DarkRed, "!: Objetivo");                        
                    }                    
                }

                ConsoleKeyInfo PressedKey;

                do
                {
                    PressedKey = ReadKey(true);
                }
                while (KeyAvailable);

                switch(PressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        SelectedIndex--;
                        if (SelectedIndex < 0) SelectedIndex = Options.Length - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        SelectedIndex++;
                        if (SelectedIndex > Options.Length - 1) SelectedIndex = 0;
                        break;
                    case ConsoleKey.Enter:
                        switch(SelectedIndex)
                        {
                            case 0:
                                Clear();
                                Thread.Sleep(200);
                                Start();
                                break;
                            case 2:
                                Environment.Exit(0);
                                break;
                        }                        
                        break;
                }
            }            
        }
        private static void StartScreenAux(int x, int y, ConsoleColor color, string text)
        {
            SetCursorPosition(x, y);
            ForegroundColor = color;
            Write(text.Substring(0,1));
            ResetColor();
            Write(text.Substring(1));
        }
        private static void PlayerInput()
        {
            if (Render.IsNearEnemy(Torny.X, Torny.Y, Map)) Events.GameEventBattles(Torny, Map, CurrentMap, "E");
            else
            {
                ConsoleKeyInfo pressedKey;

                do
                {
                    pressedKey = ReadKey(true);

                } while (KeyAvailable);

                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        MapBorder(pressedKey);
                        if (Render.IsWalkable(Map, Torny.X, Torny.Y - 1)) Torny.Y--;
                        break;
                    case ConsoleKey.DownArrow:
                        MapBorder(pressedKey);
                        if (Render.IsWalkable(Map, Torny.X, Torny.Y + 1)) Torny.Y++;
                        break;
                    case ConsoleKey.LeftArrow:
                        MapBorder(pressedKey);
                        if (Render.IsWalkable(Map, Torny.X - 1, Torny.Y)) Torny.X--;
                        break;
                    case ConsoleKey.RightArrow:
                        MapBorder(pressedKey);
                        if (Render.IsWalkable(Map, Torny.X + 1, Torny.Y)) Torny.X++;
                        break;
                    case ConsoleKey.Escape:
                        Menu.MainMenu(Torny);
                        break;
                    case ConsoleKey.Enter:
                        if (Render.IsNearSomething(Torny.X, Torny.Y, Map, "C"))
                        {
                            Events.GameEventChests(Torny, Map, CurrentMap, "C");
                        }
                        if (Render.IsNearSomething(Torny.X, Torny.Y, Map, "?"))
                        {
                            Events.GameEventInterestPoints(Torny, Map, CurrentMap, "?");
                        }
                        if (Render.IsNearSomething(Torny.X, Torny.Y, Map, "|"))
                        {
                            Events.GameEventDoors(Torny, Map, CurrentMap, "|");
                        }
                        if (Render.IsNearSomething(Torny.X, Torny.Y, Map, "-"))
                        {
                            Events.GameEventDoors(Torny, Map, CurrentMap, "-");
                        }
                        if (Render.IsNearSomething(Torny.X, Torny.Y, Map, "."))
                        {
                            Events.GameEventItems(Torny, Map, CurrentMap, ".");
                        }
                        if (Render.IsNearSomething(Torny.X, Torny.Y, Map, "!"))
                        {
                            Events.GameEventObjectivePoints(Torny, Map, CurrentMap, "!");
                        }
                        break;
                }
            }                        
        }
        private static void DrawEverything()
        {            
            Menu.Console();
            Torny.DrawPosition();            
            Render.WorldDraw(Map, Torny.X, Torny.Y); // Melhor render possivel. Sem delay algum, renderiza apenas o que está perto do jogador.
            Torny.Draw();
            Thread.Sleep(75);                       
        }
        private static void MapBorder(ConsoleKeyInfo pressedKey)
        {
            switch (CurrentMap)
            {
                case "Catacombs": //Pronto
                    if (pressedKey.Key == ConsoleKey.DownArrow && Torny.Y == 38 && (Torny.X == 22 || Torny.X == 23 || Torny.X == 24 || Torny.X == 25))
                    {
                        Map = LevelParser.ParseFileToArray($"Text_Files\\Maps\\Abandoned_Fortress.txt");
                        CurrentMap = "Abandoned_Fortress";
                        Torny.Y = 0;
                    }
                    if (pressedKey.Key == ConsoleKey.RightArrow && Torny.X == 78 && (Torny.Y == 2 || Torny.Y == 3 || Torny.Y == 4))
                    {
                        Map = LevelParser.ParseFileToArray($"Text_Files\\Maps\\Confinement.txt");
                        CurrentMap = "Confinement";
                        Torny.X = 0;
                    }
                    break;
                case "Abandoned_Fortress": //Pronto
                    if (pressedKey.Key == ConsoleKey.UpArrow && Torny.Y == 1 && (Torny.X == 22 || Torny.X == 23 || Torny.X == 24 || Torny.X == 25))
                    {
                        Map = LevelParser.ParseFileToArray($"Text_Files\\Maps\\Catacombs.txt");
                        CurrentMap = "Catacombs";
                        Torny.Y = 39;
                    }
                    if (pressedKey.Key == ConsoleKey.DownArrow && Torny.Y == 38 && (Torny.X == 34 || Torny.X == 35 || Torny.X == 36 || Torny.X == 37))
                    {
                        Map = LevelParser.ParseFileToArray($"Text_Files\\Maps\\Ruins.txt");
                        CurrentMap = "Ruins";
                        Torny.Y = 0;
                    }
                    if (pressedKey.Key == ConsoleKey.LeftArrow && Torny.X == 1 && (Torny.Y == 17 || Torny.Y == 18 || Torny.Y == 19))
                    {
                        Map = LevelParser.ParseFileToArray($"Text_Files\\Maps\\Serpent_Man_Dungeon.txt");
                        CurrentMap = "Serpent_Man_Dungeon";
                        Torny.X = 79;
                    }
                    break;
                case "Ruins": //Pronto
                    if (pressedKey.Key == ConsoleKey.UpArrow && Torny.Y == 1 && (Torny.X == 34 || Torny.X == 35 || Torny.X == 36 || Torny.X == 37))
                    {
                        Map = LevelParser.ParseFileToArray($"Text_Files\\Maps\\Abandoned_Fortress.txt");
                        CurrentMap = "Abandoned_Fortress";
                        Torny.Y = 39;
                    }
                    if (pressedKey.Key == ConsoleKey.DownArrow && Torny.Y == 38 && (Torny.X == 10 || Torny.X == 11 || Torny.X == 12 || Torny.X == 13))
                    {
                        Map = LevelParser.ParseFileToArray($"Text_Files\\Maps\\Underground_Passage.txt");
                        CurrentMap = "Underground_Passage";
                        Torny.Y = 0;
                    }
                    if (pressedKey.Key == ConsoleKey.RightArrow && Torny.X == 78 && (Torny.Y == 23 || Torny.Y == 24 || Torny.Y == 25))
                    {
                        Map = LevelParser.ParseFileToArray($"Text_Files\\Maps\\Old_Crypt.txt");
                        CurrentMap = "Old_Crypt";
                        Torny.X = 0;
                    }
                    break;
                case "Old_Crypt": //Pronto
                    if (pressedKey.Key == ConsoleKey.LeftArrow && Torny.X == 1 && (Torny.Y == 23 || Torny.Y == 24 || Torny.Y == 25))
                    {
                        Map = LevelParser.ParseFileToArray($"Text_Files\\Maps\\Ruins.txt");
                        CurrentMap = "Ruins";
                        Torny.X = 79;
                    }
                    break;
                case "Serpent_Man_Dungeon": //Pronto
                    if (pressedKey.Key == ConsoleKey.DownArrow && Torny.Y == 38 && (Torny.X == 6 || Torny.X == 7 || Torny.X == 8 || Torny.X == 9))
                    {
                        Map = LevelParser.ParseFileToArray($"Text_Files\\Maps\\Bandits_Domain.txt");
                        CurrentMap = "Bandits_Domain";
                        Torny.Y = 0;
                    }
                    if (pressedKey.Key == ConsoleKey.DownArrow && Torny.Y == 38 && (Torny.X == 65 || Torny.X == 66 || Torny.X == 67 || Torny.X == 68))
                    {
                        Map = LevelParser.ParseFileToArray($"Text_Files\\Maps\\Bandits_Domain.txt");
                        CurrentMap = "Bandits_Domain";
                        Torny.Y = 0;
                    }
                    if (pressedKey.Key == ConsoleKey.RightArrow && Torny.X == 78 && (Torny.Y == 17 || Torny.Y == 18 || Torny.Y == 19))
                    {
                        Map = LevelParser.ParseFileToArray($"Text_Files\\Maps\\Abandoned_Fortress.txt");
                        CurrentMap = "Abandoned_Fortress";
                        Torny.X = 0;
                    }
                    break;
                case "Bandits_Domain": //Pronto
                    if (pressedKey.Key == ConsoleKey.UpArrow && Torny.Y == 1 && (Torny.X == 6 || Torny.X == 7 || Torny.X == 8 || Torny.X == 9))
                    {
                        Map = LevelParser.ParseFileToArray($"Text_Files\\Maps\\Serpent_Man_Dungeon.txt");
                        CurrentMap = "Serpent_Man_Dungeon";
                        Torny.Y = 39;
                    }
                    if (pressedKey.Key == ConsoleKey.UpArrow && Torny.Y == 1 && (Torny.X == 65 || Torny.X == 66 || Torny.X == 67 || Torny.X == 68))
                    {
                        Map = LevelParser.ParseFileToArray($"Text_Files\\Maps\\Serpent_Man_Dungeon.txt");
                        CurrentMap = "Serpent_Man_Dungeon";
                        Torny.Y = 39;
                    }
                    break;
                case "Underground_Passage": //Pronto
                    if (pressedKey.Key == ConsoleKey.UpArrow && Torny.Y == 1 && (Torny.X == 10 || Torny.X == 11 || Torny.X == 12 || Torny.X == 13))
                    {
                        Map = LevelParser.ParseFileToArray($"Text_Files\\Maps\\Ruins.txt");
                        CurrentMap = "Ruins";
                        Torny.Y = 39;
                    }
                    if (pressedKey.Key == ConsoleKey.DownArrow && Torny.Y == 38 && (Torny.X == 38 || Torny.X == 39 || Torny.X == 40 || Torny.X == 41))
                    {
                        Map = LevelParser.ParseFileToArray($"Text_Files\\Maps\\Ancient_Dragon_Cave.txt");
                        CurrentMap = "Ancient_Dragon_Cave";
                        Torny.Y = 0;
                    }
                    break;
                case "Ancient_Dragon_Cave": //Pronto
                    if (pressedKey.Key == ConsoleKey.UpArrow && Torny.Y == 1 && (Torny.X == 38 || Torny.X == 39 || Torny.X == 40 || Torny.X == 41))
                    {
                        Map = LevelParser.ParseFileToArray($"Text_Files\\Maps\\Underground_Passage.txt");
                        CurrentMap = "Underground_Passage";
                        Torny.Y = 39;
                    }
                    break;
                case "Confinement": //Pronto
                    if (pressedKey.Key == ConsoleKey.LeftArrow && Torny.X == 1 && (Torny.Y == 2 || Torny.Y == 3 || Torny.Y == 4))
                    {
                        Map = LevelParser.ParseFileToArray($"Text_Files\\Maps\\Catacombs.txt");
                        CurrentMap = "Catacombs";
                        Torny.X = 79;
                    }
                    break;
            }
        }
        private static void GameLoop()
        {
            bool running = true;

            while (running)
            {
                DrawEverything();
                PlayerInput();                
                Torny.LevelUp();
            }
        }
        internal static void GameOver()
        {
            Clear();
            SetCursorPosition(59, 38);
            Write("Continuar...");
            ForegroundColor = ConsoleColor.DarkRed;
            Render.Draw(LevelParser.ParseFileToArray("Text_Files\\GameOver.txt"), 27, 14);
            int[] Xpos = [31, 32, 33, 47, 54, 55, 59, 62, 80, 87, 90, 93];
            string[] BloodDrip = ["▀", "█", "▓", "▒", "░"];
            bool bleedingEffect = true;
            do
            {
                Thread.Sleep(1000);
                int choice = rnd.Next(Xpos.Length);
                for (int i = 0; i < BloodDrip.Length; i++)
                {
                    if (KeyAvailable)
                    {
                        bleedingEffect = false;
                        break;
                    }
                    else
                    {
                        SetCursorPosition(Xpos[choice], 19 + i);
                        Write(BloodDrip[i]);
                        Thread.Sleep(100);
                        SetCursorPosition(Xpos[choice], 19 + i);
                        Write(" ");
                    }
                }

            } while (bleedingEffect);
            ResetColor();
            ReadKey();
            Environment.Exit(0);
        }        
    }
}
