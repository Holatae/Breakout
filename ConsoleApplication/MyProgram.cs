using System;

public class MyProgram
{
    private int trackLength = 17;
    private int x = 1;
    private int y = 1;
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

}
