using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeBase;

namespace MazeGenerate
{
    class node
    {
        public int a, b, x, y;
        public node(int _a, int _b, int _x, int _y)
        {
            a = _a;
            b = _b;
            x = _x;
            y = _y;
        }
    }
    public class Random_Kurskal
    {
        private int[,] id = null;
        private List<node> vec = null;
        private int[] dj = null;
        private int n, m;
        private MazeStruct output = null;
        public Random_Kurskal(int _n, int _m)
        {
            n = _n;
            m = _m;
            output = new MazeStruct(n, m);
            id = new int[n, m];
            dj = new int[n * m];
            vec = new List<node>();
        }
        int find(int x)
        {
            return dj[x] == x ? x : dj[x] = find(dj[x]);
        }
        public void MazeFixer(MazeStruct ms)
        {
            vec.Clear();
            int cnt = 0;
            for (int i = 1; i < n; i += 2)
                for (int j = 1; j < m; j += 2)
                {
                    id[i, j] = ++cnt;
                }
            for (int i = 1; i < n - 1; i++)
            {
                for (int j = 1; j < m - 1; j++)
                {
                    if (ms.maze[i, j] == 1)
                    {
                        if ((ms.maze[i, j - 1] == 0) && (ms.maze[i, j + 1] == 0))
                            vec.Add(new node(id[i, j - 1], id[i, j + 1], i, j));
                        else if ((ms.maze[i - 1, j] == 0) && (ms.maze[i + 1, j] == 0))
                            vec.Add(new node(id[i - 1, j], id[i + 1, j], i, j));
                    }
                }
            }
            for (int i = 1; i <= cnt; i++)
                dj[i] = i;
            List<node> randvec = vec.OrderBy(a => Guid.NewGuid()).ToList<node>();

            for (int i = 0; i < randvec.Count; i++)
            {
                if (find(randvec[i].a) != find(randvec[i].b))
                {
                    ms.maze[randvec[i].x, randvec[i].y] = 0;
                    dj[find(randvec[i].a)] = find(randvec[i].b);
                }
            }
        }
        public MazeStruct Generate()
        {
            vec.Clear();
            int cnt = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    output.maze[i, j] = 1;
            for (int i = 1; i < n; i += 2)
                for (int j = 1; j < m; j += 2)
                {
                    output.maze[i, j] = 0;
                    id[i, j] = ++cnt;
                }
            for (int i = 1; i < n - 1; i++)
            {
                for (int j = 1; j < m - 1; j++)
                {
                    if (output.maze[i, j] == 1)
                    {
                        if ((output.maze[i, j - 1] == 0) && (output.maze[i, j + 1] == 0))
                            vec.Add(new node(id[i, j - 1], id[i, j + 1], i, j));
                        else if ((output.maze[i - 1, j] == 0) && (output.maze[i + 1, j] == 0))
                            vec.Add(new node(id[i - 1, j], id[i + 1, j], i, j));
                    }
                }
            }
            for (int i = 1; i <= cnt; i++)
                dj[i] = i;
            List<node> randvec = vec.OrderBy(a => Guid.NewGuid()).ToList<node>();
            for (int i = 0; i < randvec.Count; i++) 
            {
                if (find(randvec[i].a) != find(randvec[i].b))
                {
                    output.maze[randvec[i].x, randvec[i].y] = 0;
                    dj[find(randvec[i].a)] = find(randvec[i].b);
                }
            }
            return output;
        }
    }
}
