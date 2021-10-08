using System;
using System.Threading;

namespace ConsoleApplication
{
    public class MyProgram
    {
        private int _posX = 1;
        private int _posY = 1;

        private const int StageWidth = 15;
        private const int StageHeight = 19;

        bool isRunning = true;
        public void Run()
        {
            Draw();
            Player player = new Player(StageWidth, StageHeight);
            Thread playerThread = new Thread(() => player.InputChecker());
            playerThread.Start();
            while(isRunning)
            {
                MoveBall();
            }
        }

        void MoveBall()
        {
            bool isPlaying = true;

            int tempX = 1;
            int tempY = 1;
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
                
                //TODO REMEMBER THAT 2 SHOULD BE 1 IN THE FUTURE
                
                if (_posY == StageHeight - 2)
                {
                    tempY = -1;
                }
                else if(_posY == 1)
                {
                    tempY = 1;
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
            Console.Write("-");
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

    }
}
