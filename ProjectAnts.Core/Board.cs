using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAnts.Core
{
    public class Board
    {
        private int x;
        private int y;

        public int Size { get; }
        public Board(int size)
        {
            this.x = size;
            this.y = size;
        }
    }
}
