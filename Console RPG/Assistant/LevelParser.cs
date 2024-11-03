namespace Console_RPG.Assistant
{
    internal class LevelParser
    {
        internal static string[,] ParseFileToArray(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            string firstLine = lines[0];
            int rows = lines.Length;
            int columns = firstLine.Length;
            string[,] grid = new string[rows, columns];

            for (int y = 0; y < rows; y++)
            {
                string line = lines[y];
                for (int x = 0; x < columns; x++)
                {
                    char currentChar = line[x];
                    grid[y, x] = currentChar.ToString();
                }
            }
            return grid;
        }
        public static void MatrixToText(string[,] mapToUpdate, string currentMap)
        {
            string text = string.Empty;
            string patch = $"Text_Files\\Maps\\{currentMap}.txt";

            for (int y = 0; y < mapToUpdate.GetLength(0); y++)
            {
                for (int x = 0; x < mapToUpdate.GetLength(1); x++)
                {
                    text += mapToUpdate[y, x].ToString();
                }
                text += Environment.NewLine;
            }
            File.WriteAllText(patch, text);
        }
    }
}
