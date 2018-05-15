using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeBase;

namespace MazeGenerate
{
    public class Aldous_Broder
    {
        private int[,] dir;
        private bool[,] vis;
        private int[,] id = null;
        private List<int> vec;
        private List<Node> Vec = null;
        private int[] dj = null;
        private List<int> randvec;
        private int n, m;
        private MazeStruct output = null;
        public Aldous_Broder(int _n, int _m)
        {
            n = _n;
            m = _m;
            dir = new int[4, 2];
            dir[0, 0] = 1; dir[0, 1] = 0; dir[1, 0] = 0; dir[1, 1] = 1;
            dir[2, 0] = -1; dir[2, 1] = 0; dir[3, 0] = 0; dir[3, 1] = -1;
            vis = new bool[n, m];
            vec = new List<int>();
            output = new MazeStruct(n, m);
            id = new int[n, m];
            dj = new int[n * m];
            Vec = new List<Node>();
        }
        int find(int x)
        {
            return dj[x] == x ? x : dj[x] = find(dj[x]);
        }
        private struct node
        {
            public int x, y, dir;
            public node(int _x, int _y, int _dir)
            {
                x = _x;
                y = _y;
                dir = _dir;
            }
        }
        private void dfs(int x,int y)
        {
            Stack<node> sta = new Stack<node>();
            sta.Push(new node(x, y, 0));
            while (sta.Count != 0)
            {
                node tmp = sta.Pop();
                x = tmp.x;
                y = tmp.y;
                int d = tmp.dir;
                vis[x, y] = true;
                randvec = vec.OrderBy(a => Guid.NewGuid()).ToList<int>();
                while (d < 4)
                {
                    int g = x + dir[randvec[d], 0] * 2;
                    int h = y + dir[randvec[d], 1] * 2;
                    if (g >= 0 && h >= 0 && g < n && h < m)
                    {
                        if (vis[g, h] == false && output.maze[g, h] == 0)
                        {
                            vis[g, h] = true;
                            output.maze[g - dir[randvec[d], 0], h - dir[randvec[d], 1]] = 0;
                            tmp.x = x; tmp.y = y; tmp.dir = d + 1;
                            dj[find(id[x,y])] = find(id[g,h]);
                            sta.Push(new node(x, y, d + 1));
                            randvec = vec.OrderBy(a => Guid.NewGuid()).ToList<int>();
                            x = g;
                            y = h;
                            d = 0;
                        }
                        else
                        {
                            d++;
                        }
                    }
                    else
                    {
                        d++;
                    }
                }
            }
        }
        class Node
        {
            public int a, b, x, y;
            public Node(int _a, int _b, int _x, int _y)
            {
                a = _a;
                b = _b;
                x = _x;
                y = _y;
            }
        }
        public MazeStruct Generate()
        {
            Vec.Clear();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    output.maze[i, j] = 1;
            for (int i = 1; i < n; i += 2)
                for (int j = 1; j < m; j += 2)
                {
                    output.maze[i, j] = 0;
                }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    vis[i, j] = false;
                }
            }
            Vec.Clear();
            for(int i = 0; i < 4; i++)
            {
                vec.Add(i);
            }
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
                    if (output.maze[i, j] == 1)
                    {
                        if ((output.maze[i, j - 1] == 0) && (output.maze[i, j + 1] == 0))
                            Vec.Add(new Node(id[i, j - 1], id[i, j + 1], i, j));
                        else if ((output.maze[i - 1, j] == 0) && (output.maze[i + 1, j] == 0))
                            Vec.Add(new Node(id[i - 1, j], id[i + 1, j], i, j));
                    }
                }
            }
            for (int i = 1; i <= cnt; i++)
                dj[i] = i;
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            dfs((rand.Next() % (n / 2) * 2 + 1), (rand.Next() % (m / 2) * 2 + 1));

            List<Node> randVec = Vec.OrderBy(a => Guid.NewGuid()).ToList<Node>();

            for (int i = 0; i < randVec.Count; i++)
            {
                if (find(randVec[i].a) != find(randVec[i].b))
                {
                    output.maze[randVec[i].x, randVec[i].y] = 0;
                    dj[find(randVec[i].a)] = find(randVec[i].b);
                }
            }
            return output;
        }
    }
}
