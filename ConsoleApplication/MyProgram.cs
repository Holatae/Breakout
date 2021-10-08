using System;

public class MyProgram
{
    private int posX = 1;
    private int posY = 1;

    readonly int stageLength = 15;
    readonly int stageHight = 19;

    bool isRunning = true;
    public void Run()
    {
        Draw();
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
            Console.SetCursorPosition(posX, posY);

            #region CheckDirection

            if (posX == stageLength - 1)
            {
                tempX = -1;
            }
            else if(posX == 1)
            {
                tempX = 1;
            }
            
            if (posY == stageHight - 1)
            {
                tempY = -1;
            }
            else if(posY == 1)
            {
                tempY = 1;
            }
            #endregion

            posX += tempX;
            posY += tempY;
            Console.SetCursorPosition(posX, posY );
            Console.Write("@");
            System.Threading.Thread.Sleep(200);
            Console.SetCursorPosition(posX, posY );
            Console.Write(" ");
        }
    }


    void GoingRight()
    {
        while (posX <= stageLength || posY <= stageHight)
        {
            Console.SetCursorPosition(posX, posY);
            posX += 1;
            posY += 1;
            Console.SetCursorPosition(posX, posY - 1);
            Console.Write("@");
            System.Threading.Thread.Sleep(200);
            Console.SetCursorPosition(posX - 1, posY - 1);
            Console.Write("  ");
        }
        //for (int i = 0; i < stageLength; i++)
        //{
        //    Console.SetCursorPosition(x, y);
        //    x += 1;
        //    y += 1;
        //    Console.SetCursorPosition(x, y - 1);
        //    Console.Write("@");
        //    System.Threading.Thread.Sleep(200);
        //    Console.SetCursorPosition(x - 1, y - 1);
        //    Console.Write("  ");

        //}

    }
    void GoingLeft()
    {
        for (int i = 0; i < stageLength; i++)
        {
            Console.SetCursorPosition(posX, posY);
            Console.Write("");
            posX -= 1;
            posY -= 1;
            Console.Write("@");
            System.Threading.Thread.Sleep(200);
            Console.SetCursorPosition(posX + 1, posY + 1);
            Console.Write(" ");
        }
    }

    public void Draw()
    {
        
        //XY === HÄR
        int x = stageLength;
        int y = 0;
        //Right wall
        Console.SetCursorPosition(x, y);
        for (int i = 0; i < stageHight; i++)
        {
            Console.WriteLine("@");
            y += 1;
            Console.SetCursorPosition(x, y);

        }

        //Left wall
        x = 0;
        y = 0;
        Console.SetCursorPosition(x, y);
        for (int i = 0; i < stageHight; i++)
        {
            Console.WriteLine("@");
            y += 1;
            Console.SetCursorPosition(x, y);
        }

        y = 19;
        x = 1;
        //Floor
        Console.SetCursorPosition(x, y);
        for (int i = 0; i < stageLength - 1; i++)
        {
            Console.WriteLine("-");
            x += 1;
            Console.SetCursorPosition(x, y);
        }

        y = 0;
        x = 1;
        //Roof
        Console.SetCursorPosition(x, y);
        for (int i = 0; i < stageLength - 1; i++)
        {
            Console.WriteLine("-");
            x += 1;
            Console.SetCursorPosition(x, y);
        }

        x = 1;
        y = 1;
    }

}
