using Console_RPG.Entities;

namespace Console_RPG.Assistant
{
    internal class Menu
    {
        private static string[] Options = [];
        private static int SelectedIndex = 0;
        private static ConsoleKeyInfo PressedKey;
        internal static void Console()
        {
            Render.Draw(LevelParser.ParseFileToArray($"Text_Files\\Console_Box.txt"), 80, 29);
            ForegroundColor = ConsoleColor.DarkGray;
            SetCursorPosition(83, 38);
            Write("[Status]   [Inventário]   [Técnica]   [Sair]");
            ResetColor();
        }
        internal static void MainMenu(Player player)
        {
            Options = ["Status", "Inventário", "Técnica", "Sair"];
            bool AvaliableMenu = true;
            while ( AvaliableMenu )
            {
                for ( int i = 0; i < Options.Length; i++)
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
