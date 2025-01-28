using ProjectAnts.Core;
using System;

class Program
{
    static void Main(string[] args)
    {
        Board newBoard = new Board(10);
        Console.WriteLine("Project Ants!");
        CreateBoard(newBoard);
    }
    private static void CreateBoard(Board board)
    {
        for (int i = 0; i < board.Size; i++)
        {
            for(int j = 0; j < board.Size; j++)
            {
                Console.Write(".");
            }
            Console.WriteLine(".");
        }
    }
}