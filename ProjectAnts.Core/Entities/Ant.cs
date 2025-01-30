using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAnts.Core
{
    public class Ant
    {
        public int Age { get; set; }

        public Ant()
        {
            Age = 0;
        }
        public void UpdateAge()
        {
            Age++;
        }
    }
}
