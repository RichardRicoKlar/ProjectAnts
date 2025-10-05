using ProjectAnts.Core;

int tickCount = 0;

Console.WriteLine("Project Ants!");
Console.WriteLine();

Board board = ExperimentDefaults.Board;


for (int i = 0; i < ExperimentDefaults.AntsStarted; i++) board.SpawnAnt();

for (int i = 0; i < ExperimentDefaults.BugsStarted; i++) board.SpawnBug();

for (int i = 0; i < ExperimentDefaults.SugarsStarted; i++) board.SpawnSugar();

board.Display();

var tickTimer = new System.Timers.Timer(500);
tickTimer.Elapsed += (sender, e) =>
{
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