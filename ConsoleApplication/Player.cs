using System;

namespace ConsoleApplication
{
    public class Player
    {
        public int PosX { get; private set; }
        public int PosY { get; }
        private readonly int _stageWidth;
        public readonly int Size;

        public Player(int stageWidth, int stageHeight, int size)
        {
            _stageWidth = stageWidth;
            PosX = stageWidth / 2 + 1;
            PosY = stageHeight - 1;
            Size = size;
        }

        //If direction is 0, move left, if direction is 1 move right
        private void Move(int direction)
        {
            switch (direction)
            {
                case 0:
                    if(PosX - 1 <= 0){break;}
                    Console.SetCursorPosition(PosX, PosY);
                    for (int i = 0; i < Size; i++)
                    {
                        Console.Write(" ");
                    }
                    PosX += -1;
                    Console.SetCursorPosition(PosX, PosY);
                    for (int i = 0; i < Size; i++)
                    {
                        Console.Write("-");
                    }
                    break;
                case 1:
                    if(PosX + Size >= _stageWidth){break;}
                    Console.SetCursorPosition(PosX, PosY);
                    for (int i = 0; i < Size; i++)
                    {
                        Console.Write(" ");
                    }
                    PosX += 1;
                    Console.SetCursorPosition(PosX, PosY);

                    for (int i = 0; i < Size; i++)
                    {
                        Console.Write("-");
                    }
                    break;
            }
        }

        //Checks for input
        public void InputChecker(bool isRunning = true)
        {
            while (isRunning)
            {
                if (Console.ReadKey().Key == ConsoleKey.RightArrow)
                {
                    Move(1);
                }

                if (Console.ReadKey().Key == ConsoleKey.LeftArrow)
                {
                    Move(0);
                }
            }
        }
    }
}