using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace Maze
{
    public static class Program
    {
        public static Form MainForm;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            int n, m;
            n = 61;
            m = 61;
            try
            {
                n = Convert.ToInt32(Interaction.InputBox("請輸入迷宮長(N,奇數,大於4,小於602)", "Input", "61"));
                m = Convert.ToInt32(Interaction.InputBox("請輸入迷宮寬(M,奇數,大於4,小於602)", "Input", "61"));
                check(n, m);
            }
            catch
            {
                return;
            }
            MainForm = new _MainForm(n,m);
            Application.Run(MainForm);
        }
        static void check(int n, int m)
        {
            if (n <= 3 || m <= 3 || n % 2 == 0 || m % 2 == 0 || n >= 602 || m >= 602)
            {
                throw new Exception();
            }
        }
    }
}
