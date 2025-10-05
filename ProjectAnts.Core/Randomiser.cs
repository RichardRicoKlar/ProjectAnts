namespace ProjectAnts.Core
{
    public class Randomiser
    {
        private static readonly Random rng = new();
        public static (int dx, int dy) RandomDirection()
        {
            int direction = rng.Next(4);
            return direction switch
            {
                0 => (0, -1), // up
                1 => (0, 1),  // down
                2 => (-1, 0), // left
                3 => (1, 0),  // right
                _ => (0, 0)
            };
        }
    }
}
