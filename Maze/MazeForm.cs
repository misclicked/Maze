using MazeBase;
using MazeGenerate;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze
{
    public partial class MazeForm : Form
    {
        private int n, m;
        private float pW, pH;
        private bool setStart;
        private bool setEnd;
        private float orgstx, orgsty;
        private float orgedx, orgedy;
        private float stx, sty;
        private float edx, edy;
        private string usingalgo;
        private bool timerStart = false;
        private Stopwatch now;
        private Color lastPbColor = Color.Black;
        private PointF lastPointF;
        private bool lastFlag = false;
        private Queue Que = null;
        private Thread runner = null;
        private MazeStruct myMaze = null;
        private PictureBox mainPb = null;
        private string nowMode = "play";
        private Bitmap bmp = null;
        MainData md = null;
        private bool _o;
        public MazeForm(int _n, int _m, string path = "",bool old = false)
        {
            InitializeComponent();
            _o = true;
            DesktopLocation = new Point(100, 100);
            n = _n;
            m = _m;
            if (path != "")
            {
                using (StreamReader file = new StreamReader(path))
                {
                    n = Convert.ToInt32(file.ReadLine());
                    m = Convert.ToInt32(file.ReadLine());
                    sty = Convert.ToInt32(file.ReadLine());
                    stx = Convert.ToInt32(file.ReadLine());
                    edy = Convert.ToInt32(file.ReadLine());
                    edx = Convert.ToInt32(file.ReadLine());
                    myMaze = new MazeStruct(n, m);
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            myMaze.maze[i, j] = file.Read() - '0';
                        }
                    }
                }
            }
            else
            {
                int tmp = n;
                n = m;
                m = tmp;
                myMaze = new MazeStruct(n, m);
                stx = sty = 1;
                edx = n - 2;
                edy = m - 2;
            }
            string subPath = "Mazes";

            this.openFileDialog1.InitialDirectory = Path.Combine(Application.StartupPath, subPath);

            this.saveFileDialog1.InitialDirectory = Path.Combine(Application.StartupPath, subPath);
            bool exists = System.IO.Directory.Exists(Path.Combine(Application.StartupPath,subPath));

            if (!exists)
                System.IO.Directory.CreateDirectory(Path.Combine(Application.StartupPath, subPath));
            LB.DisplayMember = "name";
            LB.ValueMember = "value";
            Queue myQue = new Queue();
            Que = Queue.Synchronized(myQue);
            DoubleBuffered = true;
            panelMaze.Height = 610;
            panelMaze.Width = 610;
            pH = panelMaze.Height / m;
            pW = panelMaze.Width / n;

            bmp = new Bitmap((int)pH * m, (int)pW * n);
            mainPb = new PictureBox();
            mainPb.MouseClick += panelMaze_MouseClick;
            mainPb.MouseMove += panelMaze_MouseMove;
            mainPb.MouseLeave += panelMaze_MouseLeave_1;
            mainPb.Height = (int)pH * m;
            mainPb.Width = (int)pW * n;
            mainPb.Location = new Point(0, 0);
            mainPb.Image = bmp;
            panelMaze.Height = (int)pH * m;
            panelMaze.Width = (int)pW * n;
            panelMaze.Controls.Add(mainPb);
            

            runner = new Thread(initMaze);
            st_Lb.Text = "(" + stx.ToString() + "," + sty.ToString() + ")";
            ed_Lb.Text = "(" + edx.ToString() + "," + edy.ToString() + ")";
            radioButton1.Checked = true;
            md = new MainData(n, m, pW, pH, stx, sty, edx, edy, myMaze, Que, 0);
            timer.Enabled = true;
            initMaze();
            clearPb();
            now = new Stopwatch();
            this.FormClosing += new FormClosingEventHandler(Maze_FormClosing);
        }
        private void setMode(string mode)
        {
            if (mode == "play")
            {
                mainPb.MouseDown -= edit_MouseDown;
                mainPb.MouseUp -= edit_MouseUp;
                mainPb.MouseClick -= edit_MouseClick;
                mainPb.MouseMove -= edit_MouseMove;
                mainPb.MouseClick += panelMaze_MouseClick;
                mainPb.MouseMove += panelMaze_MouseMove;
            }
            else if(mode =="edit")
            {
                mainPb.MouseClick -= panelMaze_MouseClick;
                mainPb.MouseMove -= panelMaze_MouseMove;
                mainPb.MouseDown += edit_MouseDown;
                mainPb.MouseUp += edit_MouseUp;
                mainPb.MouseClick += edit_MouseClick;
                mainPb.MouseMove += edit_MouseMove;
            }
        }

        #region edit mode
        private bool wallmode = false;
        private bool roadmode = false;
        private void edit_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                bmp.GetPixel(e.X, e.Y);
            }
            catch
            {
                return;
            }
            if (setEnd && (bmp.GetPixel(e.X, e.Y) != Color.Black))
            {
                ed_Lb.Text = "(" + (e.X / (int)pW).ToString() + "," + (e.Y / (int)pH).ToString() + ")";
                edx = (e.X / (int)pW);
                edy = (e.Y / (int)pH);
            }
            else if (setStart && (bmp.GetPixel(e.X, e.Y) != Color.Black))
            {
                st_Lb.Text = "(" + (e.X / (int)pW).ToString() + "," + (e.Y / (int)pH).ToString() + ")";
                stx = (e.X / (int)pW);
                sty = (e.Y / (int)pH);
            }
            if (!lastFlag)
            {
                lastFlag = true;
                lastPointF = new PointF(e.X / (int)pW, e.Y / (int)pH);
                lastPbColor = bmp.GetPixel(e.X, e.Y);
                Que.Enqueue(new DrawTask(lastPointF.X * pW, lastPointF.Y * pH, pW, pH, Color.Red));
            }
            else if (new PointF(e.X / (int)pW, e.Y / (int)pH) != lastPointF)
            {
                Que.Enqueue(new DrawTask(lastPointF.X * pW, lastPointF.Y * pH, pW, pH, lastPbColor));
                lastPointF = new PointF(e.X / (int)pW, e.Y / (int)pH);
                lastPbColor = bmp.GetPixel(e.X, e.Y);
                Que.Enqueue(new DrawTask(lastPointF.X * pW, lastPointF.Y * pH, pW, pH, Color.Red));
            }
            if (wallmode)
            {
                myMaze.maze[(int)(e.X / (int)pW), (int)(e.Y / (int)pH)] = 1;
                lastPbColor = Color.Black;
            }
            if (roadmode)
            {
                myMaze.maze[(int)(e.X / (int)pW), (int)(e.Y / (int)pH)] = 0;
                lastPbColor = SystemColors.Control; 
            }
            
        }

        private void edit_MouseClick(object sender, MouseEventArgs e)
        {
            myMaze.maze[(int)(e.X / pW), (int)(e.Y / pH)] = myMaze.maze[(int)(e.X / pW), (int)(e.Y / pH)] == 0 ? 1 : 0;
            lastPbColor = myMaze.maze[(int)(e.X / pW), (int)(e.Y / pH)] == 1 ? Color.Black : SystemColors.Control;
            if (setEnd)
            {
                Que.Enqueue(new DrawTask(orgedx * pW, orgedy * pH, pW, pH, SystemColors.Control));
                setEnd = false;
            }
            if (setStart)
            {
                Que.Enqueue(new DrawTask(orgstx * pW, orgsty * pH, pW, pH, SystemColors.Control));
                setStart = false;
            }
        }
        private void edit_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                myMaze.maze[(int)(e.X / pW), (int)(e.Y / pH)] = 1;
            }
            catch
            {
                wallmode = false;
                roadmode = false;
                return;
            }
            if (e.Button == MouseButtons.Left)
            {
                myMaze.maze[(int)(e.X / pW), (int)(e.Y / pH)] = 1;
                lastPbColor = Color.Black;
                wallmode = false;
            }
            else if (e.Button == MouseButtons.Right)
            {
                myMaze.maze[(int)(e.X / pW), (int)(e.Y / pH)] = 0;
                lastPbColor = SystemColors.Control;
                roadmode = false;
            }
            
        }

        private void edit_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                wallmode = true;
            }
            else if (e.Button == MouseButtons.Right)
            {
                roadmode = true;
            }
            
        }
        #endregion
        private void initMaze()
        {
            Que.Enqueue(new DrawTask(0, 0, mainPb.Width, mainPb.Height, SystemColors.Control));
        }

        private void abBtn_Click(object sender, EventArgs e)
        {
            if (runner.IsAlive)
                return;
            Aldous_Broder ab = new Aldous_Broder(n, m);
            myMaze = ab.Generate();
            clearPb();
        }
        private void KurskalBtn_Click(object sender, EventArgs e)
        {
            if (runner.IsAlive)
                return;
            Random_Kurskal rk = new Random_Kurskal(n,m);
            myMaze = rk.Generate();
            clearPb();
        }


        private void BFSbtn_Click(object sender, EventArgs e)
        {
            if (runner.IsAlive)
                return;
            RadioButton checkedButton = spdPanel.Controls.OfType<RadioButton>()
                                         .FirstOrDefault(r => r.Checked);
            md = new MainData(n, m, pW, pH, stx, sty, edx, edy, myMaze, Que, Convert.ToInt32(checkedButton.Tag));
            BFS bfs = new BFS(md);
            clearPb();
            runner = new Thread(bfs.run);
            now.Restart();
            timerStart = true;
            usingalgo = "BFS";
            runner.Start();
        }

        private void DFSbtn_Click(object sender, EventArgs e)
        {
            if (runner.IsAlive)
                return;
            RadioButton checkedButton = spdPanel.Controls.OfType<RadioButton>()
                                         .FirstOrDefault(r => r.Checked);
            md = new MainData(n, m, pW, pH, stx, sty, edx, edy, myMaze, Que, Convert.ToInt32(checkedButton.Tag));
            DFS dfs = new DFS(md);
            clearPb();
            runner = new Thread(dfs.run);
            now.Restart();
            timerStart = true;
            usingalgo = "DFS";
            runner.Start();
        }
        private class LBitem
        {
            public string name { get; set; }
            public int value { get; set;}
            public LBitem(string _name, int _value)
            {
                name = _name;
                value = _value;
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            Que.Enqueue(new DrawTask(stx * pW, sty * pH, pW, pH, Color.Orange));
            Que.Enqueue(new DrawTask(edx * pW, edy * pH, pW, pH, Color.RosyBrown));
            if(!setStart)
                myMaze.maze[(int)stx, (int)sty] = 0;
            if(!setEnd)
                myMaze.maze[(int)edx, (int)edy] = 0;
            using (Graphics G = Graphics.FromImage(bmp))
            {
                while (Que.Count != 0)
                {
                    DrawTask dt = Que.Dequeue() as DrawTask;
                    if (dt == null)
                        continue;
                    G.FillRectangle(new SolidBrush(dt.c), dt.x, dt.y, dt.w, dt.h);
                }
            }
            mainPb.Refresh();
            if (runner.IsAlive)
            {
                timerLb.Text = now.ElapsedMilliseconds.ToString() + "ms";
            }
            else if (timerStart == true)
            {
                string tmp = now.ElapsedMilliseconds.ToString();
                LB.Items.Add(new LBitem((usingalgo + ", " + Convert.ToInt32(astarGb.Controls.OfType<RadioButton>()
                                         .FirstOrDefault(r => r.Checked).Tag).ToString() + ", " + Convert.ToInt32(powGb.Controls.OfType<RadioButton>()
                                         .FirstOrDefault(r => r.Checked).Tag).ToString() + ", " + Convert.ToInt32(timeGb.Controls.OfType<RadioButton>()
                                         .FirstOrDefault(r => r.Checked).Tag).ToString() + ", " + now.ElapsedMilliseconds.ToString() + "ms"), (int)now.ElapsedMilliseconds));
                enableGB(true);
                now.Stop();
                timerLb.Text = tmp + "ms";
                int visibleItems = LB.ClientSize.Height / LB.ItemHeight;
                LB.TopIndex = Math.Max(LB.Items.Count - visibleItems + 1, 0);
                timerStart = false;
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            if (runner.IsAlive)
                return;
            clearPb();
        }

        private void astarBtn_Click(object sender, EventArgs e)
        {
            if (runner.IsAlive)
                return;
            RadioButton checkedButton = spdPanel.Controls.OfType<RadioButton>()
                                         .FirstOrDefault(r => r.Checked);
            md = new MainData(n, m, pW, pH, stx, sty, edx, edy, myMaze, Que, Convert.ToInt32(checkedButton.Tag));
            Astar ast = new Astar(md, Convert.ToInt32(astarGb.Controls.OfType<RadioButton>()
                                         .FirstOrDefault(r => r.Checked).Tag), Convert.ToInt32(powGb.Controls.OfType<RadioButton>()
                                         .FirstOrDefault(r => r.Checked).Tag), Convert.ToInt32(timeGb.Controls.OfType<RadioButton>()
                                         .FirstOrDefault(r => r.Checked).Tag));
            
            clearPb();
            enableGB(false);
            runner = new Thread(ast.run);
            now.Restart();
            timerStart = true;
            usingalgo = "Astar";
            runner.Start();
        }
        private void enableGB(bool flag)
        {
            foreach (Control c in astarGb.Controls)
            {
                if (c is RadioButton)
                {
                    (c as RadioButton).Enabled = flag;
                }
            }
            foreach (Control c in powGb.Controls)
            {
                if (c is RadioButton)
                {
                    (c as RadioButton).Enabled = flag;
                }
            }
            foreach (Control c in timeGb.Controls)
            {
                if (c is RadioButton)
                {
                    (c as RadioButton).Enabled = flag;
                }
            }
        }
        public class cmp : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                LBitem lx = x as LBitem;
                LBitem ly = y as LBitem;
                if (lx.value > ly.value)
                {
                    return 1;
                }
                else if (lx.value < ly.value)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
                
            }
        }


        private void sortBtn_Click(object sender, EventArgs e)
        {
            ArrayList q = new ArrayList();
            foreach (object o in LB.Items)
                q.Add(o);
            q.Sort(new cmp()); 
            LB.Items.Clear();
            foreach(object o in q)
                LB.Items.Add(o); 
        }

        private void panelMaze_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                bmp.GetPixel(e.X, e.Y);
            }
            catch
            {
                return;
            }
            if (setEnd && (bmp.GetPixel(e.X, e.Y) != Color.Black)) 
            {
                ed_Lb.Text = "(" + (e.X / (int)pW).ToString() + "," + (e.Y / (int)pH).ToString() + ")";
                edx = (e.X / (int)pW);
                edy = (e.Y / (int)pH);
            }
            else if (setStart && (bmp.GetPixel(e.X, e.Y) != Color.Black))  
            {
                st_Lb.Text = "(" + (e.X / (int)pW).ToString() + "," + (e.Y / (int)pH).ToString() + ")";
                stx = (e.X / (int)pW);
                sty = (e.Y / (int)pH);
            }
            if (_o == true)
            {
                _o = false;
                lastFlag = true;
                lastPointF = new Point(e.X / (int)pW, e.Y / (int)pH);
                lastPbColor = bmp.GetPixel(e.X, e.Y);
                return;
            }
            if (!lastFlag)
            {
                lastFlag = true;
                lastPointF = new Point(e.X / (int)pW, e.Y / (int)pH);
                lastPbColor = bmp.GetPixel(e.X, e.Y);
                if (lastPbColor == Color.Red)
                    return;
                Que.Enqueue(new DrawTask(lastPointF.X * pW, lastPointF.Y * pH, pW, pH, Color.Red));
            }
            else if (new Point(e.X / (int)pW, e.Y / (int)pH) != lastPointF) 
            {
                Que.Enqueue(new DrawTask(lastPointF.X * pW, lastPointF.Y * pH, pW, pH, lastPbColor));
                lastPointF = new Point(e.X / (int)pW, e.Y / (int)pH);
                lastPbColor = bmp.GetPixel(e.X, e.Y);
                if (lastPbColor == Color.Red)
                    return;
                Que.Enqueue(new DrawTask(lastPointF.X * pW, lastPointF.Y * pH, pW, pH, Color.Red));

            }
        }

        private void panelMaze_MouseLeave(object sender, EventArgs e)
        {
            lastFlag = false;
        }

        private void panelMaze_MouseClick(object sender, MouseEventArgs e)
        {
            if (setEnd)
            {
                Que.Enqueue(new DrawTask(orgedx * pW, orgedy * pH, pW, pH, SystemColors.Control));
                setEnd = false;
            }
            if (setStart)
            {
                Que.Enqueue(new DrawTask(orgstx * pW, orgsty * pH, pW, pH, SystemColors.Control));
                setStart = false;
            }
        }

        private void panelMaze_MouseLeave_1(object sender, EventArgs e)
        {
            lastFlag = false;
            Que.Enqueue(new DrawTask(lastPointF.X * pW, lastPointF.Y * pH, pW, pH, lastPbColor));

            if (setEnd || setStart)
                clearPb();
        }

        private void modeBtn_Click(object sender, EventArgs e)
        {
            if (runner.IsAlive)
                return;
            if (nowMode == "play")
            {
                nowMode = "edit";
                setMode(nowMode);
                ((Button)sender).Text = "離開編輯";
            }
            else
            {
                nowMode = "play";
                setMode(nowMode);
                ((Button)sender).Text = "編輯模式";
            }
        }

        private void clearMazeBtn_Click(object sender, EventArgs e)
        {
            if (runner.IsAlive)
                return;
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    myMaze.maze[i, j] = 0;
                }
            }
            clearPb();
        }

        private void clearLbBtn_Click(object sender, EventArgs e)
        {
            LB.Items.Clear();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }
        static void check(int n, int m)
        {
            if (n <= 3 || m <= 3 || n % 2 == 0 || m % 2 == 0 || n >= 603 || m >= 603)
            {
                throw new Exception();
            }
        }
        private void 新遊戲ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                n = Convert.ToInt32(Interaction.InputBox("請輸入迷宮長(N,奇數,大於4,小於602)", "Input", "61"));
                m = Convert.ToInt32(Interaction.InputBox("請輸入迷宮寬(M,奇數,大於4,小於602)", "Input", "61"));
                check(n, m);
                Program.MainForm.Invoke((MethodInvoker)delegate () {
                    Form tmp = (new MazeForm(n, m,"",true));
                    tmp.StartPosition = FormStartPosition.CenterScreen;
                    tmp.Show();
                });
                Con = true;
            }
            catch
            {
            }
            this.Close();
        }

        private void 離開ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 存取迷宮ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(saveFileDialog1.FileName))
                {
                    file.WriteLine(m.ToString());
                    file.WriteLine(n.ToString());
                    file.WriteLine(sty.ToString());
                    file.WriteLine(stx.ToString());
                    file.WriteLine(edy.ToString());
                    file.WriteLine(edx.ToString());
                    for (int i = 0; i < n; i++)
                    {
                        for(int j = 0; j < m; j++)
                        {
                            file.Write(myMaze.maze[j, i]);
                        }
                    }
                }
            }
        }

        private void 讀取迷宮ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Program.MainForm.Invoke((MethodInvoker)delegate () {
                    Form tmp = (new MazeForm(n, m,openFileDialog1.FileName,true));
                    tmp.StartPosition = FormStartPosition.CenterScreen;
                    tmp.Show();
                });
                Con = true;
                this.Close();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void mastarBtn_Click(object sender, EventArgs e)
        {
            if (runner.IsAlive)
                return;
            RadioButton checkedButton = spdPanel.Controls.OfType<RadioButton>()
                                         .FirstOrDefault(r => r.Checked);
            md = new MainData(n, m, pW, pH, stx, sty, edx, edy, myMaze, Que, Convert.ToInt32(checkedButton.Tag));
            Bstar bst = new Bstar(md, Convert.ToInt32(astarGb.Controls.OfType<RadioButton>()
                                         .FirstOrDefault(r => r.Checked).Tag), Convert.ToInt32(powGb.Controls.OfType<RadioButton>()
                                         .FirstOrDefault(r => r.Checked).Tag), Convert.ToInt32(timeGb.Controls.OfType<RadioButton>()
                                         .FirstOrDefault(r => r.Checked).Tag));

            clearPb();
            enableGB(false);
            runner = new Thread(bst.run);
            now.Restart();
            timerStart = true;
            usingalgo = "BSstar";
            runner.Start();
        }

        private void MazeForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show(e.ToString());
        }

        private void fillBtn_Click(object sender, EventArgs e)
        {
            if (runner.IsAlive)
                return;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    myMaze.maze[i, j] = 1;
                }
            }
            clearPb();
        }
        private bool Con = false;
        private void Maze_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (runner != null && runner.IsAlive)
                runner.Abort();
            timer.Stop();
            timer.Enabled = false;
            timer.Dispose();
            if(!Con)
                Application.Exit();
        }
        private void setStartBtn_Click(object sender, EventArgs e)
        {
            if (runner.IsAlive)
                return;
            orgstx = stx;
            orgsty = sty;
            setEnd = false;
            setStart = true;
        }

        private void setEndBtn_Click(object sender, EventArgs e)
        {
            if (runner.IsAlive)
                return;
            orgedx = edx;
            orgedy = edy;
            setStart = false;
            setEnd = true;
        }

        private void clearPb()
        {
            setStart = false;
            setEnd = false;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (myMaze.maze[i, j] == 0)
                        Que.Enqueue(new DrawTask(i * pW, j * pH, pW, pH, SystemColors.Control));
                    else
                        Que.Enqueue(new DrawTask(i * pW, j * pH, pW, pH, Color.Black));
                }
            }
            timerLb.Text = "0ms";
        }
        private void rb_changed(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (md != null)
                md.delay = Convert.ToInt32(rb.Tag);
        }

        private void 讀資結格式迷宮ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                string subPath = "Mazes/tmp.maze";
                Program.MainForm.Invoke((MethodInvoker)delegate()
                {
                    using (System.IO.StreamWriter writer =
                        new System.IO.StreamWriter(Path.Combine(Application.StartupPath, subPath)))
                    {
                        using (StreamReader reader = new StreamReader(openFileDialog2.FileName))
                        {
                            myMaze.maze = new int[610, 610];
                            int tmpcnt = 0;
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                m = line.Length;
                                for (int i = 0; i < m; i++)
                                {
                                    myMaze.maze[tmpcnt, i] = line[i] - '0';
                                }
                                tmpcnt++;
                            }
                            n = tmpcnt;
                            stx = sty = 1;
                            edx = m - 1;
                            edy = n - 1;
                        }
                        writer.WriteLine(m.ToString());
                        writer.WriteLine(n.ToString());
                        writer.WriteLine(sty.ToString());
                        writer.WriteLine(stx.ToString());
                        writer.WriteLine(edy.ToString());
                        writer.WriteLine(edx.ToString());
                        for (int i = 0; i < m; i++)
                        {
                            for (int j = 0; j < n; j++)
                            {
                                writer.Write(myMaze.maze[j, i]);
                            }
                        }
                    }
                    Form tmp = (new MazeForm(n, m, Path.Combine(Application.StartupPath, subPath), true));
                    tmp.StartPosition = FormStartPosition.CenterScreen;
                    tmp.Show();
                });
                Con = true; 
                this.Close();
            }
        }
    }
    class DrawTask
    {
        public float x, y;
        public float h, w;
        public Color c;
        public DrawTask(float _x, float _y, float _h, float _w,Color _c)
        {
            x = _x;
            y = _y;
            h = _w;
            w = _h;
            c = _c;
        }
    }
    class MainData
    {
        public int  n, m, delay;
        public float stx, sty, edx, edy, pW, pH;
        public MazeStruct myMaze;
        public Queue Que;
        public MainData(int _n, int _m,float _pW,float _pH, float _stx, float _sty, float _edx, float _edy, MazeStruct _myMaze, Queue _Que, int _delay)
        {
            n = _n;
            m = _m;
            pW = _pW;
            pH = _pH;
            stx = _stx;
            sty = _sty;
            edx = _edx;
            edy = _edy;
            myMaze = _myMaze;
            Que = _Que;
            delay = _delay;
        }
    }
}
