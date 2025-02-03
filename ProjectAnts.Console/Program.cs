using ProjectAnts.Core;

Console.WriteLine("Test");

Board newBoard = new Board(20); //Board dimentions

for (int i = 0; i < newBoard.Y; i++)
{
    for (int j = 0; j < newBoard.X; j++)
    {
        Console.Write(" . ");
        /*
        if (x == 0 || y == 0 || x == newBoard.Size -1 || y == newBoard.Size - 1)
        {
            Console.Write("#");
        }
        else { Console.Write(" "); }
        */
    }
    Console.WriteLine();
}