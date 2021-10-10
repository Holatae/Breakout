using System;

namespace ConsoleApplication
{
    public class BreakableBlock
    {
        private int posX;
        private int posY;
        private int row;
        private bool isBrocken = false;

        void BreakBlock()
        {
            Console.SetCursorPosition(posX, posY);
            Console.Write(" ");
        }

        public BreakableBlock(int posX, int posY, int row)
        {
            this.posX = posX;
            this.posY = posY;
            this.row = row;
            Console.SetCursorPosition(this.posX, this.posY);
            Console.Write($"{ConsoleColor.Blue}@");
        }
    }
}