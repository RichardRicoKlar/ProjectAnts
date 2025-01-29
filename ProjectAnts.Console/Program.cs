using ProjectAnts.Core;
using System;
using System.Runtime.CompilerServices;
using System.Timers;

class Program
{
    static void Main(string[] args)
    {
        LoadBoard(); //First load

        //Timer
        System.Timers.Timer aTimer = new System.Timers.Timer();
        aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        aTimer.Interval = 1000; // ~ 1 seconds
        aTimer.Enabled = true;

        Console.WriteLine("Press \'q\' to quit the sample.");
        while (Console.Read() != 'q') ;
    }
    private static void CreateBoard(Board board)
    {
        for (int i = 0; i < board.Size; i++)
        {
            for(int j = 0; j < board.Size; j++)
            {
                Cell c = board.TheGrid[i,j];
                Console.Write(" . ");
            }
            Console.WriteLine(" . ");
        }
    }
    private static void LoadBoard()
    {
        Console.Clear();

        Console.WriteLine("Project Ants!");
        Console.WriteLine(); //mezera

        Board newBoard = new Board(10);
        CreateBoard(newBoard);

        Console.WriteLine();
    }
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        //Entities logic and movements

        LoadBoard();
    }
}