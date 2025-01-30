using ProjectAnts.Core;
using System;
using System.Runtime.CompilerServices;
using System.Timers;

class Program
{
    static Board newBoard = new Board(11);
    static void Main(string[] args)
    {
        newBoard.TheGrid[5, 5].OccupyingEntity = new Ant();

        LoadBoard(); //First load

        //Timer
        System.Timers.Timer aTimer = new System.Timers.Timer();
        aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        aTimer.Interval = 1000; // ~ 1 seconds
        aTimer.Enabled = true;

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
                if (c.OccupyingEntity is Ant) { AntLogic(c);
                }
            }
        }
    }
    private static void AntLogic(Cell cell)
    {
        Cell cellHolder = cell;
        cell.OccupyingEntity = null;
        Randomiser.RandomDirection(cellHolder);
        newBoard.TheGrid[cellHolder.RowNumber, cellHolder.ColumnNumber].OccupyingEntity = new Ant();
    }
}