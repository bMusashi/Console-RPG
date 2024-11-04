global using static System.Console;
namespace Console_RPG
{
    class Program
    {
        //Calcula o tamanho do console se baseando na proporção áurea
        private static readonly int Height = 41;
        private static readonly int Width = Convert.ToInt32(Height * 1.61803398875) *  2;        
        public static void Main()
        {
            Title = "Console RPG";
            CursorVisible = false;
            SetWindowSize(Width, Height);
            SetBufferSize(Width, Height);

            //Inicia a tela principal Apt
            Game.StartScreen();            
        }        
    }
}