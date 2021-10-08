﻿using System;

public class MyProgram
{
    private int posX = 1;
    private int posY = 1;

    int stageLength = 15;
    int stageHight = 19;

    bool isRunning = true;
    public void Run()
    {
        Draw();
        while(isRunning)
        {
            Forward();
            BackWards();
        }
    }


    void Forward()
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
    void BackWards()
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
