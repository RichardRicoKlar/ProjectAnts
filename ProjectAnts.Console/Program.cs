using ProjectAnts.Core;

int tickCount = 0;

Console.WriteLine("Project Ants!");
Console.WriteLine();

Board board = ExperimentDefaults.Board;
board.Display();

var tickTimer = new System.Timers.Timer(500);
tickTimer.Elapsed += (sender, e) =>
{
    tickCount++;           // increment tick counter
    board.Tick(tickCount);
    board.Display();
    Console.WriteLine($"\nDay: {tickCount}");
    Console.WriteLine("Press ESC to stop the simulation...");
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