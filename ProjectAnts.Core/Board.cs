namespace ProjectAnts.Core
{
    public class Board
    {
        public int X { get; }
        public int Y { get; }
        public Cell[,] CurrentCell { get; set; }

        private int entityX = 5;
        private int entityY = 5;
        private static readonly Random rng = new();

        public Board(int size) : this(size, size) { }

        public Board(int x, int y)
        {
            X = x;
            Y = y;
            CurrentCell = new Cell[x, y];

            for (int i = 0; i < Y; i++)
            {
                for (int j = 0; j < X; j++)
                {
                    CurrentCell[j, i] = new Cell(j, i);
                }
            }

            // Place entity somewhere
            entityX = rng.Next(0, X);
            entityY = rng.Next(0, Y);
            CurrentCell[entityX, entityY].HasEntity = true;

            // Place sugar at random position (not overlapping entity)
            PlaceSugar();
        }

        public void Display()
        {
            Console.Clear();
            for (int i = 0; i < Y; i++)
            {
                for (int j = 0; j < X; j++)
                {
                    var cell = CurrentCell[j, i];
                    if (cell.HasEntity)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("E ");
                        Console.ResetColor();
                    }
                    else if (cell.HasSugar)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("O ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("_ ");
                    }
                }
                Console.WriteLine();
            }
        }

        public void Tick(int tickCount)
        {
            CurrentCell[entityX, entityY].HasEntity = false;

            (int dx, int dy) = RandomDirection();
            int newX = entityX + dx;
            int newY = entityY + dy;

            if (newX >= 0 && newX < X && newY >= 0 && newY < Y)
            {
                entityX = newX;
                entityY = newY;
            }

            var newCell = CurrentCell[entityX, entityY];

            // Check for sugar collision BEFORE setting HasEntity = true
            if (newCell.HasSugar)
            {
                // Remove sugar from the cell
                newCell.HasSugar = false;
            }

            // Now update entity position
            newCell.HasEntity = true;

            // Spawn new sugar every x ticks AFTER handling entity movement
            if (tickCount % ExperimentDefaults.SugarSpawnRate == 0)
            {
                SpawnSugar();
            }
        }

        private void PlaceSugar()
        {
            int sugarX, sugarY;
            do
            {
                sugarX = rng.Next(0, X);
                sugarY = rng.Next(0, Y);
            }
            while (sugarX == entityX && sugarY == entityY);

            CurrentCell[sugarX, sugarY].HasSugar = true;
        }
        public void SpawnSugar()
        {
            int sugarX, sugarY;
            int attempts = 0;
            const int maxAttempts = 100; // avoid infinite loop

            do
            {
                sugarX = rng.Next(0, X);
                sugarY = rng.Next(0, Y);
                attempts++;
            }
            while ((CurrentCell[sugarX, sugarY].HasEntity || CurrentCell[sugarX, sugarY].HasSugar) && attempts < maxAttempts);

            // Only place sugar if found a free spot
            if (!CurrentCell[sugarX, sugarY].HasEntity && !CurrentCell[sugarX, sugarY].HasSugar)
                CurrentCell[sugarX, sugarY].HasSugar = true;
        }
        private static (int dx, int dy) RandomDirection()
        {
            // 4 possible directions: up, down, left, right (no diagonals)
            int direction = rng.Next(4); // 0=up, 1=down, 2=left, 3=right

            return direction switch
            {
                0 => (0, -1),// up
                1 => (0, 1),// down
                2 => (-1, 0),// left
                3 => (1, 0),// right
                _ => (0, 0),// fallback, should never happen
            };
        }
    }
}
