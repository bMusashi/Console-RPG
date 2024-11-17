using Console_RPG.Entities;

namespace Console_RPG.Assistant
{
    internal class Menu
    {
        private static string[] Options = [];
        private static int SelectedIndex = 0;
        private static ConsoleKeyInfo PressedKey;
        private static int LanguageSelectedIndex = 0;
        internal static void Console()
        {
            Render.Draw(LevelParser.ParseFileToArray($"Text_Files\\Console_Box.txt"), 80, 29);
            ForegroundColor = ConsoleColor.DarkGray;
            SetCursorPosition(83, 38);
            Write(Game.currentLanguageStrings["ConsoleOptions"]);
            ResetColor();
        }
        internal static void StartScreen(string language)
        {
            var json = File.ReadAllText(language);
            Game.currentLanguageStrings = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            Clear();
            Render.Draw(LevelParser.ParseFileToArray("Text_Files\\Start_Screen.txt"), 32, 11);
            string[] Options = [Game.currentLanguageStrings["StartScreenStart"], Game.currentLanguageStrings["StartScreenHowToPlay"], Game.currentLanguageStrings["StartScreenLanguage"], Game.currentLanguageStrings["StartScreenQuit"]];
            int SelectedIndex = 1;
            bool AvaliableMenu = true;
            while (AvaliableMenu)
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
                        Write(Game.currentLanguageStrings["StartScreenInstructionArrow"]);
                        SetCursorPosition(56, 30);
                        Write(Game.currentLanguageStrings["StartScreenInstructionInteract"]);
                        SetCursorPosition(56, 31);
                        Write(Game.currentLanguageStrings["StartScreenInstructionDescriptions"]);
                        StartScreenAux(56, 32, ConsoleColor.Yellow, Game.currentLanguageStrings["StartScreenInstructionC"]);
                        StartScreenAux(56, 33, ConsoleColor.Red, Game.currentLanguageStrings["StartScreenInstructionE"]);
                        StartScreenAux(56, 34, ConsoleColor.White, Game.currentLanguageStrings["StartScreenInstruction?"]);
                        StartScreenAux(56, 35, ConsoleColor.DarkYellow, Game.currentLanguageStrings["StartScreenInstruction|"]);
                        StartScreenAux(56, 36, ConsoleColor.DarkYellow, Game.currentLanguageStrings["StartScreenInstruction-"]);
                        StartScreenAux(56, 37, ConsoleColor.Cyan, Game.currentLanguageStrings["StartScreenInstruction."]);
                        StartScreenAux(56, 38, ConsoleColor.DarkRed, Game.currentLanguageStrings["StartScreenInstruction!"]);
                    }                    
                }

                ConsoleKeyInfo PressedKey;

                do
                {
                    PressedKey = ReadKey(true);
                }
                while (KeyAvailable);

                switch (PressedKey.Key)
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
                        switch (SelectedIndex)
                        {
                            case 0:
                                Clear();
                                Thread.Sleep(200);
                                Game.Start();
                                break;
                            case 2:
                                LanguageSelector();                                
                                break;
                            case 3:
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
            Write(text.Substring(0, 1));
            ResetColor();
            Write(text.Substring(1));
        }
        private static void LanguageSelector()
        {
            string[] Options = [Game.currentLanguageStrings["StartScreenLanguageEN"], Game.currentLanguageStrings["StartScreenLanguageES"], Game.currentLanguageStrings["StartScreenLanguagePT"]];            
            bool AvaliableMenu = true;
            string SelectedLanguage = null;

            while (AvaliableMenu)
            {
                Render.ConsoleClear("              ", 1, 41, 35);
                for (int i = 0; i < Options.Length; i++)
                {
                    SetCursorPosition(41, 35);
                    Write($"< {Options[LanguageSelectedIndex]} >");
                }

                ConsoleKeyInfo PressedKey;

                do
                {
                    PressedKey = ReadKey(true);
                }
                while (KeyAvailable);

                switch (PressedKey.Key)
                {
                    case ConsoleKey.LeftArrow:
                        LanguageSelectedIndex--;
                        if (LanguageSelectedIndex < 0) LanguageSelectedIndex = Options.Length - 1;
                        break;
                    case ConsoleKey.RightArrow:
                        LanguageSelectedIndex++;
                        if (LanguageSelectedIndex > Options.Length - 1) LanguageSelectedIndex = 0;
                        break;
                    case ConsoleKey.Enter:
                        switch(LanguageSelectedIndex)
                        {
                            case 0:
                                SelectedLanguage = "en-US.json";
                                break;
                            case 1:
                                SelectedLanguage = "es-ES.json";
                                break;
                            case 2:
                                SelectedLanguage = "pt-BR.json";
                                break;
                        }                        
                        StartScreen($"Languages\\{SelectedLanguage}");
                        break;
                    case ConsoleKey.Escape:
                        Render.ConsoleClear("              ", 1, 40, 35);
                        AvaliableMenu = false;
                        break;
                }
            }
        }
        internal static void MainMenu(Player player)
        {
            Options = [Game.currentLanguageStrings["MainMenuStats"], Game.currentLanguageStrings["MainMenuInventory"], Game.currentLanguageStrings["MainMenuSkills"], Game.currentLanguageStrings["MainMenuQuit"]];
            bool AvaliableMenu = true;
            while (AvaliableMenu)
            {
                for (int i = 0; i < Options.Length; i++)
                {
                    ForegroundColor = (i == SelectedIndex) ? ConsoleColor.White : ConsoleColor.DarkGray;

                    switch (i)
                    {
                        case 0:
                            SetCursorPosition(83, 38);
                            break;
                        case 1:
                            SetCursorPosition(94, 38);
                            break;
                        case 2:
                            SetCursorPosition(109, 38);
                            break;
                        case 3:
                            SetCursorPosition(121, 38);
                            break;
                    }
                    Write($"[{Options[i]}]");
                }
                ResetColor();
                do
                {
                    PressedKey = ReadKey(true);
                }
                while (KeyAvailable);

                switch (PressedKey.Key)
                {
                    case ConsoleKey.Escape:
                        AvaliableMenu = false;
                        SelectedIndex = 0;
                        break;
                    case ConsoleKey.LeftArrow:
                        SelectedIndex--;
                        if (SelectedIndex < 0) SelectedIndex = Options.Length - 1;
                        break;
                    case ConsoleKey.RightArrow:
                        SelectedIndex++;
                        if (SelectedIndex > Options.Length - 1) SelectedIndex = 0;
                        break;
                    case ConsoleKey.Enter:
                        switch (SelectedIndex)
                        {
                            case 0:
                                player.StatsMenu();
                                break;
                            case 1:
                                player.InventoryMenu();
                                break;
                            case 2:
                                player.SkillsMenu();
                                break;
                            case 3:
                                AvaliableMenu = false;
                                SelectedIndex = 0;
                                break;
                        }
                        break;
                }
            }
        }
        internal static void PercentageBar(int percentage, int menuSpaceSize, int x, int y, ConsoleColor barColor)
        {
            for (int i = 0; i < Convert.ToInt32(percentage / 100.0 * menuSpaceSize); i++)
            {
                ForegroundColor = barColor;
                SetCursorPosition(x + i, y);
                Write("■");
            }
            ResetColor();
        }
    }
}
