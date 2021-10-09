using System;

namespace ConsoleApplication
{
    public class Player
    {
        public int posX;
        private int posY;
        private int stageWidth;
        public int size;

        public Player(int stageWidth, int stageHeight, int size)
        {
            this.stageWidth = stageWidth;
            posX = stageWidth / 2 + 1;
            posY = stageHeight - 1;
            this.size = size;
        }

        //If direction is 0, move left, if direction is 1 move right
        void Move(int direction)
        {
            switch (direction)
            {
                case 0:
                    if(posX - 1 <= 0){break;}
                    Console.SetCursorPosition(posX, posY);
                    for (int i = 0; i < size; i++)
                    {
                        Console.Write(" ");
                    }
                    posX += -1;
                    Console.SetCursorPosition(posX, posY);
                    for (int i = 0; i < size; i++)
                    {
                        Console.Write("-");
                    }
                    break;
                case 1:
                    if(posX + size >= stageWidth){break;}
                    Console.SetCursorPosition(posX, posY);
                    for (int i = 0; i < size; i++)
                    {
                        Console.Write(" ");
                    }
                    posX += 1;
                    Console.SetCursorPosition(posX, posY);

                    for (int i = 0; i < size; i++)
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