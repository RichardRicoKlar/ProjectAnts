using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAnts.Core
{
    public class StateControl
    {
        public int Rows { get; }
        public int Columns { get; }
        public GridValue[,] Grid { get; }

        private readonly List<Ant> ants = new List<Ant>();
        private readonly Random random = new Random();

        public StateControl(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Grid = new GridValue[rows, columns];
        }
        private IEnumerable<Position> EmptyPositions()
        {
            return null;
        }

        private bool OutsideGrid(Position position)
        {
            return position.Row < 0 || position.Row >= Rows || position.Column < 0 || position.Column >= Columns;
        }
    }
}
