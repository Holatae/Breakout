using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class MyProgram
    {
        private int ballPosX = 1;
        private int ballPosY = 1;

        private const int StageWidth = 15;
        private const int StageHeight = 19;
        private const int PlayerSize = 2;

        private int blockRows = 2;

        bool isRunning = true;
        Player player = new Player(StageWidth, StageHeight, PlayerSize);
        private List<BreakableBlock> blocks = new List<BreakableBlock>();

        public void Run()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Draw();
            InitializationOfBreakablesBlocks();
            Thread playerThread = new Thread(() => player.InputChecker());
            playerThread.Start();
            while (isRunning)
            {
                MoveBall();
            }
        }

        void MoveBall()
        {
            bool isPlaying = true;

            int tempX = 2;
            int tempY = 2;
            while (isPlaying)
            {
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
                // Checks if ball is in the player
                if (ballPosY == player.posY)
                {
                    //Checks collision for more all the player blocks
                    for (int i = 0; i < player.size; i++)
                    {
                        if (player.posX == ballPosX || player.posX + i == ballPosX)
                        {
                            tempY = -1;
                        }
                    }
                }
                // Checks if ball is Above Player with 1
                // Check where the player is and maybe it will hit
                if (ballPosY + 1 == player.posY)
                {
                    for (int i = 0; i < player.size; i++)
                    {
                        if (ballPosX + tempX == player.posX || ballPosX + tempX == player.posX + i)
                        {
                            tempY = -1;
                        }
                    }
                }

                //if ball is close to where the blocks should be, then calculate if blocks is near
                if (ballPosY <= blockRows + 1)
                {
                    foreach (var block in blocks)
                    {
                        if (ballPosX + tempX == block.PosX && ballPosY + tempY == block.PosY)
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

                //If you loose
                if (ballPosY > StageHeight + 2)
                {
                    tempY = 1;
                    tempX = 1;
                    ballPosX = 1;
                    ballPosY = 1;
                }

                #endregion

                //If going right X is 1 and left -1. From CheckDirection
                ballPosX += tempX;
                ballPosY += tempY;

                //Moves the ball
                Console.SetCursorPosition(ballPosX, ballPosY);
                Console.Write("@");
                Thread.Sleep(200);

                //removes the old ball
                Console.SetCursorPosition(ballPosX, ballPosY);
                Console.Write(" ");
            }
        }

        #region oldCode

        // void GoingRight()
        // {
        //     while (posX <= stageLength || posY <= stageHight)
        //     {
        //         Console.SetCursorPosition(posX, posY);
        //         posX += 1;
        //         posY += 1;
        //         Console.SetCursorPosition(posX, posY - 1);
        //         Console.Write("@");
        //         System.Threading.Thread.Sleep(200);
        //         Console.SetCursorPosition(posX - 1, posY - 1);
        //         Console.Write("  ");
        //     }
        //     //for (int i = 0; i < stageLength; i++)
        //     //{
        //     //    Console.SetCursorPosition(x, y);
        //     //    x += 1;
        //     //    y += 1;
        //     //    Console.SetCursorPosition(x, y - 1);
        //     //    Console.Write("@");
        //     //    System.Threading.Thread.Sleep(200);
        //     //    Console.SetCursorPosition(x - 1, y - 1);
        //     //    Console.Write("  ");
        //
        //     //}
        //
        // }

        // void GoingLeft()
        // {
        //     for (int i = 0; i < stageLength; i++)
        //     {
        //         Console.SetCursorPosition(posX, posY);
        //         Console.Write("");
        //         posX -= 1;
        //         posY -= 1;
        //         Console.Write("@");
        //         System.Threading.Thread.Sleep(200);
        //         Console.SetCursorPosition(posX + 1, posY + 1);
        //         Console.Write(" ");
        //     }
        // }

        #endregion

        private void Draw()
        {
            //XY === HÄR
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

            // y = StageHeight - 1;
            // x = 1;
            // //Floor
            // Console.SetCursorPosition(x, y);
            // for (int i = 0; i < StageWidth - 1; i++)
            // {
            //     Console.WriteLine("-");
            //     x += 1;
            //     Console.SetCursorPosition(x, y);
            // }

            //Draw player
            Console.SetCursorPosition(StageWidth / 2 + 1, StageHeight - 1);
            Console.ForegroundColor = ConsoleColor.Black;
            for (int i = 0; i < PlayerSize; i++)
            {
                Console.Write("-");
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
        }

        private void InitializationOfBreakablesBlocks()
        {
            for (int i = 1; i <= blockRows; i++)
            {
                for (int j = 0; j < StageWidth - 1; j++)
                {
                    blocks.Add(new BreakableBlock(j, i, 1));
                }
            }
        }
    }
}