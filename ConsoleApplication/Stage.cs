using System;

public class Stage
{
    public void Draw()
    {
        int x = 0;
        int y = 0;
        //Left wall
        for(int i = 0; i < 20; i++)
        {
            Console.WriteLine("@");
            y += 1;
            Console.SetCursorPosition(x, y);
        }
        y = 0;
        x = 20;
        //Right wall
        Console.SetCursorPosition(x, y);
        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine("@");
            y += 1;
            Console.SetCursorPosition(x, y);

        }

        y = 19;
        x = 1;
        //Floor
        Console.SetCursorPosition(x, y);
       for (int i = 0; i < 19; i++)
        {
            Console.WriteLine("-");
            x += 1;
            Console.SetCursorPosition(x, y);
        }

        y = 0;
        x = 1;
        //Roof
        Console.SetCursorPosition(x, y);
        for (int i = 0; i < 19; i++)
        {
            Console.WriteLine("-");
            x += 1;
            Console.SetCursorPosition(x, y);
        }


    }
}
