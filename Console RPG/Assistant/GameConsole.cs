namespace Console_RPG.Assistant
{
    internal class GameConsole
    {
        internal static void ConsoleOutput(string message)
        {
            Render.ConsoleClear("                                                ", 8, 81, 30);
            SetCursorPosition(81, 30);
            if (message.Length < 48) Write(message);
            else
            {
                Write($"{message[..48]}");
                SetCursorPosition(81, 31);
                if (message[48..].StartsWith(' ')) Write($"{message[49..]}"); else Write($"{message[48..]}");
            }
            Thread.Sleep(200);
            SetCursorPosition(81, 37);
            Write(Game.currentLanguageStrings["Continue"]);
            ReadKey();
        }
    }
}
