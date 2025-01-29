using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAnts.Core
{
    public class Cell
    {
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
        public bool IsOccupied { get; set; }
        public object OccupyingEntity { get; set; }

        public Cell()
        {
            RowNumber = 0;
            ColumnNumber = 0;
            OccupyingEntity = new object();
        }
        public Cell(int x, int y)
        {
            RowNumber = x;
            ColumnNumber = y;
        }
    }
}
