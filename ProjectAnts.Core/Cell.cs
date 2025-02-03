namespace ProjectAnts.Core
{
    public class Cell
    {
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
        public bool CurrentlyOccupied { get; set; }
        public Entities Entity { get; set; }

        public Cell(int x, int y)
        {
            RowNumber = x;
            ColumnNumber = y;
            Entity = Entities.Empty;
            CurrentlyOccupied = false;
        }
        public Cell(int x, int y, Entities entity)
        {
            RowNumber = x;
            ColumnNumber = y;
            Entity = entity;
            CurrentlyOccupied = true;
            if (entity == Entities.Empty)
            {
                CurrentlyOccupied = false;
            }
        }
    }
}
