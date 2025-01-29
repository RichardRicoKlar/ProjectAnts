﻿using ProjectAnts.Core;
using System;
using System.Runtime.CompilerServices;
using System.Timers;

class Program
{
    static Board newBoard = new Board(10);
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
    private static void DrawBoard(Board board)
    {
        for (int i = 0; i < board.Size; i++)
        {
            for(int j = 0; j < board.Size; j++)
            {
                Cell c = board.TheGrid[i,j];
                if (c.OccupyingEntity is Ant) { Console.Write(" x "); }
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

        DrawBoard(newBoard);

        Console.WriteLine();
    }
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        //Entities logic and movements

        LoadBoard();
    }
}