using System;

namespace ConsoleApplication
{
    public class BreakableBlock
    {
        private int posX;
        private int posY;
        private bool isBrocken = false;

        void BreakBlock()
        {
            Console.SetCursorPosition(posX, posY);
            Console.Write(" ");
        }

    }
}