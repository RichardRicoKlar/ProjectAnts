﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAnts.Core
{
    public class Board
    {
        public int X { get; }
        public int Y { get; }

        public int Size { get; set; }
        public Board(int size)
        {
            X = size;
            Y = size;
        }
    }
}
