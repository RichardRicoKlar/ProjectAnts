using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAnts.Core
{
    public class Randomiser
    {
        public static Cell RandomLocation(Board board)
        {
            Cell cell = new Cell();

            int boardSize = board.Size;
            Random random1 = new Random();
            int rowInt = random1.Next(0, boardSize);

            Random random2 = new Random();
            int columnInt = random2.Next(0, boardSize);

            cell.RowNumber = rowInt;
            cell.ColumnNumber = columnInt;

            return cell;
        }
        public static void RandomDirection(Cell cell)
        {
            //Pick method
            Random method = new Random();
            int rowInt = 0;
            int columnInt = 0;

            if (method.Next(100) < 50)
            {
                // -1 left | 0 stay | 1 right
                Random row = new Random();
                rowInt = row.Next(3) - 1;
            }
            else
            {
                Random column = new Random();
                columnInt = column.Next(3) - 1;
            }

            //Counting
            cell.RowNumber = cell.RowNumber + rowInt;
            cell.ColumnNumber = cell.ColumnNumber + columnInt;
        }
    }
}
