using System;

namespace ConsoleApplication
{
    public class Player
    {
        public int posX;
        public int posY;
        private int stageWidth;
        private int stageHeight;

        public Player(int stageWidth, int stageHeight)
        {
            this.stageWidth = stageWidth;
            this.stageHeight = stageHeight;
            posX = stageWidth / 2 + 1;
            posY = stageHeight - 1;
        }

        //If direction is 0, move left, if direction is 1 move right
        void Move(int direction)
        {
            switch (direction)
            {
                case 0:
                    if(posX - 1 <= 0){break;}
                    Console.SetCursorPosition(posX, posY);
                    Console.Write(" ");
                    posX += -1;
                    Console.SetCursorPosition(posX, posY);
                    Console.Write("-");
                    break;
                case 1:
                    if(posX + 1 >= stageWidth){break;}
                    Console.SetCursorPosition(posX, posY);
                    Console.Write(" ");
                    posX += 1;
                    Console.SetCursorPosition(posX, posY);
                    Console.Write("-");
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