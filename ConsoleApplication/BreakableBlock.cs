using System;

namespace ConsoleApplication
{
    public class BreakableBlock
    {
        public int PosX { get; }
        public int PosY { get; } //AKA the row the block is on
        public bool IsDestroyed { get; private set; }

        void BreakBlock()
        {
            Console.SetCursorPosition(PosX, PosY);
            Console.Write(" ");
        }

        public BreakableBlock(int posX, int posY)
        {
            PosX = posX;
            PosY = posY;
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