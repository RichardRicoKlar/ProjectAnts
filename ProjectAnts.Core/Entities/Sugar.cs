namespace ProjectAnts.Core.Entities
{
    public class Sugar(int positionX, int positionY)
    {
        public int X { get; private set; } = positionX;
        public int Y { get; private set; } = positionY;
        public int Lifetime { get; private set; } = 0;
        public void Tick(Board board)
        {
            Cell cell = board.CurrentCell[X, Y];

            Lifetime++;
            if (Lifetime >= ExperimentDefaults.SugarDecayTime)
            {
                cell.CurrentEntity = Entity.Empty;
                board.SpawnBug(X, Y);
            }
        }
    }
}
