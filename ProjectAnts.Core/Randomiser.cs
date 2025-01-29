using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAnts.Core
{
    public class Randomiser
    {
        public Cell RandomDirection(Cell cell)
        {
            // -1 left | 0 stay | 1 right
            Random row = new Random();
            int rowInt = row.Next(-1, 1);

            // -1 up | 0 stay | 1 down
            Random column = new Random();
            int columnInt = column.Next(-1, 1);

            //Counting
            cell.RowNumber = cell.RowNumber + rowInt;
            cell.ColumnNumber = cell.ColumnNumber + columnInt;

            return cell;
        }
    }
}
