namespace ProjectAnts.Core
{
    public class Board
    {
        public int X { get; }
        public int Y { get; }
        public Cell[,] CurrentCell { get; set; }
        public int[] Size { get; set; }
        public Board(int size)
        {
            X = size;
            Y = size;
            Size = [size,size];
            CurrentCell = new Cell[size, size];
            for (int i = 0; i < Y; i++)
            {
                for (int j = 0; j < X; j++)
                {
                    CurrentCell[j,i] = new Cell(j,i);
                }
            }
        }
        public Board(int x, int y)
        {
            X = x;
            Y = y;
            Size = [x, y];
            CurrentCell = new Cell[x, y];
            for (int i = 0; i < Y; i++)
            {
                for (int j = 0; j < X; j++)
                {
                    CurrentCell[j, i] = new Cell(j, i);
                }
            }
        }
    }
}
