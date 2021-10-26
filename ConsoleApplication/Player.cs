using System;

namespace ConsoleApplication
{
    public class Player
    {
        public int posX { get; private set; }
        public int posY { get; }
        private int stageWidth;
        public int Size;
        
        public bool HasMoved { get; set; }

        public Player(int stageWidth, int stageHeight, int size)
        {
            this.stageWidth = stageWidth;
            posX = stageWidth / 2 + 1;
            posY = stageHeight - 1;
            Size = size;
        }

        //If direction is 0, move left, if direction is 1 move right
        private void Move(int direction)
        {
            switch (direction)
            {
                // Left
                case 0:
                {
                    if (posX - 1 <= 0)
                    {
                        break;
                    }

                    posX -= 1;
                    break;
                }
                
                // Right
                case 1:
                {
                    if (posX + Size >= stageWidth)
                    {
                        break;
                    }

                    posX += 1;
                    break;
                }
                
                default:
                    break;
            }
            // Removes player
            // Console.SetCursorPosition(posX, posY);
            // for (int i = 0; i < Size; i++)
            // {
            //     Console.Write(" ");
            // }
            // //Writes Player
            // Console.SetCursorPosition(posX, posY);
            // for (int i = 0; i < Size; i++)
            // {
            //     Console.Write("-");
            // }

            HasMoved = true;
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

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    Environment.Exit(1);
                }
            }
        }
    }
}