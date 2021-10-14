using System;

namespace ConsoleApplication
{
    public class MainMenu
    {
        public void Show()
        {
            // Changes how the main menu size depending on the size of the console
            
            //Roof
            Console.SetCursorPosition(0,0);
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("@");
            }

            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("@");
            }
            
            Console.SetCursorPosition(Console.WindowWidth / 2 / 2, Console.WindowHeight / 2);
            Console.WriteLine("Welcome to Breakout");
            Console.WriteLine("(S)tart Game");
            Console.WriteLine("(Q)uit");
            
            Console.SetCursorPosition(Console.WindowWidth / 2 / 2, Console.WindowHeight - 2);
            Console.WriteLine("Press button in parenthesis to do the action");

            if (Console.ReadKey().Key == ConsoleKey.S)
            {
                MyProgram game = new MyProgram();
                game.Run();
            }
            else if (Console.ReadKey().Key == ConsoleKey.Q)
            {
                Environment.Exit(1);
            }

        }
    }
}