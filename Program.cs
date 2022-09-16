using Common.ConsoleIO;
using System;

namespace C_Sharp_PoLiS
{
    class Program
    {
        static DataContext dataContext;
        static Menu editor;

        static void Editor()
        {
            dataContext = new DataContext();
            editor = new Menu(dataContext);
            editor.Run3();
        }

        static void Main(string[] args)
        {
            Settings.SetConsoleParam("police officer");
            Editor();


            Console.ReadKey();
        }
    }
}
