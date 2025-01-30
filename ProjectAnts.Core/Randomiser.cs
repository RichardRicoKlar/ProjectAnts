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
        public static Cell RandomDirection(Cell cell)
        {
            // -1 left | 0 stay | 1 right
            Random row = new Random();
            int rowInt = row.Next(3) - 1;

            // -1 up | 0 stay | 1 down
            int columnInt = 0;
            if (cell.RowNumber == rowInt)
            {
                Random column = new Random();
                columnInt = column.Next(3) - 1;
            }

            //Counting
            cell.RowNumber = cell.RowNumber + rowInt;
            cell.ColumnNumber = cell.ColumnNumber + columnInt;

            Console.WriteLine("Row roll: " + rowInt);
            Console.WriteLine("Column roll: " + columnInt);

            return cell;
        }
    }
}
