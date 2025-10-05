namespace ProjectAnts.Core.Entities
{
    public class Ant(int startX, int startY)
    {
        public int X { get; private set; } = startX;
        public int Y { get; private set; } = startY;
        public int Lifetime { get; private set; } = 0;
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


            // Interactions
            Cell cell = board.CurrentCell[X, Y];

            switch (cell.CurrentEntity)
            {
                case Entity.Ant:
                    board.SpawnAnt();
                    board.SpawnAnt();
                    Kill();
                    board.Ants.Remove(this);
                    break;
                case Entity.Bug:
                    var bug = board.Bugs.FirstOrDefault(b => b.X == X && b.Y == Y && b.IsAlive);
                    if (bug != null)
                    {
                        bug.Kill();
                        board.Bugs.Remove(bug);
                        Lifetime -= ExperimentDefaults.BugLifeValue;
                        cell.CurrentEntity = Entity.Empty;
                    }
                    break;
                case Entity.Sugar:
                    Lifetime -= ExperimentDefaults.SugarLifeValue;
                    cell.CurrentEntity = Entity.Empty;
                    board.SpawnAnt(); // Nom nom time
                    break;
                default: break;
            }
                    
            cell.CurrentEntity = Entity.Ant;

            Lifetime++;
            if (Lifetime >= ExperimentDefaults.AntLifeTime)
            {
                cell.CurrentEntity = Entity.Empty;
                IsAlive = false;
            }
        }
        public void Kill()
        {
            IsAlive = false;
        }
    }
}
