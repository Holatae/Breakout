using System;

namespace ConsoleApplication
{
    public class BreakableBlock
    {
        public int PosX { get; }
        public int PosY { get; }
        private int row;
        private bool isBrocken = false;

        void BreakBlock()
        {
            Console.SetCursorPosition(PosX, PosY);
            Console.Write(" ");
        }

        public BreakableBlock(int posX, int posY, int row)
        {
            PosX = posX;
            PosY = posY;
            this.row = row;
            Console.SetCursorPosition(this.PosX + 1, this.PosY);
            Console.Write("$");
        }
    }
}