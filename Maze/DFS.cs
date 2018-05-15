using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze
{
    class DFS
    {
        private int[,] dir;
        private bool[,] vis;
        MainData md;
        public DFS(MainData _md)
        {
            md = _md;
            dir = new int[4, 2];
            dir[0, 0] = 1; dir[0, 1] = 0; dir[1, 0] = 0; dir[1, 1] = 1;
            dir[2, 0] = -1; dir[2, 1] = 0; dir[3, 0] = 0; dir[3, 1] = -1;
            vis = new bool[md.n, md.m];
        }
        public void run()
        {
            for (int i = 0; i < md.n; i++)
            {
                for (int j = 0; j < md.m; j++)
                {
                    vis[i, j] = false;
                }
            }
            dfs((int)md.stx, (int)md.sty);
        }
        private struct node
        {
            public int x, y, dir;
            public node(int _x,int _y,int _dir)
            {
                x = _x;
                y = _y;
                dir = _dir;
            }
        }
        private void dfs(int x, int y)
        {
            Stack<node> sta = new Stack<node>();
            sta.Push(new node(x, y,0));
            while (sta.Count != 0)
            {
                node tmp = sta.Pop();
                x = tmp.x;
                y = tmp.y;
                int d = tmp.dir;
                vis[x, y] = true;
                md.Que.Enqueue(new DrawTask(x * md.pW, y * md.pH, md.pW, md.pH, Color.Green));
                Thread.Sleep(md.delay);
                while (d < 4)
                {
                    int g = x + dir[d, 0];
                    int h = y + dir[d, 1];
                    if (g >= 0 && h >= 0 && g < md.n && h < md.m)
                    {
                        if (g == md.edx && h == md.edy && md.myMaze.maze[g, h] == 0)
                        {
                            vis[g, h] = true;
                            md.Que.Enqueue(new DrawTask(g * md.pW, h * md.pH, md.pW, md.pH, Color.Green));
                            return;
                        }
                        if (vis[g, h] == false && md.myMaze.maze[g, h] == 0)
                        {
                            vis[g, h] = true;
                            tmp.x = x; tmp.y = y; tmp.dir = d + 1;
                            sta.Push(new node(x, y, d + 1));
                            x = g;
                            y = h;
                            d = 0;
                            md.Que.Enqueue(new DrawTask(g * md.pW, h * md.pH, md.pW, md.pH, Color.Green));
                            Thread.Sleep(md.delay);
                        }
                        else
                        {
                            d++;
                        }
                    }else
                    {
                        d++;
                    }
                }
                md.Que.Enqueue(new DrawTask(x * md.pW, y * md.pH, md.pW, md.pH, SystemColors.Control));
                Thread.Sleep(md.delay);
            }
        }
    }
}
