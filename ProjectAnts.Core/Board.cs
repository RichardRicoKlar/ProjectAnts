using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAnts.Core
{
    public class Board
    {
        public int Size { get; set; }
        public Cell[,] TheGrid { get; set; }
        public Board(int s)
        {
            Size = s;
            TheGrid = new Cell[Size, Size];

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    TheGrid[i, j] = new Cell(i,j);
                }
            }
        }
    }
}
