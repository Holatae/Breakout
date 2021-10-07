using System;

public class Stage
{
    int stageLengthX = 15;
    int stageLengthY = 19;
    public void Draw()
    {
        int x = 0;
        int y = 0;
        //Left wall
        for(int i = 0; i < stageLengthY; i++)
        {
            Console.WriteLine("@");
            y += 1;
            Console.SetCursorPosition(x, y);
        }
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
