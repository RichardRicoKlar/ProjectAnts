namespace ProjectAnts.Core
{
    public class Cell(int x, int y)
    {
        public int RowNumber { get; set; } = x;
        public int ColumnNumber { get; set; } = y;
        public bool HasEntity { get; set; } = false;
        public bool HasSugar { get; set; } = false;
    }
}
