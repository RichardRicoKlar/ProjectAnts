namespace ProjectAnts.Core
{
    public class Randomiser
    {
        public static void RandomDirection(Board board, Cell cell)
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
            board.CurrentCell[cell.RowNumber + rowInt, cell.ColumnNumber + columnInt].Entity = cell.Entity;
            cell.Entity = Entities.Empty;
        }
    }
}
