using ProjectAnts.Core;
using System;
using System.Runtime.CompilerServices;
using System.Timers;

class Program
{
    static Board newBoard = new Board(11);
    static void Main(string[] args)
    {
        LoadBoard(); //First load
        Ant ant = new Ant();
        newBoard.TheGrid[5, 5].OccupyingEntity = ant;
        ant.Position = newBoard.TheGrid[5, 5];
        //Timer
        System.Timers.Timer aTimer = new System.Timers.Timer();
        aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        aTimer.Interval = 1000; // ~ 1 seconds
        aTimer.Enabled = true;

        Console.WriteLine("Press \'q\' to quit the sample.");
        while (Console.Read() != 'q') ;
    }
    private static void DrawBoard(Board board)
    {
        for (int i = 0; i < board.Size; i++)
        {
            for(int j = 0; j < board.Size; j++)
            {
                Cell c = board.TheGrid[i,j];
                if (c.OccupyingEntity is Ant) { Console.Write(" X "); }
                else { Console.Write(" . "); }
            }
            Console.WriteLine(" . ");
        }
    }
    private static void LoadBoard()
    {
        Console.Clear();

        Console.WriteLine("Project Ants!");
        Console.WriteLine(); //Empty line

        DrawBoard(newBoard);

        Console.WriteLine(); //Empty line
    }
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        //Entities logic and movements
        BoardMovement(newBoard);
        LoadBoard();
    }
    private static void BoardMovement(Board board)
    {
        for (int i = 0; i < board.Size; i++)
        {
            for (int j = 0; j < board.Size; j++)
            {
                Cell c = board.TheGrid[i, j];
                if (c.OccupyingEntity is Ant) { /* AntLogic(c); */ }
            }
        }
    }
    private static void AntLogic (Cell cell)
    {
        cell.OccupyingEntity = null;
        newBoard.TheGrid[cell.RowNumber, cell.ColumnNumber] = cell;
        Cell newCell = Randomiser.RandomDirection(cell);
        newCell.OccupyingEntity = new Ant();
        newBoard.TheGrid[newCell.RowNumber, newCell.ColumnNumber] = newCell;
    }
}