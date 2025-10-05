namespace ProjectAnts.Core
{
    public class ExperimentDefaults
    {
        public static readonly Board Board = new(15, 15);
        public static readonly int SpeedRate = 200; // %

        // Sugar settings
        public static readonly int SugarsStarted = 3;
        public static readonly double SugarSpawnRate = 1;
        public static readonly int SugarLifeValue = 20;
        public static readonly int SugarDecayTime = 50;

        // Ant settings
        public static readonly int AntsStarted = 5;
        public static readonly int AntLifeTime = 25;

        // Bug settings
        public static readonly int BugsStarted = 2;
        public static readonly int BugLifeValue = 10;
    }
}
