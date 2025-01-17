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
    }
}
