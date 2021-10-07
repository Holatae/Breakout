using System;

public class MyProgram
{
    private int x = 1;
    private int y = 1;

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
        while (x <= stageLength || y <= stageHight)
        {
            Console.SetCursorPosition(x, y);
            x += 1;
            y += 1;
            Console.SetCursorPosition(x, y - 1);
            Console.Write("@");
            System.Threading.Thread.Sleep(200);
            Console.SetCursorPosition(x - 1, y - 1);
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
            Console.SetCursorPosition(x, y);
            Console.Write("");
            x -= 1;
            y -= 1;
            Console.Write("@");
            System.Threading.Thread.Sleep(200);
            Console.SetCursorPosition(x + 1, y + 1);
            Console.Write(" ");
        }
    }

    public void Draw()
    {
        //XY === HÄR
        y = 0;
        x = stageLength;
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
