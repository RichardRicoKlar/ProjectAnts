using ProjectAnts.Core;

public class ConsoleControls
{
    public static void UpdateBoard(Board board)
    {
        Console.Clear(); //Clear down the console

        for (int y = 0; y < board.Y; y++)
        {
            for (int x = 0; x < board.X; x++)
            {

                if (board.CurrentCell[x, y].Entity == Entities.Ant) //Find Ant
                {
                    Console.Write("X");
                    continue;
                }

                if (x == 0 || y == 0 || x == board.X - 1 || y == board.Y - 1) //Build walls
                {
                    Console.Write("#");
                    board.CurrentCell[x, y].Entity = Entities.Wall; //Mark as wall
                }
                else { Console.Write(" "); }
            }
            Console.WriteLine();
        }
    }
}
