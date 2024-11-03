using Console_RPG.Entities;

namespace Console_RPG.Assistant
{
    internal class Render
    {
        internal static void ConsoleClear(string space, int lines, int posX, int posY)
        {
            for (int i = 0; i < lines; i++)
            {
                SetCursorPosition(posX, posY + i);
                Write(space);
            }
        }
        internal static void Draw(string[,] grid, int positionX, int positionY)
        {
            for (int y = 0; y < grid.GetLength(0); y++)
            {
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    string element = grid[y, x];
                    SetCursorPosition(positionX + x, positionY + y);
                    Write(element);
                }
            }
        }        
        /*
        internal static void WorldDraw(string[,] grid, int playerX, int playerY) //Usado apenas para o desenvolvimento
        {
            for (int y = 0; y < grid.GetLength(0); y++)
            {
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    if (x == playerX && y == playerY)
                    {
                        ForegroundColor = Player.PlayerColor;
                        Write(Player.PlayerMarker);
                    }
                    else
                    {
                        string element = grid[y, x];

                        if (element != " ")
                        {
                            if (NextToPlayerElement(playerX, playerY, x, y)) ForegroundColor = ElementColor(element);
                            else ForegroundColor = ConsoleColor.Black;

                            if (y == 0 || y == 39 || x == 0 || x == 79) ForegroundColor = ConsoleColor.White;
                        }

                        ForegroundColor = ElementColor(element);

                        SetCursorPosition(x, y);
                        Write(element);
                        ResetColor();                        
                    }
                }
            }
        }*/
        internal static void WorldDraw(string[,] grid, int playerX, int playerY) //Render Com maior otimização, mostra apenas uma parte do mapa
        {
            ConsoleClear("                                                                              ", 38, 1, 1);

            int xFix = 6;
            int yFix = 3;            

            var dicX = new Dictionary<int, int>
            {
                { 73, 6 },
                { 74, 7 },
                { 75, 8 },
                { 76, 9 },
                { 77, 10 },
                { 78, 11 },
                { 5, 5 },
                { 4, 4 },
                { 3, 3 },
                { 2, 2 },
                { 1, 1 }
            };            

            if (dicX.TryGetValue(playerX, out int valueX)) xFix = valueX;

            var dicY = new Dictionary<int, int>
            {
                { 37, 4 },
                { 38, 5 },
                { 39, 6 },
                { 2, 2 },
                { 1, 1 }
            };

            if (dicY.TryGetValue(playerY, out int valueY)) yFix = valueY;

            for (int y = 0; y < 7; y++)
            {
                for (int x = 0; x < 13; x++)
                {
                    string element = grid[playerY - yFix + y, playerX - xFix + x];

                    if (element != " ")
                    {
                        if (NextToPlayerElement(playerX, playerY, playerX - xFix + x, playerY - yFix + y)) ForegroundColor = ElementColor(element);                        
                        else ForegroundColor = ConsoleColor.Black;
                    }                    

                    SetCursorPosition(playerX - xFix + x, playerY - yFix + y);
                    Write(element);
                    ResetColor();                    
                }
            }

            SetCursorPosition(0, 0);
            Write("┌──────────────────────────────────────────────────────────────────────────────┐");
            SetCursorPosition(0, 39);
            Write("└──────────────────────────────────────────────────────────────────────────────┘");
            for (int i = 0; i < 38; i++)
            {
                SetCursorPosition(0, 1 + i);
                Write("│");
                SetCursorPosition(79, 1 + i);
                Write("│");
            }

        }
        internal static ConsoleColor ElementColor(string element)
        {
            return element switch
            {                
                "C" => ConsoleColor.Yellow,
                "E" => ConsoleColor.Red,
                "?" => ConsoleColor.White,
                "|" => ConsoleColor.DarkYellow,
                "-" => ConsoleColor.DarkYellow,
                "." => ConsoleColor.Cyan,                
                "!" => ConsoleColor.Magenta,
                _ => ConsoleColor.White,
            };
        }
        internal static bool IsWalkable(string[,] grid, int posX, int posY)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            if (posX < 0 || posY < 0 || posX >= cols || posY >= rows) return false;
            else return grid[posY, posX] == " " || grid[posY, posX] == ".";
        }
        internal static void KillObject(int x, int y, string obj, string[,] mapToUpdate, string currentMap)
        {
            if (mapToUpdate[y, x] == obj)
            {
                mapToUpdate[y, x] = " ";
            }
            if (mapToUpdate[y + 1, x] == obj)
            {
                mapToUpdate[y + 1, x] = " ";
            }
            else if (mapToUpdate[y, x - 1] == obj)
            {
                mapToUpdate[y, x - 1] = " ";
            }
            else if (mapToUpdate[y - 1, x] == obj)
            {
                mapToUpdate[y - 1, x] = " ";
            }
            else if (mapToUpdate[y, x + 1] == obj)
            {
                mapToUpdate[y, x + 1] = " ";
            }
            LevelParser.MatrixToText(mapToUpdate, currentMap);
        }
        internal static void ModifyMap(int x, int y, string obj, string[,] mapToModify, string currentMap)
        {
            mapToModify[y, x] = obj;
            LevelParser.MatrixToText(mapToModify, currentMap);            
        }
        internal static bool IsNearSomething(int x, int y, string[,] map, string thing) //Verifica se o player está ao lado de algo especificado.
        {
            if (map[y, x] == thing || map[y + 1, x] == thing || map[y, x - 1] == thing || map[y - 1, x] == thing || map[y, x + 1] == thing) return true;
            else return false;
        }
        internal static bool IsNearEnemy(int x, int y, string[,] map) //Detectar inimigo. Funcionou, mas pode ser melhorado. O programa crash caso você tente verificar uma posição que está fora do do grid -x
        {

            try
            {
                if (
                //Up
                (map[y - 2, x - 3] == "E") ||
                (map[y - 2, x - 2] == "E") ||
                (map[y - 2, x - 1] == "E") ||
                (map[y - 2, x] == "E") ||
                (map[y - 2, x + 1] == "E") ||
                (map[y - 2, x + 2] == "E") ||
                (map[y - 2, x + 3] == "E") ||

                //Down
                (map[y + 2, x - 3] == "E") ||
                (map[y + 2, x - 2] == "E") ||
                (map[y + 2, x - 1] == "E") ||
                (map[y + 2, x] == "E") ||
                (map[y + 2, x + 1] == "E") ||
                (map[y + 2, x + 2] == "E") ||
                (map[y + 2, x + 3] == "E") ||

                //Left
                (map[y - 1, x - 4] == "E") ||
                (map[y, x - 4] == "E") ||
                (map[y + 1, x - 4] == "E") ||

                //Right
                (map[y - 1, x + 4] == "E") ||
                (map[y, x + 4] == "E") ||
                (map[y + 1, x + 4] == "E")
                )
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        internal static bool NextToPlayerElement(int Px, int Py, int Ex, int Ey)
        {
            if (
                (Ex + 1 == Px && Ey + 1 == Py) ||
                (Ex == Px && Ey + 1 == Py) ||
                (Ex - 1 == Px && Ey + 1 == Py) ||
                (Ex + 1 == Px && Ey == Py) ||
                (Ex - 1 == Px && Ey == Py) ||
                (Ex + 1 == Px && Ey - 1 == Py) ||
                (Ex == Px && Ey - 1 == Py) ||
                (Ex - 1 == Px && Ey - 1 == Py) ||

                /////////////////////////////////

                (Ex + 2 == Px && Ey + 2 == Py) || //r
                (Ex + 1 == Px && Ey + 2 == Py) ||
                (Ex == Px && Ey + 2 == Py) ||
                (Ex - 1 == Px && Ey + 2 == Py) ||
                (Ex - 2 == Px && Ey + 2 == Py) || //r
                (Ex + 2 == Px && Ey + 1 == Py) ||
                (Ex - 2 == Px && Ey + 1 == Py) ||
                (Ex + 2 == Px && Ey == Py) ||
                (Ex - 2 == Px && Ey == Py) ||
                (Ex + 2 == Px && Ey - 1 == Py) ||
                (Ex - 2 == Px && Ey - 1 == Py) ||
                (Ex + 2 == Px && Ey - 2 == Py) || //r
                (Ex + 1 == Px && Ey - 2 == Py) ||
                (Ex == Px && Ey - 2 == Py) ||
                (Ex - 1 == Px && Ey - 2 == Py) ||
                (Ex - 2 == Px && Ey - 2 == Py) || //r

                /////////////////////////////////

                (Ex + 3 == Px && Ey + 2 == Py) ||
                (Ex - 3 == Px && Ey + 2 == Py) ||
                (Ex + 4 == Px && Ey + 1 == Py) || //r
                (Ex + 3 == Px && Ey + 1 == Py) ||
                (Ex - 3 == Px && Ey + 1 == Py) ||
                (Ex - 4 == Px && Ey + 1 == Py) || //r
                (Ex + 4 == Px && Ey == Py) ||
                (Ex + 3 == Px && Ey == Py) ||
                (Ex - 3 == Px && Ey == Py) ||
                (Ex - 4 == Px && Ey == Py) ||
                (Ex + 4 == Px && Ey - 1 == Py) || //r
                (Ex + 3 == Px && Ey - 1 == Py) ||
                (Ex - 3 == Px && Ey - 1 == Py) ||
                (Ex - 4 == Px && Ey - 1 == Py) || //r
                (Ex + 3 == Px && Ey - 2 == Py) ||
                (Ex - 3 == Px && Ey - 2 == Py)
                )
            {
                return true;
            }
            return false;
        }
    }
}
