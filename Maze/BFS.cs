using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Maze
{
    class BFS
    {
        private int[,] dir;
        private bool[,] vis;
        private Point[,] parent;
        MainData md;
        public BFS(MainData _md)
        {
            md = _md;
            dir = new int[4, 2];
            dir[0, 0] = 1; dir[0, 1] = 0; dir[1, 0] = 0; dir[1, 1] = 1;
            dir[2, 0] = -1; dir[2, 1] = 0; dir[3, 0] = 0; dir[3, 1] = -1;
            vis = new bool[md.n, md.m];
            parent = new Point[md.n, md.m];
        }
        public void run()
        {
            for (int i = 0; i < md.n; i++)
            {
                for (int j = 0; j < md.m; j++)
                {
                    vis[i, j] = false;
                    parent[i, j] = new Point(i, j);
                }
            }
            bfs((int)md.stx, (int)md.sty);
        }
        private void bfs(int x, int y)
        {
            Queue<Point> que = new Queue<Point>();
            que.Enqueue(new Point(x, y)); 
            vis[x, y] = true;
            while (que.Count != 0)
            {
                Point kvp = que.Dequeue();
                x = kvp.X;
                y = kvp.Y;
                md.Que.Enqueue(new DrawTask(x * md.pW, y * md.pH, md.pW, md.pH, Color.Green));
                Thread.Sleep(md.delay);
                for (int i = 0; i < 4; i++)
                {
                    int g = x + dir[i, 0];
                    int h = y + dir[i, 1];
                    if (g >= 0 && h >= 0 && g < md.n && h < md.m)
                    {
                        if (g == md.edx && h == md.edy && md.myMaze.maze[g, h] == 0)
                        {
                            vis[g, h] = true;
                            parent[g, h] = new Point(x, y);
                            md.Que.Enqueue(new DrawTask(g * md.pW, h * md.pH, md.pW, md.pH, Color.Green));
                            Thread.Sleep(md.delay);
                            markPath(g, h);
                            return;
                        }
                        if (vis[g, h] == false && md.myMaze.maze[g, h] == 0)
                        {
                            vis[g, h] = true;
                            parent[g, h] = new Point(x, y);
                            que.Enqueue(new Point(g, h));
                        }
                    }
                }
            }
        }
        private void markPath(int x,int y)
        {
            int tx, ty;
            while(true){
                md.Que.Enqueue(new DrawTask(x * md.pW, y * md.pH, md.pW, md.pH, Color.Yellow));
                if (!(parent[x, y].X != x || parent[x, y].Y != y))
                    break;
                tx = parent[x, y].X;
                ty = parent[x, y].Y;
                x = tx;
                y = ty;
            }
        }
    }
}
