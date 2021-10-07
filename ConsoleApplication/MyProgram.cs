using System;

public class MyProgram
{
    private int trackLength = 17;
    private int x = 1;
    private int y = 1;

    int stageLengthX = 15;
    int stageLengthY = 19;
    public void Run()
    {
        Forward();
    }


    void Forward()
    {
        for (int i = 0; i < trackLength; i++)
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

        BackWards();

    }
    void BackWards()
    {
        for (int i = 0; i < trackLength; i++)
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
        Forward();
    }

    public void Draw()
    {
        
        y = 0;
        x = stageLengthX;
        //Right wall
        Console.SetCursorPosition(x, y);
        for (int i = 0; i < stageLengthY; i++)
        {
            Console.WriteLine("@");
            y += 1;
            Console.SetCursorPosition(x, y);

        }

        y = 19;
        x = 1;
        //Floor
        Console.SetCursorPosition(x, y);
        for (int i = 0; i < stageLengthX - 1; i++)
        {
            Console.WriteLine("-");
            x += 1;
            Console.SetCursorPosition(x, y);
        }

        y = 0;
        x = 1;
        //Roof
        Console.SetCursorPosition(x, y);
        for (int i = 0; i < stageLengthX - 1; i++)
        {
            Console.WriteLine("-");
            x += 1;
            Console.SetCursorPosition(x, y);
        }
    }

}
