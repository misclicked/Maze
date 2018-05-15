namespace Maze
{
    partial class MazeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelMaze = new System.Windows.Forms.Panel();
            this.KurskalBtn = new System.Windows.Forms.Button();
            this.DFSbtn = new System.Windows.Forms.Button();
            this.setStartBtn = new System.Windows.Forms.Button();
            this.setEndBtn = new System.Windows.Forms.Button();
            this.st_Lb = new System.Windows.Forms.Label();
            this.ed_Lb = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.BFSbtn = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timerLb = new System.Windows.Forms.Label();
            this.clearbtn = new System.Windows.Forms.Button();
            this.abBtn = new System.Windows.Forms.Button();
            this.spdPanel = new System.Windows.Forms.Panel();
            this.astarBtn = new System.Windows.Forms.Button();
            this.astarGb = new System.Windows.Forms.GroupBox();
            this.timeGb = new System.Windows.Forms.GroupBox();
            this.radioButton14 = new System.Windows.Forms.RadioButton();
            this.radioButton15 = new System.Windows.Forms.RadioButton();
            this.radioButton16 = new System.Windows.Forms.RadioButton();
            this.radioButton17 = new System.Windows.Forms.RadioButton();
            this.radioButton18 = new System.Windows.Forms.RadioButton();
            this.powGb = new System.Windows.Forms.GroupBox();
            this.radioButton13 = new System.Windows.Forms.RadioButton();
            this.radioButton12 = new System.Windows.Forms.RadioButton();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.LB = new System.Windows.Forms.ListBox();
            this.sortBtn = new System.Windows.Forms.Button();
            this.modeBtn = new System.Windows.Forms.Button();
            this.clearMazeBtn = new System.Windows.Forms.Button();
            this.clearLbBtn = new System.Windows.Forms.Button();
            this.fillBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.選項ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新遊戲ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.存取迷宮ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.讀取迷宮ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.讀資結格式迷宮ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.離開ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.mastarBtn = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.spdPanel.SuspendLayout();
            this.astarGb.SuspendLayout();
            this.timeGb.SuspendLayout();
            this.powGb.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMaze
            // 
            this.panelMaze.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMaze.Location = new System.Drawing.Point(46, 71);
            this.panelMaze.Name = "panelMaze";
            this.panelMaze.Size = new System.Drawing.Size(610, 610);
            this.panelMaze.TabIndex = 0;
            // 
            // KurskalBtn
            // 
            this.KurskalBtn.Location = new System.Drawing.Point(712, 75);
            this.KurskalBtn.Name = "KurskalBtn";
            this.KurskalBtn.Size = new System.Drawing.Size(74, 23);
            this.KurskalBtn.TabIndex = 1;
            this.KurskalBtn.Text = "產生迷宮1";
            this.KurskalBtn.UseVisualStyleBackColor = true;
            this.KurskalBtn.Click += new System.EventHandler(this.KurskalBtn_Click);
            // 
            // DFSbtn
            // 
            this.DFSbtn.Location = new System.Drawing.Point(810, 75);
            this.DFSbtn.Name = "DFSbtn";
            this.DFSbtn.Size = new System.Drawing.Size(75, 23);
            this.DFSbtn.TabIndex = 2;
            this.DFSbtn.Text = "DFS";
            this.DFSbtn.UseVisualStyleBackColor = true;
            this.DFSbtn.Click += new System.EventHandler(this.DFSbtn_Click);
            // 
            // setStartBtn
            // 
            this.setStartBtn.Location = new System.Drawing.Point(46, 33);
            this.setStartBtn.Name = "setStartBtn";
            this.setStartBtn.Size = new System.Drawing.Size(75, 23);
            this.setStartBtn.TabIndex = 3;
            this.setStartBtn.Text = "設定起點";
            this.setStartBtn.UseVisualStyleBackColor = true;
            this.setStartBtn.Click += new System.EventHandler(this.setStartBtn_Click);
            // 
            // setEndBtn
            // 
            this.setEndBtn.Location = new System.Drawing.Point(224, 33);
            this.setEndBtn.Name = "setEndBtn";
            this.setEndBtn.Size = new System.Drawing.Size(75, 23);
            this.setEndBtn.TabIndex = 4;
            this.setEndBtn.Text = "設定終點";
            this.setEndBtn.UseVisualStyleBackColor = true;
            this.setEndBtn.Click += new System.EventHandler(this.setEndBtn_Click);
            // 
            // st_Lb
            // 
            this.st_Lb.AutoSize = true;
            this.st_Lb.BackColor = System.Drawing.Color.Orange;
            this.st_Lb.Location = new System.Drawing.Point(147, 38);
            this.st_Lb.Name = "st_Lb";
            this.st_Lb.Size = new System.Drawing.Size(28, 12);
            this.st_Lb.TabIndex = 5;
            this.st_Lb.Text = "(1,1)";
            // 
            // ed_Lb
            // 
            this.ed_Lb.AutoSize = true;
            this.ed_Lb.BackColor = System.Drawing.Color.RosyBrown;
            this.ed_Lb.Location = new System.Drawing.Point(340, 38);
            this.ed_Lb.Name = "ed_Lb";
            this.ed_Lb.Size = new System.Drawing.Size(40, 12);
            this.ed_Lb.TabIndex = 6;
            this.ed_Lb.Text = "(49,49)";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(20, 26);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(65, 16);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.Tag = "0";
            this.radioButton1.Text = "No Limit";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.rb_changed);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(20, 46);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(77, 16);
            this.radioButton2.TabIndex = 8;
            this.radioButton2.TabStop = true;
            this.radioButton2.Tag = "1";
            this.radioButton2.Text = "High Speed";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.rb_changed);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(20, 67);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(75, 16);
            this.radioButton3.TabIndex = 9;
            this.radioButton3.TabStop = true;
            this.radioButton3.Tag = "25";
            this.radioButton3.Text = "Low Speed";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.rb_changed);
            // 
            // BFSbtn
            // 
            this.BFSbtn.Location = new System.Drawing.Point(810, 114);
            this.BFSbtn.Name = "BFSbtn";
            this.BFSbtn.Size = new System.Drawing.Size(75, 23);
            this.BFSbtn.TabIndex = 10;
            this.BFSbtn.Text = "BFS";
            this.BFSbtn.UseVisualStyleBackColor = true;
            this.BFSbtn.Click += new System.EventHandler(this.BFSbtn_Click);
            // 
            // timer
            // 
            this.timer.Interval = 20;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // timerLb
            // 
            this.timerLb.Font = new System.Drawing.Font("Elephant", 25F);
            this.timerLb.Location = new System.Drawing.Point(917, 76);
            this.timerLb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timerLb.Name = "timerLb";
            this.timerLb.Size = new System.Drawing.Size(172, 43);
            this.timerLb.TabIndex = 11;
            this.timerLb.Text = "0ms";
            this.timerLb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // clearbtn
            // 
            this.clearbtn.Location = new System.Drawing.Point(1014, 121);
            this.clearbtn.Margin = new System.Windows.Forms.Padding(2);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(75, 23);
            this.clearbtn.TabIndex = 12;
            this.clearbtn.Text = "Clear";
            this.clearbtn.UseVisualStyleBackColor = true;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // abBtn
            // 
            this.abBtn.Location = new System.Drawing.Point(712, 114);
            this.abBtn.Margin = new System.Windows.Forms.Padding(2);
            this.abBtn.Name = "abBtn";
            this.abBtn.Size = new System.Drawing.Size(74, 23);
            this.abBtn.TabIndex = 13;
            this.abBtn.Text = "產生迷宮2";
            this.abBtn.UseVisualStyleBackColor = true;
            this.abBtn.Click += new System.EventHandler(this.abBtn_Click);
            // 
            // spdPanel
            // 
            this.spdPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.spdPanel.Controls.Add(this.radioButton2);
            this.spdPanel.Controls.Add(this.radioButton1);
            this.spdPanel.Controls.Add(this.radioButton3);
            this.spdPanel.Location = new System.Drawing.Point(695, 450);
            this.spdPanel.Margin = new System.Windows.Forms.Padding(2);
            this.spdPanel.Name = "spdPanel";
            this.spdPanel.Size = new System.Drawing.Size(110, 114);
            this.spdPanel.TabIndex = 14;
            // 
            // astarBtn
            // 
            this.astarBtn.Location = new System.Drawing.Point(810, 149);
            this.astarBtn.Name = "astarBtn";
            this.astarBtn.Size = new System.Drawing.Size(75, 23);
            this.astarBtn.TabIndex = 15;
            this.astarBtn.Text = "Astar";
            this.astarBtn.UseVisualStyleBackColor = true;
            this.astarBtn.Click += new System.EventHandler(this.astarBtn_Click);
            // 
            // astarGb
            // 
            this.astarGb.Controls.Add(this.timeGb);
            this.astarGb.Controls.Add(this.powGb);
            this.astarGb.Controls.Add(this.radioButton8);
            this.astarGb.Controls.Add(this.radioButton7);
            this.astarGb.Controls.Add(this.radioButton6);
            this.astarGb.Controls.Add(this.radioButton5);
            this.astarGb.Controls.Add(this.radioButton4);
            this.astarGb.Location = new System.Drawing.Point(810, 178);
            this.astarGb.Margin = new System.Windows.Forms.Padding(2);
            this.astarGb.Name = "astarGb";
            this.astarGb.Padding = new System.Windows.Forms.Padding(2);
            this.astarGb.Size = new System.Drawing.Size(200, 126);
            this.astarGb.TabIndex = 16;
            this.astarGb.TabStop = false;
            this.astarGb.Text = "Astar 啟發方式";
            // 
            // timeGb
            // 
            this.timeGb.Controls.Add(this.radioButton14);
            this.timeGb.Controls.Add(this.radioButton15);
            this.timeGb.Controls.Add(this.radioButton16);
            this.timeGb.Controls.Add(this.radioButton17);
            this.timeGb.Controls.Add(this.radioButton18);
            this.timeGb.Location = new System.Drawing.Point(142, 10);
            this.timeGb.Margin = new System.Windows.Forms.Padding(2);
            this.timeGb.Name = "timeGb";
            this.timeGb.Padding = new System.Windows.Forms.Padding(2);
            this.timeGb.Size = new System.Drawing.Size(49, 109);
            this.timeGb.TabIndex = 6;
            this.timeGb.TabStop = false;
            this.timeGb.Text = "倍數";
            // 
            // radioButton14
            // 
            this.radioButton14.AutoSize = true;
            this.radioButton14.Location = new System.Drawing.Point(4, 89);
            this.radioButton14.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton14.Name = "radioButton14";
            this.radioButton14.Size = new System.Drawing.Size(35, 16);
            this.radioButton14.TabIndex = 9;
            this.radioButton14.Tag = "10";
            this.radioButton14.Text = "10";
            this.radioButton14.UseVisualStyleBackColor = true;
            // 
            // radioButton15
            // 
            this.radioButton15.AutoSize = true;
            this.radioButton15.Location = new System.Drawing.Point(4, 72);
            this.radioButton15.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton15.Name = "radioButton15";
            this.radioButton15.Size = new System.Drawing.Size(29, 16);
            this.radioButton15.TabIndex = 8;
            this.radioButton15.Tag = "5";
            this.radioButton15.Text = "5";
            this.radioButton15.UseVisualStyleBackColor = true;
            // 
            // radioButton16
            // 
            this.radioButton16.AutoSize = true;
            this.radioButton16.Location = new System.Drawing.Point(4, 52);
            this.radioButton16.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton16.Name = "radioButton16";
            this.radioButton16.Size = new System.Drawing.Size(29, 16);
            this.radioButton16.TabIndex = 7;
            this.radioButton16.Tag = "3";
            this.radioButton16.Text = "3";
            this.radioButton16.UseVisualStyleBackColor = true;
            // 
            // radioButton17
            // 
            this.radioButton17.AutoSize = true;
            this.radioButton17.Location = new System.Drawing.Point(4, 31);
            this.radioButton17.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton17.Name = "radioButton17";
            this.radioButton17.Size = new System.Drawing.Size(29, 16);
            this.radioButton17.TabIndex = 6;
            this.radioButton17.Tag = "2";
            this.radioButton17.Text = "2";
            this.radioButton17.UseVisualStyleBackColor = true;
            // 
            // radioButton18
            // 
            this.radioButton18.AutoSize = true;
            this.radioButton18.Checked = true;
            this.radioButton18.Location = new System.Drawing.Point(4, 11);
            this.radioButton18.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton18.Name = "radioButton18";
            this.radioButton18.Size = new System.Drawing.Size(29, 16);
            this.radioButton18.TabIndex = 5;
            this.radioButton18.TabStop = true;
            this.radioButton18.Tag = "1";
            this.radioButton18.Text = "1";
            this.radioButton18.UseVisualStyleBackColor = true;
            // 
            // powGb
            // 
            this.powGb.Controls.Add(this.radioButton13);
            this.powGb.Controls.Add(this.radioButton12);
            this.powGb.Controls.Add(this.radioButton11);
            this.powGb.Controls.Add(this.radioButton10);
            this.powGb.Controls.Add(this.radioButton9);
            this.powGb.Location = new System.Drawing.Point(98, 10);
            this.powGb.Margin = new System.Windows.Forms.Padding(2);
            this.powGb.Name = "powGb";
            this.powGb.Padding = new System.Windows.Forms.Padding(2);
            this.powGb.Size = new System.Drawing.Size(39, 109);
            this.powGb.TabIndex = 5;
            this.powGb.TabStop = false;
            this.powGb.Text = "次方";
            // 
            // radioButton13
            // 
            this.radioButton13.AutoSize = true;
            this.radioButton13.Location = new System.Drawing.Point(4, 89);
            this.radioButton13.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton13.Name = "radioButton13";
            this.radioButton13.Size = new System.Drawing.Size(35, 16);
            this.radioButton13.TabIndex = 4;
            this.radioButton13.Tag = "10";
            this.radioButton13.Text = "10";
            this.radioButton13.UseVisualStyleBackColor = true;
            // 
            // radioButton12
            // 
            this.radioButton12.AutoSize = true;
            this.radioButton12.Location = new System.Drawing.Point(4, 72);
            this.radioButton12.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton12.Name = "radioButton12";
            this.radioButton12.Size = new System.Drawing.Size(29, 16);
            this.radioButton12.TabIndex = 3;
            this.radioButton12.Tag = "5";
            this.radioButton12.Text = "5";
            this.radioButton12.UseVisualStyleBackColor = true;
            // 
            // radioButton11
            // 
            this.radioButton11.AutoSize = true;
            this.radioButton11.Location = new System.Drawing.Point(4, 52);
            this.radioButton11.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton11.Name = "radioButton11";
            this.radioButton11.Size = new System.Drawing.Size(29, 16);
            this.radioButton11.TabIndex = 2;
            this.radioButton11.Tag = "3";
            this.radioButton11.Text = "3";
            this.radioButton11.UseVisualStyleBackColor = true;
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.Location = new System.Drawing.Point(4, 31);
            this.radioButton10.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(29, 16);
            this.radioButton10.TabIndex = 1;
            this.radioButton10.Tag = "2";
            this.radioButton10.Text = "2";
            this.radioButton10.UseVisualStyleBackColor = true;
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.Checked = true;
            this.radioButton9.Location = new System.Drawing.Point(4, 11);
            this.radioButton9.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(29, 16);
            this.radioButton9.TabIndex = 0;
            this.radioButton9.TabStop = true;
            this.radioButton9.Tag = "1";
            this.radioButton9.Text = "1";
            this.radioButton9.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(5, 103);
            this.radioButton8.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(71, 16);
            this.radioButton8.TabIndex = 4;
            this.radioButton8.Tag = "5";
            this.radioButton8.Text = "餘弦距離";
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(5, 82);
            this.radioButton7.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(95, 16);
            this.radioButton7.TabIndex = 3;
            this.radioButton7.Tag = "4";
            this.radioButton7.Text = "切比雪夫距離";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(5, 62);
            this.radioButton6.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(83, 16);
            this.radioButton6.TabIndex = 2;
            this.radioButton6.Tag = "3";
            this.radioButton6.Text = "曼哈頓距離";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Checked = true;
            this.radioButton5.Location = new System.Drawing.Point(5, 41);
            this.radioButton5.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(82, 16);
            this.radioButton5.TabIndex = 1;
            this.radioButton5.TabStop = true;
            this.radioButton5.Tag = "2";
            this.radioButton5.Text = "歐幾里得^2";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(5, 20);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(95, 16);
            this.radioButton4.TabIndex = 0;
            this.radioButton4.Tag = "1";
            this.radioButton4.Text = "歐幾里得距離";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // LB
            // 
            this.LB.FormattingEnabled = true;
            this.LB.ItemHeight = 12;
            this.LB.Location = new System.Drawing.Point(816, 322);
            this.LB.Margin = new System.Windows.Forms.Padding(2);
            this.LB.Name = "LB";
            this.LB.Size = new System.Drawing.Size(161, 220);
            this.LB.TabIndex = 17;
            // 
            // sortBtn
            // 
            this.sortBtn.Location = new System.Drawing.Point(816, 545);
            this.sortBtn.Margin = new System.Windows.Forms.Padding(2);
            this.sortBtn.Name = "sortBtn";
            this.sortBtn.Size = new System.Drawing.Size(56, 18);
            this.sortBtn.TabIndex = 18;
            this.sortBtn.Text = "排序";
            this.sortBtn.UseVisualStyleBackColor = true;
            this.sortBtn.Click += new System.EventHandler(this.sortBtn_Click);
            // 
            // modeBtn
            // 
            this.modeBtn.Location = new System.Drawing.Point(712, 149);
            this.modeBtn.Margin = new System.Windows.Forms.Padding(2);
            this.modeBtn.Name = "modeBtn";
            this.modeBtn.Size = new System.Drawing.Size(74, 23);
            this.modeBtn.TabIndex = 19;
            this.modeBtn.Text = "編輯模式";
            this.modeBtn.UseVisualStyleBackColor = true;
            this.modeBtn.Click += new System.EventHandler(this.modeBtn_Click);
            // 
            // clearMazeBtn
            // 
            this.clearMazeBtn.Location = new System.Drawing.Point(712, 183);
            this.clearMazeBtn.Margin = new System.Windows.Forms.Padding(2);
            this.clearMazeBtn.Name = "clearMazeBtn";
            this.clearMazeBtn.Size = new System.Drawing.Size(74, 23);
            this.clearMazeBtn.TabIndex = 20;
            this.clearMazeBtn.Text = "清除迷宮";
            this.clearMazeBtn.UseVisualStyleBackColor = true;
            this.clearMazeBtn.Click += new System.EventHandler(this.clearMazeBtn_Click);
            // 
            // clearLbBtn
            // 
            this.clearLbBtn.Location = new System.Drawing.Point(876, 545);
            this.clearLbBtn.Margin = new System.Windows.Forms.Padding(2);
            this.clearLbBtn.Name = "clearLbBtn";
            this.clearLbBtn.Size = new System.Drawing.Size(56, 18);
            this.clearLbBtn.TabIndex = 21;
            this.clearLbBtn.Text = "清除";
            this.clearLbBtn.UseVisualStyleBackColor = true;
            this.clearLbBtn.Click += new System.EventHandler(this.clearLbBtn_Click);
            // 
            // fillBtn
            // 
            this.fillBtn.Location = new System.Drawing.Point(712, 219);
            this.fillBtn.Margin = new System.Windows.Forms.Padding(2);
            this.fillBtn.Name = "fillBtn";
            this.fillBtn.Size = new System.Drawing.Size(74, 23);
            this.fillBtn.TabIndex = 22;
            this.fillBtn.Text = "塗滿迷宮";
            this.fillBtn.UseVisualStyleBackColor = true;
            this.fillBtn.Click += new System.EventHandler(this.fillBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.選項ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1120, 24);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // 選項ToolStripMenuItem
            // 
            this.選項ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新遊戲ToolStripMenuItem,
            this.存取迷宮ToolStripMenuItem,
            this.讀取迷宮ToolStripMenuItem,
            this.讀資結格式迷宮ToolStripMenuItem,
            this.離開ToolStripMenuItem});
            this.選項ToolStripMenuItem.Name = "選項ToolStripMenuItem";
            this.選項ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.選項ToolStripMenuItem.Text = "選項";
            // 
            // 新遊戲ToolStripMenuItem
            // 
            this.新遊戲ToolStripMenuItem.Name = "新遊戲ToolStripMenuItem";
            this.新遊戲ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.新遊戲ToolStripMenuItem.Text = "新迷宮";
            this.新遊戲ToolStripMenuItem.Click += new System.EventHandler(this.新遊戲ToolStripMenuItem_Click);
            // 
            // 存取迷宮ToolStripMenuItem
            // 
            this.存取迷宮ToolStripMenuItem.Name = "存取迷宮ToolStripMenuItem";
            this.存取迷宮ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.存取迷宮ToolStripMenuItem.Text = "儲存迷宮";
            this.存取迷宮ToolStripMenuItem.Click += new System.EventHandler(this.存取迷宮ToolStripMenuItem_Click);
            // 
            // 讀取迷宮ToolStripMenuItem
            // 
            this.讀取迷宮ToolStripMenuItem.Name = "讀取迷宮ToolStripMenuItem";
            this.讀取迷宮ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.讀取迷宮ToolStripMenuItem.Text = "讀取迷宮";
            this.讀取迷宮ToolStripMenuItem.Click += new System.EventHandler(this.讀取迷宮ToolStripMenuItem_Click);
            // 
            // 讀資結格式迷宮ToolStripMenuItem
            // 
            this.讀資結格式迷宮ToolStripMenuItem.Name = "讀資結格式迷宮ToolStripMenuItem";
            this.讀資結格式迷宮ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.讀資結格式迷宮ToolStripMenuItem.Text = "讀資結格式迷宮";
            this.讀資結格式迷宮ToolStripMenuItem.Click += new System.EventHandler(this.讀資結格式迷宮ToolStripMenuItem_Click);
            // 
            // 離開ToolStripMenuItem
            // 
            this.離開ToolStripMenuItem.Name = "離開ToolStripMenuItem";
            this.離開ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.離開ToolStripMenuItem.Text = "離開";
            this.離開ToolStripMenuItem.Click += new System.EventHandler(this.離開ToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.maze";
            this.openFileDialog1.Filter = "Maze檔案|*.maze";
            this.openFileDialog1.SupportMultiDottedExtensions = true;
            this.openFileDialog1.Title = "讀取迷宮";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.maze";
            this.saveFileDialog1.FileName = "newMaze";
            this.saveFileDialog1.Filter = "Maze檔案|*.maze";
            this.saveFileDialog1.SupportMultiDottedExtensions = true;
            this.saveFileDialog1.Title = "儲存迷宮";
            // 
            // mastarBtn
            // 
            this.mastarBtn.Location = new System.Drawing.Point(891, 150);
            this.mastarBtn.Margin = new System.Windows.Forms.Padding(2);
            this.mastarBtn.Name = "mastarBtn";
            this.mastarBtn.Size = new System.Drawing.Size(75, 23);
            this.mastarBtn.TabIndex = 24;
            this.mastarBtn.Text = "BS*";
            this.mastarBtn.UseVisualStyleBackColor = true;
            this.mastarBtn.Visible = false;
            this.mastarBtn.Click += new System.EventHandler(this.mastarBtn_Click);
            // 
            // MazeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 713);
            this.Controls.Add(this.mastarBtn);
            this.Controls.Add(this.fillBtn);
            this.Controls.Add(this.clearLbBtn);
            this.Controls.Add(this.clearMazeBtn);
            this.Controls.Add(this.modeBtn);
            this.Controls.Add(this.sortBtn);
            this.Controls.Add(this.LB);
            this.Controls.Add(this.astarBtn);
            this.Controls.Add(this.astarGb);
            this.Controls.Add(this.spdPanel);
            this.Controls.Add(this.abBtn);
            this.Controls.Add(this.clearbtn);
            this.Controls.Add(this.timerLb);
            this.Controls.Add(this.BFSbtn);
            this.Controls.Add(this.ed_Lb);
            this.Controls.Add(this.st_Lb);
            this.Controls.Add(this.setEndBtn);
            this.Controls.Add(this.setStartBtn);
            this.Controls.Add(this.DFSbtn);
            this.Controls.Add(this.KurskalBtn);
            this.Controls.Add(this.panelMaze);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MazeForm";
            this.Text = "迷宮";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MazeForm_KeyPress);
            this.spdPanel.ResumeLayout(false);
            this.spdPanel.PerformLayout();
            this.astarGb.ResumeLayout(false);
            this.astarGb.PerformLayout();
            this.timeGb.ResumeLayout(false);
            this.timeGb.PerformLayout();
            this.powGb.ResumeLayout(false);
            this.powGb.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMaze;
        private System.Windows.Forms.Button KurskalBtn;
        private System.Windows.Forms.Button DFSbtn;
        private System.Windows.Forms.Button setStartBtn;
        private System.Windows.Forms.Button setEndBtn;
        private System.Windows.Forms.Label st_Lb;
        private System.Windows.Forms.Label ed_Lb;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Button BFSbtn;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label timerLb;
        private System.Windows.Forms.Button clearbtn;
        private System.Windows.Forms.Button abBtn;
        private System.Windows.Forms.Panel spdPanel;
        private System.Windows.Forms.Button astarBtn;
        private System.Windows.Forms.GroupBox astarGb;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.GroupBox timeGb;
        private System.Windows.Forms.GroupBox powGb;
        private System.Windows.Forms.RadioButton radioButton14;
        private System.Windows.Forms.RadioButton radioButton15;
        private System.Windows.Forms.RadioButton radioButton16;
        private System.Windows.Forms.RadioButton radioButton17;
        private System.Windows.Forms.RadioButton radioButton18;
        private System.Windows.Forms.RadioButton radioButton13;
        private System.Windows.Forms.RadioButton radioButton12;
        private System.Windows.Forms.RadioButton radioButton11;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.ListBox LB;
        private System.Windows.Forms.Button sortBtn;
        private System.Windows.Forms.Button modeBtn;
        private System.Windows.Forms.Button clearMazeBtn;
        private System.Windows.Forms.Button clearLbBtn;
        private System.Windows.Forms.Button fillBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 選項ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新遊戲ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 離開ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 存取迷宮ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 讀取迷宮ToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button mastarBtn;
        private System.Windows.Forms.ToolStripMenuItem 讀資結格式迷宮ToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
    }
}