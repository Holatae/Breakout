using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApplication
{
    public class NoTheards
    {
        private const int StageHeight = 12;
        private const int StageWidth = 20;

        private int ballPosX;
        private int ballPosY;
        private int ballSpeed;

        private int speed = 150;

        private int blockRows = 2;

        private int playerPosX = 4;
        private int playerY = StageHeight - 1;
        private int playerSize = 2;
        private bool hasMoved = false;

        private bool isRunning = true;
        private bool hasDrawnedStage;
        private bool hasDrawendPlayer = false;

        private List<BreakableBlock> blocks = new List<BreakableBlock>();


        public void Run()
        {
            Thread playerThread = new Thread(() => PlayerMovement());
            playerThread.Start();
            Console.Clear();
            InitializationOfBreakablesBlocks();

            while (isRunning)
            {
                Draw();
            }
        }

        private void PlayerMovement()
        {
            while (isRunning)
            {
                ConsoleKeyInfo cki;
                if (Console.KeyAvailable == false)
                {
                    cki = Console.ReadKey(true);

                    //Move Left
                    if (cki.Key == ConsoleKey.LeftArrow)
                    {
                        if (playerPosX - 1 != 0)
                        {
                            playerPosX -= 1;
                            hasMoved = true;
                        }
                    }

                    // Move Right
                    else if (cki.Key == ConsoleKey.RightArrow)
                    {
                        if (playerPosX + 1 != StageWidth - 1)
                        {
                            playerPosX += 1;
                            hasMoved = true;
                        }
                    }
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
                Console.SetCursorPosition(playerPosX, playerY);
                for (int i = 0; i < playerSize; i++)
                {
                    Console.Write("-");
                }
            }

            #region drawPlayer

            //Clear player
            if (hasMoved)
            {
                for (int i = 1; i < StageWidth - 1; i++)
                {
                    Console.SetCursorPosition(i, playerY);
                    Console.Write(" ");
                    hasMoved = false;
                }
            }
            
            //Move player
            for (int i = 0; i < playerSize; i++)
            {
                Console.SetCursorPosition(playerPosX + 1, playerY);
            }

            #endregion

            MoveBall();

            #region DrawBall

            
            //Moves the ball
            Console.SetCursorPosition(ballPosX, ballPosY);
            Console.Write("@");
            Thread.Sleep(speed);

            //removes the old ball
            Console.SetCursorPosition(ballPosX, ballPosY);
            Console.Write(" ");

            #endregion
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

        void MoveBall()
        {
            bool isPlaying = true;

            int tempX = 1;
            int tempY = 1;
            Console.SetCursorPosition(ballPosX, ballPosY);

            //Check which direction the ball is going

            #region CheckDirection

            if (ballPosX == StageWidth - 1)
            {
                tempX = -1;
            }
            else if (ballPosX == 1)
            {
                tempX = 1;
            }

            // IF ballposY Är större eller lika med StageHeight -2 och < Stage height
            if (ballPosY is >= StageHeight - 2 and < StageHeight)
            {
                //Checks collision for more all the player blocks
                for (int i = 0; i < playerSize; i++)
                {
                    // Checks if player is hitting ball or is going to hit the ball
                    if (playerPosX + tempX == ballPosX || playerPosX == ballPosX ||
                        playerPosX + tempX + i == ballPosX || playerPosX + i == ballPosX)
                    {
                        tempY = -1;
                        Console.SetCursorPosition(playerPosX, playerY);
                        for (int j = 0; j < playerSize; j++)
                        {
                            Console.Write("-");
                        }
                    }
                }
            }

            // if the ball comes close to the block, the game checks every
            // frame if the ball hits one of the blocks. If it hit
            // then destroy the block and change the balls direction.
            if (ballPosY >= blockRows + 1)
            {
                foreach (var block in blocks)
                {
                    if (ballPosX + tempX == block.PosX && ballPosY + tempY == block.PosY && !block.IsDestroyed)
                    {
                        Console.SetCursorPosition(block.PosX, block.PosY);
                        Console.Write(" ");
                        block.Destroy();
                        tempY = 1;
                    }
                }
            }

            if (ballPosY == 1)
            {
                tempY = 1;
            }

            //If you loose than reset the ball
            if (ballPosY > StageHeight + 2)
            {
                Random random = new Random();
                tempY = 1;
                tempX = 1;
                ballPosX = random.Next(1, StageWidth - 1);
                ballPosY = blockRows + 1;
            }

            #endregion

            //If going right X is 1 and left -1. From CheckDirection
            ballPosX += tempX;
            ballPosY += tempY;

        }
    }
}