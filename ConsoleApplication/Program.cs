using System;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.CursorVisible = false;
            MainMenu menu = new MainMenu();
            menu.Show();
            // Console.CursorVisible = false;
            // MyProgram myProgram = new MyProgram();
            // myProgram.Run();

        }

    }
}
// 1. Flytta en boll tvärs över skärmen.
// 2. Få bollen att åka tillbaka igen
// 3. Få den att åka fram och tillbaka hela tiden
// Problem ett. flytta bollen