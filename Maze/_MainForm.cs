using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze
{
    public partial class _MainForm : Form
    {
        public _MainForm(int n,int m)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            Form tmp = (new MazeForm(n, m));
            tmp.StartPosition = FormStartPosition.CenterScreen;
            tmp.Show();
        }
    }
}
