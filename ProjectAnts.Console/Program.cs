using ProjectAnts.Core;

Console.WriteLine("Project Ants!");
Console.WriteLine();

Board newBoard = new Board(25,15); //Create new board
newBoard.CurrentCell[5, 5].Entity = Entities.Ant; //Drop ant to test the code


ConsoleControls.UpdateBoard(newBoard);

System.Timers.Timer aTimer = new System.Timers.Timer();
aTimer.Elapsed += (sender, e) => ConsoleControls.UpdateBoard(newBoard);
aTimer.Interval = 1000; // ~ 5 seconds
aTimer.Enabled = true;
aTimer.AutoReset = true;

while (Console.Read() != 'q') ;