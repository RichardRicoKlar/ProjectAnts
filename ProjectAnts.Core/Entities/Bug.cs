namespace ProjectAnts.Core.Entities
{
    public class Bug(int startX, int startY)
    {
        public int X { get; private set; } = startX;
        public int Y { get; private set; } = startY;
        public bool IsAlive { get; private set; } = true;
        public void Tick(Board board)
        {
            if (!IsAlive) return;

            board.CurrentCell[X, Y].CurrentEntity = Entity.Empty;

            (int dx, int dy) = Randomiser.RandomDirection();
            int newX = X + dx;
            int newY = Y + dy;

            if (newX >= 0 && newX < board.X && newY >= 0 && newY < board.Y)
            {
                X = newX;
                Y = newY;
            }

            var cell = board.CurrentCell[X, Y];

            switch (cell.CurrentEntity)
            {
                case Entity.Ant:
                    Kill();
                    break;
                case Entity.Bug:
                    board.SpawnBug();
                    break;
                case Entity.Sugar:
                    cell.CurrentEntity = Entity.Empty;
                    break;
                default: break;
            }

            board.CurrentCell[X, Y].CurrentEntity = Entity.Bug;
        }

        public void Kill()
        {
            IsAlive = false;
        }
    }
}
