using System;

namespace ConsoleApplication
{
    public class BreakableBlock
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        private int row;
        public bool IsDestroyed { get; private set; }

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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("$");
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public void Destroy()
        {
            IsDestroyed = true;
        }
    }
}