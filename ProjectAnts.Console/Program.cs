using ProjectAnts.Core;

Console.WriteLine("Project Ants!");
Console.WriteLine();

int tickCount = 0;

Board board = ExperimentDefaults.Board;

for (int i = 0; i < ExperimentDefaults.AntsStarted; i++) board.SpawnAnt();

for (int i = 0; i < ExperimentDefaults.BugsStarted; i++) board.SpawnBug();

for (int i = 0; i < ExperimentDefaults.SugarsStarted; i++) board.SpawnSugar();

board.Display();

var tickTimer = new System.Timers.Timer(500);
tickTimer.Elapsed += (sender, e) =>
{
    Console.WriteLine("Project Ants!");
    Console.WriteLine();

    tickCount++;

    // Tick all ants
    board.Tick(tickCount);

    board.Display();
    Console.WriteLine();
    Console.WriteLine($"Day: {tickCount}");
    Console.WriteLine("Press ESC to stop the simulation...");

    // Check if there are any living ants
    if (!board.Ants.Any(a => a.IsAlive))
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nAll ants have died. Stopping simulation.");
        Console.ResetColor();
        tickTimer.Stop();
    }

    // Check if ants dominated the board
    if (board.Ants.Count >= (board.X * board.Y * 0.9))
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\nAnts have dominated the board in {tickCount} days. Stopping simulation.");
        Console.ResetColor();
        tickTimer.Stop();
    }

    // Check if bugs have dominated the board
    if (board.Bugs.Count >=  (board.X * board.Y * 0.9))
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\nBugs have dominated the board in {tickCount} days. Stopping simulation.");
        Console.ResetColor();
        tickTimer.Stop();
    }
};
tickTimer.AutoReset = true;
tickTimer.Start();

Console.WriteLine("\nPress ESC to stop the simulation...");

// Keep app running until ESC pressed
while (true)
{
    if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
        break;
}

tickTimer.Stop();
tickTimer.Dispose();