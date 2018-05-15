using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeBase
{
    public class MazeStruct
    {
        public int[,] maze = null;
        public MazeStruct(int n,int m)
        {
            maze = new int[n, m];
        }
    }
}
