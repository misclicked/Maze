using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wintellect.PowerCollections;

namespace Maze
{
    class Bstar
    {
        private long[,] dir;
        private bool[,] vis;
        private bool[,] vis2;
        private KeyValuePair<long, long>[,] parent;
        private long[,] G;
        private long algo, pp, tm;
        private System.Windows.Vector V1;
        private System.Windows.Vector V2;
        MainData md;
        public Bstar(MainData _md,long _algo, long _pp, long _tm)
        {
            algo = _algo;
            pp = _pp;
            tm = _tm;
            md = _md;
            parent = new KeyValuePair<long, long>[md.n, md.m];
            dir = new long[4, 2];
            G = new long[md.n, md.m];
            dir[0, 0] = 1; dir[0, 1] = 0; dir[1, 0] = 0; dir[1, 1] = 1;
            dir[2, 0] = -1; dir[2, 1] = 0; dir[3, 0] = 0; dir[3, 1] = -1;
            vis = new bool[md.n, md.m];
            vis2 = new bool[md.n, md.m];
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private long H(Point a)
        {
            switch (algo)
            {
                case 1:
                    return (long)Math.Pow(_H(a), pp) * tm;
                case 2:
                    return (long)Math.Pow(_H(a), pp) * tm;
                case 3:
                    return (long)Math.Pow(_H(a), pp) * tm;
                case 4:
                    return (long)Math.Pow(_H(a), pp) * tm;
                case 5:
                    return (long)Math.Pow(_H(a), pp) * tm;
                default:
                    return 0;
            }
        }
        private long _H(Point a)
        {
            switch (algo)
            {
                case 1:
                    return (long)(Math.Sqrt((a.X - md.edx) * (a.X - md.edx)) + Math.Sqrt((a.Y - md.edy) * (a.Y - md.edy)));
                case 2:
                    return (a.X - (int)md.edx) * (a.X - (int)md.edx) + (a.Y - (int)md.edy) * (a.Y - (int)md.edy);
                case 3:
                    return Math.Abs((a.X - (int)md.edx)) + Math.Abs((a.Y - (int)md.edy) * (a.Y - (int)md.edy));
                case 4:
                    return Math.Max(Math.Abs((a.X - (int)md.edx)), Math.Abs((a.Y - (int)md.edy)));
                case 5:
                    double V1len = (Math.Sqrt(V1.X * V1.X + V1.Y * V1.Y));
                    double V2len = (Math.Sqrt(V2.X * V2.X + V2.Y * V2.Y));
                    double A = (V1.X * V2.X + V1.Y * V2.Y) / (V1len*V2len);
                    long B = (long)(md.n * md.m * A * -1);
                    return B;
                    return (long)(md.n * md.m * (a.X * md.edx + a.Y * md.edy) / ((Math.Sqrt(a.X * a.Y) * Math.Sqrt(md.edx * md.edy)))) ;
                default:
                    return 0;
            }
        }
        private void markPath(int x, int y)
        {
            int tx, ty;
            while (true)
            {
                md.Que.Enqueue(new DrawTask((int)x * md.pW, (int)y * md.pH, md.pW, md.pH, Color.Yellow));
                if (!(parent[x, y].Key != x || parent[x, y].Value != y))
                    break;
                tx = (int)parent[x, y].Key;
                ty = (int)parent[x, y].Value;
                x = tx;
                y = ty;
            }
        }
        public void run()
        {
            for (long i = 0; i < md.n; i++)
            {
                for (long j = 0; j < md.m; j++)
                {
                    vis[i, j] = false;
                    vis2[i, j] = false;
                    parent[i, j] = new KeyValuePair<long, long>(i, j);
                    G[i, j] = 0;
                }
            }
            Thread a = new Thread(() => astar(new Point((int)md.stx, (int)md.sty)));
            Thread b = new Thread(() => bfs(new Point((int)md.stx, (int)md.sty)));
            a.Start();
            b.Start();
        }


        public class cmp : IComparer<KeyValuePair<long, Point>>
        {
            int IComparer<KeyValuePair<long, Point>>.Compare(KeyValuePair<long, Point> x, KeyValuePair<long, Point> y)
            {
                if (x.Key < y.Key)
                {
                    return -1;
                }
                else if (x.Key > y.Key)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
                throw new NotImplementedException();
            }
        }
        private void bfs(Point p)
        {
            long x = p.X;
            long y = p.Y;
            Queue<Point> que = new Queue<Point>();
            que.Enqueue(new Point((int)x, (int)y));
            vis2[x, y] = true;
            while (que.Count != 0)
            {
                Point kvp = que.Dequeue();
                x = kvp.X;
                y = kvp.Y;
                md.Que.Enqueue(new DrawTask((int)x * md.pW, (int)y * md.pH, md.pW, md.pH, Color.Green));
                Thread.Sleep(md.delay);
                for (long i = 0; i < 4; i++)
                {
                    long g = x + dir[i, 0];
                    long h = y + dir[i, 1];
                    if (g >= 0 && h >= 0 && g < md.n && h < md.m)
                    {
                        if (g == md.edx && h == md.edy && md.myMaze.maze[g, h] == 0)
                        {
                            vis2[g, h] = true;
                            parent[x, y] = new KeyValuePair<long, long>(g, h);
                            md.Que.Enqueue(new DrawTask((int)g * md.pW, (int)h * md.pH, md.pW, md.pH, Color.Green));
                            Thread.Sleep(md.delay);
                            return;
                        }
                        if (vis[g,h] ==false && vis2[g, h] == false && md.myMaze.maze[g, h] == 0)
                        {
                            vis2[g, h] = true;
                            parent[x, y] = new KeyValuePair<long, long>(g, h);
                            que.Enqueue(new Point((int)g, (int)h));
                        }
                    }
                }
            }
        }
        private void astar(Point p)
        {
            long x = p.X;
            long y = p.Y;
            OrderedBag<KeyValuePair<long, Point>> pq = new OrderedBag<KeyValuePair<long, Point>>(new cmp());
            V2 = new System.Windows.Vector(md.edx - x, md.edy - y);
            V1 = new System.Windows.Vector(1, 0);
            pq.Add(new KeyValuePair<long, Point>(G[x, y] + H(new Point((int)x, (int)y)), new Point((int)x, (int)y)));
            G[x, y] = 1;
            vis[x, y] = true;
            while (pq.Count != 0)
            {
                KeyValuePair<long, Point> kvp = pq.RemoveFirst();
                x = kvp.Value.X;
                y = kvp.Value.Y;
                md.Que.Enqueue(new DrawTask((int)x * md.pW, (int)y * md.pH, md.pW, md.pH, Color.Green));
                Thread.Sleep(md.delay);
                for (long i = 0; i < 4; i++)
                {
                    long g = x + dir[i, 0];
                    long h = y + dir[i, 1];
                    long now = kvp.Key;

                    if (g >= 0 && h >= 0 && g < md.n && h < md.m)
                    {
                        if (vis2[g, h] && md.myMaze.maze[g, h] == 0)
                        {
                            parent[g, h] = new KeyValuePair<long, long>(x, y);
                            md.Que.Enqueue(new DrawTask((int)x * md.pW, (int)y * md.pH, md.pW, md.pH, Color.Green));
                            Thread.Sleep(md.delay);
                            markPath((int)g, (int)h);
                            return;
                        }
                        if (!vis[g, h] && md.myMaze.maze[g, h] == 0)
                        {
                            G[g, h] = G[x, y] + 1;
                            if (g == md.edx && h == md.edy)
                            {
                                parent[g, h] = new KeyValuePair<long, long>(x, y);
                                md.Que.Enqueue(new DrawTask((int)x * md.pW, (int)y * md.pH, md.pW, md.pH, Color.Green));
                                Thread.Sleep(md.delay);
                                markPath((int)g, (int)h);
                                return;
                            }
                            V1 = new System.Windows.Vector(g - x, h - y);
                            V2 = new System.Windows.Vector(md.edx - x, md.edy - y);
                            long here = G[g, h] + H(new Point((int)g, (int)h));
                            vis[g, h] = true;
                            parent[g, h] = new KeyValuePair<long, long>(x, y);
                            pq.Add(new KeyValuePair<long, Point>(here, new Point((int)g, (int)h)));
                        }
                    }
                }
            }
        }
    }
}
