using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class NoTheards
    {
        private static int StageHeight = 12;
        private int StageWidth = 20;

        private int ballPosX;
        private int ballPosY;
        private int ballSpeed;

        private int blockRows = 2;

        private int playerPosX;
        private int playerY = StageHeight - 1;
        private int playerSize = 2;

        private bool isRunning = true;
        private bool hasDrawnedStage = false;
        private bool hasDrawendPlayer = false;

        private List<BreakableBlock> blocks = new List<BreakableBlock>();

        public void Run()
        {
            Console.Clear();
            InitializationOfBreakablesBlocks();

            while (isRunning)
            {
                Draw();
                PlayerMovement();
            }
        }

        private void PlayerMovement()
        {
            ConsoleKeyInfo cki;
            if (Console.KeyAvailable == false)
            {
                cki = Console.ReadKey(true);
                
                //Move Left
                if (cki.Key == ConsoleKey.LeftArrow)
                {
                    playerPosX -= 1;
                }
                
                // Move Right
                else if (cki.Key == ConsoleKey.RightArrow)
                {
                    playerPosX += 1;
                }
            }
        }
        private void Draw()
        {
            if (!hasDrawnedStage)
            {
                #region Drawing stage

                //XY === Here
                Console.ForegroundColor = ConsoleColor.Black;
                int x = StageWidth;
                int y = 0;
                
                //Right wall
                Console.SetCursorPosition(x, y);
                for (int i = 0; i < StageHeight; i++)
                {
                    Console.WriteLine("@");
                    y += 1;
                    Console.SetCursorPosition(x, y);
                }

                //Left wall
                x = 0;
                y = 0;
                Console.SetCursorPosition(x, y);
                for (int i = 0; i < StageHeight; i++)
                {
                    Console.WriteLine("@");
                    y += 1;
                    Console.SetCursorPosition(x, y);
                }

                Console.SetCursorPosition(StageWidth / 2 + 1, StageHeight - 1);

                y = 0;
                x = 1;
                //Roof
                Console.SetCursorPosition(x, y);
                for (int i = 0; i < StageWidth - 1; i++)
                {
                    Console.WriteLine("-");
                    x += 1;
                    Console.SetCursorPosition(x, y);
                }

                #endregion

                hasDrawnedStage = true;
            }

            if (!hasDrawendPlayer)
            { 
                Console.SetCursorPosition(playerPosX, StageHeight - 1);
                for (int i = 0; i < playerSize; i++)
                {
                    Console.Write("-");
                }
            }
            
            
        }

        private void InitializationOfBreakablesBlocks()
        {
            //Generatre Rows
            for (int i = 1; i <= blockRows; i++)
            {
                //generate each block on row
                for (int j = 0; j < StageWidth - 1; j++)
                {
                    blocks.Add(new BreakableBlock(j, i));
                }
            }
        }
    }
}