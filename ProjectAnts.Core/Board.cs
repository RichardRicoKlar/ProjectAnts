using ProjectAnts.Core.Entities;

namespace ProjectAnts.Core
{
    public class Board
    {
        public int X { get; }
        public int Y { get; }
        public Cell[,] CurrentCell { get; set; }
        public List<Ant> Ants { get; set; } = [];
        public List<Bug> Bugs { get; set; } = [];
        public List<Sugar> Sugars { get; set; } = [];
        private static readonly Random rng = new();
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
        }
        public void Display()
        {
            Console.Clear();
            for (int i = 0; i < Y; i++)
            {
                for (int j = 0; j < X; j++)
                {
                    var cell = CurrentCell[j, i];
                    switch (cell.CurrentEntity)
                    {
                        case Entity.Ant:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("A ");
                            Console.ResetColor();
                            break;
                        case Entity.Bug:
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("B ");
                            Console.ResetColor();
                            break;
                        case Entity.Sugar:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("O ");
                            Console.ResetColor();
                            break;
                        default: Console.Write("_ "); break;
                    }
                }
                Console.WriteLine();
            }
        }
        public void Tick(int tickCount)
        {
            // Move ants
            foreach (Ant ant in Ants.ToList()) ant.Tick(this);

            // Move bugs
            foreach (Bug bug in Bugs.ToList()) bug.Tick(this);

            // Tick sugars
            foreach (Sugar sugar in Sugars) sugar.Tick(this);

            // Spawn new sugar every 5 ticks
            if (tickCount % (rng.Next(5,11)*ExperimentDefaults.SugarSpawnRate) == 0) SpawnSugar();
        }
        public void SpawnSugar()
        {
            int sugarX, sugarY;
            int attempts = 0;
            const int maxAttempts = 10; // avoid infinite loop in very full boards

            do
            {
                sugarX = rng.Next(0, X);
                sugarY = rng.Next(0, Y);
                attempts++;
            }
            while (CurrentCell[sugarX, sugarY].CurrentEntity != Entity.Empty && attempts < maxAttempts);

            // Only place sugar if we found a free spot
            if (CurrentCell[sugarX, sugarY].CurrentEntity == Entity.Empty)
            {
                Sugars.Add(new Sugar(sugarX, sugarY));
                CurrentCell[sugarX, sugarY].CurrentEntity = Entity.Sugar;
            }
        }
        public void SpawnAnt()
        {
            int antX = rng.Next(0, X);
            int antY = rng.Next(0, Y);
            Ants.Add(new(antX, antY));
            CurrentCell[antX, antY].CurrentEntity = Entity.Ant;
        }
        public void SpawnBug()
        {
            int bugX = rng.Next(0, X);
            int bugY = rng.Next(0, Y);
            Bugs.Add(new(bugX, bugY));
            CurrentCell[bugX, bugY].CurrentEntity = Entity.Bug;
        }
        public void SpawnBug(int x, int y)
        {
            Bugs.Add(new(x, y));
            CurrentCell[x, y].CurrentEntity = Entity.Bug;
        }
    }
}
