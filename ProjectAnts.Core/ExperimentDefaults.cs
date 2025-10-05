namespace ProjectAnts.Core
{
    public class ExperimentDefaults
    {
        public static readonly Board Board = new(15, 15);

        // Sugar settings
        public static readonly int SugarsStarted = 3;
        public static readonly int SugarSpawnRate = 1;
        public static readonly int SugarLifeValue = 20;

        // Ant settings
        public static readonly int AntsStarted = 6;
        public static readonly int AntLifeTime = 20;

        // Bug settings
        public static readonly int BugsStarted = 5;
        public static readonly int BugLifeValue = 10;
    }
}
