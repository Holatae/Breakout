using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class MyProgram
    {
        private int _posX;
        private int _posY;

        private const int StageWidth = 15;
        private const int StageHeight = 19;
        private const int PlayerSize = 2;

        private int blockRows = 2;

        bool isRunning = true;
        Player player = new Player(StageWidth, StageHeight, PlayerSize);
        private List<BreakableBlock> blocks = new List<BreakableBlock>();
        public void Run()
        {
            Console.Clear();
            Draw();
            InitializationOfBreakablesBlocks();
            
            //Player starting position
            Random random = new Random();
            _posX = random.Next(1, StageWidth - 1);
            _posY = blockRows + 1;
            
            Thread playerThread = new Thread(start: () => player.InputChecker());
            playerThread.Start();
            while(isRunning)
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
                Console.SetCursorPosition(_posX, _posY);
            
                //Check which direction the ball is going
                #region CheckDirection

                if (_posX == StageWidth - 1)
                {
                    tempX = -1;
                }
                else if(_posX == 1)
                {
                    tempX = 1;
                }
                
                if (_posY is >= StageHeight - 2 and < StageHeight)
                {
                    //Checks collision for more all the player blocks
                    for (int i = 0; i < player.Size; i++)
                    {
                        // Checks if player is hitting ball or is going to hit the ball
                        if (player.PosX + tempX == _posX || player.PosX == _posX  || 
                            player.PosX + tempX + i ==_posX|| player.PosX + i == _posX)
                        {
                            tempY = -1;
                            Console.SetCursorPosition(player.PosX, player.PosY);
                            for (int j = 0; j < player.Size; j++)
                            {
                                Console.Write("-");
                            }
                        }
                    }
                }
                
                // if the ball comes close to the block, the game checks every
                // frame if the ball hits one of the blocks. If it hit
                // then destroy the block and change the balls direction.
                if(_posY >= blockRows + 1)
                {
                    foreach (var block in blocks)
                    {
                        if (_posX + tempX == block.PosX && _posY + tempY == block.PosY && !block.IsDestroyed)
                        {
                            Console.SetCursorPosition(block.PosX, block.PosY);
                            Console.Write(" ");
                            block.Destroy();
                            tempY = 1;
                        }
                    }
                }

                if (_posY == 1)
                {
                    tempY = 1;
                }

                //If you loose than reset the ball
                if (_posY > StageHeight + 2)
                {
                    Random random = new Random();
                    tempY = 1;
                    tempX = 1;
                    _posX = random.Next(1 ,StageWidth - 1);
                    _posY = blockRows + 1;
                }
                #endregion
            
                //If going right X is 1 and left -1. From CheckDirection
                _posX += tempX;
                _posY += tempY;
            
                //Moves the ball
                Console.SetCursorPosition(_posX, _posY );
                Console.Write("@");
                System.Threading.Thread.Sleep(200);
            
                //removes the old ball
                Console.SetCursorPosition(_posX, _posY );
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
            for (int i = 0; i < player.Size; i++)
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
